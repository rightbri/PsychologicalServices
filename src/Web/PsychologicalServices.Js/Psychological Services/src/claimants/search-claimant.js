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
		this.claimantDob = null;
	}
	
	search() {
		if (this.claimantSearch || this.claimantDob) {
			this.claimant = null;
			this.searchClaimant({
				'name': this.claimantSearch,
				'dateOfBirth': this.claimantDob
			});
		}
		else {
			this.claimants = null;
		}
	}
	
	searchClaimant(criteria) {
		if (
			(criteria.name && criteria.name.length > 0 && criteria.name.length >= this.claimantSearchMinLength) ||
			(criteria.dateOfBirth && criteria.dateOfBirth.length > 0 && !/^\d{2}\/\d{2}\/\d{4}$/.test(criteria.dateOfBirth))
		) {
			this.dataRepository.searchClaimants(criteria).then(data => this.claimants = data);
		}
	}
	
	selectClaimant(claimant) {
		this.claimant = claimant;
		this.claimantSearch = null;
		this.claimantDob = null;
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
