import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from '../common/config';
import {Context} from '../common/context';
import {DialogService} from 'aurelia-dialog';
import {ClaimantSearchDialog} from '../claimants/ClaimantSearchDialog';
import {ClaimDialog} from '../claims/ClaimDialog';
import {AppointmentDialog} from '../appointments/AppointmentDialog';
import {MedRehabDialog} from '../medRehab/MedRehabDialog';
import {NoteDialog} from '../notes/NoteDialog';
import {MessageDialog} from '../common/MessageDialog';
import moment from 'moment';

@inject(Router, DataRepository, DialogService, Config, Context)
export class EditAssessment {
	constructor(router, dataRepository, dialogService, config, context) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.dialogService = dialogService;
		this.config = config;
		this.context = context;
		
		this.assessment = null;
		
		this.assessmentTypes = null;
		this.referralTypes = null;
		this.referralSources = null;
		this.reportStatuses = null;
		this.docListWriters = null;
		this.notesWriters = null;
		this.issuesInDispute = null;
		this.claims = null;
		this.claimant = null;
		
		this.assessmentTypeMatcher = (a, b) => a.assessmentTypeId === b.assessmentTypeId;
		this.reportStatusMatcher = (a, b) => a.reportStatusId === b.reportStatusId;
		this.referralSourceMatcher = (a, b) => a.referralSourceId === b.referralSourceId;
		this.referralTypeMatcher = (a, b) => a.referralTypeId === b.referralTypeId;
		this.issueInDisputeMatcher = (a, b) => a.issueInDisputeId === b.issueInDisputeId;
		this.userMatcher = (a, b) => a != null && b != null && a.userId === b.userId;
		//this.companyMatcher = (a, b) => a.companyId === b.companyId;
		
		this.error = null;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getAssessment(id)
				.then(data => {
					this.assessment = data;
					
					this.checkMedRehab();
					
					if (this.assessment.referralType) {
						this.issuesInDispute = this.assessment.referralType.issuesInDispute;
					}
					
					if (this.assessment.claims && this.assessment.claims.length > 0) {
						this.claimant = this.assessment.claims[0].claimant;
					}
					
					return this.getData(this.assessment);
				});
		}
		else {
			//new assessment
			return this.context.getUser()
				.then(user => {
					return this.dataRepository.getNewAppointment(user.company.companyId)
						.then(appointment => {
							
							this.assessment = {
								company: user.company,
								appointments: [ appointment ],
								claims: [],
								issuesInDispute: [],
								medRehabs: [],
								notes: []
							};
							
							return this.getData();
						});
				});
		}
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getAssessmentTypes().then(data => this.assessmentTypes = data),
			this.dataRepository.getReferralTypes().then(data => this.referralTypes = data),
			this.dataRepository.getReferralSources().then(data => this.referralSources = data),
			this.dataRepository.getReportStatuses().then(data => this.reportStatuses = data),
			this.dataRepository.getDocListWriters(this.assessment.company.companyId).then(data => this.docListWriters = data),
			this.dataRepository.getNotesWriters(this.assessment.company.companyId).then(data => this.notesWriters = data)//,
			//this.dataRepository.getCompanies().then(data => this.companies = data)
		]);
	}
	
	save() {
		
		var isNew = this.assessment.assessmentId === 0;
		
		this.dataRepository.saveAssessment(this.assessment)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
					
                if (data.isSaved) {
                    this.assessment = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editAssessment',
							{ 'id': this.assessment.assessmentId },
							{ 'trigger': false, replace: true }
						);
						
						this.editType = 'Edit';
					}
					
					this.dialogService.open({viewModel: MessageDialog, model: { heading: 'Saved', message: 'Assessment saved' } });
                }
				
				if (data.isError) {
					this.dialogService.open({viewModel: MessageDialog, model: { heading: 'Error', message: data.errorDetails } });
				}
            });
	}
	
	back() {
		this.router.navigateBack();
	}

	referralTypeChanged() {
		this.issuesInDispute = this.assessment.referralType.issuesInDispute;
	}
	
	checkMedRehab() {
		this.medRehabSelected = this.assessment.issuesInDispute.some(issueInDispute => issueInDispute && issueInDispute.name === 'Med Rehab');
	}
	
	newMedRehab() {
		return this.editMedRehab({ assessmentId: this.assessment.assessmentId, date: moment().format('MM/DD/YYYY'), amount: 0 })
			.then(data => {
				if (!data.wasCancelled) {
					this.assessment.medRehabs.push(data.medRehab);
				}
			});
	}
	
	editMedRehab(medRehab) {
		var original = JSON.parse(JSON.stringify(medRehab));
		
		return this.dialogService.open({viewModel: MedRehabDialog, model: medRehab})
			.then(result => {
				var copyFrom = original;
				
				if (!result.wasCancelled) {
					copyFrom = result.output;
				}
				
				for (var prop in copyFrom) {
					if (copyFrom.hasOwnProperty(prop)) {
						medRehab[prop] = copyFrom[prop];
					}
				}
				
				return { wasCancelled: result.wasCancelled, medRehab: medRehab };
			})
	}
	
	searchClaimant() {
		var original = JSON.parse(JSON.stringify(this.claimant));
		
		return this.dialogService.open({viewModel: ClaimantSearchDialog, model: this.claimant})
			.then(result => {
				var source = original;

				if (!result.wasCancelled) {
					source = result.output;
				}
				
				this.claimant = source;
				
				return { wasCancelled: result.wasCancelled, claimant: this.claimant };
			})
			.then(result => {
				if (!result.wasCancelled) {
					if (this.assessment.claims && this.assessment.claims.length > 0) {
						for (var claim of this.assessment.claims) {
							claim.claimant = result.claimant;
						}
					}
				}
			});
	}
	
	newClaim() {
		return this.editClaim({ claimant: this.claimant })
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
		this.dataRepository.getNewAppointment(this.assessment.company.companyId)//, this.assessment.assessmentId)
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
	
	newNote() {
		return this.editNote({ createUser: this.context.user, createDate: new Date(), updateUser: this.context.user, updateDate: new Date() })
			.then(data => {
				if (!data.wasCancelled) {
					this.assessment.notes.push(data.note);
				}
			});
	}
	
	editNote(note) {
		var original = JSON.parse(JSON.stringify(note));
		
		return this.dialogService.open({viewModel: NoteDialog, model: note})
			.then(result => {
				var copyFrom = original;
				
				if (!result.wasCancelled) {
					copyFrom = result.output;
				}
				
				for (var prop in copyFrom) {
					if (copyFrom.hasOwnProperty(prop)) {
						note[prop] = copyFrom[prop];
					}
				}
				
				return { wasCancelled: result.wasCancelled, note: note };
			});
	}
}