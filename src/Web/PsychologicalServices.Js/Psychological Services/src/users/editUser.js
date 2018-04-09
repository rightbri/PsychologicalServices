import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {DateService} from 'common/dateService';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import moment from 'moment';

@inject(DataRepository, Context, Config, DateService, Router, Notifier, Scroller)
export class EditUser {
	constructor(dataRepository, context, config, dateService, router, notifier, scroller) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		this.dateService = dateService;
		this.router = router;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.user = null;
		this.unavailableDate = null;
		
		this.datepickerOptions = {
			dateFormat: "d-m-Y",
			inline: true,
			mode: "multiple"
		};
		
		this.roleMatcher = (a, b) => a !== null && b !== null && a.roleId === b.roleId;
		this.addressMatcher = (a, b) => a !== null && b !== null && a.addressId === b.addressId;
		
		this.unavailabilityFocus = false;

		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getUser(id)
				.then(user => {
					this.user = user;
					
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
					unavailability: [],
					travelFees: []
				};
				
				return this.getData();
			});
		}
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.searchAddress({
				'addressTypeIds': [this.config.addressDefaults.userAddressTypeId]
			}).then(data => this.addresses = data),
			this.dataRepository.getRoles().then(data => this.roles = data),
			this.dataRepository.getCities().then(data => {
				this.cities = data;
				
				this.user.travelFees = this.user.travelFees.concat(
					getMissingTravelFees(data, this.user.travelFees)
				).sort((a, b) => {
					if (a.city.name < b.city.name) {
						return -1;
					}
					else if (a.city.name > b.city.name) {
						return 1;
					}
					
					return 0;
				});
			})
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
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
				
				this.saveDisabled = false;
            })
			.catch(err => {
				this.saveDisabled = false;
			});
	}
	
	back() {
		this.router.navigateBack();
	}

	addUnavailability() {
		let index = this.user.unavailability.findIndex(unavailability => unavailability.startDate === this.unavailableDate);

		if (Date.parse(this.unavailableDate) && index === -1) {
			let unavailability = getUnavailability(this.unavailableDate);

			this.user.unavailability.push(unavailability);

			this.unavailableDate = null;

			this.unavailabilityFocus = true;
		}
	}

	removeUnavailability(unavailability) {
		let index = this.user.unavailability.indexOf(unavailability);
		if (index > -1) {
			this.user.unavailability.splice(index, 1);
		}
	}
}

function getMissingTravelFees(cities, travelFees) {
	return cities.filter(city => 
		!travelFees.some(travelFee => travelFee.city.cityId === city.cityId)
	).map(function(city) { return { city: city, amount: 0 };});
}

function getUnavailability(date) {
	return {
		'startDate': date,
		'endDate': moment(date).add(1, 'days').subtract(1, 'seconds').toDate()
	};
}