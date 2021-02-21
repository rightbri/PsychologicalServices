import {inject} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {Context} from 'common/context';
import {NotesRepository} from 'testingResults/notesRepository';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';
import html2canvas from 'html2canvas';

@inject(BindingSignaler, NotesRepository, Context, Notifier, Scroller)
export class Notes {

    constructor(signaler, notesRepository, context, notifier, scroller) {
        this.signaler = signaler;
        this.notesRepository = notesRepository;
        this.context = context;
        this.notifier = notifier;
        this.scroller = scroller;

        this.searchCompanyId = null;
        this.claimant = null;
        this.claimants = null;
        this.pronoun = null;
        this.gender = null;

        this.assessments = null;
        this.assessment = null;
        this.responses = null;
        this.reviewAnswers = false;
        
        this.pronouns = [];
        this.yesNo = [];
        this.yesNoDontKnow = [];
        this.yesNoNa = [];
        this.yesNoPartially = [];
        this.genders = [];
        this.socioeconomicStatuses = [];
        this.relationshipStatuses = [];
        this.ageUnits = [];
        this.neurologicalAndPsychiatricDiseases = [];
        this.emotionalIssues = [];
        this.depressionSymptoms = [];
        this.worries = [];
        this.stressors = [];
        this.whereaboutsObjects = [];
        this.memoryAids = [];
        this.visualSpatialIssues = [];
        this.sleepIssues = [];
        this.sleepIssueCauses = [];
        this.languageIssues = [];
        this.safetyConcerns = [];
        this.executiveIssues = [];
        this.inappropriateSocialBehaviors = [];
        this.readingIssues = [];
        this.weightChangeTypes = [];
        this.cognitiveChangeTypes = [];
        this.moodChangeTypes = [];
        this.travelIssues = [];
        this.travelPreferences = [];
        this.currentStateTasks = [];
        this.currentStateAbilities = [];
        this.currentStateIssues = [];
        this.travelAbilities = [];
        this.treatmentPrograms = [];
        this.treatmentProviders = [];
        this.months = [];
        this.initialInjuriesAndSymptoms = [];
        this.studentSelfRatings = [];
        this.medicalConditions = [];
        this.abusedDrugs = [];
        this.physicalStates = [];
        this.prognosis = [];
        this.reminderChecklistItems = [];
        this.observations = [];
        this.headacheDescriptions = [];
        this.headacheReliefActivities = [];
        this.headacheFrequencies = [];
        this.hobbies = [];
        this.treatmentSessionFormats = [];
        this.counsellingMethods = [];
        this.hitHeadOnObjects = [];
        this.identificationVerificationMethods = [];

        this.self = this;

		this.valueMatcher = (a, b) => {
            return a && b && a.value === b.value;
        }
    }

    activate(params) {
        var id = params.id;
		
        return this.getData().then(x => {
            if (id) {
                return this.load(id);
            }
        });
    }

