import {inject} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {Context} from 'common/context';
import {DataRepository} from 'services/dataRepository';
import {NotesRepository} from 'testingResults/notesRepository';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';
import {AgeService} from 'common/ageService';
import 'number-to-words';

@inject(BindingSignaler, DataRepository, NotesRepository, Context, Notifier, Scroller, AgeService, numberToWords)
export class NotesOutput {

    constructor(signaler, dataRepository, notesRepository, context, notifier, scroller, ageService, numberToWords) {
        this.signaler = signaler;
        this.dataRepository = dataRepository;
        this.notesRepository = notesRepository;
        this.context = context;
        this.notifier = notifier;
        this.scroller = scroller;
        this.ageService = ageService;
        this.numberToWords = numberToWords;

        this.searchCompanyId = null;
        this.claimant = null;
        this.claimants = null;
        this.pronoun = null;
        this.gender = null;

        this.assessments = null;
        this.assessment = null;
        this.responses = null;
        this.name = null;
        
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
        this.safetyConcerns = [];
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
        this.headacheDescriptions = [];
        this.headacheReliefActivities = [];
        this.headacheFrequencies = [];
        this.hobbies = [];

        this.self = this;

		this.valueMatcher = (a, b) => {
            return a && b && a.value === b.value;
        }

        this.getItemValueForCurrentContext = function(item) {
            return this.getItemValueForContext(item, this);
        }.bind(this);

        this.getItemValueForCurrentContextPast = function(item) {
            return this.getItemValueForContextPast(item, this);
        }.bind(this);

        this.getFamilyNeurologicalOrPsychiatricDiseasesTextForCurrentContext = function(item) {
            return this.getFamilyNeurologicalOrPsychiatricDiseasesTextForContext(item, this);
        }.bind(this);
        
        this.isNotSkipAbilityWithContext = function(task) {
            return this.isNotSkipAbility(task, this);
        }.bind(this);

        this.currentStateIssueTextWithContext = function(value) {
            return this.currentStateIssueText(value, this);
        }.bind(this);

        this.getAgeTextForCurrentContext = function(age) {
            return this.getAgeTextForContext(age, this);
        }.bind(this);

        this.getRecreationalActivityDescriptionForCurrentContext = function(activity) {
            return this.getRecreationalActivityDescriptionForContext(activity, this);
        }.bind(this);

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
                    this.notesRepository.getPronouns().then(data => {
                        this.pronouns = this.asArray(data);
                        this.pronounsMap = data;
                    }),
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
                        this.headacheDescriptionsMap = data;
                    }),
                    this.notesRepository.getHeadacheReliefActivities().then(data => {
                        this.headacheReliefActivities = this.asArray(data);
                        this.headacheReliefActivitiesMap = data;
                    }),
                    this.notesRepository.getHeadacheFrequencies().then(data => {
                        this.headacheFrequenciesMap = data;
                    }),
                    this.notesRepository.getHeadacheFrequencies2().then(data => {
                        this.headacheFrequencies2Map = data;
                    }),
                    this.notesRepository.getHobbies().then(data => {
                        this.hobbies = this.asArray(data);
                        this.hobbiesMap = data;
                    }),
                    this.notesRepository.getAccidentCategories().then(data => {
                        this.accidentCategoriesMap = data;
                    }),
                    this.notesRepository.getTreatmentSessionFormats().then(data => {
                        this.treatmentSessionFormatsMap = data;
                    }),
                    this.notesRepository.getCounsellingMethods().then(data => {
                        this.counsellingMethodsMap = data;
                    }),
                    this.notesRepository.getHitHeadOnObjects().then(data => {
                        this.hitHeadOnObjectsMap = data;
                    }),
                    this.notesRepository.getIdentificationVerificationMethods().then(data => {
                        this.identificationVerificationMethodsMap = data;
                    }),
                    this.notesRepository.getPanicAttackFrequencies().then(data => {
                        this.panicAttackFrequenciesMap = data;
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
        this.name = null;

        this.claimant = null;
        this.changed('claimant-changed');
    }

    search(claimant, companyId) {
        this.reset();

		return this.notesRepository.searchAssessments(
            claimant ? claimant.claimantId : null, companyId).then(data => this.assessments = data);
    }
    
    select(assessment) {
        return this.notesRepository.getNotes(assessment.assessmentId).then(data => {
            this.name = data.name;
            this.assessment = data.assessment;
            this.responses = data.responses;

            return this.notesRepository.getCurrentStateTasks(this.responses.createdAtVersion).then(data => {
                this.currentStateTasks = this.asArray(data);
                this.currentStateTasksMap = data;
            });
        });
    }

    changed(signalName) {
        this.signaler.signal(signalName);
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

    getMatch(values, value) {
        if (!values || !value || !(values.length || values[value])) { return null; }

        if (values.length) {
            let val = values.filter(v => v.value === value);
            return val.length > 0 ? val[0] : null;
        }

        if (values[value]) {
            return values[value];
        }
    }

    isNotSkipAbility(task, context) {
        return task && (task.isNA || (task.ability && !context.currentStateAbilitiesMap[task.ability].isSkip));
    }

    currentStateIssueText(value, context) {
        return value && context && context.currentStateIssuesMap[value].format(context);
    }

    currentStateIssuesSorted(issues) {
        let issuesSorted = issues.slice().sort((a, b) => a && b ? this.currentStateIssuesMap[a].sort - this.currentStateIssuesMap[b].sort : 0);

        return issuesSorted;
    }

    observationResponse(id) {
        let observation = this.responses.observations.find(o => o.value === id);

        if (observation) {
            return observation.response;
        }

        return null;
    }

    @computedFrom('responses.observations')
    get observationsRecallingAllYes() {
        if (!this.responses) { return false; }

        let responses = [
            this.observationResponse('claimantIssuesRecallingPreviousState'),
            this.observationResponse('claimantIssuesRecallingIncident'),
            this.observationResponse('claimantIssuesRecallingTreatment')
        ];

        let allYes = responses.every(x => this.isYes(x));
        return allYes;
    }

    @computedFrom('responses.observations')
    get observationsRecallingAllNo() {
        if (!this.responses) { return false; }

        let responses = [
            this.observationResponse('claimantIssuesRecallingPreviousState'),
            this.observationResponse('claimantIssuesRecallingIncident'),
            this.observationResponse('claimantIssuesRecallingTreatment')
        ];

        let allNo = responses.every(x => this.isNo(x));
        return allNo;
    }

    @computedFrom('responses.observations')
    get test() {
        if (!this.responses) { return ""; }

        let responses = [
            { "response": this.observationResponse('claimantIssuesRecallingPreviousState'), "description": `${this.pronoun.possessiveAdjective} previous state` },
            { "response": this.observationResponse('claimantIssuesRecallingIncident'), "description": "specific details about the index accident" },
            { "response": this.observationResponse('claimantIssuesRecallingTreatment'), "description": `${this.pronoun.possessiveAdjective} post-accident treatment` }
        ];

        let anyYes = responses.some(x => this.isYes(x.response));
        let anyNo = responses.some(x => this.isNo(x.response));

        if (anyYes && anyNo) {
            let no = responses.filter(x => this.isNo(x.response)).map(x => x.description).join(' or ');
            let yes = responses.filter(x => this.isYes(x.response)).map(x => x.description).join(' and ');

            let value = ` did not appear to have any issues recalling ${no}, but reported issues recalling ${yes}.`;
            return value;
        }
        else if (anyYes && !anyNo) {
            let yes = responses.filter(x => this.isYes(x.response)).map(x => x.description).join(' and ');

            let value = ` reported issues recalling ${yes}.`;
            return value;
        }
        else if (anyNo && !anyYes) {
            let no = responses.filter(x => this.isNo(x.response)).map(x => x.description).join(' or ');
            
            let value = ` did not appear to have any issues recalling ${no}.`;
            return value;
        }

        return ``;
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
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.timeOfAccident) { return false; }

        return this.responses.accidentDetails.timeOfAccident.timeType === "specific";
    }

    @computedFrom('responses.accidentDetails.timeOfAccident.timeType')
    get timeOfAccidentIsGeneral() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.timeOfAccident) { return false; }

        return this.responses.accidentDetails.timeOfAccident.timeType === "general";
    }

    @computedFrom('responses.accidentDetails.hitHeadOn')
    get hitHeadOnIsOther() {
        if (this.responses === null || this.responses.accidentDetails === null) { return false; }

        return this.responses.accidentDetails.hitHeadOn === "other";
    }

    @computedFrom('responses.accidentDetails.ocfCompleter.treatmentSessions.sessionFormat')
    get treatmentSessionFormatIsOther() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.ocfCompleter || !this.responses.accidentDetails.ocfCompleter.treatmentSessions) { return false; }

        return this.responses.accidentDetails.ocfCompleter.treatmentSessions.sessionFormat === "other";
    }

    @computedFrom('responses.accidentDetails.counsellingMethod')
    get counsellingMethodIsOther() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.counsellingMethod) { return false; }

        return this.responses.accidentDetails.counsellingMethod === "other";
    }
    
    @computedFrom('responses.identification.verificationMethod.method')
    get idMethodIsOther() {
        if (this.responses === null || this.responses.identification === null) { return false; }
        
        return this.responses.identification.verificationMethod.method === "other";
    }

    @computedFrom(
        'responses.accidentDetails.hospitalStayLength.hours',
        'responses.accidentDetails.hospitalStayLength.days',
        'responses.accidentDetails.hospitalStayLength.weeks',
        'responses.accidentDetails.hospitalStayLength.months'
    )
    get hospitalStayLength() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.hospitalStayLength) { return []; }

        let values = [
            { "value": this.responses.accidentDetails.hospitalStayLength.months, "description": function(x) { return x == 1 ? "month" : "months"; } },
            { "value": this.responses.accidentDetails.hospitalStayLength.weeks, "description": function(x) { return x == 1 ? "week" : "weeks"; } },
            { "value": this.responses.accidentDetails.hospitalStayLength.days, "description": function(x) { return x == 1 ? "day" : "days"; } },
            { "value": this.responses.accidentDetails.hospitalStayLength.hours, "description": function(x) { return x == 1 ? "hour" : "hours"; } }
        ];

        let filteredValues = values.filter(v => v.value);

        let results = filteredValues.map(v => (this.isNumeric(v.value) ? this.numberToWords.toWords(v.value) : v.value) + " " + v.description(v.value));

        return results;
    }

    @computedFrom(
        'responses.accidentDetails.lossOfConsciousness.length.seconds',
        'responses.accidentDetails.lossOfConsciousness.length.minutes',
        'responses.accidentDetails.lossOfConsciousness.length.hours',
        'responses.accidentDetails.lossOfConsciousness.length.days',
        'responses.accidentDetails.lossOfConsciousness.length.weeks'
    )
    get lossOfConsciousnessLength() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.lossOfConsciousness) { return []; }

        let values = [
            { "value": this.responses.accidentDetails.lossOfConsciousness.length.weeks, "description": function(x) { return x == 1 ? "week" : "weeks"; } },
            { "value": this.responses.accidentDetails.lossOfConsciousness.length.days, "description": function(x) { return x == 1 ? "day" : "days"; } },
            { "value": this.responses.accidentDetails.lossOfConsciousness.length.hours, "description": function(x) { return x == 1 ? "hour" : "hours"; } },
            { "value": this.responses.accidentDetails.lossOfConsciousness.length.minutes, "description": function(x) { return x == 1 ? "minute" : "minutes"; } },
            { "value": this.responses.accidentDetails.lossOfConsciousness.length.seconds, "description": function(x) { return x == 1 ? "second" : "seconds"; } }
        ];

        let filteredValues = values.filter(v => v.value);

        let results = filteredValues.map(v => (this.isNumeric(v.value) ? this.numberToWords.toWords(v.value) : v.value) + " " + v.description(v.value));

        return results;
    }

    @computedFrom(
        'responses.accidentDetails.postTraumaticAmnesia.length.seconds',
        'responses.accidentDetails.postTraumaticAmnesia.length.minutes',
        'responses.accidentDetails.postTraumaticAmnesia.length.hours',
        'responses.accidentDetails.postTraumaticAmnesia.length.days',
        'responses.accidentDetails.postTraumaticAmnesia.length.weeks'
    )
    get postTraumaticAmnesiaLength() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.postTraumaticAmnesia) { return []; }

        let values = [
            { "value": this.responses.accidentDetails.postTraumaticAmnesia.length.weeks, "description": function(x) { return x == 1 ? "week" : "weeks"; } },
            { "value": this.responses.accidentDetails.postTraumaticAmnesia.length.days, "description": function(x) { return x == 1 ? "day" : "days"; } },
            { "value": this.responses.accidentDetails.postTraumaticAmnesia.length.hours, "description": function(x) { return x == 1 ? "hour" : "hours"; } },
            { "value": this.responses.accidentDetails.postTraumaticAmnesia.length.minutes, "description": function(x) { return x == 1 ? "minute" : "minutes"; } },
            { "value": this.responses.accidentDetails.postTraumaticAmnesia.length.seconds, "description": function(x) { return x == 1 ? "second" : "seconds"; } }
        ];

        let filteredValues = values.filter(v => v.value);

        let results = filteredValues.map(v => (this.isNumeric(v.value) ? this.numberToWords.toWords(v.value) : v.value) + " " + v.description(v.value));

        return results;
    }

    @computedFrom('examinations.psychological.completions')
    get psychologicalCompletions() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.examinations || !this.responses.accidentDetails.examinations.psychological || !this.responses.accidentDetails.examinations.psychological.completions) { return []; }

        let data = this.responses.accidentDetails.examinations.psychological.completions.filter(x => x.withWhom || x.when).map(x => `${x.withWhom} ${x.when}`.trim());

        return data;
    }

    @computedFrom('examinations.psychiatric.completions')
    get psychiatricCompletions() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.examinations || !this.responses.accidentDetails.examinations.psychiatric || !this.responses.accidentDetails.examinations.psychiatric.completions) { return []; }

        let data = this.responses.accidentDetails.examinations.psychiatric.completions.filter(x => x.withWhom || x.when).map(x => `${x.withWhom} ${x.when}`.trim());

        return data;
    }

    @computedFrom('examinations.npNc.completions')
    get npNcCompletions() {
        if (this.responses === null || !this.responses.accidentDetails || !this.responses.accidentDetails.examinations || !this.responses.accidentDetails.examinations.npNc || !this.responses.accidentDetails.examinations.npNc.completions) { return []; }

        let data = this.responses.accidentDetails.examinations.npNc.completions.filter(x => x.withWhom || x.when).map(x => `${x.withWhom} ${x.when}`.trim());

        return data;
    }

    @computedFrom('examinations.psychological.completions')
    get anyPsychologicalCompletions() {
        let data = this.psychologicalCompletions;

        return data.some(x => x);
    }

    @computedFrom('examinations.psychiatric.completions')
    get anyPsychiatricCompletions() {
        let data = this.psychiatricCompletions;

        return data.some(x => x);
    }

    @computedFrom('examinations.npNc.completions')
    get anyNpNcCompletions() {
        let data = this.npNcCompletions;

        return data.some(x => x);
    }

    isNumeric(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    distinct(arr) {
        let aMap = {};

        return arr.filter(element => {
            let count = (aMap[element] || 0) + 1;
            aMap[element] = count;
            return count === 1;
        });
    }

    getInjuriesAndSymptomsForResponses(criteria) {
        if (!this.responses || !this.responses.accidentDetails || !this.responses.accidentDetails.injuriesAndSymptoms) { return []; }

        let data = this.responses.accidentDetails.injuriesAndSymptoms
            .filter(item => item.response != null && criteria(item))
            .map(item => this.initialInjuriesAndSymptomsMap[item.value]);

        return data;
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get yesFractures() {
        let data = this.getInjuriesAndSymptomsForResponses(item => this.isYes(item.response) && this.initialInjuriesAndSymptomsMap[item.value].isFractures);

        let any = data.some(x => x);

        return any;
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get fracturesDetail() {
        let fractures = this.getInjuriesAndSymptomsForResponses(item => this.isYes(item.response) && this.initialInjuriesAndSymptomsMap[item.value].isFractures);

        if (fractures.length === 1) {
            let details = this.responses.accidentDetails.injuriesAndSymptoms.filter(x => x.value === fractures[0].value).map(x => x.details);

            return details.length === 1 ? details[0] : "";
        }

        return "";
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get noFractures() {
        let data = this.getInjuriesAndSymptomsForResponses(item => this.isNo(item.response) && this.initialInjuriesAndSymptomsMap[item.value].isFractures);

        let any = data.some(x => x);

        return any;
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get yesLacerations() {
        let data = this.getInjuriesAndSymptomsForResponses(item => this.isYes(item.response) && this.initialInjuriesAndSymptomsMap[item.value].isLacerations);

        let any = data.some(x => x);

        return any;
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get noLacerations() {
        let data = this.getInjuriesAndSymptomsForResponses(item => this.isNo(item.response) && this.initialInjuriesAndSymptomsMap[item.value].isLacerations);

        let any = data.some(x => x);

        return any;
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get dontKnowLacerations() {
        return this.getInjuriesAndSymptomsForResponses(item => this.isDontKnow(item.response) && this.initialInjuriesAndSymptomsMap[item.value].isLacerations);
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get selectedInjuriesAndSymptoms() {
        return this.getInjuriesAndSymptomsForResponses(item => this.isYes(item.response) && !this.initialInjuriesAndSymptomsMap[item.value].isSeparateOutput);
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get unselectedInjuriesAndSymptoms() {
        return this.getInjuriesAndSymptomsForResponses(item => this.isNo(item.response) && !this.initialInjuriesAndSymptomsMap[item.value].isSeparateOutput);
    }

    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get dontKnowInjuriesAndSymptoms() {
        return this.getInjuriesAndSymptomsForResponses(item => this.isDontKnow(item.response) && !this.initialInjuriesAndSymptomsMap[item.value].isSeparateOutput);
    }
    
    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get anySelectedInjuriesAndSymptoms() {
        return this.selectedInjuriesAndSymptoms.some(item => item);
    }
    
    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get anyUnselectedInjuriesAndSymptoms() {
        return this.unselectedInjuriesAndSymptoms.some(item => item);
    }
    
    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get anyDontKnowInjuriesAndSymptoms() {
        return this.dontKnowInjuriesAndSymptoms.some(item => item);
    }

    @computedFrom('responses.accidentDetails.otherInjuriesAndSymptoms')
    get anyOtherInjuriesAndSymptoms() {
        if (!this.responses || !this.responses.accidentDetails || !this.responses.accidentDetails.otherInjuriesAndSymptoms) { return false; }

        return this.responses.accidentDetails.otherInjuriesAndSymptoms.length &&
            this.responses.accidentDetails.otherInjuriesAndSymptoms.some(x => x && x.length > 0);
    }
    
    @computedFrom('responses.accidentDetails.injuriesAndSymptoms')
    get singleUnselectedInjuriesAndSymptom() {
        return this.unselectedInjuriesAndSymptoms.length === 1;
    }

    @computedFrom(
        'responses.personalHistory.psychological.takenMoodMedication',
        'responses.personalHistory.psychological.onMoodMedicationAtTimeOfAccident',
        'responses.personalHistory.psychological.hadMentalHealthTesting',
        'responses.personalHistory.psychological.hadMentalHealthCounselling',
        'responses.personalHistory.psychological.hospitalizedDueToPsychologicalConcerns'
    )
    get yesPsychologicalHistory() {
        if (!this.responses || !this.responses.personalHistory || !this.responses.personalHistory.psychological || !this.responses.personalHistory.psychological.takenMoodMedication) { return []; }
        
        let data = [
            { "value": this.isYes(this.responses.personalHistory.psychological.takenMoodMedication) && this.isYes(this.responses.personalHistory.psychological.onMoodMedicationAtTimeOfAccident), "description": function(context) { return `had used medication for ${context.pronoun.possessiveAdjective} mood (which ${context.pronoun.subject} was using at the time of the accident)`; } },
            { "value": this.isYes(this.responses.personalHistory.psychological.takenMoodMedication) && this.isNo(this.responses.personalHistory.psychological.onMoodMedicationAtTimeOfAccident), "description": function(context) { return `had used medication for ${context.pronoun.possessiveAdjective} mood (which ${context.pronoun.subject} was not using at the time of the accident)`; } },
            { "value": this.isYes(this.responses.personalHistory.psychological.hadMentalHealthTesting), "description": function(context) { return `completed a mental health assessment`; } },
            { "value": this.isYes(this.responses.personalHistory.psychological.hadMentalHealthCounselling), "description": function(context) { return `was seen for counselling`; } },
            { "value": this.isYes(this.responses.personalHistory.psychological.hospitalizedDueToPsychologicalConcerns), "description": function(context) { return `had been hospitalized due to psychological concerns`; } }
        ];
        
        return data.filter(x => x.value).map(x => x.description(this));
    }

    @computedFrom(
        'responses.personalHistory.psychological.takenMoodMedication',
        'responses.personalHistory.psychological.hadMentalHealthTesting',
        'responses.personalHistory.psychological.hadMentalHealthCounselling',
        'responses.personalHistory.psychological.hospitalizedDueToPsychologicalConcerns'
    )
    get noPsychologicalHistory() {
        if (!this.responses || !this.responses.personalHistory || !this.responses.personalHistory.psychological || !this.responses.personalHistory.psychological.takenMoodMedication) { return []; }
        
        let data = [
            { "value": this.isNo(this.responses.personalHistory.psychological.takenMoodMedication), "description": function(context) { return `had been using medication for ${context.pronoun.possessiveAdjective} mood prior to the accident`; } },
            { "value": this.isNo(this.responses.personalHistory.psychological.hadMentalHealthTesting), "description": function(context) { return `had completed any mental health assessments`; } },
            { "value": this.isNo(this.responses.personalHistory.psychological.hadMentalHealthCounselling), "description": function(context) { return `had been seen for any counselling`; } },
            { "value": this.isNo(this.responses.personalHistory.psychological.hospitalizedDueToPsychologicalConcerns), "description": function(context) { return `had been hospitalized due to psychological concerns`; } }
        ];
        
        return data.filter(x => x.value).map(x => x.description(this));
    }

    @computedFrom(
        'responses.personalHistory.psychological.takenMoodMedication',
        'responses.personalHistory.psychological.onMoodMedicationAtTimeOfAccident',
        'responses.personalHistory.psychological.hadMentalHealthTesting',
        'responses.personalHistory.psychological.hadMentalHealthCounselling',
        'responses.personalHistory.psychological.hospitalizedDueToPsychologicalConcerns'
    )
    get anyYesPsychologicalHistory() {
        return this.yesPsychologicalHistory.some(item => item);
    }
    
    @computedFrom(
        'responses.personalHistory.psychological.takenMoodMedication',
        'responses.personalHistory.psychological.hadMentalHealthTesting',
        'responses.personalHistory.psychological.hadMentalHealthCounselling',
        'responses.personalHistory.psychological.hospitalizedDueToPsychologicalConcerns'
    )
    get anyNoPsychologicalHistory() {
        return this.noPsychologicalHistory.some(item => item);
    }

    @computedFrom(
        'responses',
        'claimants'
    )
    get formVisible() {
        return this.responses && !this.claimants;
    }

    @computedFrom(
        'responses.personalHistory.languages'
    )
    get knownLanguages() {
        if (!this.responses || !this.responses.personalHistory.languages) { return []; }

        let data = this.responses.personalHistory.languages.filter(item => item && item.length > 0);

        return data;
    }

    @computedFrom(
        'responses.personalHistory.growingUp.abuse.physical',
        'responses.personalHistory.growingUp.abuse.sexual',
        'responses.personalHistory.growingUp.abuse.mental'
    )
    get yesAbuseTypes() {
        if (!this.responses || !this.responses.personalHistory.growingUp || !this.responses.personalHistory.growingUp.abuse) { return []; }
        
        let data = [
            { "response": this.responses.personalHistory.growingUp.abuse.physical, "value": "physical" },
            { "response": this.responses.personalHistory.growingUp.abuse.sexual, "value": "sexual" },
            { "response": this.responses.personalHistory.growingUp.abuse.mental, "value": "mental" }
        ];

        return data.filter(item => item && item.response === "yes");
    }

    @computedFrom(
        'responses.personalHistory.growingUp.abuse.physical',
        'responses.personalHistory.growingUp.abuse.sexual',
        'responses.personalHistory.growingUp.abuse.mental'
    )
    get noAbuseTypes() {
        if (!this.responses || !this.responses.personalHistory.growingUp || !this.responses.personalHistory.growingUp.abuse) { return []; }
        
        let data = [
            { "response": this.responses.personalHistory.growingUp.abuse.physical, "value": "physical" },
            { "response": this.responses.personalHistory.growingUp.abuse.sexual, "value": "sexual" },
            { "response": this.responses.personalHistory.growingUp.abuse.mental, "value": "mental" }
        ];

        return data.filter(item => item && item.response === "no");
    }

    @computedFrom(
        'responses.personalHistory.growingUp.abuse.physical',
        'responses.personalHistory.growingUp.abuse.sexual',
        'responses.personalHistory.growingUp.abuse.mental'
    )
    get noAbuseGrowingUp() {
        if (!this.responses || !this.responses.personalHistory.growingUp || !this.responses.personalHistory.growingUp.abuse) { return false; }

        return this.responses.personalHistory.growingUp.abuse.physical === "no" &&
            this.responses.personalHistory.growingUp.abuse.sexual === "no" &&
            this.responses.personalHistory.growingUp.abuse.mental === "no";
    }

    @computedFrom(
        'responses.personalHistory.brothers.skip',
        'responses.personalHistory.sisters.skip'        
    )
    get skipSiblings() {
        return this.responses && this.responses.personalHistory.brothers.skip && this.responses.personalHistory.sisters.skip;
    }

    @computedFrom(
        'responses.personalHistory.children.sons.skip',
        'responses.personalHistory.children.daughters.skip'        
    )
    get skipChildren() {
        return this.responses && this.responses.personalHistory.children.sons.skip && this.responses.personalHistory.children.daughters.skip;
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

    getNeurologicalOrPsychiatricDiagnosisForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.personalHistory.neurologicalOrPsychiatricDiseases
            .filter(item => criteria(item))
            .map(item => this.neurologicalAndPsychiatricDiseasesMap[item.value]);

        return data;
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get selectedNeurologicalOrPsychiatricDiagnosis() {
        return this.getNeurologicalOrPsychiatricDiagnosisForResponses(item => item.self !== null && this.isYes(item.self));
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get unselectedNeurologicalOrPsychiatricDiagnosis() {
        return this.getNeurologicalOrPsychiatricDiagnosisForResponses(item => item.self !== null && this.isNo(item.self));
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get dontKnowNeurologicalOrPsychiatricDiagnosis() {
        return this.getNeurologicalOrPsychiatricDiagnosisForResponses(item => item.self !== null && this.isDontKnow(item.self));
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anySelectedNeurologicalOrPsychiatricDiagnosis() {
        return this.selectedNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anyUnselectedNeurologicalOrPsychiatricDiagnosis() {
        return this.unselectedNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anyDontKnowNeurologicalOrPsychiatricDiagnosis() {
        return this.dontKnowNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get selectedFamilyNeurologicalOrPsychiatricDiagnosis() {
        if (!this.responses) { return []; }

        let data = this.responses.personalHistory.neurologicalOrPsychiatricDiseases
            .filter(item => item.family !== null && this.isYes(item.family))
            .map(item => {
                return {
                    "value": this.neurologicalAndPsychiatricDiseasesMap[item.value],
                    "data": item
                };
            });

        return data;
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get unselectedFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.getNeurologicalOrPsychiatricDiagnosisForResponses(item => item.family !== null && this.isNo(item.family));
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get dontKnowFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.getNeurologicalOrPsychiatricDiagnosisForResponses(item => item.family !== null && this.isDontKnow(item.family));
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anySelectedFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.selectedFamilyNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anyUnselectedFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.unselectedFamilyNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anyDontKnowFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.dontKnowFamilyNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    getEmotionalIssuesForResponses(criteria) {
        if (!this.responses || !this.responses.psychological.emotional) { return []; }

        let data = this.responses.psychological.emotional
            .filter(item => item.response != null && criteria(item))
            .map(item => this.emotionalIssues[item.value]);

        return data;
    }

    @computedFrom('responses.psychological.emotional')
    get yesEmotionalIssues() {
        return this.getEmotionalIssuesForResponses(item => this.isYes(item.response) && !this.emotionalIssues[item.value].isCriesEasily);
    }

    @computedFrom('responses.psychological.emotional')
    get noEmotionalIssues() {
        return this.getEmotionalIssuesForResponses(item => this.isNo(item.response) && !this.emotionalIssues[item.value].isCriesEasily);
    }

    @computedFrom('responses.psychological.emotional')
    get dontKnowEmotionalIssues() {
        return this.getEmotionalIssuesForResponses(item => this.isDontKnow(item.response) && !this.emotionalIssues[item.value].isCriesEasily);
    }

    @computedFrom('responses.psychological.emotional')
    get anyYesEmotionalIssues() {
        return this.yesEmotionalIssues.some(item => item);
    }

    @computedFrom('responses.psychological.emotional')
    get anyNoEmotionalIssues() {
        return this.noEmotionalIssues.some(item => item);
    }

    @computedFrom('responses.psychological.emotional')
    get anyDontKnowEmotionalIssues() {
        return this.dontKnowEmotionalIssues.some(item => item);
    }

    @computedFrom('responses.psychological.emotional')
    get yesCriesEasily() {
        return this.getEmotionalIssuesForResponses(item => this.isYes(item.response) && this.emotionalIssues[item.value].isCriesEasily).some(item => item);
    }

    @computedFrom('responses.psychological.emotional')
    get noCriesEasily() {
        return this.getEmotionalIssuesForResponses(item => this.isNo(item.response) && this.emotionalIssues[item.value].isCriesEasily).some(item => item);
    }

    @computedFrom('responses.psychological.emotional')
    get dontKnowCriesEasily() {
        return this.getEmotionalIssuesForResponses(item => this.isDontKnow(item.response) && this.emotionalIssues[item.value].isCriesEasily).some(item => item);
    }

    

    @computedFrom('responses.psychological.emotional')
    get anyEmotionalIssues() {
        if (!this.responses || !this.responses.psychological.emotional) { return false; }

        return this.responses.psychological.emotional.filter(item => this.isAnswered(item.response)).some(item => item);
    }

    getDepressionSymptomsForResponses(criteria) {
        if (!this.responses || !this.responses.psychological.depressionSymptoms) { return []; }

        let data = this.responses.psychological.depressionSymptoms
            .filter(item => item.response != null && criteria(item))
            .map(item => this.depressionSymptoms[item.value]);

        return data;
    }

    @computedFrom('responses.psychological.depressionSymptoms')
    get yesDepressionSymptoms() {
        return this.getDepressionSymptomsForResponses(item => this.isYes(item.response));
    }

    @computedFrom('responses.psychological.depressionSymptoms')
    get noDepressionSymptoms() {
        return this.getDepressionSymptomsForResponses(item => this.isNo(item.response));
    }

    @computedFrom('responses.psychological.depressionSymptoms')
    get dontKnowDepressionSymptoms() {
        return this.getDepressionSymptomsForResponses(item => this.isDontKnow(item.response));
    }

    @computedFrom('responses.psychological.depressionSymptoms')
    get anyDepressionSymptoms() {
        return this.getDepressionSymptomsForResponses(item => this.isAnswered(item.response)).some(item => item);
    }

    @computedFrom('responses.psychological.depressionSymptoms')
    get anyYesDepressionSymptoms() {
        return this.yesDepressionSymptoms.some(item => item);
    }

    @computedFrom('responses.psychological.depressionSymptoms')
    get anyNoDepressionSymptoms() {
        return this.noDepressionSymptoms.some(item => item);
    }

    @computedFrom('responses.psychological.depressionSymptoms')
    get anyDontKnowDepressionSymptoms() {
        return this.dontKnowDepressionSymptoms.some(item => item);
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
    get noWorries() {
        return this.getWorriesForResponses(item => this.isNo(item.response));
    }

    @computedFrom('responses.psychological.worry')
    get anyWorries() {
        return this.getWorriesForResponses(item => this.isAnswered(item.response)).some(item => item);
    }

    @computedFrom('responses.psychological.worry')
    get anyYesWorries() {
        return this.yesWorries.some(item => item);
    }

    @computedFrom('responses.psychological.worry')
    get anyNoWorries() {
        return this.noWorries.some(item => item);
    }

    @computedFrom(
        'responses.psychological.hallucinationsAuditory',
        'responses.psychological.hallucinationsVisual',
        'responses.psychological.hallucinationsCommand'
    )
    get hallucinationCharacteristics() {
        if (!this.responses) { return []; }

        let data = [
            { "response": this.responses.psychological.hallucinationsAuditory, "value": function(context) { return `auditory`; } },
            { "response": this.responses.psychological.hallucinationsVisual, "value": function(context) { return `visual`; } },
            { "response": this.responses.psychological.hallucinationsCommand, "value": function(context) { return `command`; } }
        ].filter(item => this.isYes(item.response));

        return data;
    }
    
    @computedFrom(
        'responses.psychological.hallucinationsAuditory',
        'responses.psychological.hallucinationsVisual',
        'responses.psychological.hallucinationsCommand'
    )
    get anyHallucinationCharacteristics() {
        let any = this.hallucinationCharacteristics.some(item => item);

        return any;
    }

    @computedFrom('responses.psychological.travel.travelIssues')
    get anyTravelIssues() {
        if (!this.responses || !this.responses.psychological.travel || !this.responses.psychological.travel.travelIssues) { return false; }

        let any = this.responses.psychological.travel.travelIssues.some(item => item);

        return any;
    }

    @computedFrom('responses.psychological.travel.travelIssues')
    get selectedTravelIssues() {
        if (!this.responses || !this.responses.psychological.travel || !this.responses.psychological.travel.travelIssues) { return []; }

        let data = this.responses.psychological.travel.travelIssues.map(item => this.travelIssuesMap[item]);

        return data;
    }

    @computedFrom('responses.neuropsychological.memory.visual.forgetWhereaboutsOf')
    get anyForgottenWhereaboutsObjects() {
        if (!this.responses) { return []; }

        let any =
            this.responses &&
            this.isYes(this.responses.neuropsychological.memory.visual.forgetWhereaboutsOfObjects) &&
            this.forgottenWhereaboutsObjects.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.memory.visual.forgetWhereaboutsOf',
        'responses.neuropsychological.memory.visual.additionalWhereaboutsObjects'
    )
    get forgottenWhereaboutsObjects() {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.memory.visual.forgetWhereaboutsOf.concat(
            this.responses.neuropsychological.memory.visual.additionalWhereaboutsObjects.filter(item => item && item.length > 0)
        ).reduce(function (accumulator, currentValue) {
            if (!accumulator.some(item => item === currentValue)) { accumulator.push(currentValue); }
            return accumulator;
          }, []).map(item => this.whereaboutsObjectsMap.hasOwnProperty(item) ? this.whereaboutsObjectsMap[item].format(this) : item);

        return data;
    }

    @computedFrom('responses.neuropsychological.memory.aids.aidsUsed')
    get anyNonFamilyMemoryAidsUsed() {
        let any = this.responses && this.responses.neuropsychological.memory.aids.aidsUsed.some(item => item);

        return any;
    }

    @computedFrom('responses.neuropsychological.memory.aids.aidsUsed')
    get selectedMemoryAids() {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.memory.aids.aidsUsed.map(item => this.memoryAidsMap[item]);

        return data;
    }

    get selectedReadingIssues() {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.attention.readingIssues.map(item => this.readingIssuesMap[item]);

        return data;
    }

    getSafetyConcernsForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.memory.safetyConcerns
            .filter(item => item.response != null && criteria(item))
            .map(item => this.safetyConcerns[item.value]);

        return data;
    }

    @computedFrom('responses.neuropsychological.memory.safetyConcerns')
    get selectedSafetyConcerns() {
        let data = this.getSafetyConcernsForResponses(item => this.isYes(item.response));

        return data;
    }

    @computedFrom('responses.neuropsychological.memory.safetyConcerns')
    get anySelectedSafetyConcerns() {
        let any = this.selectedSafetyConcerns.some(item => item);

        return any;
    }

    @computedFrom('responses.neuropsychological.memory.safetyConcerns')
    get unselectedSafetyConcerns() {
        let data = this.getSafetyConcernsForResponses(item => this.isNo(item.response));

        return data;
    }

    @computedFrom('responses.neuropsychological.memory.safetyConcerns')
    get anyUnselectedSafetyConcerns() {
        let any = this.unselectedSafetyConcerns.some(item => item);

        return any;
    }

    @computedFrom('responses.neuropsychological.memory.safetyConcerns')
    get dontKnowSafetyConcerns() {
        let data = this.getSafetyConcernsForResponses(item => this.isDontKnow(item.response));

        return data;
    }

    @computedFrom('responses.neuropsychological.memory.safetyConcerns')
    get anyDontKnowSafetyConcerns() {
        let any = this.dontKnowSafetyConcerns.some(item => item);

        return any;
    }

    getLanguageIssuesForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.language
            .filter(item => item.response != null && criteria(item))
            .map(item => this.languageIssues[item.value]);

        return data;
    }

    @computedFrom('responses.neuropsychological.language')
    get selectedLanguageIssues() {
        let data = this.getLanguageIssuesForResponses(item => this.isYes(item.response));

        return data;
    }

    @computedFrom('responses.neuropsychological.language')
    get anySelectedLanguageIssues() {
        let any = this.selectedLanguageIssues.some(item => item);

        return any;
    }

    @computedFrom('responses.neuropsychological.language')
    get unselectedLanguageIssues() {
        let data = this.getLanguageIssuesForResponses(item => this.isNo(item.response));

        return data;
    }

    @computedFrom('responses.neuropsychological.language')
    get anyUnselectedLanguageIssues() {
        let any = this.unselectedLanguageIssues.some(item => item);

        return any;
    }

    getVisualSpatialIssuesForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.visualSpatial
            .concat(this.responses.neuropsychological.atypical)
            .filter(item => item.response != null && criteria(item))
            .map(item => this.visualSpatialIssues[item.value]);

        return data;
    }

    @computedFrom('responses.neuropsychological.visualSpatial')
    get anySelectedVisualSpatialIssues() {
        return this.selectedVisualSpatialIssues.some(item => item);
    }

    @computedFrom('responses.neuropsychological.visualSpatial')
    get anyUnselectedVisualSpatialIssues() {
        return this.unselectedVisualSpatialIssues.some(item => item);
    }

    @computedFrom('responses.neuropsychological.visualSpatial')
    get selectedVisualSpatialIssues() {
        return this.getVisualSpatialIssuesForResponses(item => this.isYes(item.response));
    }

    @computedFrom('responses.neuropsychological.visualSpatial')
    get unselectedVisualSpatialIssues() {
        return this.getVisualSpatialIssuesForResponses(item => this.isNo(item.response));
    }

    @computedFrom('responses.neuropsychological.atypical')
    get selectedAtypicalIssues() {
        return this.selectedVisualSpatialIssues.filter(item => item.isAtypical);
    }

    @computedFrom('responses.neuropsychological.atypical')
    get unselectedAtypicalIssues() {
        return this.unselectedVisualSpatialIssues.filter(item => item.isAtypical);
    }

    @computedFrom('responses.neuropsychological.atypical')
    get deniedAtypicalSymptomology() {
        //must not have any "yes" responses and at least one "no" response
        return !this.selectedAtypicalIssues.some(item => item) && this.unselectedAtypicalIssues.some(item => item);
    }

    getSleepIssueCausesForResponses() {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.physical.sleep.issueCauses
            .map(item => this.sleepIssueCausesMap[item]);
        
        return data;
    }

    @computedFrom('responses.neuropsychological.physical.sleep.issueCauses')
    get selectedSleepIssueCauses() {
        let data = this.getSleepIssueCausesForResponses();
        
        return data;
    }

    get anySelectedSleepIssueCauses() {
        return this.selectedSleepIssueCauses.some(item => item);
    }

    getSleepIssuesForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.physical.sleep.issues
            .filter(item => item.response != null && criteria(item))
            .map(item => this.sleepIssuesMap[item.value]);

        return data;
    }

    @computedFrom('responses.neuropsychological.physical.sleep.issues')
    get selectedSleepIssues() {
        let data = this.getSleepIssuesForResponses(item => this.isYes(item.response));

        return data;
    }

    @computedFrom('responses.neuropsychological.physical.sleep.issues')
    get unselectedSleepIssues() {
        let data = this.getSleepIssuesForResponses(item => this.isNo(item.response));

        return data;
    }

    @computedFrom('responses.neuropsychological.physical.sleep.issues')
    get allSelectedSleepIssues() {
        return this.selectedSleepIssues.some(item => item) && this.selectedSleepIssues.length === this.sleepIssues.length;
    }

    @computedFrom('responses.neuropsychological.physical.sleep.issues')
    get anySelectedSleepIssues() {
        return this.selectedSleepIssues.some(item => item);
    }

    @computedFrom('responses.neuropsychological.physical.sleep.issues')
    get anyUnselectedSleepIssues() {
        return this.unselectedSleepIssues.some(item => item);
    }

    getExecutiveIssuesForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.executive.issues
            .filter(item => item.response != null && criteria(item))
            .map(item => this.executiveIssues[item.value]);

        return data;
    }

    @computedFrom('responses.neuropsychological.executive.issues')
    get harderToMultiTask() {
        return this.getExecutiveIssuesForResponses(item => this.isYes(item.response) && this.executiveIssues[item.value].isHarderToMultiTask).some(item => item);
    }

    @computedFrom('responses.neuropsychological.executive.issues')
    get anySelectedExecutiveFunctionIssues() {
        return this.selectedExecutiveFunctionIssues.filter(item => !item.noOutput).some(item => item);
    }

    @computedFrom('responses.neuropsychological.executive.issues')
    get anyUnselectedExecutiveFunctionIssues() {
        return this.unselectedExecutiveFunctionIssues.filter(item => !item.noOutput).some(item => item);
    }

    @computedFrom('responses.neuropsychological.executive.issues')
    get selectedExecutiveFunctionIssues() {
        let data = this.getExecutiveIssuesForResponses(item => this.isYes(item.response));

        return data;
    }

    @computedFrom('responses.neuropsychological.executive.issues')
    get unselectedExecutiveFunctionIssues() {
        let data = this.getExecutiveIssuesForResponses(item => this.isNo(item.response));

        return data;
    }

    getInappropriateSocialBehaviorsForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.neuropsychological.executive.inappropriateSocialBehaviors
            .filter(item => item.response != null && criteria(item))
            .map(item => this.inappropriateSocialBehaviors[item.value]);

        return data;
    }

    @computedFrom('responses.neuropsychological.executive.inappropriateSocialBehaviors')
    get selectedInappropriateSocialBehavior() {
        let data = this.getInappropriateSocialBehaviorsForResponses(item => this.isYes(item.response));

        return data;
    }

    getStressorsForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.psychological.stressors
            .concat(this.responses.psychological.otherStressors.map(item => {
                return { "self": item.self, "family": item.family, "value": item.value };
            }))
            .filter(item => criteria(item))
            .map(item => {
                return this.stressorsMap[item.value] || { "description": item.value, "format": function(context) { return item.value; } };
            });

        return data;
    }

    @computedFrom(
        'this.responses.psychological.stressors',
        'this.responses.psychological.otherStressors'
    )
    get selectedStressors() {
        return this.getStressorsForResponses(item => item.self !== null && this.isYes(item.self));
    }

    @computedFrom(
        'this.responses.psychological.stressors',
        'this.responses.psychological.otherStressors'
    )
    get unselectedStressors() {
        return this.getStressorsForResponses(item => item.self !== null && this.isNo(item.self));
    }

    @computedFrom(
        'this.responses.psychological.stressors',
        'this.responses.psychological.otherStressors'
    )
    get anySelectedStressors() {
        return this.selectedStressors.some(item => item);
    }

    @computedFrom(
        'this.responses.psychological.stressors',
        'this.responses.psychological.otherStressors'
    )
    get anyUnselectedStressors() {
        return this.unselectedStressors.some(item => item);
    }

    @computedFrom(
        'this.responses.psychological.stressors',
        'this.responses.psychological.otherStressors'
    )
    get selectedFamilyStressors() {
        return this.getStressorsForResponses(item => item.family !== null && this.isYes(item.family));
    }

    @computedFrom(
        'this.responses.psychological.stressors',
        'this.responses.psychological.otherStressors'
    )
    get unselectedFamilyStressors() {
        return this.getStressorsForResponses(item => item.family !== null && this.isNo(item.family));
    }

    @computedFrom(
        'this.responses.psychological.stressors',
        'this.responses.psychological.otherStressors'
    )
    get anySelectedFamilyStressors() {
        return this.selectedFamilyStressors.some(item => item);
    }

    @computedFrom(
        'this.responses.psychological.stressors',
        'this.responses.psychological.otherStressors'
    )
    get anyUnselectedFamilyStressors() {
        return this.unselectedFamilyStressors.some(item => item);
    }


    getTreatmentProvidersForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.treatment.initial.providers
            .filter(item => criteria(item))
            .map(item => {
                return this.treatmentProvidersMap[item.value];
            });

        return data;
    }

    @computedFrom('this.responses.treatment.initial.providers','this.responses.treatment.initial.programs')
    get anySelectedTreatmentProvidersOrPrograms() {
        let providers = this.getTreatmentProvidersForResponses(item => item.sinceAccident !== null && this.isYes(item.sinceAccident));

        let programs = this.getTreatmentProgramsForResponses(item => item.sinceAccident !== null && this.isYes(item.sinceAccident));

        return providers.some(item => item) || programs.some(item => item);
    }

    @computedFrom('this.responses.treatment.initial.providers')
    get selectedCurrentTreatmentProviders() {
        return this.getTreatmentProvidersForResponses(item => item.current !== null && this.isYes(item.current.response));
    }

    @computedFrom('this.responses.treatment.initial.providers')
    get anySelectedCurrentTreatmentProviders() {
        return this.selectedCurrentTreatmentProviders.some(item => item);
    }

    @computedFrom('this.responses.treatment.initial.providers')
    get selectedPastTreatmentProviders() {
        return this.getTreatmentProvidersForResponses(item => item.past !== null && this.isYes(item.past.response));
    }

    @computedFrom('this.responses.treatment.initial.providers')
    get anySelectedPastTreatmentProviders() {
        return this.selectedPastTreatmentProviders.some(item => item);
    }

    @computedFrom('this.responses.treatment.initial.providers')
    get unselectedPastTreatmentProviders() {
        return this.getTreatmentProvidersForResponses(item => item.past !== null && this.isNo(item.past.response));
    }

    @computedFrom('this.responses.treatment.initial.providers')
    get anyUnselectedPastTreatmentProviders() {
        return this.unselectedPastTreatmentProviders.some(item => item);
    }

    @computedFrom(
        'this.responses.treatment.initial.providers',
        'this.responses.treatment.initial.programs'
    )
    get selectedBeneficialTreatments() {
        return this.getTreatmentProvidersForResponses(item => item.beneficial !== null && this.isYes(item.beneficial.response)
        ).concat(this.getTreatmentProgramsForResponses(item => item.beneficial !== null && this.isYes(item.beneficial.response)));
    }

    @computedFrom(
        'this.responses.treatment.initial.providers',
        'this.responses.treatment.initial.programs'
    )
    get anySelectedBeneficialTreatments() {
        return this.selectedBeneficialTreatments.some(item => item);
    }

    @computedFrom(
        'this.responses.treatment.initial.providers',
        'this.responses.treatment.initial.programs'
    )
    get unselectedBeneficialTreatments() {
        return this.getTreatmentProvidersForResponses(item => item.beneficial !== null && this.isNo(item.beneficial.response)
        ).concat(this.getTreatmentProgramsForResponses(item => item.beneficial !== null && this.isNo(item.beneficial.response)));
    }

    @computedFrom(
        'this.responses.treatment.initial.providers',
        'this.responses.treatment.initial.programs'
    )
    get anyUnselectedBeneficialTreatments() {
        return this.unselectedBeneficialTreatments.some(item => item);
    }

    getTreatmentProgramsForResponses(criteria) {
        if (!this.responses) { return []; }

        let data = this.responses.treatment.initial.programs
            .filter(item => criteria(item))
            .map(item => {
                return this.treatmentProgramsMap[item.value];
            });

        return data;
    }

    @computedFrom('this.responses.treatment.initial.programs')
    get unselectedPainProgram() {
        return this.getTreatmentProgramsForResponses(item => item.past !== null && this.isNo(item.past.response) && this.treatmentProgramsMap[item.value].isPainProgram).some(item => item);
    }
    
    @computedFrom('this.responses.treatment.initial.programs')
    get unselectedDriversRehabProgram() {
        return this.getTreatmentProgramsForResponses(item => item.past !== null && this.isNo(item.past.response) && this.treatmentProgramsMap[item.value].isDriversRehab).some(item => item);
    }

    @computedFrom('this.responses.treatment.initial.programs')
    get selectedPainProgram() {
        return this.getTreatmentProgramsForResponses(item => item.past !== null && this.isYes(item.past.response) && this.treatmentProgramsMap[item.value].isPainProgram).some(item => item);
    }
    
    @computedFrom('this.responses.treatment.initial.programs')
    get selectedDriversRehabProgram() {
        return this.getTreatmentProgramsForResponses(item => item.past !== null && this.isYes(item.past.response) && this.treatmentProgramsMap[item.value].isDriversRehab).some(item => item);
    }

    isFrequencyAnswered(frequency) {
        if (!frequency) { return false; }
        return this.isDontKnow(frequency.unit) ||
            (frequency.unit == 'number' && frequency.number && frequency.period) ||
            (frequency.unit == 'range' && frequency.rangeStart && frequency.rangeEnd && frequency.period);
    }


    any(items) {
        return items && items.some(item => item);
    }

    @computedFrom('responses.neuropsychological.currentState.tasks')
    get anyCurrentStateTaskResponses() {
        let any = this.responses && this.responses.neuropsychological.currentState.tasks.filter(item => item && (item.isNA || (item.ability && !this.currentStateAbilitiesMap[item.ability].isSkip))).some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.currentState.tasks'
    )
    get isCaregivingAbilityAnswered() {
        if (!this.responses) { return false; }

        let caregiving = this.responses.neuropsychological.currentState.tasks.find(item => item.value === "caregiving");
        
        return caregiving && !caregiving.isNA && this.isAnswered(caregiving.ability);
    }

    @computedFrom('responses.neuropsychological.currentState.preAccidentRecreationalActivities')
    get anyPreAccidentRecreationalActivities() {
        let any = this.responses && this.responses.neuropsychological.currentState.preAccidentRecreationalActivities.some(item => item && item.length > 0);

        return any;
    }

    @computedFrom('responses.neuropsychological.physical.pain.currentPainAreas')
    get multipleCurrentPainAreas() {
        if (!this.responses) { return false; }

        let areas = this.responses.neuropsychological.physical.pain.currentPainAreas.filter(x => x && x.length > 0);

        return areas && areas.length > 1;
    }

    @computedFrom('responses.neuropsychological.physical.other.issues')
    get anyOtherPhysicalIssues() {
        if (!this.responses || !this.responses.neuropsychological || !this.responses.neuropsychological.physical || !this.responses.neuropsychological.physical.other || !this.responses.neuropsychological.physical.other.issues) { return false; }

        let issues = this.responses.neuropsychological.physical.other.issues.filter(x => x && x.length > 0);

        return issues && issues.length > 0;
    }

    @computedFrom('responses.neuropsychological.physical.headaches.headacheDescription')
    get selectedHeadacheDescriptions() {
        if (!this.responses || !this.responses.neuropsychological.physical.headaches.headacheDescription) { return []; }

        let data = this.responses.neuropsychological.physical.headaches.headacheDescription.map(item => this.headacheDescriptionsMap[item]);

        return data;
    }

    @computedFrom('responses.neuropsychological.physical.headaches.headacheReliefActivities')
    get selectedHeadacheReliefActivities() {
        if (!this.responses || !this.responses.neuropsychological.physical.headaches.headacheReliefActivities) { return []; }

        let data = this.responses.neuropsychological.physical.headaches.headacheReliefActivities.map(item => this.headacheReliefActivitiesMap[item]);

        return data;
    }

    @computedFrom(
        'responses.personalHistory.birthPosition',
        'responses.personalHistory.brothers.ages.length',
        'responses.personalHistory.sisters.ages.length'
    )
    get birthPositionText() {
        if (!this.responses) { return ""; }

        let position = this.responses.personalHistory.birthPosition || 1;
        let siblingCount = this.responses.personalHistory.brothers.ages.length + this.responses.personalHistory.sisters.ages.length + 1;
        let siblingCountText = this.numberToWords.toWords(siblingCount);
        let positionOrdinal = this.numberToWords.toWordsOrdinal(position);

        if (siblingCount === 1) {
            return "";
        }
        else if (siblingCount === 2) {
            return `${position === 1 ? "elder" : "younger"} of the ${siblingCountText} children`;
        }
        else if (siblingCount > 2) {
            if (position === 1) { return `youngest of the ${siblingCountText} children`; }
            else if (position === siblingCount) { return `oldest of the ${siblingCountText} children`; }
            else if (siblingCount === 3 && position === 2) { return `middle child`; }
            else {
                return `${positionOrdinal} of ${siblingCountText} children`;
            }
        }
    }

    getItemValueForContext(item, context) {
        if (item) {
            return isFunction(item.format) 
                ? item.format(context)
                : isFunction(item.value)
                    ? item.value(context)
                    : item.value;
        }
        return "";
    }

    getItemValueForContextPast(item, context) {
        if (item) {
            return isFunction(item.formatPast)
                ? item.formatPast(context)
                : isFunction(item.format)
                    ? item.format(context)
                    : isFunction(item.value)
                        ? item.value(context)
                        : item.value;
        }
        return "";
    }

    getFamilyNeurologicalOrPsychiatricDiseasesTextForContext(item, context) {
        if (item) {
            let text = this.getItemValueForContext(item.value, context);

            if (item.data.familyMember) {
                text += ` (${item.data.familyMember})`;
            }
            
            return text;
        }
        return "";
    }

    getNumberText(number) {
        if (!number) { return ""; }

        return number < 10
            ? this.numberToWords.toWords(number)
            : number;
    }

    getAgeTextForContext(age, context) {
        return age && age.value && age.unit ? (context.getNumberText(age.value) + " " + age.unit) : "";
    }

    getRecreationalActivityDescriptionForContext(activity, context) {
        return activity && this.hobbiesMap[activity] ? this.hobbiesMap[activity].format(context) : activity;
    }

    getItemValue(item) {
        return item.value;
    }

    getItemDescription(item) {
        return item.description;
    }

    notSkip(item) {
        return item && !item.isSkip;
    }

    notAtypical(item) {
        return item && !item.isAtypical;
    }
}

function isFunction(f) {
    return typeof(f) === 'function';
}
