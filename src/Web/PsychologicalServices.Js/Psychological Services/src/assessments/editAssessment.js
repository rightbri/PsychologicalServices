import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import moment from 'moment';

@inject(Router, DataRepository, Config, Context, Scroller, Notifier)
export class EditAssessment {
	constructor(router, dataRepository, config, context, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.assessment = null;

		this.assessmentTypeMatcher = (a, b) => a != null && b != null && a.assessmentTypeId === b.assessmentTypeId;
		this.reportStatusMatcher = (a, b) => a != null && b != null && a.reportStatusId === b.reportStatusId;
		this.referralSourceMatcher = (a, b) => a != null && b != null && a.referralSourceId === b.referralSourceId;
		this.referralTypeMatcher = (a, b) => a != null && b != null && a.referralTypeId === b.referralTypeId;
		this.colorMatcher = (a, b) => a != null && b != null && a.colorId === b.colorId;
		this.userMatcher = (a, b) => a != null && b != null && a.userId === b.userId;
		this.attributeMatcher = (a, b) => a !== null && b !== null && a.attributeId === b.attributeId;
		
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
								
								let appointmentTime = new Date(this.assessment.appointments[0].appointmentTime);
								firstAppointmentDate = new Date(appointmentTime.getFullYear(), appointmentTime.getMonth(), appointmentTime.getDate());
							}
							