    getData() {
        return this.context.getUser()
            .then(user => {
                this.user = user;
                this.searchCompanyId = user.company.companyId;

                return Promise.all([
                    this.notesRepository.getPronouns().then(data => this.pronouns = this.asArray(data)),
                    this.notesRepository.getYesNo().then(data => {
                        this.yesNo = this.asArray(data);
                        this.yesNoMap = data;
                    }),
                    this.notesRepository.getYesNoDontKnow().then(data => {
                        this.yesNoDontKnow = this.asArray(data);
                        this.yesNoDontKnowMap = data;
                    }),
                    this.notesRepository.getYesNoNa().then(data => {
                        this.yesNoNa = this.asArray(data);
                        this.yesNoNaMap = data;
                    }),
                    this.notesRepository.getYesNoPartially().then(data => {
                        this.yesNoPartially = this.asArray(data);
                        this.yesNoPartiallyMap = data;
                    }),
                    this.notesRepository.getGenders().then(data => this.genders = data),
                    this.notesRepository.getSocioeconomicStatuses().then(data => this.socioeconomicStatuses = data),
                    this.notesRepository.getRelationshipStatuses().then(data => {
                        this.relationshipStatuses = this.asArray(data);
                        this.relationshipStatusesMap = data;
                    }),
                    this.notesRepository.getAgeUnits().then(data => {
                        this.ageUnits = this.asArray(data);
                        this.ageUnitsMap = data;
                    }),
                    this.notesRepository.getNeurologicalAndPsychiatricDiseases().then(data => {
                        this.neurologicalAndPsychiatricDiseases = this.asArray(data);
                        this.neurologicalAndPsychiatricDiseasesMap = data;
                    }),
                    this.notesRepository.getEmotionalIssues().then(data => this.emotionalIssues = data),
                    this.notesRepository.getDepressionSymptoms().then(data => this.depressionSymptoms = data),
                    this.notesRepository.getWorries().then(data => this.worries = data),
                    this.notesRepository.getStressors().then(data => {
                        this.stressors = this.asArray(data);
                        this.stressorsMap = data;
                    }),
                    this.notesRepository.getWhereaboutsObjects().then(data => {
                        this.whereaboutsObjects = this.asArray(data);
                        this.whereaboutsObjectsMap = data;
                    }),
                    this.notesRepository.getMemoryAids().then(data => {
                        this.memoryAids = this.asArray(data);
                        this.memoryAidsMap = data;
                    }),
                    this.notesRepository.getVisualSpatialIssues().then(data => this.visualSpatialIssues = data),
                    this.notesRepository.getSleepIssues().then(data => {
                        this.sleepIssues = this.asArray(data);
                        this.sleepIssuesMap = data;
                    }),
                    this.notesRepository.getSleepIssueCauses().then(data => {
                        this.sleepIssueCauses = this.asArray(data);
                        this.sleepIssueCausesMap = data;
                    }),
                    this.notesRepository.getSafetyConcerns().then(data => this.safetyConcerns = data),
                    this.notesRepository.getLanguageIssues().then(data => this.languageIssues = data),
                    this.notesRepository.getExecutiveIssues().then(data => this.executiveIssues = data),
                    this.notesRepository.getInappropriateSocialBehaviors().then(data => this.inappropriateSocialBehaviors = data),
                    this.notesRepository.getReadingIssues().then(data => {
                        this.readingIssues = this.asArray(data);
                        this.readingIssuesMap = data;
                    }),
                    this.notesRepository.getWeightChangeTypes().then(data => {
                        this.weightChangeTypes = this.asArray(data);
                        this.weightChangeTypesMap = data;
                    }),
                    this.notesRepository.getCognitiveChangeTypes().then(data => {
                        this.cognitiveChangeTypes = this.asArray(data);
                        this.cognitiveChangeTypesMap = data;
                    }),
                    this.notesRepository.getMoodChangeTypes().then(data => {
                        this.moodChangeTypes = this.asArray(data);
                        this.moodChangeTypesMap = data;
                    }),
                    this.notesRepository.getTravelIssues().then(data => {
                        this.travelIssues = this.asArray(data);
                        this.travelIssuesMap = data;
                    }),
                    this.notesRepository.getTravelPreferences().then(data => {
                        this.travelPreferences = this.asArray(data);
                        this.travelPreferencesMap = data;
                    }),
                    this.notesRepository.getCurrentStateAbilities().then(data => {
                        this.currentStateAbilities = this.asArray(data);
                        this.currentStateAbilitiesMap = data;
                    }),
                    this.notesRepository.getCurrentStateIssues().then(data => {
                        this.currentStateIssues = this.asArray(data);
                        this.currentStateIssuesMap = data;
                    }),
                    this.notesRepository.getTravelAbilities().then(data => this.travelAbilities = data),
                    this.notesRepository.getTreatmentPrograms().then(data => {
                        this.treatmentPrograms = this.asArray(data);
                        this.treatmentProgramsMap = data;
                    }),
                    this.notesRepository.getTreatmentProviders().then(data => {
                        this.treatmentProviders = this.asArray(data);
                        this.treatmentProvidersMap = data;
                    }),
                    this.notesRepository.getMonths().then(data => this.months = data),
                    this.notesRepository.getInitialInjuriesAndSymptoms().then(data => {
                        this.initialInjuriesAndSymptoms = this.asArray(data);
                        this.initialInjuriesAndSymptomsMap = data;
                    }),
                    this.notesRepository.getStudentSelfRatings().then(data => {
                        this.studentSelfRatings = this.asArray(data);
                        this.studentSelfRatingsMap = data;
                    }),
                    this.notesRepository.getMedicalConditions().then(data => {
                        this.medicalConditions = this.asArray(data);
                        this.medicalConditionsMap = data;
                    }),
                    this.notesRepository.getAbusedDrugs().then(data => {
                        this.abusedDrugs = this.asArray(data);
                        this.abusedDrugsMap = data;
                    }),
                    this.notesRepository.getPhysicalStates().then(data => {
                        this.physicalStates = this.asArray(data);
                        this.physicalStatesMap = data;
                    }),
                    this.notesRepository.getPrognosis().then(data => {
                        this.prognosis = this.asArray(data);
                        this.prognosisMap = data;
                    }),
                    this.notesRepository.getReminderChecklistItems().then(data => {
                        this.reminderChecklistItems = this.asArray(data);
                        this.reminderChecklistItemsMap = data;
                    }),
                    this.notesRepository.getObservations().then(data => {
                        this.observations = this.asArray(data);
                        this.observationsMap = data;
                    }),
                    this.notesRepository.getHeadacheDescriptions().then(data => {
                        this.headacheDescriptions = this.asArray(data);
                    }),
                    this.notesRepository.getHeadacheReliefActivities().then(data => {
                        this.headacheReliefActivities = this.asArray(data);
                    }),
                    this.notesRepository.getHeadacheFrequencies().then(data => {
                        this.headacheFrequencies = this.asArray(data);
                    }),
                    this.notesRepository.getHeadacheFrequencies2().then(data => {
                        this.headacheFrequencies2 = this.asArray(data);
                    }),
                    this.notesRepository.getHobbies().then(data => {
                        this.hobbies = this.asArray(data);
                    }),
                    this.notesRepository.getTreatmentSessionFormats().then(data => {
                        this.treatmentSessionFormats = this.asArray(data);
                    }),
                    this.notesRepository.getCounsellingMethods().then(data => {
                        this.counsellingMethods = this.asArray(data);
                    }),
                    this.notesRepository.getHitHeadOnObjects().then(data => {
                        this.hitHeadOnObjects = this.asArray(data);
                    }),
                    this.notesRepository.getIdentificationVerificationMethods().then(data => {
                        this.identificationVerificationMethods = this.asArray(data);
                    }),
                    this.notesRepository.getPanicAttackFrequencies().then(data => {
                        this.panicAttackFrequencies = this.asArray(data);
                    })
                ]);
            });
    }

