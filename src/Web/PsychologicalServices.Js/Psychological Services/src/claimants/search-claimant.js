import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';

@inject(Element, DataRepository, Config)
export class SearchClaimantCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) claimant;
	
	constructor(element, dataRepository, config) {
		this.element = element;
		this.dataRepository = dataRepository;
		this.config = config;
		
		this.claimantSearchMinLength = 2;
		this.claimantSearch = null;
		this.claimants = null;
	}
	
	search() {
		if (this.claimantSearch) {
			this.claimant = null;
			this.searchClaimant(this.claimantSearch);
		}
		else {
			this.claimants = null;
		}
	}
	
	searchClaimant(lastName) {
		if (this.claimantSearch.length >= this.claimantSearchMinLength) {
			this.dataRepository.getClaimants(lastName).then(data => {
				this.claimants = data;
			});
		}
	}
	
	selectClaimant(claimant) {
		this.claimant = claimant;
		
		fireEvent(this.element, 'selected', claimant);
	}
	
	@computedFrom('claimants', 'claimant')
	get showResults() {
		return this.claimants && !this.claimant;
	}
}

function createEvent(name, customData) {
	let customEvent;
	
	if (window.CustomEvent) {
		customEvent = new CustomEvent(name, { bubbles: true, 'detail': { claimant: customData } });
	}
	else {
		customEvent = document.createEvent('CustomEvent');
		
		customEvent.initCustomEvent(name, true, true, { 'detail': { claimant: customData } });
	}
	
	return customEvent;
}

function fireEvent(element, name, customData) {  
	var event = createEvent(name, customData);
	element.dispatchEvent(event);
}