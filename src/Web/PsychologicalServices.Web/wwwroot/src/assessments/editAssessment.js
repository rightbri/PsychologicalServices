import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DialogService} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import {ClaimantSearchDialog} from 'claimants/ClaimantSearchDialog';
import {ClaimDialog} from 'claims/ClaimDialog';
import {AppointmentDialog} from 'appointments/AppointmentDialog';
import {MedRehabDialog} from 'medRehab/MedRehabDialog';
import {AssessmentReportDialog} from 'reports/AssessmentReportDialog';
import {NoteDialog} from 'notes/NoteDialog';
import moment from 'moment';

@inject(Router, DataRepository, DialogService, Config, Context, Scroller, Notifier)
export class EditAssessment {
	constructor(router, dataRepository, dialogService, config, context, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.dialogService = dialogService;
		this.config = config;
		this.context = context;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.assessment = null;
		
		this.assessmentTypes = null;
		this.referralTypes = null;
		this.referralSources = null;
		this.reportStatuses = null;
		this.docListWriters = null;
		this.notesWriters = null;
		this.claims = null;
		this.claimant = null;
		this.notes = null;
		this.medRehabs = null;
		this.colors = null;
		this.attributes = null;
		
		this.assessmentTypeMatcher = (a, b) => a != null && b != null && a.assessmentTypeId === b.assessmentTypeId;
		this.reportStatusMatcher = (a, b) => a != null && b != null && a.reportStatusId === b.reportStatusId;
		this.referralSourceMatcher = (a, b) => a != null && b != null && a.referralSourceId === b.referralSourceId;
		this.referralTypeMatcher = (a, b) => a != null && b != null && a.referralTypeId === b.referralTypeId;
		this.colorMatcher = (a, b) => a != null && b != null && a.colorId === b.colorId;
		this.userMatcher = (a, b) => a != null && b != null && a.userId === b.userId;
		this.attributeMatcher = (a, b) => a !== null && b !== null && a.attributeId === b.attributeId;
		
		this.error = null;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		return this.context.getUser()
			.then(user => {
				this.user = user;
				
				if (id) {
					return this.dataRepository.getAssessment(id)
						.then(data => {
							this.assessment = data;
							
							this.checkMedRehab();
							
							if (this.assessment.claims && this.assessment.claims.length > 0) {
								this.claimant = this.assessment.claims[0].claimant;
							}
							
							var firstAppointmentDate = null;
							
							if (this.assessment.appointments && this.assessment.appointments.length > 0) {
								this.assessment.appointments.sort((a, b) => {
									if (a.appointmentTime < b.appointmentTime) {
										return -1;
									}
									else if (a.appointmentTime > b.appointmentTime) {
										return 1;
									}
									
									return 0;
								});
								
								firstAppointmentDate = this.assessment.appointments[0].appointmentTime;
							}
							
							return this.getData(firstAppointmentDate);
						});
				}
				else {
					let appointmentDate = new Date(params.year, params.month - 1, params.day);
					appointmentDate.setHours(this.config.defaultNewAppointmentHour);
		
					return this.dataRepository.getNewAppointment(user.company.companyId)
						.then(appointment => {
							
							appointment.appointmentTime = appointmentDate;
							
							this.assessment = {
								company: user.company,
								appointments: [ appointment ],
								claims: [],
								medRehabs: [],
								notes: [],
								colors: [],
								attributes: [],
								reports: []
							};
							
							return this.getData(appointment.appointmentTime);
						});
				}
			});
	}
	
	getData(firstAppointmentDate) {
		return Promise.all([
			this.dataRepository.getAssessmentTypes().then(data => this.assessmentTypes = data),
			this.dataRepository.getReferralTypes().then(data => this.referralTypes = data),
			this.dataRepository.getReferralSources().then(data => this.referralSources = data),
			this.dataRepository.getReportStatuses().then(data => this.reportStatuses = data),
			
			this.dataRepository.searchUsers({
				companyId: this.context.user.company.companyId,
				rightId: this.config.rights.WriteDocList,
				availableDate: firstAppointmentDate,
			}).then(data => this.docListWriters = data),
			
			this.dataRepository.searchUsers({
				companyId: this.context.user.company.companyId,
				rightId: this.config.rights.WriteNotes,
				availableDate: firstAppointmentDate,
			}).then(data => this.notesWriters = data),
			
			this.dataRepository.getColors().then(data => this.colors = data),
			this.dataRepository.searchAttributes({
				companyIds: [this.context.user.company.companyId],
				attributeTypeIds: this.config.assessmentDefaults.attributeTypeIds,
				isActive: true
			}).then(data => this.attributes = data)
		]);
	}
	
	save() {
		
		var isNew = this.assessment.assessmentId === 0;
		
		this.dataRepository.saveAssessment(this.assessment)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
					
                if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
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
					
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
            });
	}
	
	back() {
		this.router.navigateBack();
	}
	
	checkMedRehab() {
		this.medRehabSelected = this.assessment.reports.some(report => 
			report.issuesInDispute.some(issueInDispute => 
				issueInDispute && issueInDispute.name === 'Med Rehab'
			)
		);
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
		this.dataRepository.getNewAppointment(this.assessment.company.companyId)
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
	
	newReport() {
		return this.editReport({ issuesInDispute: [] })
			.then(data => {
				if (!data.wasCancelled) {
					this.assessment.reports.push(data.report);
				}
			});
	}
	
	editReport(report) {
		var original = JSON.parse(JSON.stringify(report));
		
		return this.dialogService.open({viewModel: AssessmentReportDialog, model: { report: report, issuesInDispute: this.assessment.referralType.issuesInDispute } })
			.then(result => {
				var copyFrom = original;
				
				if (!result.wasCancelled) {
					copyFrom = result.output;
					
					this.checkMedRehab();
				}
				
				for (var prop in copyFrom) {
					if (copyFrom.hasOwnProperty(prop)) {
						report[prop] = copyFrom[prop];
					}
				}
				
				return { wasCancelled: result.wasCancelled, report: report };
			});
	}
	
	removeReport(report) {
		this.assessment.reports.splice(this.assessment.reports.indexOf(report), 1);
		this.checkMedRehab();
	}
	
	getAttributeTypeIds(attributeTypes)
	{
		if (attributeTypes)
		{
			return attributeTypes.map(at => at.attributeTypeId);
		}
		
		return [];
	}
}