    claimantSelected(e) {
        let gender = e.detail.claimant.gender;

        this.gender = this.genders.find(g => g.abbreviation === gender);

        this.genderChanged(this.gender);

        this.search(e.detail.claimant, this.searchCompanyId);

        this.claimants = null;
    }

    reset(resetClaimantData) {
        this.responses = null;
        this.assessments = null;
        this.assessment = null;

        this.claimant = null;
        this.changed('claimant-changed');
    }

    search(claimant, companyId) {
        this.reset();

		return this.notesRepository.searchAssessments(
			claimant ? claimant.claimantId : null,
			companyId
		).then(data => this.assessments = data);
    }
    
    select(assessment) {
        return this.load(assessment.assessmentId);
    }

    load(assessmentId) {
        return this.notesRepository.getNotes(assessmentId).then(data => {
            this.assessment = data.assessment;
            this.responses = data.responses;

            return Promise.all([
                this.notesRepository.getCurrentStateTasks(this.responses.createdAtVersion).then(data => {
                    this.currentStateTasks = this.asArray(data);
                    this.currentStateTasksMap = data;
                })
            ]);
        });
    }

    scrollToTop() {
        this.scroller.scrollTo(document.body);
    }

    scrollToBottom() {
        this.scroller.scrollTo(document.getElementById("bottom"));
    }

