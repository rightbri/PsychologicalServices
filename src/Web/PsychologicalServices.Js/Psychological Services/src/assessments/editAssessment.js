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
		this.attributeMatcher = (a, b) => a !== null && b !== null && a.attribute.attributeId === b.attribute.attributeId;
		this.credibilityMatcher = (a, b) => a !== null && b !== null && a.credibilityId === b.credibilityId;
		this.diagnosisFoundResponseMatcher = (a, b) => a !== null && b !== null && a.diagnosisFoundResponseId === b.diagnosisFoundResponseId;

		this.saveDisabled = false;
		this.validationErrors = null;

		this.summaryCollapseRows = 4;
		this.summaryExpandRows = 20;
		this.summaryEditRows = this.summaryCollapseRows;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		return this.context.getUser()
			.then(user => {
				this.user = user;
				
				if (id) {
					return this.dataRepository.getAssessment(id)
						.then(assessment => {
							this.assessment = assessment;
							
							this.setCredibilityVisibility(this.assessment.assessmentType.name);
							
							if (this.assessment.claims && this.assessment.claims.length > 0) {
								this.claimant = this.assessment.claims[0].claimant;
							}
							
							return this.getData().then(() => {
								this.assessmentTypeChanged();
								
								this.filterDocListWriters(this.assessment);
								
								this.filterNotesWriters(this.assessment);
								
								this.checkMedRehab();

								this.scroller.scrollTo(0)
							});
						});
				}
				else {
					return this.dataRepository.getNewAssessment(user.company.companyId, params.year, params.month, params.day)
						.then(assessment => {
							this.assessment = assessment;
							
							return this.getData().then(() => {
								this.assessmentTypeChanged();
								
								this.filterDocListWriters(this.assessment);
								
								this.filterNotesWriters(this.assessment);

								this.scroller.scrollTo(0);
							});
						});
				}
			});
	}
	/*
	canDeactivate() {
		return this.dirtyPrompter.confirm('Exit without saving?');
	}
	*/
	getData() {
		return Promise.all([
			this.dataRepository.getAssessmentTypes().then(data => this.assessmentTypes = data),
			this.dataRepository.getReferralTypes().then(data => this.referralTypes = data),
			this.dataRepository.getReferralSources().then(data => this.referralSources = data),
			this.dataRepository.getReportStatuses().then(data => this.reportStatuses = data),
			this.dataRepository.getColors().then(data => this.colors = data),
			this.dataRepository.getGenders().then(data => this.genders = data),
			this.dataRepository.getCredibilities().then(data => this.credibilities = data),
			this.dataRepository.getDiagnosisFoundResponses().then(data => this.diagnosisFoundResponses = data),
			
			this.dataRepository.searchUsers({
				companyId: this.user.company.companyId,
				rightId: this.config.rights.WriteDocList,
			}).then(data => this.docListWriters = data),
			
			this.dataRepository.searchUsers({
				companyId: this.user.company.companyId,
				rightId: this.config.rights.WriteNotes,
			}).then(data => this.notesWriters = data),
			
			this.dataRepository.searchAttributes({
				companyIds: [this.user.company.companyId],
				isActive: true
			}).then(data => this.attributes = data),

			this.dataRepository.searchUsers({
				companyId: this.user.company.companyId,
				rightId: this.config.rights.Psychometrist,
			}).then(data => this.psychometrists = data),
			
			this.dataRepository.searchUsers({
				companyId: this.user.company.companyId,
				rightId: this.config.rights.Psychologist,
			}).then(data => this.psychologists = data),
			
			this.dataRepository.getAppointmentStatuses().then(data => this.appointmentStatuses = data),
			
			this.dataRepository.searchAddress({
				addressTypeIds: this.config.appointmentDefaults.addressTypeIds
			}).then(data => this.appointmentAddresses = data),
			
			this.dataRepository.searchContacts({
				contactTypeIds: [this.config.contactTypes.lawyer, this.config.contactTypes.lawClerk]
			}).then(data => this.defenseLawyers = data)
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
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
				
				this.saveDisabled = false;
            })
			.catch(err => {
				this.saveDisabled = false;
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
		let claimant = e.detail.claimant;
		
		this.claimant = claimant;
		
		if (this.assessment.claims && this.assessment.claims.length > 0) {
			for (var claim of this.assessment.claims) {
				claim.claimant = claimant;
			}
		}
		else {
			this.assessment.claims = [
				{ 'claimant': claimant }
			];
		}
		
		this.claimantEditModel = null;
	}
	
	newClaimant() {
		let claimant = { isAdd: true, dateOfBirth: new Date(), isActive: true };
		this.editClaimant(claimant);
	}
	
	editClaimant(claimant) {
		let model = { 'genders': this.genders, 'claimant': claimant };
		this.claimantEditModel = model;
	}
	
	claimantCanceled(e) {
		let claimant = e.detail.claimant;
		
		if (!claimant.isAdd) {
			copyValues(claimant, this.claimantEditModel.claimant);
		}
		
		this.claimantEditModel = null;
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
		appointment.attributes = this.getAppointmentAttributes(appointment);

		this.appointmentEditModel = {
			'appointment': appointment,
			'psychometrists': this.psychometrists,
			'psychologists': this.psychologists,
			'appointmentStatuses': this.appointmentStatuses,
			'addresses': this.appointmentAddresses
		};
	}
	
	appointmentEdited(e) {
		let appointment = e.detail.appointment;
		
		if (appointment.isAdd) {
			delete appointment['isAdd'];
			this.assessment.appointments.push(appointment);
		}
		
		this.appointmentEditModel = null;

		this.filterDocListWriters(this.assessment);
								
		this.filterNotesWriters(this.assessment);
	}
	
	appointmentCanceled(e) {
		let appointment = e.detail.appointment;

		if (!appointment.isAdd) {
			copyValues(appointment, this.appointmentEditModel.appointment);
		}
		
		this.appointmentEditModel = null;

		this.filterDocListWriters(this.assessment);
								
		this.filterNotesWriters(this.assessment);
	}
	
	removeAppointment(appointment) {
		this.assessment.appointments.splice(this.assessment.appointments.indexOf(appointment), 1);
	}

	filterDocListWriters(assessment) {
		let firstAppointmentTime = this.getFirstAppointmentTime(assessment);

		this.filteredDocListWriters = this.docListWriters.filter(user =>
			user.isActive ||
			firstAppointmentTime === null ||
			Date.parse(user.dateInactivated) > Date.parse(firstAppointmentTime)
		);
	}

	filterNotesWriters(assessment) {
		let firstAppointmentTime = this.getFirstAppointmentTime(assessment);

		this.filteredNotesWriters = this.notesWriters.filter(user =>
			user.isActive ||
			firstAppointmentTime === null ||
			Date.parse(user.dateInactivated) > Date.parse(firstAppointmentTime)
		);
	}

	getFirstAppointmentTime(assessment) {
		
		if (assessment != null && assessment.appointments !== null) {

			let first = assessment.appointments.map(value => value.appointmentTime).reduce(
				(accumulator, current) => (null === accumulator || current < accumulator) ? current : accumulator,
				null
			);

			return first;
		}

		return null;
	}
	
	newArbitration() {
		this.dataRepository.getNewArbitration(this.assessment.assessmentId)
			.then(data => {
				data.isAdd = true;
				data.note = data.note || { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user };

				this.editArbitration(data);
			});
	}
	
	editArbitration(arbitration) {
		arbitration.note = arbitration.note || { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user };

		this.arbitrationEditModel = {
			'arbitration': arbitration,
			'defenseLawyers': this.defenseLawyers
		};
	}
	
	arbitrationEdited(e) {
		let arbitration = e.detail.arbitration;
		
		if (arbitration.isAdd) {
			delete arbitration['isAdd'];
			this.assessment.arbitrations.push(arbitration);
		}
		
		this.arbitrationEditModel = null;
	}
	
	arbitrationCanceled(e) {
		let arbitration = e.detail.arbitration;

		if (!arbitration.isAdd) {
			copyValues(arbitration, this.arbitrationEditModel.arbitration);
		}
		
		this.arbitrationEditModel = null;
	}
	
	removeArbitration(arbitration) {
		this.assessment.arbitrations.splice(this.assessment.arbitrations.indexOf(arbitration), 1);
	}
	
	newNote() {
		let note = {
			isAdd: true,
			showOnCalendar: false,
			note: { createUser: this.user, createDate: new Date(), updateUser: this.user, updateDate: new Date() }
		}
		this.editNote(note);
	}
	
	editNote(note) {
		this.noteEditModel = note;
	}
		
	noteEdited(e) {
		let note = e.detail.assessmentNote;
		
		if (note.isAdd) {
			delete note['isAdd'];
			this.assessment.assessmentNotes.push(note);
		}
		
		this.noteEditModel = null;
	}
	
	noteCanceled(e) {
		let note = e.detail.assessmentNote;

		if (!note.isAdd) {
			copyValues(note, this.noteEditModel);
		}
		
		this.noteEditModel = null;
	}
	
	removeNote(note) {
		this.assessment.assessmentNotes.splice(this.assessment.assessmentNotes.indexOf(note), 1);
	}
	
	newReport() {
		let report = { isAdd: true, issuesInDispute: [] };
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
	

	getAppointmentAttributes(appointment) {
		let selectedAttributeTypes = this.getSelectedAttributeTypes();
		
		let existingAppointmentAttributes = appointment.attributes.filter(att =>
			selectedAttributeTypes.some(at =>
				at.attributeTypeId === att.attribute.attributeType.attributeTypeId &&
				at.showOnAppointment
			)
		);

		//add new attributes to appointment from this.attributes where not present already in appointment.attributes collection
		let newAppointmentAttributes = this.getNewAppointmentAttributes();
		
		newAppointmentAttributes = newAppointmentAttributes.filter(attribute =>
			!existingAppointmentAttributes.some(existingAttributeValue =>
				existingAttributeValue.attribute.attributeId === attribute.attributeId
			)
		).map(attribute => this.toAttributeValue(attribute));

		return existingAppointmentAttributes.concat(newAppointmentAttributes);
	}

	getNewAppointmentAttributes() {
		let selectedAttributeTypes = this.getSelectedAttributeTypes();
		
		return this.attributes.filter(attribute =>
				selectedAttributeTypes.some(attributeType =>
					attributeType.attributeTypeId === attribute.attributeType.attributeTypeId &&
					attributeType.showOnAppointment
				)
			);
	}

	toAttributeValue(attribute) {
		return { 'attribute': attribute, 'value': null };
	}

	getSelectedAttributeTypes() {
		let selectedAttributeTypes = (this.assessment && this.assessment.assessmentType) ? this.assessment.assessmentType.attributeTypes : [];
		
		return selectedAttributeTypes;
	}

	assessmentTypeChanged() {
		let selectedAttributeTypes = this.getSelectedAttributeTypes();
		
		//filter assessment attributes based on selected assessment type
		let existingAssessmentAttributes = this.assessment.attributes.filter(att =>
			selectedAttributeTypes.some(at =>
				at.attributeTypeId === att.attribute.attributeType.attributeTypeId &&
				!at.showOnAppointment
			)
		);
		
		//add new attributes to assessment from this.attributes where not present already in assessment.attributes collection
		let newAssessmentAttributes = this.attributes.filter(attribute =>
			!existingAssessmentAttributes.some(existingAttributeValue => existingAttributeValue.attribute.attributeId === attribute.attributeId) &&
				selectedAttributeTypes.some(attributeType =>
					attributeType.attributeTypeId === attribute.attributeType.attributeTypeId &&
					!attributeType.showOnAppointment
				)
		).map(attribute => this.toAttributeValue(attribute));
		
		this.assessment.attributes = existingAssessmentAttributes.concat(newAssessmentAttributes);

		//filter appointment attributes based on selected assessment type
		for (let i = 0; i < this.assessment.appointments.length; i++) {
			let appointment = this.assessment.appointments[i];

			appointment.attributes = this.getAppointmentAttributes(appointment);
		}

		this.setCredibilityVisibility(this.assessment.assessmentType.name);
	}

	setCredibilityVisibility(assessmentType) {
		//show/hide credibility questions based on selected assessment type
		let neurocognitiveCredibilityAssessmentTypes = ['NP', 'NC', 'NC/P'];

		this.showNeurocognitiveCredibility = neurocognitiveCredibilityAssessmentTypes.some(type => type === assessmentType);

		let psychologicalCredibilityAssessmentTypes = ['P', 'PVOC', 'NP', 'NC/P'];

		this.showPsychologicalCredibility = psychologicalCredibilityAssessmentTypes.some(type => type === assessmentType);
	}

	summaryEditFocus(e) {
		this.summaryEditRows = this.summaryExpandRows;

		this.scroller.scrollTo(e.target);
	}

	summaryEditBlur(e) {
		this.summaryEditRows = this.summaryCollapseRows;
	}
}

function copyValues(copyFrom, copyTo) {
	for (var prop in copyFrom) {
		if (copyTo.hasOwnProperty(prop)) {
			copyTo[prop] = copyFrom[prop];
		}
	}
}
