import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {EventHelper} from 'services/eventHelper';

@inject(Element, DataRepository, Config, EventHelper)
export class EditClaimantCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, dataRepository, config, eventHelper) {
		this.element = element;
		this.dataRepository = dataRepository;
		this.config = config;
		this.eventHelper = eventHelper;

		this.validationErrors = null;
	}
	
	modelChanged(newValue, oldValue) {
		if (newValue) {
			this.genders = newValue.genders;
		
			this.backup = getBackup(newValue.claimant);
		}
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