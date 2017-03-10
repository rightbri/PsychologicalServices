import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class ReferralSources {
	constructor(dataRepository) {
		this.dataRepository = dataRepository;
		
		this.referralSources = [];
	}
	
	activate() {
		return this.search({});
	}
	
	search(criteria) {
		return this.dataRepository.getReferralSources(criteria)
			.then(data => this.referralSources = data);
	}
}