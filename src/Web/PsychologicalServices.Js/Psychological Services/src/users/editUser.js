import {computedFrom, inject} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {DateService} from 'common/dateService';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import moment from 'moment';

@inject(BindingSignaler, DataRepository, Context, Config, DateService, Router, Notifier, Scroller)
export class EditUser {
	constructor(bindingSignaler, dataRepository, context, config, dateService, router, notifier, scroller) {
		this.bindingSignaler = bindingSignaler;
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		this.dateService = dateService;
		this.router = router;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.user = null;

		this.editUser = null;
		this.unavailableDate = null;
		this.roles = [];
		this.addresses = [];
		this.cities = [];

		this.datepickerOptions = {
			dateFormat: "d-m-Y",
			inline: true,
			mode: "multiple"
		};
		
		this.roleMatcher = (a, b) => a !== null && b !== null && a.roleId === b.roleId;
		this.addressMatcher = (a, b) => a !== null && b !== null && a.addressId === b.addressId;
		this.cityMatch = (a, b) => a && b && a.cityId === b.cityId;

		this.selectedCity = null;

		this.unavailabilityFocus = false;

		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		return this.context.getUser().then(user => {

			this.user = user;

			if (id) {
				return this.dataRepository.getUser(id)
					.then(data => {
						this.editUser = data;
						
						return this.getData();
					});
			}
			else {
				this.editUser = {
					userId: 0,
					company: user.company,
					isActive: true,
					roles: [],
					unavailability: [],
					travelFees: []
				};

				return this.getData();
			}
		});
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.searchAddress({
				'addressTypeIds': [this.config.addressDefaults.userAddressTypeId]
			}).then(data => this.addresses = data),
			this.dataRepository.getRoles().then(data => this.roles = data),
			this.dataRepository.getCities().then(data => this.cities = data)
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
		var isNew = this.editUser.userId === 0;

		this.dataRepository.saveUser(this.editUser)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.editUser = data.item;

					if (this.editUser.id === this.user.id) {
						let self = this;
						this.context.getUser(true).then(data => {
							self.user = data;

							if (!self.context.hasPermission('EditUser')) {
								self.router.navigateToRoute('home');
							}
						});
					}

					if (isNew) {
						this.router.navigateToRoute(
							'editUser',
							{ 'id': this.editUser.userId },
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
		let index = this.editUser.unavailability.findIndex(unavailability => unavailability.startDate === this.unavailableDate);

		if (Date.parse(this.unavailableDate) && index === -1) {
			let unavailability = getUnavailability(this.unavailableDate);

			this.editUser.unavailability.push(unavailability);

			this.unavailableDate = null;

			this.unavailabilityFocus = true;
		}
	}

	removeUnavailability(unavailability) {
		if (confirm('Remove Unavailability\nAre you sure?')) {
			let index = this.editUser.unavailability.indexOf(unavailability);
			if (index > -1) {
				this.editUser.unavailability.splice(index, 1);
			}
		}
	}

	addTravelFee(selectedCity) {
		if (selectedCity) {
			this.editUser.travelFees.push({ city: selectedCity, amount: 0 });

			this.selectedCity = null;
			
			this.bindingSignaler.signal('travel-fee-city-list');
		}
	}

	removeTravelFee(travelFee) {
		if (confirm('Remove travel fee\nAre you sure?')) {
			let index = this.editUser.travelFees.indexOf(travelFee);
	
			if (index > -1) {
				this.editUser.travelFees.splice(index, 1);
	
				this.bindingSignaler.signal('travel-fee-city-list');
			}
		}
	}

	@computedFrom('cities', 'user.travelFees')
	get travelFeeCityList() {
		let cities = this.cities.filter(c => !this.editUser.travelFees.some(tf => tf.city.cityId === c.cityId));

		return cities;
	}
}

function getUnavailability(date) {
	return {
		'startDate': date,
		'endDate': moment(date).add(1, 'days').subtract(1, 'seconds').toDate()
	};
}