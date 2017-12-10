import {inject, bindable, bindingMode} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {AgeService} from 'common/ageService';
import {EventHelper} from 'services/eventHelper';

@inject(Element, DataRepository, Config, AgeService, EventHelper)
export class EditClaimantCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, dataRepository, config, ageService, eventHelper) {
		this.element = element;
		this.dataRepository = dataRepository;
		this.config = config;
		this.ageService = ageService;
		this.eventHelper = eventHelper;

		this.validationErrors = null;

		this.age = 0;
	}
	
	modelChanged(newValue, oldValue) {
		if (newValue) {
			this.genders = newValue.genders;
		
			this.backup = getBackup(newValue.claimant);

			this.age = this.ageService.getAge(newValue.claimant.dateOfBirth);
		}
	}

	ageWasChanged() {
		let newDateOfBirth = this.ageService.getBirthDate(this.age);
		console.log('age changed .. new date of birth is ' + newDateOfBirth);
		
		this.model.claimant.dateOfBirth = newDateOfBirth;
	}
	
	ok(e) {
		this.dataRepository.saveClaimant(this.model.claimant)
			.then(data => {
				
				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (data.isSaved) {
					this.model.claimant = data.item;
					
					this.backup = getBackup(this.model.claimant);

					this.eventHelper.fireEvent(this.element, 'edited', { 'claimant': this.model.claimant });
				}
			});
	}
	
	cancel(e) {
		this.eventHelper.fireEvent(this.element, 'canceled', { 'claimant': this.backup });
	}
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}