							return this.getData(firstAppointmentDate)
								.then(() => this.scroller.scrollTo(0));
						});
				}
				else {
					return this.dataRepository.getNewAssessment(user.company.companyId, params.year, params.month, params.day)
						.then(assessment => {
							this.assessment = assessment;
							
							return this.getData(this.assessment.appointments[0].appointmentTime)
								.then(() => this.scroller.scrollTo(0));
						});
				}
			});
	}
	/*
	canDeactivate() {
		
		return this.dirtyPrompter.confirm('Exit without saving?');
		
	}
	*/
	getData(firstAppointmentDate) {
		return Promise.all([
			this.dataRepository.getAssessmentTypes().then(data => this.assessmentTypes = data),
			this.dataRepository.getReferralTypes().then(data => this.referralTypes = data),
			this.dataRepository.getReferralSources().then(data => this.referralSources = data),
			this.dataRepository.getReportStatuses().then(data => this.reportStatuses = data),
			this.dataRepository.getColors().then(data => this.colors = data),
			
			this.dataRepository.searchUsers({
				companyId: this.user.company.companyId,
				rightId: this.config.rights.WriteDocList,
				availableDate: firstAppointmentDate,
			}).then(data => this.docListWriters = data),
			
			this.dataRepository.searchUsers({
				companyId: this.user.company.companyId,
				rightId: this.config.rights.WriteNotes,
				availableDate: firstAppointmentDate,
			}).then(data => this.notesWriters = data),
			
			this.dataRepository.searchAttributes({
				companyIds: [this.user.company.companyId],
				attributeTypeIds: this.config.assessmentDefaults.attributeTypeIds,
				isActive: true
			}).then(data => this.attributes = data),

			this.dataRepository.searchUsers({
				companyId: this.user.company.companyId,
				rightId: this.config.rights.Psychometrist,
				availableDate: firstAppointmentDate
			}).then(data => this.psychometrists = data),
			
			this.dataRepository.searchUsers({
				companyId: this.user.company.companyId,
				rightId: this.config.rights.Psychologist,
				availableDate: firstAppointmentDate
			}).then(data => this.psychologists = data),
			
			this.dataRepository.getAppointmentStatuses().then(data => this.appointmentStatuses = data),
			
			this.dataRepository.searchAddress({
				addressTypeIds: this.config.appointmentDefaults.addressTypeIds
			}).then(data => this.appointmentAddresses = data),
			
			this.dataRepository.searchAttributes({
				companyIds: [this.user.company.companyId],
				attributeTypeIds: this.config.appointmentDefaults.attributeTypeIds,
				isActive: true
			}).then(data => this.appointmentAttributes = data)
		]);
	}
	
	save() {
		
		var isNew = this.assessment.assessmentId === 0;
		
		if (isNew) {
			this.assessment.createUser = this.user;
		}
		
		this.assessment.updateUser = this.user;
		
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
		let medRehab = {
			assessmentId: this.assessment.assessmentId,
			date: moment().utc().format(),
			amount: 0,
			isAdd: true
		};
		this.editMedRehab(medRehab);
	}
	
	editMedRehab(medRehab) {
		this.medRehabEditModel = medRehab;
	}
	
	medRehabEdited(e) {
		let medRehab = e.detail.medRehab;
		
		if (medRehab.isAdd) {
			delete medRehab['isAdd'];
			this.assessment.medRehabs.push(medRehab);
		}
		
		this.medRehabEditModel = null;
	}
	
	medRehabCanceled(e) {
		let medRehab = e.detail.medRehab;

		if (!medRehab.isAdd) {
			copyValues(medRehab, this.medRehabEditModel);
		}
		
		this.medRehabEditModel = null;
	}
	
	removeMedRehab(medRehab) {
		
		this.assessment.medRehabs.splice(this.assessment.medRehabs.indexOf(medRehab), 1);
	}
	
	claimantSelected(e) {
		let result = e.detail;
		
		this.claimant = result.claimant;
		
		if (this.assessment.claims && this.assessment.claims.length > 0) {
			for (var claim of this.assessment.claims) {
				claim.claimant = result.claimant;
			}
		}
		else {
			this.assessment.claims = [
				{ 'claimant': result.claimant }
			];
		}
	}
	
	newClaim() {
		let claim = { claimant: this.claimant, isAdd: true };
		this.editClaim(claim);
	}
	
	editClaim(claim) {
		this.claimEditModel = claim;
	}
	
	claimEdited(e) {
		let claim = e.detail.claim;
		
		if (claim.isAdd) {
			delete claim['isAdd'];
			this.assessment.claims.push(claim);
		}
		
		this.claimEditModel = null;
	}
	
	claimCanceled(e) {
		let claim = e.detail.claim;

		if (!claim.isAdd) {
			copyValues(claim, this.claimEditModel);
		}
		
		this.claimEditModel = null;
	}

	removeClaim(claim) {
		this.assessment.claims.splice(this.assessment.claims.indexOf(claim), 1);
	}
	
	newAppointment() {
		this.dataRepository.getNewAppointment(this.assessment.company.companyId)
			.then(data => {
				data.isAdd = true;
				this.editAppointment(data);
			});
	}
	
	editAppointment(appointment) {
		this.appointmentEditModel = {
			'appointment': appointment,
			'psychometrists': this.psychometrists,
			'psychologists': this.psychologists,
			'appointmentStatuses': this.appointmentStatuses,
			'addresses': this.appointmentAddresses,
			'attributes': this.appointmentAttributes
		};
	}
	
	appointmentEdited(e) {
		let appointment = e.detail.appointment;
		
		if (appointment.isAdd) {
			delete appointment['isAdd'];
			this.assessment.appointments.push(appointment);
		}
		
		this.appointmentEditModel = null;
	}
	
	appointmentCanceled(e) {
		let appointment = e.detail.appointment;

		if (!appointment.isAdd) {
			copyValues(appointment, this.appointmentEditModel);
		}
		
		this.appointmentEditModel = null;
	}
	
	removeAppointment(appointment) {
		this.assessment.appointments.splice(this.assessment.appointments.indexOf(appointment), 1);
	}
	
	newNote() {
		let note = { createUser: this.user, createDate: new Date(), updateUser: this.user, updateDate: new Date(), isAdd: true };
		this.editNote(note);
	}
	
	editNote(note) {
		this.noteEditModel = note;
	}
		
	noteEdited(e) {
		let note = e.detail.note;
		
		if (note.isAdd) {
			delete note['isAdd'];
			this.assessment.notes.push(note);
		}
		
		this.noteEditModel = null;
	}
	
	noteCanceled(e) {
		let note = e.detail.note;

		if (!note.isAdd) {
			copyValues(note, this.noteEditModel);
		}
		
		this.noteEditModel = null;
	}
	
	removeNote(note) {
		this.assessment.notes.splice(this.assessment.notes.indexOf(note), 1);
	}
	
	newReport() {
		let report = { isNew: true, issuesInDispute: [] };
		this.editReport(report);
	}
	
	editReport(report) {
		this.reportEditModel = {
			report: report,
			issuesInDispute: this.assessment.referralType.issuesInDispute,
			reportTypes: this.assessment.assessmentType.reportTypes
		};
	}
	
	reportEdited(e) {
		let report = e.detail.report;
		
		if (report.isAdd) {
			delete report['isAdd'];
			this.assessment.reports.push(report);
		}
		
		this.checkMedRehab();
		
		this.reportEditModel = null;
	}
	
	reportCanceled(e) {
		let report = e.detail.report;

		if (!report.isAdd) {
			copyValues(report, this.reportEditModel.report);
		}
		
		this.reportEditModel = null;
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

function copyValues(copyFrom, copyTo) {
	for (var prop in copyFrom) {
		if (copyTo.hasOwnProperty(prop)) {
			copyTo[prop] = copyFrom[prop];
		}
	}
}
