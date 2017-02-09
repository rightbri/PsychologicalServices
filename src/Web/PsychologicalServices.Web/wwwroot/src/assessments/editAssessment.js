import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {DialogService} from 'aurelia-dialog';
import {ClaimDialog} from '../claims/ClaimDialog';
import {AppointmentDialog} from '../appointments/AppointmentDialog';

@inject(Router, DataRepository, DialogService)
export class EditAssessment {
	constructor(router, dataRepository, dialogService) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.dialogService = dialogService;
		
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
		
		this.issueInDisputeMatcher = (a, b) => a.issueInDisputeId === b.issueInDisputeId;
	}
	
	activate(params) {
		var id = params.id;
		
		var assessmentPromise = this.dataRepository.getAssessment(id).then(data => this.assessment = data);
		
		return assessmentPromise.then(data => 
			Promise.all([
				this.dataRepository.getAssessmentTypes().then(data => this.assessmentTypes = data),
				this.dataRepository.getReferralTypes().then(data => this.referralTypes = data),
				this.dataRepository.getReferralSources().then(data => this.referralSources = data),
				this.dataRepository.getReportStatuses().then(data => this.reportStatuses = data),
				this.dataRepository.getDocListWriters(this.companyId).then(data => this.docListWriters = data),
				this.dataRepository.getNotesWriters(this.companyId).then(data => this.notesWriters = data),
				this.dataRepository.getCompanies().then(data => this.companies = data),
				this.dataRepository.getReferralTypeIssuesInDispute(data.referralTypeId).then(data => this.issuesInDispute = data)
			])
		);
		
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
	
	newClaim() {
		return this.editClaim({})
			.then(data => {
				if (!data.wasCancelled) {
					this.assessment.claims.push(data.claim);
				}
			});
	}
	
	editClaim(claim) {
		var original = JSON.parse(JSON.stringify(claim));
		
		return this.dialogService.open({viewModel: ClaimDialog, model: claim})
			.then(result => {
				var copyFrom = original;
				
				if (!result.wasCancelled) {
					copyFrom = result.output;
				}
				
				for (var prop in copyFrom) {
					if (copyFrom.hasOwnProperty(prop)) {
						claim[prop] = copyFrom[prop];
					}
				}
				
				return { wasCancelled: result.wasCancelled, claim: claim };
			})
	}
	
	newAppointment() {
		this.dataRepository.getNewAppointment(this.assessment.company.companyId, this.assessment.assessmentId)
			.then(data => this.editAppointment(data))
			.then(data => {
				if (!data.wasCancelled) {
					this.assessment.appointments.push(data.appointment);
				}
			});
	}
	
	editAppointment(appointment) {
		var original = JSON.parse(JSON.stringify(appointment));
		
		return this.dialogService.open({viewModel: AppointmentDialog, model: appointment})
			.then(result => {
				var copyFrom = original;
				
				if (!result.wasCancelled) {
					copyFrom = result.output;
				}
				
				for (var prop in copyFrom) {
					if (copyFrom.hasOwnProperty(prop)) {
						appointment[prop] = copyFrom[prop];
					}
				}
				
				return { wasCancelled: result.wasCancelled, appointment: appointment };
			});
	}
}