    save() {
        try {
            this.notesRepository.saveNotes(this.assessment.assessmentId, this.responses).then(data => {

                if (data.isSaved) {
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
            })
        }
        catch (err) {
            console.log(err);
        }
    }

    delete() {
        if (confirm('Delete Notes\nAre you sure?')) {
            this.notesRepository.deleteNotes(this.assessment.assessmentId).then(data => {
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				else {
					this.reset(true);
                    
                    if (data.isDeleted) {
                        this.notifier.info('Deleted');
                    }
				}
			});
        }
    }

    genderChanged(gender) {
        let pronoun = this.pronouns.filter(p => p.gender === gender.abbreviation);

        this.pronoun = pronoun.length > 0 ? pronoun[0] : null;
    }

    asArray(map) {
        let a = [];

        for (let key in map) {
            a.push(map[key]);
        }

        return a;
    }

    isUnanswered(value) {
        try {
            return !!!value;
        }
        catch (err) {
            //console.log(value);
            console.log(err);
            throw err;
        }
    }

    isAnswered(value) {
        try {
            return value !== undefined && value !== null && (!this.yesNoDontKnowMap.hasOwnProperty(value) || !this.yesNoDontKnowMap[value].isSkip);
        }
        catch (err) {
            //console.log(value);
            console.log(err);
            throw err;
        }
    }

    isYes(value) {
        return value !== undefined && 
            value !== null &&
            this.yesNoDontKnowMap.hasOwnProperty(value) &&
            this.yesNoDontKnowMap[value].isYes;
    }

    isNo(value) {
        return value !== undefined &&
            value !== null &&
            this.yesNoDontKnowMap.hasOwnProperty(value) &&
            this.yesNoDontKnowMap[value].isNo;
    }

    isDontKnow(value) {
        return value !== undefined &&
            value !== null &&
            this.yesNoDontKnowMap.hasOwnProperty(value) &&
            this.yesNoDontKnowMap[value].isDontKnow;
    }

    isSkip(value) {
        return value !== undefined &&
            value !== null &&
            this.yesNoDontKnowMap.hasOwnProperty(value) &&
            this.yesNoDontKnowMap[value].isSkip;
    }
    
    notSkip(item) {
        return item && !item.isSkip;
    }

    notAtypical(item) {
        return item && !item.isAtypical;
    }

    changed(signalName) {
        this.signaler.signal(signalName);
    }

    @computedFrom('assessment')
    get assessmentDate() {
        let appointmentTimes = this.assessment !== null && this.assessment.appointments !== null ? this.assessment.appointments.map(appointment => appointment.appointmentTime).sort((a, b) => a - b) : [];
        
        return appointmentTimes.length > 0 ? appointmentTimes[0] : null;
    }

    @computedFrom('assessment')
    get issuesInDispute() {
        if (this.assessment === null) { return []; }

        let idMap = {};

        var issues = this.distinct(
            this.assessment.reports.map(r => r.issuesInDispute.map(id => id.name)).reduce((accumulator, currentValue) => {
                return accumulator.concat(currentValue);
            }, [])
        );

        return issues;
    }

    @computedFrom('assessment')
    get dateOfAccident() {
        if (this.assessment === null) { return ""; }

        var claims = this.assessment.claims !== null
            ? this.assessment.claims.map(c => c.dateOfLoss)
            : [];
        
        return claims.length > 0 ? claims[0] : "";
    }

    @computedFrom('responses.accidentDetails.timeOfAccident.timeType')
    get timeOfAccidentIsSpecific() {
        if (!this.responses || !this.responses.accidentDetails || !this.responses.accidentDetails.timeOfAccident) { return false; }

        return this.responses.accidentDetails.timeOfAccident.timeType === "specific";
    }

    @computedFrom('responses.accidentDetails.timeOfAccident.timeType')
    get timeOfAccidentIsGeneral() {
        if (!this.responses || !this.responses.accidentDetails || !this.responses.accidentDetails.timeOfAccident) { return false; }

        return this.responses.accidentDetails.timeOfAccident.timeType === "general";
    }

    distinct(arr) {
        let aMap = {};

        return arr.filter(element => {
            let count = (aMap[element] || 0) + 1;
            aMap[element] = count;
            return count === 1;
        });
    }

    @computedFrom('responses.identification.verificationMethod.method')
    get idMethodIsOther() {
        if (this.responses === null || this.responses.identification === null) { return false; }
        
        return this.responses.identification.verificationMethod.method === "other";
    }

    @computedFrom('responses.accidentDetails.hitHeadOn')
    get hitHeadOnIsOther() {
        if (this.responses === null || this.responses.accidentDetails === null) { return false; }

        return this.responses.accidentDetails.hitHeadOn === "other";
    }

    @computedFrom('responses.accidentDetails.counsellingMethod')
    get counsellingMethodIsOther() {
        if (this.responses === null || this.responses.accidentDetails === null) { return false; }

        return this.responses.accidentDetails.counsellingMethod === "other";
    }

    @computedFrom('responses.accidentDetails.ocfCompleter.treatmentSessions.sessionFormat')
    get treatmentSessionFormatIsOther() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.ocfCompleter || !this.responses.accidentDetails.ocfCompleter.treatmentSessions) { return false; }

