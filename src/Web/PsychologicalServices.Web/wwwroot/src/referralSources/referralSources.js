import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class ReferralSources {
	constructor(dataRepository) {
		this.dataRepository = dataRepository;

		this.referralSources = [];
		this.referralSourceTypes = [];
		
		this.searchName = null;
		this.searchReferralSourceTypeIds = [];
		this.searchActive = null;
	}
	
	activate() {
		return Promise.all([
			this.dataRepository.getReferralSourceTypes().then(data => this.referralSourceTypes = data),
			this.search()
		]);
	}
	
	search() {
		return this.dataRepository.getReferralSources({
			name: this.searchName,
			referralSourceTypeIds: this.searchReferralSourceTypeIds,
			isActive: this.searchActive
		}).then(data => this.referralSources = data);
	}
}