import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';

@inject(Router, DataRepository)
export class EditAssessment {
	constructor(router, dataRepository) {
		this.router = router;
		this.dataRepository = dataRepository;
		
		this.companyId = 1;
		
		this.assessment = null;
		
		this.assessmentTypes = null;
		this.referralTypes = null;
		this.referralSources = null;
		this.reportStatuses = null;
		this.docListWriters = null;
		this.notesWriters = null;
		this.companies = null;
		this.issuesInDispute = null;
		this.claims = null;
	}
	
	activate(params) {
		var id = params.id;
		
		return Promise.all([
			this.dataRepository.getAssessmentTypes().then(data => this.assessmentTypes = data),
			this.dataRepository.getReferralTypes().then(data => this.referralTypes = data),
			this.dataRepository.getReferralSources().then(data => this.referralSources = data),
			this.dataRepository.getReportStatuses().then(data => this.reportStatuses = data),
			this.dataRepository.getDocListWriters(this.companyId).then(data => this.docListWriters = data),
			this.dataRepository.getNotesWriters(this.companyId).then(data => this.notesWriters = data),
			this.dataRepository.getCompanies().then(data => this.companies = data),
			this.dataRepository.getIssuesInDispute().then(data => this.issuesInDispute = data),
			this.dataRepository.getAssessment(id).then(data => this.assessment = data)
		]);
	}
	
	save() {
		this.dataRepository.saveAssessment(this.assessment)
            .then(data => {

                if (data.isError) {
                    alert(data.errorDetails);
                }

                if (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0) {
                    alert('validation errors: ' + data.validationResult.validationErrors.length);
                }

                if (data.isSaved) {
                    this.assessment = data.item;
					alert('saved');
                }
            });
	}
	
	back() {
		this.router.navigateBack();
	}
	
}