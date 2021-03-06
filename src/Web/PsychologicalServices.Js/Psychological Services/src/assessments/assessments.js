import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Notifier} from 'services/notifier';

@inject(DataRepository, Config, Context, Notifier)
export class Assessments {
	constructor(dataRepository, config, context, notifier) {
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.notifier = notifier;
		
		this.referralSources = null;
		
		this.searchNeedsStatusUpdate = null;
		this.searchReferralSourceId = null;
		this.searchClaimant = null;
		this.searchCompanyId = null;
	}
	
	activate() {
		
		return this.getData();
	}
	
	getData() {
		return Promise.all([
			this.context.getUser().then(user => this.searchCompanyId = user.company.companyId), 
			this.dataRepository.getReferralSources().then(data => this.referralSources = data)
		]);
	}
	
	search() {
		return this.dataRepository.searchAssessments({
			'referralSourceId': this.searchReferralSourceId,
			'claimantId': this.searchClaimant ? this.searchClaimant.claimantId : null,
			'needsStatusUpdate': this.searchNeedsStatusUpdate,
			'companyId': this.searchCompanyId
		}).then(data => this.assessments = data);
	}
	
	deleteAssessment(assessment) {
		if (confirm('Delete Assessment\nAre you sure?')) {
			this.dataRepository.deleteAssessment(assessment.assessmentId).then(data => {
			
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				else {
					this.assessments = this.assessments.filter(value => value.assessmentId !== assessment.assessmentId);

					this.notifier.info('Deleted');
				}
			});
		}
	}
}
