import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class Assessments {
	constructor(dataRepository, config, context) {
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		
		this.referralSources = null;
		
		this.searchReferralSourceId = null;
		this.searchClaimant = null;
		this.searchCompanyId = null;
	}
	
	activate() {
		
		return this.getData();
	}
	
	getData() {
		return Promise.all([
			this.context.getUser().then(user => this.searchCompanyId = user.company.companyId).catch(err => {
				return;
			}), 
			this.dataRepository.getReferralSources().then(data => this.referralSources = data)
		]);
	}
	
	search() {
		return this.dataRepository.searchAssessments({
			referralSourceId: this.searchReferralSourceId,
			claimantId: this.searchClaimant ? this.searchClaimant.claimantId : null,
			companyId: this.searchCompanyId
		}).then(data => this.assessments = data);
	}
}
