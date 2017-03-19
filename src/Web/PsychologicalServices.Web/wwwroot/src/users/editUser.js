import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import moment from 'moment';

@inject(DataRepository, Context, Config, Router, Notifier, Scroller)
export class EditUser {
	constructor(dataRepository, context, config, router, notifier, scroller) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		this.router = router;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.roles = null;
		this.locations = null;
		
		this.user = null;
		this.unavailableDates = [];
		
		this.datepickerOptions = {
			'multidate': true,
			clearBtn: true
		};
		
		this.roleMatcher = (a, b) => a !== null && b !== null && a.roleId === b.roleId;
		
		this.error = null;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getUser(id)
				.then(user => {
					this.user = user;
					this.unavailableDates = this.user.unavailability.map(u => new Date(u.startDate));

					return this.getData();
				});
		}
		else {
			return this.context.getUser().then(user => {
				this.user = {
					userId: 0,
					company: user.company,
					isActive: true,
					roles: [],
					unavailability: []
				};
				
				return this.getData();
			});
		}
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getRoles().then(data => this.roles = data),
			this.dataRepository.searchAddress({
				isActive: true
			}).then(data => {
				this.locations = data;
				
				this.user.travelFees = this.user.travelFees.concat(
					getMissingTravelFees(data, this.user.travelFees)
				).sort((a, b) => {
					if (a.location.name < b.location.name) {
						return -1;
					}
					else if (a.location.name > b.location.name) {
						return 1;
					}
					
					return 0;
				});
			})
		]);
	}
	
	save() {
		var isNew = this.user.userId === 0;

		this.dataRepository.saveUser(this.user)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.user = data.item;

					if (isNew) {
						this.router.navigateToRoute(
							'editUser',
							{ 'id': this.user.userId },
							{ 'trigger': false, replace: true }
						);
						
						this.editType = 'Edit';
					}
					
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
            });
	}
	
	back() {
		this.router.navigateBack();
	}
	
	dateChanged(e) {
		this.user.unavailability = e.detail.dates.map(d => { return { 'startDate': d, 'endDate': moment(d).add(1, 'days').subtract(1, 'seconds').toDate() }; });
		this.unavailableDates = e.detail.dates;
	}
}

function getMissingTravelFees(locations, travelFees) {
	return locations.filter(location => 
		!travelFees.some(travelFee => travelFee.location.addressId === location.addressId)
	).map(function(location) { return { location: location, amount: 0 };});
}