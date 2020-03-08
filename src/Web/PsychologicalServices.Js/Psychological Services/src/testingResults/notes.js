import {inject} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {Context} from 'common/context';
import {NotesRepository} from 'testingResults/notesRepository';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';

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
        this.initialInjuriesAndSymptoms = [];
        this.studentSelfRatings = [];
        this.medicalConditions = [];
        this.abusedDrugs = [];
        this.physicalStates = [];
        this.prognosis = [];
        this.reminderChecklistItems = [];
        this.observations = [];

        this.self = this;

		this.valueMatcher = (a, b) => {
            return a && b && a.value === b.value;
        }
    }

    activate() {
        return this.getData();
    }

    getData() {
        return this.context.getUser()
            .then(user => {
                this.user = user;
                this.searchCompanyId = user.company.companyId;

                return Promise.all([
                    this.notesRepository.getPronouns().then(data => this.pronouns = data),
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
                    this.notesRepository.getCurrentStateTasks().then(data => {
                        this.currentStateTasks = this.asArray(data);
                        this.currentStateTasksMap = data;
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
        return this.notesRepository.getNotes(assessment.assessmentId).then(data => {
            this.assessment = data.assessment;
            this.responses = data.responses;
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
        return value !== undefined && value !== null && this.yesNoDontKnowMap[value].isYes;
    }

    isNo(value) {
        return value !== undefined && value !== null && this.yesNoDontKnowMap[value].isNo;
    }

    isDontKnow(value) {
        return value !== undefined && value !== null && this.yesNoDontKnowMap[value].isDontKnow;
    }

    isSkip(value) {
        return value !== undefined && value !== null && this.yesNoDontKnowMap[value].isSkip;
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
        'responses.personalHistory.sisters.howMany'
    )
    get siblingCount() {
        return this.responses ? (
            this.responses.personalHistory.brothers.howMany !== null
                ? parseInt(this.responses.personalHistory.brothers.howMany, 10)
                : 0) +
            (this.responses.personalHistory.sisters.howMany !== null
                ? parseInt(this.responses.personalHistory.sisters.howMany, 10)
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

    @computedFrom('responses.psychological.worry')
    get worriesAboutFinances() {
        return this.yesWorries.some(item => item.isFinances);
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

    any(items) {
        return items && items.some(item => item);
    }

    @computedFrom(
        'responses.neuropsychological.currentState.tasks'
    )
    get isCaregivingAbilityAnswered() {
        if (!this.responses) { return false; }

        let caregiving = this.responses.neuropsychological.currentState.tasks.find(item => item.value === "caregiving");
        
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
        this.responses.dayOfAssessment.medications.push({ "name": "", "purpose": "", "whenStarted": "" });
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
}