        return this.responses.accidentDetails.ocfCompleter.treatmentSessions.sessionFormat === "other";
    }

    @computedFrom('responses.interviewType')
    get isMvaInterview() {
        if (this.responses == null) { return false; }

        return this.responses.interviewType === "mva";
    }

    @computedFrom('responses.interviewType')
    get isLtdInterview() {
        if (this.responses == null) { return false; }

        return this.responses.interviewType === "ltd";
    }

    @computedFrom(
        'responses',
        'claimants'
    )
    get formVisible() {
        return this.responses && !this.claimants;
    }

    @computedFrom(
        'responses.personalHistory.brothers.howMany',
        'responses.personalHistory.sisters.howMany',
        'responses.personalHistory.halfBrothers.howMany',
        'responses.personalHistory.halfSisters.howMany',
        'responses.personalHistory.stepBrothers.howMany',
        'responses.personalHistory.stepSisters.howMany'
    )
    get siblingCount() {
        return this.responses ? (
            this.responses.personalHistory.brothers && this.responses.personalHistory.brothers.howMany !== null
                ? parseInt(this.responses.personalHistory.brothers.howMany, 10)
                : 0) +
            (this.responses.personalHistory.sisters && this.responses.personalHistory.sisters.howMany !== null
                ? parseInt(this.responses.personalHistory.sisters.howMany, 10)
                : 0) +
            (this.responses.personalHistory.halfBrothers && this.responses.personalHistory.halfBrothers.howMany !== null
                ? parseInt(this.responses.personalHistory.halfBrothers.howMany, 10)
                : 0) +
            (this.responses.personalHistory.halfSisters && this.responses.personalHistory.halfSisters.howMany !== null
                ? parseInt(this.responses.personalHistory.halfSisters.howMany, 10)
                : 0) +
            (this.responses.personalHistory.stepBrothers && this.responses.personalHistory.stepBrothers.howMany !== null
                ? parseInt(this.responses.personalHistory.stepBrothers.howMany, 10)
                : 0) +
            (this.responses.personalHistory.stepSisters && this.responses.personalHistory.stepSisters.howMany !== null
                ? parseInt(this.responses.personalHistory.stepSisters.howMany, 10)
                : 0) : 0 ;
    }

    @computedFrom(
        'responses.personalHistory.children.sons.howMany',
        'responses.personalHistory.children.daughters.howMany'
    )
    get childCount() {
        return this.responses ? (
            this.responses.personalHistory.children.sons.howMany !== null
                ? parseInt(this.responses.personalHistory.children.sons.howMany, 10)
                : 0) +
            (this.responses.personalHistory.children.daughters.howMany !== null
                ? parseInt(this.responses.personalHistory.children.daughters.howMany, 10)
                : 0) : 0;
    }

    @computedFrom('responses.personalHistory.children.sons.ages')
    get anySonsAgeIncomplete() {
        if (!this.responses || !this.responses.personalHistory.children.sons.ages) { return false; }
        
        let any = this.responses.personalHistory.children.sons.ages.some(age => this.isUnanswered(age.value) || this.isUnanswered(age.unit));

        return any;
    }


    @computedFrom('responses.personalHistory.relationship.status')
    get isMarriedOrCommonLaw() {
        if (!this.responses || !this.responses.personalHistory.relationship || !this.responses.personalHistory.relationship.status || !this.relationshipStatusesMap.hasOwnProperty(this.responses.personalHistory.relationship.status)) { return false; }
        
        let status = this.relationshipStatusesMap[this.responses.personalHistory.relationship.status];

        return status && (status.isMarried || status.isCommonLaw);
    }

    getWorriesForResponses(criteria) {
        if (!this.responses || !this.responses.psychological.worry) { return []; }

        let data = this.responses.psychological.worry
            .filter(item => item.response != null && criteria(item))
            .map(item => this.worries[item.value]);

        return data;
    }

    @computedFrom('responses.psychological.worry')
    get yesWorries() {
        return this.getWorriesForResponses(item => this.isYes(item.response));
    }

    @computedFrom('responses.personalHistory.medical.familyMedicalConditions')
    get familyMedicalConditionOtherIsSelected() {
        if (this.responses === null) { return false; }
        
        return this.responses.personalHistory.medical.familyMedicalConditions.some(item => item === "other");
    }

    @computedFrom('responses.personalHistory.medical.drugsUsed')
    get everUsedAlchohol() {
        if (this.responses === null) { return false; }
        
        return this.responses.personalHistory.medical.drugsUsed.some(item => item === "alchohol");
    }

    @computedFrom('responses.personalHistory.medical.drugsUsed')
    get everUsedTobacco() {
        if (this.responses === null) { return false; }
        
        return this.responses.personalHistory.medical.drugsUsed.some(item => item === "tobacco");
    }

    @computedFrom('responses.personalHistory.medical.drugsUsed')
    get everUsedThc() {
        if (this.responses === null) { return false; }
        
        return this.responses.personalHistory.medical.drugsUsed.some(item => item === "thc");
    }

    get sustainedFractures() {
        if (this.responses === null) { return false; }

        let fracturesYes = this.responses.accidentDetails.injuriesAndSymptoms.some(item => item.value === "fractures" && this.isYes(item.response));

        return fracturesYes;
    }

    any(items) {
        return items && items.some(item => item);
    }

    @computedFrom(
        'responses.neuropsychological.currentState.tasks'
    )
    get isCaregivingAbilityAnswered() {
        if (!this.responses) { return false; }

        let caregiving = this.responses.neuropsychological.currentState.tasks.find(item => item.isCaregiving === true);
        
        return caregiving && !caregiving.isNA && this.isAnswered(caregiving.ability);
    }

    addLanguage() {
        this.responses.personalHistory.languages.push("");
    }

    siblingCountChanged(siblingCount, siblingAges) {
        if (siblingCount > siblingAges.length) {
            let toAdd = siblingCount - siblingAges.length;
            for (let i = 0; i < toAdd; i++) {
                siblingAges.push({ "value": null, "unit": null });
            }

            this.changed('sibling-count-changed');
        }
        else if (siblingCount < siblingAges.length) {
            siblingAges.splice(siblingCount, siblingAges.length - siblingCount);

            this.changed('sibling-count-changed');
        }
    }

    childrenCountChanged(childCount, childAges) {
        if (childCount > childAges.length) {
            let toAdd = childCount - childAges.length;
            for (let i = 0; i < toAdd; i++) {
                childAges.push({ "value": null, "unit": null });
            }

            this.changed('child-count-changed');
        }
        else if (childCount < childAges.length) {
            childAges.splice(childCount, childAges.length - childCount);

            this.changed('child-count-changed');
        }
    }

    addDayOfAssessmentMedication() {
        this.responses.dayOfAssessment.medications.push({ "name": "", "purpose": "", "whenStarted": "", "usedAtTimeOfAccident": "" });
    }

    removeDayOfAssessmentMedication(medication) {
		if (confirm("Remove medication\nAre you sure?")) {
			this.responses.dayOfAssessment.medications.splice(this.responses.dayOfAssessment.medications.indexOf(medication), 1);
		}		
	}

    addOtherAccidentInjurySymptom() {
        this.responses.accidentDetails.otherInjuriesAndSymptoms.push("");
    }

    addPsychologicalCompletion() {
        this.responses.accidentDetails.examinations.psychological.completions.push({ "withWhom": "", "when": "" });
    }

    addPsychiatricCompletion() {
        this.responses.accidentDetails.examinations.psychiatric.completions.push({ "withWhom": "", "when": "" });
    }

    addNpNcCompletion() {
        this.responses.accidentDetails.examinations.npNc.completions.push({ "withWhom": "", "when": "" });
    }

    addOtherStressor() {
        this.responses.psychological.otherStressors.push({ "self": null, "family": null, "value": "" });
    }

    addWhereaboutsObject() {
        this.responses.neuropsychological.memory.visual.additionalWhereaboutsObjects.push("");
    }

    addPreAccidentRecreationalActivity() {
        this.responses.neuropsychological.currentState.preAccidentRecreationalActivities.push("");
    }

    addCurrentPainArea() {
        this.responses.neuropsychological.physical.pain.currentPainAreas.push("");
    }

    addOtherPhysicalIssue() {
        this.responses.neuropsychological.physical.other.issues.push("");
    }

    screenshot() {
        let fileName = this.claimant.lastName + ', ' + this.claimant.firstName + ' - Dr. Watson\'s Interview Notes.png';

        html2canvas(document.getElementById("notesContent")).then(canvas => {
            canvas.toBlob(function(blob) {
                if (navigator.msSaveBlob) {
                    return navigator.msSaveBlob(blob, fileName);
                }
                
                var blobUrl = window.URL.createObjectURL(blob);
                var anchor = document.createElement('a');
                anchor.download = fileName;
                anchor.href = blobUrl;
                document.body.appendChild(anchor);
                anchor.click();
                document.body.removeChild(anchor);
            });
        }).catch(function (error) {
            console.log(error);
        	/* This is fired when the promise executes without the DOM */    
    	});
    }
}
