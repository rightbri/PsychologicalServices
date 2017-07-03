import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {EventHelper} from 'services/eventHelper';

@inject(Element, DataRepository, Config, EventHelper)
export class SearchClaimantCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) claimant;
	@bindable({ defaultBindingMode: bindingMode.twoWay }) claimants;
	
	constructor(element, dataRepository, config, eventHelper) {
		this.element = element;
		this.dataRepository = dataRepository;
		this.config = config;
		this.eventHelper = eventHelper;
		
		this.claimantSearchMinLength = 2;
		this.claimantSearch = null;
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
	
	searchClaimant(name) {
		if (this.claimantSearch.length >= this.claimantSearchMinLength) {
			this.dataRepository.getClaimants(name).then(data => {
				this.claimants = data;
			});
		}
	}
	
	selectClaimant(claimant) {
		this.claimant = claimant;
		
		this.eventHelper.fireEvent(this.element, 'selected', { 'claimant': claimant });
	}
	
	@computedFrom('claimants', 'claimant')
	get showResults() {
		return this.claimants && !this.claimant;
	}
	
	enterpressed(e) {
		this.search();
	}
}
