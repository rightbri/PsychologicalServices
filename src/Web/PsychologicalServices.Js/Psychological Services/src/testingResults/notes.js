import {inject} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {Context} from 'common/context';
import {DataRepository} from 'services/dataRepository';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';
import {AgeService} from 'common/ageService';
import 'number-to-words';

@inject(BindingSignaler, DataRepository, Context, Notifier, Scroller, AgeService, numberToWords)
export class Notes {

    constructor(signaler, dataRepository, context, notifier, scroller, ageService, numberToWords) {
        this.signaler = signaler;
        this.dataRepository = dataRepository;
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

        this.getItemValueForCurrentContext = function(item) {
            return this.getItemValueForContext(item, this);
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
                    this.getPronouns().then(data => this.pronouns = data),
                    this.getYesNo().then(data => {
                        this.yesNo = this.asArray(data);
                        this.yesNoMap = data;
                    }),
                    this.getYesNoDontKnow().then(data => {
                        this.yesNoDontKnow = this.asArray(data);
                        this.yesNoDontKnowMap = data;
                    }),
                    this.getYesNoNa().then(data => {
                        this.yesNoNa = this.asArray(data);
                        this.yesNoNaMap = data;
                    }),
                    this.getYesNoPartially().then(data => {
                        this.yesNoPartially = this.asArray(data);
                        this.yesNoPartiallyMap = data;
                    }),
                    this.getGenders().then(data => this.genders = data),
                    this.getSocioeconomicStatuses().then(data => this.socioeconomicStatuses = data),
                    this.getRelationshipStatuses().then(data => {
                        this.relationshipStatuses = this.asArray(data);
                        this.relationshipStatusesMap = data;
                    }),
                    this.getAgeUnits().then(data => {
                        this.ageUnits = this.asArray(data);
                        this.ageUnitsMap = data;
                    }),
                    this.getNeurologicalAndPsychiatricDiseases().then(data => {
                        this.neurologicalAndPsychiatricDiseases = this.asArray(data);
                        this.neurologicalAndPsychiatricDiseasesMap = data;
                    }),
                    this.getEmotionalIssues().then(data => this.emotionalIssues = data),
                    this.getDepressionSymptoms().then(data => this.depressionSymptoms = data),
                    this.getWorries().then(data => this.worries = data),
                    this.getStressors().then(data => {
                        this.stressors = this.asArray(data);
                        this.stressorsMap = data;
                    }),
                    this.getWhereaboutsObjects().then(data => {
                        this.whereaboutsObjects = this.asArray(data);
                        this.whereaboutsObjectsMap = data;
                    }),
                    this.getMemoryAids().then(data => {
                        this.memoryAids = this.asArray(data);
                        this.memoryAidsMap = data;
                    }),
                    this.getVisualSpatialIssues().then(data => this.visualSpatialIssues = data),
                    this.getSleepIssues().then(data => {
                        this.sleepIssues = this.asArray(data);
                        this.sleepIssuesMap = data;
                    }),
                    this.getSleepIssueCauses().then(data => {
                        this.sleepIssueCauses = this.asArray(data);
                        this.sleepIssueCausesMap = data;
                    }),
                    this.getLanguageIssues().then(data => this.languageIssues = data),
                    this.getExecutiveIssues().then(data => this.executiveIssues = data),
                    this.getInappropriateSocialBehaviors().then(data => this.inappropriateSocialBehaviors = data),
                    this.getReadingIssues().then(data => {
                        this.readingIssues = this.asArray(data);
                        this.readingIssuesMap = data;
                    }),
                    this.getWeightChangeTypes().then(data => {
                        this.weightChangeTypes = this.asArray(data);
                        this.weightChangeTypesMap = data;
                    }),
                    this.getCognitiveChangeTypes().then(data => {
                        this.cognitiveChangeTypes = this.asArray(data);
                        this.cognitiveChangeTypesMap = data;
                    }),
                    this.getMoodChangeTypes().then(data => {
                        this.moodChangeTypes = this.asArray(data);
                        this.moodChangeTypesMap = data;
                    }),
                    this.getTravelIssues().then(data => {
                        this.travelIssues = this.asArray(data);
                        this.travelIssuesMap = data;
                    }),
                    this.getTravelPreferences().then(data => {
                        this.travelPreferences = this.asArray(data);
                        this.travelPreferencesMap = data;
                    }),
                    this.getCurrentStateTasks().then(data => {
                        this.currentStateTasks = this.asArray(data);
                        this.currentStateTasksMap = data;
                    }),
                    this.getCurrentStateAbilities().then(data => {
                        this.currentStateAbilities = this.asArray(data);
                        this.currentStateAbilitiesMap = data;
                    }),
                    this.getCurrentStateIssues().then(data => {
                        this.currentStateIssues = this.asArray(data);
                        this.currentStateIssuesMap = data;
                    }),
                    this.getTravelAbilities().then(data => this.travelAbilities = data),
                    this.getTreatmentPrograms().then(data => {
                        this.treatmentPrograms = this.asArray(data);
                        this.treatmentProgramsMap = data;
                    }),
                    this.getTreatmentProviders().then(data => {
                        this.treatmentProviders = this.asArray(data);
                        this.treatmentProvidersMap = data;
                    }),
                    this.getInitialInjuriesAndSymptoms().then(data => {
                        this.initialInjuriesAndSymptoms = this.asArray(data);
                        this.initialInjuriesAndSymptomsMap = data;
                    }),
                    this.getStudentSelfRatings().then(data => {
                        this.studentSelfRatings = this.asArray(data);
                        this.studentSelfRatingsMap = data;
                    }),
                    this.getMedicalConditions().then(data => {
                        this.medicalConditions = this.asArray(data);
                        this.medicalConditionsMap = data;
                    }),
                    this.getAbusedDrugs().then(data => {
                        this.abusedDrugs = this.asArray(data);
                        this.abusedDrugsMap = data;
                    }),
                    this.getPhysicalStates().then(data => {
                        this.physicalStates = this.asArray(data);
                        this.physicalStatesMap = data;
                    }),
                    this.getPrognosis().then(data => {
                        this.prognosis = this.asArray(data);
                        this.prognosisMap = data;
                    }),
                    this.getReminderChecklistItems().then(data => {
                        this.reminderChecklistItems = this.asArray(data);
                        this.reminderChecklistItemsMap = data;
                    }),
                    this.getObservations().then(data => {
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
        this.name = null;

        this.claimant = null;
        this.changed('claimant-changed');
    }

    search(claimant, companyId) {
        this.reset();

		return this.dataRepository.searchAssessments({
			'claimantId': claimant ? claimant.claimantId : null,
			'companyId': companyId
		}).then(data => this.assessments = data);
    }
    
    select(assessment) {
        return this.dataRepository.getAssessmentTestingResults(assessment.assessmentId, 'notes').then(data => {
            this.name = data.name;
            this.assessment = data.assessment;
            this.responses = getResponses(data.responses);
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
            let responseData = getResponsesString(this.responses);

            this.dataRepository.saveAssessmentTestingResults({
                "name": this.name,
                "responses": responseData,
                "assessment": {
                    "assessmentId": this.assessment.assessmentId
                }
            }).then(data => {

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
            this.dataRepository.deleteAssessmentTestingResults(this.assessment.assessmentId, this.name).then(data => {
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
    
    getPronouns() {
        let data = [
            {
                "gender": "M",
                "subject": "he",
                "object": "him",
                "possessiveAdjective": "his",
                "possessivePronoun": "his"
            },
            {
                "gender": "F",
                "subject": "she",
                "object": "her",
                "possessiveAdjective": "her",
                "possessivePronoun": "hers"
            },
            {
                "gender": "U",
                "subject": "they",
                "object": "their",
                "possessiveAdjective": "their",
                "possessivePronoun": "theirs"
            }
        ];

        return getPromise(data);
    }

    asArray(map) {
        let a = [];

        for (let key in map) {
            a.push(map[key]);
        }

        return a;
    }

    getYesNo() {
        let data = {
            "yes": { "description": "Yes", "value": "yes", "isYes": true },
            "no": { "description": "No", "value": "no", "isNo": true },
            "skip": { "description": "Skip", "value": "skip", "isSkip": true }
        };

        return getPromise(data);
    }

    getYesNoDontKnow() {
        let data = {
            "yes": { "description": "Yes", "value": "yes", "isYes": true },
            "no": { "description": "No", "value": "no", "isNo": true },
            "dontKnow": { "description": "DK", "value": "dontKnow", "isDontKnow": true },
            "skip": { "description": "Skip", "value": "skip", "isSkip": true }
        };

        return getPromise(data);
    }

    getYesNoNa() {
        let data = {
            "yes": { "description": "Yes", "value": "yes", "isYes": true },
            "no": { "description": "No", "value": "no", "isNo": true },
            "na": { "description": "NA", "value": "notApplicable", "isNotApplicable": true },
            "skip": { "description": "Skip", "value": "skip", "isSkip": true }
        };

        return getPromise(data);
    }

    getYesNoPartially() {
        let data = {
            "yes": { "description": "Yes", "value": "yes", "isYes": true },
            "no": { "description": "No", "value": "no", "isNo": true },
            "partially": { "description": "Partially", "value": "partially", "isPartially": true },
            "skip": { "description": "Skip", "value": "skip", "isSkip": true }
        };

        return getPromise(data);
    }

    getGenders() {
        let data = [
            { "abbreviation": "M", "description": "Male", "title": "Mr." },
            { "abbreviation": "F", "description": "Female", "title": "Ms." },
            { "abbreviation": "U", "description": "Unkonwn", "title": "Mr." }
        ];

        return getPromise(data);
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

    getSocioeconomicStatuses() {
        let data = [
            { "description": "Poor", "value": "poor", "format": function(context) { return `a household that ${context.pronoun.subject} would describe as being poor`; } },
            { "description": "Lower Class", "value": "lowerClass", "format": function(context) { return `a lower-class socioeconomic household`; } },
            { "description": "Middle Class", "value": "middleClass", "format": function(context) { return `a middle-class socioeconomic household`; } },
            { "description": "Upper Class", "value": "upperClass", "format": function(context) { return `an upper-class socioeconomic household`; } },
            { "description": "Rich", "value": "rich", "format": function(context) { return `a household that ${context.pronoun.subject} would describe as being rich`; } },
            { "description": "Skip", "value": null, "format": null, "isSkip": true }
        ];

        return getPromise(data);
    }

    getRelationshipStatuses() {
        let data = {
            "single": { "description": "Single", "value": "single", "format": function(context) { return `single`; } },
            "married": { "description": "Married", "value": "married", "format": function(context) { return `married`; }, "isMarried": true },
            "commonLaw": { "description": "Common Law", "value": "commonLaw", "format": function(context) { return `in a common law relationship`; }, "isCommonLaw": true },
            "separated": { "description": "Separated", "value": "separated", "format": function(context) { return `separated`; } },
            "divorced": { "description": "Divorced", "value": "divorced", "format": function(context) { return `divorced`; } },
            "widow": { "description": "a Widow", "value": "widow", "format": function(context) { return `a widow`; } },
            "widower": { "description": "a Widower", "value": "widower", "format": function(context) { return `a widower`; } }
        };

        return getPromise(data);
    }

    getAgeUnits() {
        let data = {
            "years": { "description": "Years", "value": "years" },
            "months": { "description": "Months", "value": "months" }
        };

        return getPromise(data);
    }

    getNeurologicalAndPsychiatricDiseases() {
        let data = {
            "adhd": { "description": "ADHD/ADD", "value": "adhd", "format": function(context) { return `ADHD/ADD`; } },
            "dementia": { "description": "Alzheimer’s/Dementia", "value": "dementia", "format": function(context) { return `Alzheimer's/dementia`; } },
            "bipolar": { "description": "Bipolar", "value": "bipolar", "format": function(context) { return `bipolar disorder`; } },
            "schizophrenia": { "description": "Schizophrenia", "value": "schizophrenia", "format": function(context) { return `schizophrenia`; } },
            "depression": { "description": "Depression", "value": "depression", "format": function(context) { return `depression`; } },
            "anxiety": { "description": "Anxiety", "value": "anxiety", "format": function(context) { return `anxiety`; } },
            "epilepsy": { "description": "Epilepsy", "value": "epilepsy", "format": function(context) { return `epilepsy`; } },
            "learningDisorder": { "description": "Learning Disorder", "value": "learningDisorder", "format": function(context) { return `learning disorder`; } }
        };

        return getPromise(data);
    }

    getEmotionalIssues() {
        let data = {
            "sadness": { "description": "Sadness", "format": function(context) { return `sadness`; } },
            "overwhelmed": { "description": "Overwhelmed", "format": function(context) { return `feelings of being overwhelmed`; } },
            "hopelessness": { "description": "Hopelessness", "format": function(context) { return `hopelessness`; } },
            "depression": { "description": "Depression", "format": function(context) { return `depression`; } },
            "helplessness": { "description": "Helplessness", "format": function(context) { return `helplessness`; } },
            "labile": { "description": "Labile", "format": function(context) { return `lability`; } },
            "worthlessness": { "description": "Worthlessness", "format": function(context) { return `worthlessness`; } },
            "frustrated": { "description": "Frustrated", "format": function(context) { return `frustration`; } },
            "guilt": { "description": "Guilt", "format": function(context) { return `guilt`; } },
            "withdrawn": { "description": "Withdrawn", "format": function(context) { return `withdrawal`; } },
            "dependency": { "description": "Dependency", "format": function(context) { return `dependency`; } },
            "irritable": { "description": "Irritable", "format": function(context) { return `irritability`; } },
            "lessIndependent": { "description": "Less independent", "format": function(context) { return `feelings of being less independent`; } },
            "cryEasily": { "description": "Cry Easily", "isCriesEasily": true },
            "anhedonia": { "description": "Anhedonia", "format": function(context) { return `anhedonia`; } },
            "burden": { "description": "Burden", "format": function(context) { return `feelings of being a burden on others`; } },
            "apathy": { "description": "Apathy", "format": function(context) { return `apathy`; } },
            "amotivation": { "description": "Amotivation", "format": function(context) { return `lack of motivation`; } }
        };

        return getPromise(data);
    }

    getDepressionSymptoms() {
        let data = {
            "more irritable": { "description": "More irritable?", "format": function(context) { return `more irritable`; } },
            "easily upset": { "description": "Easily upset?", "format": function(context) { return `less tolerant`; } },
            "less tolerant": { "description": "Less tolerant?", "format": function(context) { return `easily upset`; } },
            "less patient": { "description": "Less patient?", "format": function(context) { return `less patient`; } }
        };

        return getPromise(data);
    }

    getWorries() {
        let data = {
            "future": { "description": "Future", "format": function(context) { return `future`; } },
            "recovery": { "description": "Recovery", "format": function(context) { return `recovery`; } },
            "finances": { "description": "Finances", "format": function(context) { return `finances`; }, "isFinances": true }
        };

        return getPromise(data);
    }

    getStressors() {
        let data = {
            "relationshipBreakup": { "description": "Breakup of Relationship(s)", "format": function(context) { return `a breakup in a relationship`; } },
            "deathInFamily": { "description": "Death(s) in the family", "format": function(context) { return `a death in the family`; } },
            "legalIssues": { "description": "Legal Issues/Arrests", "format": function(context) { return `legal issues/arrests`; } },
            "lossOfEmployment": { "description": "Loss of Employment", "format": function(context) { return `loss of employment`; } },
            "majorIllness": { "description": "Major Illness", "format": function(context) { return `major illness`; } },
            "majorFinancialProblems": { "description": "Major Financial Problems", "format": function(context) { return `major financial problems`; } },
            "otherAccidents": { "description": "OTHER accidents/injuries", "format": function(context) { return `another accident or injury`; } }
        };

        return getPromise(data);
    }

    getWhereaboutsObjects() {
        let data = {
            "bank card": { "description": "Bank card", "value": "bank card", "format": function(context) { return `bank card`; } },
            "eye glasses": { "description": "Eye Glasses", "value": "eye glasses", "format": function(context) { return `eye glasses`; } },
            "iPad/tablet": { "description": "iPad/tablet", "value": "iPad/tablet", "format": function(context) { return `iPad/tablet`; } },
            "keys": { "description": "Keys", "value": "keys", "format": function(context) { return `keys`; } },
            "paperwork": { "description": "Paperwork", "value": "paperwork", "format": function(context) { return `paperwork`; } },
            "phone": { "description": "Phone", "value": "phone", "format": function(context) { return `phone`; } },
            "wallet": { "description": "Wallet", "value": "wallet", "format": function(context) { return `wallet`; } },
            "beverage": { "description": "Beverage", "value": "beverage", "format": function(context) { return `beverage`; } }
        };

        return getPromise(data);
    }

    getMemoryAids() {
        let data = {
            "alarms": { "description": "Alarms", "value": "alarms", "format": function(context) { return `alarms`; } },
            "calendar": { "description": "Calendar", "value": "calendar", "format": function(context) { return `calendar`; } },
            "lists": { "description": "List", "value": "lists", "format": function(context) { return `lists`; } },
            "notes": { "description": "Notes", "value": "notes", "format": function(context) { return `notes`; } },
            "phone": { "description": "Phone", "value": "phone", "format": function(context) { return `phone`; } },
            "reminders": { "description": "Reminders", "value": "reminders", "format": function(context) { return `reminders`; } },
            "schedules": { "description": "Schedules", "value": "schedules", "format": function(context) { return `schedules`; } },
            "whiteboard": { "description": "Whiteboard", "value": "whiteboard", "format": function(context) { return `whiteboard`; } }
        };

        return getPromise(data);
    }

    getVisualSpatialIssues() {
        let data = {
            "balanceIssues": { "description": "Balance Issues", "format": function(context) { return `balance issues`; } },
            "weaknessInHands": { "description": "Weakness in hands", "format": function(context) { return `weakness in ${context.pronoun.possessiveAdjective} hands`; } },
            "dizzinessIssues": { "description": "Dizziness issues", "format": function(context) { return `dizziness`; } },
            "tinnitus": { "description": "Tinnitus", "format": function(context) { return `tinnitus`; } },
            "changeInTaste": { "description": "Change in sense of taste", "format": function(context) { return `change in ${context.pronoun.possessiveAdjective} sense of taste`; } },
            "changeInSmell": { "description": "Change in sense of smell", "format": function(context) { return `change in ${context.pronoun.possessiveAdjective} sense of smell`; } },
            "itchyFingernails": { "description": "Itchy fingernails", "format": function(context) { return `itchy fingernails (atypical symptomology)`; }, "isAtypical": true },
            "seizures": { "description": "Seizures", "format": function(context) { return `seizures`; } },
            "fainting": { "description": "Fainting", "format": function(context) { return `fainting`; } },
            "lightSensitivity": { "description": "Light Sensitivity", "format": function(context) { return `sensitivity to light`; } },
            "noiseSensitivity": { "description": "Noise sensitivity", "format": function(context) { return `sensitivity to noise`; } },
            "blurryVision": { "description": "Blurry vision", "format": function(context) { return `blurry vision`; } },
            "doubleVision": { "description": "Double vision", "format": function(context) { return `double vision`; } },
            "blackAndWhiteTransientVision": { "description": "Black/white transient vision", "format": function(context) { return `black and white transient vision (atypical symptomology)`; }, "isAtypical": true }
        };

        return getPromise(data);
    }

    getSleepIssues() {
        let data = {
            "attaining": { "description": "Do you have issues attaining sleep?", "format": function(context) { return `attain`; } },
            "sustaining": { "description": "Do you have issues sustaining sleep?", "format": function(context) { return `sustain`; } },
            "regaining": { "description": "Do you have issues regaining sleep?", "format": function(context) { return `regain`; } }
        };

        return getPromise(data);
    }

    getSleepIssueCauses() {
        let data = {
            "pain": { "description": "Pain", "value": "pain", "format": function(context) { return `pain`; } },
            "nightmares": { "description": "Nightmares", "value": "nightmares", "format": function(context) { return `nightmares`; } },
            "thinking": { "description": "Thinking", "value": "thinking", "format": function(context) { return `thinking`; } }
        };
        
        return getPromise(data);
    }

    getLanguageIssues() {
        let data = {
            "lostInConversations": { "description": "Easily lost in conversations?", "format": function(context) { return `feeling lost in conversations`; } },
            "tipOfTongueIssues": { "description": "Tip of the Tongue issues?", "format": function(context) { return `having tip of tongue issues`; } },
            "repeatingYourself": { "description": "Repeating yourself?", "format": function(context) { return `times where ${context.pronoun.subject} repeats ${context.pronoun.object}self`; } },
            "askingOthersToRepeat": { "description": "Asking others to repeat?", "format": function(context) { return `times when ${context.pronoun.subject} asks others to repeat what they have said`; } },
            "filtering": { "description": "Filtering?", "format": function(context) { return `problems with filtering`; } },
            "wordSubstitution": { "description": "Word substitution?", "format": function(context) { return `times where ${context.pronoun.subject} tends to substitute words`; } }
        };

        return getPromise(data);
    }

    getExecutiveIssues() {
        let data = {
            "multiTasking": {
                "description": "Multi-tasking",
                "format": function(context) { return `multi-task${context.harderToMultiTask ? ` (which ${context.pronoun.subject} now finds harder)` : ``}`; }
            },
            "harderToMultiTask": { "description": "    Do you find it harder to multitask since the accident?", "format": function(context) { return ``; }, "isHarderToMultiTask": true, "noOutput": true },
            "organization": { "description": "Organization", "format": function(context) { return `organize`; } },
            "planning": { "description": "Planning", "format": function(context) { return `plan`; } },
            "decisionMaking": { "description": "Decision Making", "format": function(context) { return `make decisions`; } },
            "problemSolving": { "description": "Problem Solving", "format": function(context) { return `problem solve`; } }
        };

        return getPromise(data);
    }

    getInappropriateSocialBehaviors() {
        let data = {
            "inappropriateSocialBehaviorYellingSwearing": { "description": "Yelling/Swearing in public", "value": "yelling or swearing in public" },
            "inappropriateSocialBehaviorViolence": { "description": "Violence", "value": "violence" },
            "inappropriateSocialBehaviorSexual": { "description": "Sexually Inappropriate", "value": "sexually inappropriate behaviour" }
        };

        return getPromise(data);
    }

    getReadingIssues() {
        let data = {
            "headaches": { "description": "Headaches", "value": "headaches", "format": function(context) { return `headaches`; } },
            "visual issues": { "description": "Vision Issues", "value": "visual issues", "format": function(context) { return `visual issues`; } },
            "ability to focus": { "description": "Focus", "value": "ability to focus", "format": function(context) { return `ability to focus`; } }
        };
        
        return getPromise(data);
    }

    getWeightChangeTypes() {
        let data = {
            "don't know": { "description": "Don't know", "value": "don't know", "format": function(context) { return `${context.pronoun.subject} does not know how much ${context.pronoun.possessiveAdjective} weight has changed`; } },
            "increased": { "description": "Increased", "value": "increased", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has changed, noting an increase of `; }, "isIncreaseOrDecrease": true },
            "decreased": { "description": "Decreased", "value": "decreased", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has changed, noting a decrease of `; }, "isIncreaseOrDecrease": true },
            "fluctuated": { "description": "Fluctuated", "value": "fluctuated", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has fluctuated`; } }
        };

        return getPromise(data);
    }

    getCognitiveChangeTypes() {
        let data = {
            "worse": { "description": "Worse", "value": "worse", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} cognition is worse`; } },
            "little improvement": { "description": "Little improvement", "value": "little improvement", "format": function(context) { return `overall ${context.pronoun.subject} has seen little improvement`; } },
            "same": { "description": "Same", "value": "same", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} cognition is the same`; } },
            "better": { "description": "Better", "value": "better", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} cognitive state is better`; } },
            "resolved": { "description": "Resolved", "value": "resolved", "format": function(context) { return `${context.pronoun.subject} feels that any cognitive issues have resolved`; } },
            "plateaued": { "description": "Plateaued", "value": "plateaued", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} cognitive recovery has reached a plateau`; } },
            "skip": { "description": "Skip", "value": "skip", "format": function(context) { return ``; }, "isSkip": true }
        };

        return getPromise(data);
    }

    getMoodChangeTypes() {
        let data = {
            "worse": { "description": "Worse", "value": "worse", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} mood is worse`; } },
            "little improvement": { "description": "Little improvement", "value": "little improvement", "format": function(context) { return `overall ${context.pronoun.subject} has seen little improvement`; } },
            "same": { "description": "Same", "value": "same", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} mood is the same`; } },
            "better": { "description": "Better", "value": "better", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} mood is better`; } },
            "resolved": { "description": "Resolved", "value": "resolved", "format": function(context) { return `${context.pronoun.subject} feels that any mood issues have resolved`; } },
            "plateaued": { "description": "Plateaued", "value": "plateaued", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} emotional recovery has reached a plateau`; } },
            "skip": { "description": "Skip", "value": "skip", "format": function(context) { return ``; }, "isSkip": true }
        };

        return getPromise(data);
    }

    getTravelIssues() {
        let data = {
            "physical issues": { "description": "Physical", "value": "physical issues" },
            "mental health issues": { "description": "Mental", "value": "mental health issues" },
            "cognitive state": { "description": "Cognitive", "value": "cognitive state" }
        };

        return getPromise(data);
    }

    getTravelPreferences() {
        let data = {
            "driver": { "description": "Driver", "value": "driver", "format": function(context) { return `driver`; } },
            "passenger": { "description": "Passenger", "value": "passenger", "format": function(context) { return `passenger`; } },
            "pedestrian": { "description": "Pedestrian", "value": "pedestrian", "format": function(context) { return `pedestrian`; } },
            "skip": { "description": "Skip", "value": "skip", "isSkip": true, "format": function(context) { return ``; } }
        };
        
        return getPromise(data);
    }

    getCurrentStateTasks() {
        let data = {
            "personalCare": { "description": "Personal care", "value": "personalCare" },
            "housekeeping": { "description": "Housekeeping", "value": "housekeeping" },
            "outdoorChores": { "description": "Outdoor Tasks", "value": "outdoorChores" },
            "watchingTv": { "description": "Watching TV", "value": "watchingTv" },
            "banking": { "description": "Banking", "value": "banking" },
            "caregiving": { "description": "Caregiving", "value": "caregiving" },
            "alone": { "description": "Being Left alone", "value": "alone" }
        };

        return getPromise(data);
    }

    getCurrentStateAbilities() {
        let data = {
            "unable": { "description": "Unable", "value": "unable", format: function(context) { return `Unable`; }, "isUnable": true },
            "partiallyAble": { "description": "Partial", "value": "partiallyAble", format: function(context) { return `Partially Able`; }, "isPartiallyAble": true },
            "able": { "description": "Able", "value": "able", format: function(context) { return `Able`; }, "isAble": true },
            "skip": { "description": "Skip", "value": "skip", format: function(context) { return ``; }, "isSkip": true }
        };

        return getPromise(data);
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

    getCurrentStateIssues() {
        let data = {
            "physical": { "description": "Physical", "value": "physical", "sort": 1, "format": function(context) { return `Physical issues`; } },
            "pain": { "description": "Pain", "value": "pain", "sort": 2, "format": function(context) { return `Pain`; } },
            "apathy": { "description": "Apathy", "value": "apathy", "sort": 3, "format": function(context) { return `Apathy`; } },
            "mental": { "description": "Mental", "value": "mental", "sort": 4, "format": function(context) { return `Mental health issues`; } },
            "cognitive": { "description": "Cognitive", "value": "cognitive", "sort": 5, "format": function(context) { return `Cognition`; } }
        };

        return getPromise(data);
    }

    getTravelAbilities() {
        let data = [
            { "description": "Unable", "value": "unable", "isUnable": true },
            { "description": "Partial", "value": "only partially able", "isPartiallyAble": true },
            { "description": "Able", "value": "able", "isAble": true },
            { "description": "Skip", "value": null }
        ];

        return getPromise(data);
    }

    getTreatmentProviders() {
        let data = {
            "physiotherapist": { "description": "Physiotherapist", "value": "physiotherapist", "format": function(context) { return `Physiotherapist`; } },
            "chiropractor": { "description": "Chiropractor", "value": "chiropractor", "format": function(context) { return `Chiropractor`; } },
            "massageTherapist": { "description": "Massage Therapist", "value": "massageTherapist", "format": function(context) { return `Massage Therapist`; } },
            "acupuncturist": { "description": "Acupuncturist", "value": "acupuncturist", "format": function(context) { return `Acupuncturist`; } },
            "osteopathicProvider": { "description": "Osteopathic Provider", "value": "osteopathicProvider", "format": function(context) { return `Osteopathic Provider`; } },
            "naturopathicProvider": { "description": "Naturopathic Provider", "value": "naturopathicProvider", "format": function(context) { return `Naturopathic Provider`; } },
            "occupationalTherapist": { "description": "Occupational Therapist", "value": "occupationalTherapist", "format": function(context) { return `Occupational Therapist`; } },
            "rehabilitationWorker": { "description": "Rehabilitation Worker", "value": "rehabilitationWorker", "format": function(context) { return `Rehabilitation Worker`; } },
            "supportWorker": { "description": "Support Worker", "value": "supportWorker", "format": function(context) { return `Support Worker`; } },
            "speechLanguagePathologist": { "description": "Speech Language Pathologist", "value": "speechLanguagePathologist", "format": function(context) { return `Speech Language Pathologist`; } },
            "caseManager": { "description": "Case Manager", "value": "caseManager", "format": function(context) { return `Case Manager`; } }
        };

        return getPromise(data);
    }

    getTreatmentPrograms() {
        let data = {
            "painProgram": { "description": "Pain Program", "past": null, "current": null, "beneficial": null, "value": "painProgram", "format": function(context) { return `Pain Program`; }, "isPainProgram": true },
            "driversRehab": { "description": "Driver's Rehab", "past": null, "current": null, "beneficial": null, "value": "driversRehab", "format": function(context) { return `Driver's Rehab`; }, "isDriversRehab": true }
        };

        return getPromise(data);
    }

    getInitialInjuriesAndSymptoms() {
        let data = {
            "fractures": { "description": "Fractures", "value": "fractures", "format": function(context) { return `Fractures` } },
            "sti": { "description": "STI", "value": "sti", "format": function(context) { return `STI` } },
            "back": { "description": "Back", "value": "back", "format": function(context) { return `Back` } },
            "neck": { "description": "Neck", "value": "neck", "format": function(context) { return `Neck` } },
            "shoulder": { "description": "Shoulder", "value": "shoulder", "format": function(context) { return `Shoulder` } },
            "lacerations": { "description": "Lacerations", "value": "lacerations", "format": function(context) { return `Lacerations` } },
            "headaches": { "description": "Headaches", "value": "headaches", "format": function(context) { return `Headaches` } },
            "dizziness": { "description": "Dizziness", "value": "dizziness", "format": function(context) { return `Dizziness` } },
            "nausea": { "description": "Nausea", "value": "nausea", "format": function(context) { return `Nausea` } },
            "vomiting": { "description": "Vomiting", "value": "vomiting", "format": function(context) { return `Vomiting` } },
            "tinnitus": { "description": "Tinnitus", "value": "tinnitus", "format": function(context) { return `Tinnitus` } },
            "skip": { "description": "", "value": "skip" }
        };

        return getPromise(data);
    }

    getStudentSelfRatings() {
        let data = {
            "good": { "description": "Good", "value": "good", "format": function(context) { return `Good`; } },
            "average": { "description": "Average", "value": "average", "format": function(context) { return `Average`; } },
            "poor": { "description": "Poor", "value": "poor", "format": function(context) { return `Poor`; } },
            "excellent": { "description": "Excellent", "value": "excellent", "format": function(context) { return `Excellent`; } }
        };

        return getPromise(data);
    }

    getMedicalConditions() {
        let data = {
            "alchoholAbuse": { "description": "Alchohol Abuse", "value": "alchoholAbuse", "format": function(context) { return `Alchohol Abuse`; } },
            "cancer": { "description": "Cancer", "value": "cancer", "format": function(context) { return `Cancer`; } },
            "cholesterol": { "description": "Cholesterol", "value": "cholesterol", "format": function(context) { return `Cholesterol`; } },
            "diabetes": { "description": "Diabetes", "value": "diabetes", "format": function(context) { return `Diabetes`; } },
            "fibromyalgia": { "description": "Fibromyalgia", "value": "fibromyalgia", "format": function(context) { return `Fibromyalgia`; } },
            "heartDisease": { "description": "Heart Disease", "value": "heartDisease", "format": function(context) { return `Heart Disease`; } },
            "hypertension": { "description": "Hypertension", "value": "hypertension", "format": function(context) { return `Hypertension`; } },
            "stroke": { "description": "Stroke", "value": "stroke", "format": function(context) { return `Stroke`; } },
            "thyroidDisorder": { "description": "Thyroid Disorder", "value": "thyroidDisorder", "format": function(context) { return `Thyroid Disorder`; } },
            "other": { "description": "Other", "value": "other", "format": function(context) { return `Other`; } }
        };

        return getPromise(data);
    }

    getAbusedDrugs() {
        let data = {
            "alchohol": { "description": "Alchohol", "value": "alchohol", "format": function(context) { return `Alchohol`; } },
            "tobacco": { "description": "Tobacco", "value": "tobacco", "format": function(context) { return `Tobacco`; } },
            "thc": { "description": "THC", "value": "thc", "format": function(context) { return `THC`; } },
            "streetDrugs": { "description": "Street drugs", "value": "streetDrugs", "format": function(context) { return `Street drugs`; } },
            "prescriptionMeds": { "description": "Prescription medication that was not prescribed to you", "value": "prescriptionMeds", "format": function(context) { return `Prescription medication that was not prescribed to you`; } }
        };

        return getPromise(data);
    }

    getPhysicalStates() {
        let data = {
            "excellent": { "description": "Excellent", "value": "excellent", "format": function(context) { return `Excellent`; } },
            "good": { "description": "Good", "value": "good", "format": function(context) { return `Good`; } },
            "fair": { "description": "Fair", "value": "fair", "format": function(context) { return `Fair`; } },
            "stable": { "description": "Stable", "value": "stable", "format": function(context) { return `Stable`; } },
            "poor": { "description": "Poor", "value": "poor", "format": function(context) { return `Poor`; } }
        };

        return getPromise(data);
    }

    getPrognosis() {
        let data = {
            "good": { "description": "Good", "value": "good", "format": function(context) { return `Good`; } },
            "fair": { "description": "Fair", "value": "fair", "format": function(context) { return `Fair`; } },
            "poor": { "description": "Poor", "value": "poor", "format": function(context) { return `Poor`; } },
            "chronic": { "description": "Chronic", "value": "chronic", "format": function(context) { return `Chronic`; } },
            "plateaued": { "description": "Plateaued", "value": "plateaued", "format": function(context) { return `Plateaued`; } },
            "dontKnow": { "description": "DK", "value": "dontKnow", "format": function(context) { return `Don't know`; } }
        };

        return getPromise(data);
    }

    getReminderChecklistItems() {
        let data = {
            "introducedSelf": { "description": " 1. Did I introduce myself?", "value": "introducedSelf" },
            "explainedRole": { "description": " 2. Did I explain my role in the assessment process?", "value": "explainedRole" },
            "usedClaimantName": { "description": " 3. Did I refer to the claimant by the name?", "value": "usedClaimantName" },
            "explainedPurpose": { "description": " 4. Did I explain the purpose of the assessment?", "value": "explainedPurpose" },
            "reviewedFile": { "description": " 5. Did I review the medical file before the assessment so I knew what areas to ask about and what testing would be reasonable?", "order": 5, "value": "reviewedFile" },
            "actedProfessionally": { "description": " 6. Did I act in a professional manner?", "value": "actedProfessionally" },
            "thoroughQuestions": { "description": " 7. Was I thorough with what questions I was asking?", "value": "thoroughQuestions" },
            "privateRoom": { "description": " 8. Did I make sure that the room was private?", "value": "privateRoom" },
            "accommodationForm": { "description": " 9. Was the accommodation form completed by them?", "value": "accommodationForm" },
            "claimantNotWaiting": { "description": "10. Did I strive to make sure that the claimant was not waiting on me?", "value": "claimantNotWaiting" },
            "businessCard": { "description": "11. Did I provide them with a business card if they wanted to contact me with additional information after the assessment?", "value": "businessCard" }
        };

        return getPromise(data);
    }

    getObservations() {
        let data = {
            "claimantFriendly": { "description": "1.	Overall, was the claimant friendly and pleasant?", "value": "claimantFriendly" },
            "claimantBathedRecently": { "description": "2.	Did it appear that the claimant had bathed recently?", "value": "claimantBathedRecently" },
            "claimantAppropriateClothing": { "description": "3.	Was the claimant’s clothing appropriate for age/weather?", "value": "claimantAppropriateClothing" },
            "claimantAbleToWrite": { "description": "4.	Was the claimant able to use a pen/pencil to complete questionnaires/testing?", "value": "claimantAbleToWrite" },
            "claimantAnswersOrganized": { "description": "5.	Were the claimant’s answers well thought out/organized?", "value": "claimantAnswersOrganized" },
            "claimantAbleToRemainSeated": { "description": "6.	Was the claimant able to remain seated during the interview without taking a break or getting up to stretch?", "value": "claimantAbleToRemainSeated" },
            "neededToRepeatQuestionsOrAnswers": { "description": "7.	Did I have to repeat the questions or choices for answers?", "value": "neededToRepeatQuestionsOrAnswers" },
            "claimantWordFindingOrStuttering": { "description": "8.	Did I notice any issues with word finding/stuttering? (N/A if translator)", "value": "claimantWordFindingOrStuttering", "isNaAllowed": true },
            "claimantIssuesRecallingPreviousState": { "description": "9.	Did the claimant having any issues recalling their previous state? (i.e. Education/work/health)", "value": "claimantIssuesRecallingPreviousState" },
            "claimantIssuesRecallingIncident": { "description": "10.	Did the claimant have any issues recalling the specific details of the incident?", "value": "claimantIssuesRecallingIncident" },
            "claimantIssuesRecallingTreatment": { "description": "11.	Did the claimant have any issues recalling their post-incident treatment?", "value": "claimantIssuesRecallingTreatment" },
            "claimantCriedWhenDiscussingIncident": { "description": "12.	During the interview did the claimant tear up when discussing the incident?", "value": "claimantCriedWhenDiscussingIncident" },
            "claimantCriedWhenDiscussingLifeChanges": { "description": "13.	During the interview did the claimant tear up when discussing any changes in their life?", "value": "claimantCriedWhenDiscussingLifeChanges" },
            "claimantIssuesWithExecutiveFunctioning": { "description": "14.	Were any issues with executive functioning noted during the interview?", "value": "claimantIssuesWithExecutiveFunctioning" }
        };

        return getPromise(data);
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
    get anySelectedNeurologicalOrPsychiatricDiagnosis() {
        return this.selectedNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anyUnselectedNeurologicalOrPsychiatricDiagnosis() {
        return this.unselectedNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get selectedFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.getNeurologicalOrPsychiatricDiagnosisForResponses(item => item.family !== null && this.isYes(item.family));
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get unselectedFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.getNeurologicalOrPsychiatricDiagnosisForResponses(item => item.family !== null && this.isNo(item.family));
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anySelectedFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.selectedFamilyNeurologicalOrPsychiatricDiagnosis.some(item => item);
    }

    @computedFrom('this.responses.personalHistory.neurologicalOrPsychiatricDiseases')
    get anyUnselectedFamilyNeurologicalOrPsychiatricDiagnosis() {
        return this.unselectedFamilyNeurologicalOrPsychiatricDiagnosis.some(item => item);
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

    @computedFrom('responses.psychological.worry')
    get worriesAboutFinances() {
        return this.yesWorries.some(item => item.isFinances);
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
    get unselectedPastTreatmentPrograms() {
        return this.getTreatmentProgramsForResponses(item => item.past !== null && this.isNo(item.past.response));
    }

    @computedFrom('this.responses.treatment.initial.programs')
    get anyUnselectedPastTreatmentPrograms() {
        return this.unselectedPastTreatmentPrograms.some(item => item);
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

    getNumberText(number) {
        if (!number) { return ""; }

        return number < 10
            ? this.numberToWords.toWords(number)
            : number;
    }

    getAgeTextForContext(age, context) {
        return age && age.value && age.unit ? (context.getNumberText(age.value) + " " + age.unit) : "";
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

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}

function isFunction(f) {
    return typeof(f) === 'function';
}

function replacer(key, value) {  
    // if we get a function give us the code for that function  
    if (typeof value === 'function') {
        return value.toString();  
    }   
    return value;
}

function reviver(key, value) {
    if (typeof value === 'string' && value.indexOf('function ') === 0) {
        let functionTemplate = `(${value})`;
        return eval(functionTemplate);
    }
    return value;
}

function getResponsesString(responses) {
    return JSON.stringify(responses, replacer, 0);
}

function getResponses(responsesData) {
    let responses = responsesData ? JSON.parse(responsesData, reviver) : getNewResponses();

    return upgrade(responses, getCurrentVersion());
}

function getCurrentVersion() {
    return "15";
}

function upgrade(responses, toVersion) {
    let current = parseInt(responses.version || "1", 10);
    let target = parseInt(toVersion, 10);

    let upgradedResponses = responses;

    for (let i = current + 1; i <= target; i++) {
        upgradedResponses = upgradeIfApplicable(upgradedResponses, i - 1, i);
    }

    return upgradedResponses;
}

function upgradeIfApplicable(responses, fromVersion, toVersion) {
    let functionName = "upgrade_" + fromVersion + "_to_" + toVersion;

    if (isFunction(eval(functionName))) {
        return eval(functionName)(responses);
    }

    return responses;
}

function upgrade_8_to_9(responses) {

    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('issues')) {
        responses.neuropsychological.physical.sleep.issues = [
            { "response": null, "value": "attaining" },
            { "response": null, "value": "sustaining" },
            { "response": null, "value": "regaining" }
        ];
    }
    
    responses.version = "9";

    return responses;
}

function upgrade_9_to_10(responses) {

    responses.personalHistory.neurologicalOrPsychiatricDiseases.splice(3, 0, { "self": null, "family": null, "value": "schizophrenia" });

    responses.personalHistory.neurologicalOrPsychiatricDiseases.splice(5, 0, { "self": null, "family": null, "value": "anxiety" });
    
    responses.version = "10";

    return responses;
}

function upgrade_10_to_11(responses) {

    let currentStateTasks = [ "personalCare", "housekeeping", "outdoorChores", "watchingTv", "banking", "caregiving", "alone" ];

    responses.neuropsychological.currentState.tasks = responses.neuropsychological.currentState.tasks.filter(t => currentStateTasks.findIndex(x => x === t.value) > -1);

    let index = responses.neuropsychological.currentState.tasks.findIndex(item => item.value === "housekeeping");
    if (index === -1) {
        responses.neuropsychological.currentState.tasks.splice(1, 0, { "ability": null, "issues": [], "isNA": false, "value": "housekeeping" });
    }

    if (!responses.psychological.travel.hasOwnProperty("nervousPedestrian")) {
        responses.psychological.travel.nervousPedestrian = null;
    }
    
    if (!responses.psychological.travel.hasOwnProperty("anxiousPedestrian")) {
        responses.psychological.travel.anxiousPedestrian = null;
    }
    
    if (!responses.neuropsychological.physical.pain.hasOwnProperty("currentPainAreas")) {
        responses.neuropsychological.physical.pain.currentPainAreas = [responses.neuropsychological.physical.pain.currentPainArea];

        delete responses.neuropsychological.physical.pain.currentPainArea;
    }

    responses.version = "11";

    return responses;
}

function upgrade_11_to_12(responses) {
    let newResponses = getNewResponses();

    if (!responses.hasOwnProperty('treatment')) {
        responses.treatment = newResponses.treatment;
    }

    responses.version = "12";

    return responses;
}

function upgrade_12_to_13(responses) {
    let newResponses = getNewResponses();

    if (!responses.hasOwnProperty('identification')) {
        responses.identification = newResponses.identification;
    }

    if (!responses.hasOwnProperty('dayOfAssessment')) {
        responses.dayOfAssessment = newResponses.dayOfAssessment;
    }

    if (!responses.hasOwnProperty('accidentDetails')) {
        responses.accidentDetails = newResponses.accidentDetails;
    }

    if (!responses.hasOwnProperty('reminderChecklist')) {
        responses.reminderChecklist = newResponses.reminderChecklist;
    }

    if (!responses.hasOwnProperty('observations')) {
        responses.observations = newResponses.observations;
    }

    let personalHistoryProperties = [
        "education",
        "occupation",
        "financial",
        "medical",
        "legal",
        "psychological",
        "diagnosis",
        "prognosis",
        "impaired",
        "disabled",
        "additionalInformation"
    ];

    for (let i = 0; i < personalHistoryProperties.length; i++) {
        if (!responses.personalHistory.hasOwnProperty(personalHistoryProperties[i])) {
            responses.personalHistory[personalHistoryProperties[i]] = newResponses.personalHistory[personalHistoryProperties[i]];
        }
    }

    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('issueCauses')) {
        responses.neuropsychological.physical.sleep.issueCauses = newResponses.neuropsychological.physical.sleep.issueCauses;
    }
    
    responses.version = "13";

    return responses;
}

function upgrade_13_to_14(responses) {
    let newResponses = getNewResponses();

    if (!responses.identification.hasOwnProperty('assistance')) {
        responses.identification.assistance = newResponses.identification.assistance;
    }

    responses.version = "14";

    return responses;
}

function upgrade_14_to_15(responses) {
    let newResponses = getNewResponses();

    if (!responses.personalHistory.father.hasOwnProperty('age')) {
        responses.personalHistory.father.age = newResponses.personalHistory.father.age;

        if (responses.personalHistory.father.hasOwnProperty('yearOfBirth')) {
            responses.personalHistory.father.age.value = responses.personalHistory.father.yearOfBirth;
        }
    }
    else if (typeof responses.personalHistory.father.age === "string") {
        let tempAge = responses.personalHistory.father.age;
        responses.personalHistory.father.age = newResponses.personalHistory.father.age;
        responses.personalHistory.father.age.value = tempAge;
    }

    if (!responses.personalHistory.mother.hasOwnProperty('age')) {
        responses.personalHistory.mother.age = newResponses.personalHistory.mother.age;

        if (responses.personalHistory.mother.hasOwnProperty('yearOfBirth')) {
            responses.personalHistory.mother.age.value = responses.personalHistory.mother.yearOfBirth;
        }
    }
    else if (typeof responses.personalHistory.mother.age === "string") {
        let tempAge = responses.personalHistory.mother.age;
        responses.personalHistory.mother.age = newResponses.personalHistory.mother.age;
        responses.personalHistory.mother.age.value = tempAge;
    }

    responses.version = "15";

    return responses;
}

function getNewResponses() {
    return {
        "version": getCurrentVersion(),
        "identification": {
            "verificationMethod": {
                "method": null,
                "otherMethod": ""
            },
            "assistance": {
                "wearsGlasses": null,
                "devices": null,
                "personnel": null
            }
        },
        "dayOfAssessment": {
            "wasDriven": null,
            "droveSelf": null,
            "travelTime": {
                "minutes": "",
                "hours": ""
            },
            "priorNightSleepDescription": "",
            "medications": [
                { "name": "", "purpose": "", "whenStarted": "" }
            ],
            "takenMedicationBeforeAssessment": null
        },
        "accidentDetails": {
            "dateOfAccident": null,
            "role": null,
            "category": null,
            "secondaryImpact": null,
            "airbagsDeployed": null,
            "vehicleRolled": null,
            "additionalAccidentDetails": "",
            "hitHead": null,
            "hitHeadOn": null,
            "hitHeadOnOther": "",
            "thrownInsideVehicle": null,
            "injuriesAndSymptoms": [
                { "response": null, "value": "fractures" },
                { "response": null, "value": "lacerations" },
                { "response": null, "value": "sti" },
                { "response": null, "value": "headaches" },
                { "response": null, "value": "back" },
                { "response": null, "value": "dizziness" },
                { "response": null, "value": "neck" },
                { "response": null, "value": "nausea" },
                { "response": null, "value": "shoulder" },
                { "response": null, "value": "vomiting" },
                { "response": null, "value": "skip", "skip": true },
                { "response": null, "value": "tinnitus" }
            ],
            "otherInjuriesAndSymptoms": [""],
            "hadSurgeriesForInjuries": null,
            "wasDazed": null,
            "lossOfConsciousness": {
                "experienced": null,
                "length": {
                    "dontKnow": null,
                    "seconds": "",
                    "minutes": "",
                    "hours": "",
                    "days": "",
                    "weeks": ""
                }
            },
            "lossOfTime": null,
            "postTraumaticAmnesia": {
                "experienced": null,
                "length": {
                    "dontKnow": null,
                    "seconds": "",
                    "minutes": "",
                    "hours": "",
                    "days": "",
                    "weeks": ""
                }
            },
            "lastMemoryBeforeImpact": "",
            "firstMemoryAfterImpact": "",
            "feltCouldHaveDied": null,
            "assessedByAmbulancePersonnel": null,
            "wentToHospital": null,
            "hospitalStayLength": {
                "hours": "",
                "days": "",
                "weeks": "",
                "months": ""
            },
            "haveFamilyDoctor": null,
            "familyDoctorName": "",
            "familyDoctorHowLong": "",
            "sawFamilyDoctorSinceAccident": null,
            "psychologicalTreatmentRecommended": null,
            "hadBrainImagingInvestigations": null,
            "brainImagingInvestigationFindingsNormal": null,
            "examinations": {
                "psychological": {
                    "completed": null,
                    "completions": [
                        { "withWhom": "", "when": "" },
                        { "withWhom": "", "when": "" }
                    ]
                },
                "psychiatric": {
                    "completed": null,
                    "completions": [
                        { "withWhom": "", "when": "" },
                        { "withWhom": "", "when": "" }
                    ]
                },
                "npNc": {
                    "completed": null,
                    "completions": [
                        { "withWhom": "", "when": "" },
                        { "withWhom": "", "when": "" }
                    ]
                }
            },
            "attendedTbiAbiProgram": null,
            "startedCounselling": null,
            "startedCounsellingMonth": "",
            "startedCounsellingYear": "",
            "counsellingHowOften": "",
            "counsellingMethod": "",
            "counsellingMethodOther": "",
            "isTheCounsellingBeneficial": null,
            "whatIsTroublingYou": "",
            "ocfCompleter": {
                "metWith": null,
                "spokenWith": null,
                "treatmentSessions": {
                    "hadSessions": null,
                    "sessionFormat": null,
                    "where": ""
                }
            }
        },
        "reminderChecklist": [
            { "value": "introducedSelf", "response": "yes" },
            { "value": "explainedRole", "response": "yes" },
            { "value": "usedClaimantName", "response": "yes" },
            { "value": "explainedPurpose", "response": "yes" },
            { "value": "reviewedFile", "response": "yes" },
            { "value": "actedProfessionally", "response": "yes" },
            { "value": "thoroughQuestions", "response": "yes" },
            { "value": "privateRoom", "response": "yes" },
            { "value": "accommodationForm", "response": "yes" },
            { "value": "claimantNotWaiting", "response": "yes" },
            { "value": "businessCard", "response": "yes" }
        ],
        "observations": [
            { "value": "claimantFriendly", "response": null },
            { "value": "claimantBathedRecently", "response": null },
            { "value": "claimantAppropriateClothing", "response": null },
            { "value": "claimantAbleToWrite", "response": null },
            { "value": "claimantAnswersOrganized", "response": null },
            { "value": "claimantAbleToRemainSeated", "response": null },
            { "value": "neededToRepeatQuestionsOrAnswers", "response": null },
            { "value": "claimantWordFindingOrStuttering", "response": null },
            { "value": "claimantIssuesRecallingPreviousState", "response": null },
            { "value": "claimantIssuesRecallingIncident", "response": null },
            { "value": "claimantIssuesRecallingTreatment", "response": null },
            { "value": "claimantCriedWhenDiscussingIncident", "response": null },
            { "value": "claimantCriedWhenDiscussingLifeChanges", "response": null },
            { "value": "claimantIssuesWithExecutiveFunctioning", "response": null }
        ],
        "personalHistory": {
            "locationOfBirth": null,
            "timeOfArrivalInCanada": null,
            "languages": [""],
            "growingUp": {
                "abuse": {
                    "physical": null,
                    "sexual": null,
                    "mental": null
                },
                "developmentalMilestoneIssues": null,
                "socioeconomicClass": null
            },
            "father": {
                "skip": null,
                "dontKnow": null,
                "age": { "value": null, "skip": false, "dontKnow": false },
                "isAlive": null,
                "causeOfDeath": { "value": null, "skip": false, "dontKnow": false },
                "yearOfDeath": { "value": null, "skip": false, "dontKnow": false },
                "educationLevel": { "value": null, "skip": false, "dontKnow": false },
                "employmentAreas": { "value": null, "skip": false, "dontKnow": false }
            },
            "mother": {
                "skip": null,
                "dontKnow": null,
                "age": { "value": null, "skip": false, "dontKnow": false },
                "isAlive": null,
                "causeOfDeath": { "value": null, "skip": false, "dontKnow": false },
                "yearOfDeath": { "value": null, "skip": false, "dontKnow": false },
                "educationLevel": { "value": null, "skip": false, "dontKnow": false },
                "employmentAreas": { "value": null, "skip": false, "dontKnow": false }
            },
            "didParentsSeparateOrDivorce": null,
            "brothers": {
                "skip": true,
                "skipAges": false,
                "howMany": 0,
                "ages": []
            },
            "sisters": {
                "skip": true,
                "skipAges": false,
                "howMany": 0,
                "ages": []
            },
            "birthPosition": 0,
            "neurologicalOrPsychiatricDiseases": [
                { "self": null, "family": null, "value": "adhd" },
                { "self": null, "family": null, "value": "dementia" },
                { "self": null, "family": null, "value": "bipolar" },
                { "self": null, "family": null, "value": "schizophrenia" },
                { "self": null, "family": null, "value": "depression" },
                { "self": null, "family": null, "value": "anxiety" },
                { "self": null, "family": null, "value": "epilepsy" },
                { "self": null, "family": null, "value": "learningDisorder" }
            ],
            "relationship": {
                "status": null,
                "marriageLength": { "value": null, "unit": null },
                "partnerAge": null,
                "partnerJobTitle": null,
                "isAbusive": null,
                "previousRelationshipAbusive": null,
                "hadPriorSeriousRelationship": null,
                "priorSeriousRelationshipLength": { "value": null, "unit": null },
                "priorSeriousRelationshipReasonEnded": null
            },
            "children": {
                "sons": {
                    "skip": true,
                    "skipAges": false,
                    "howMany": 0,
                    "ages": []
                },
                "daughters": {
                    "skip": true,
                    "skipAges": false,
                    "howMany": 0,
                    "ages": []
                },
                "howManyLiveWithYou": null
            },
            "education": {
                "lastCompletedGrade": "",
                "areaOfStudy": "",
                "selfRating": null,
                "everHeldBack": null,
                "everFailedACourse": null,
                "bestSubject": "",
                "worstSubject": ""
            },
            "occupation": {
                "employedAtTheTimeOfTHeAccident": null,
                "wereYouWorkingAtTheTimeOfTHeAccident": null,
                "start": {
                    "month": "",
                    "year": ""
                },
                "end": {
                    "month": "",
                    "year": "",
                    "na": false
                },
                "jobTitle": "",
                "essentialDuties": "",
                "hoursPerWeek": "",
                "preAccidentIncome": "",
                "returnToWork": {
                    "attempted": null,
                    "when": "",
                    "successful": null,
                    "modifiedDutiesOrHours": "",
                    "ableToReturn": null,
                    "whenAble": null,
                    "necessaryAccommodations": ""
                },
                "timeOff": "",
                "previousEmploymentHistory": ""
            },
            "financial": {
                "experiencingFinancialStress": null,
                "tightFinancially": null,
                "haveDebt": null,
                "amountOfDebt": ""
            },
            "medical": {
                "familyMedicalHistory": null,
                "familyMedicalConditions": [],
                "familyMedicalConditionOther": "",
                "drugsUsed": [],
                "everTreatedForSubstanceAbuse": null,
                "currently": {
                    "alchoholConsumptionIncreased": null,
                    "tobaccoUseIncreased": null,
                    "thcUseIncreased": null
                },
                "beforeAccident": {
                    "medicalConditionsDiagnosed": null,
                    "medicalConditions": [],
                    "surgeries": {
                        "response": null,
                        "details": ""
                    },
                    "injuries": {
                        "response": null,
                        "details": ""
                    },
                    "illnesses": {
                        "repsonse": null,
                        "details": ""
                    },
                    "mvas": {
                        "response": null,
                        "details": ""
                    },
                    "headInjuries": {
                        "response": null,
                        "details": ""
                    },
                    "priorState": null
                },
                "sinceAccident": {
                    "medicalDiagnosis": {
                        "response": null,
                        "details": ""
                    },
                    "surgeries": {
                        "response": null,
                        "details": ""
                    },
                    "mvas": {
                        "response": null,
                        "details": ""
                    },
                    "headInjuries": {
                        "response": null,
                        "details": ""
                    }
                }
            },
            "legal": {
                "everArrested": {
                    "response": null,
                    "details": ""
                },
                "everCharged": {
                    "response": null,
                    "details": ""
                },
                "bondableIssues": {
                    "response": null
                }
            },
            "psychological": {
                "anyHistory": null,
                "takenMoodMedication": null,
                "onMoodMedicationAtTimeOfAccident": null,
                "hospitalizedDueToPsychologicalConcerns": null,
                "hadMentalHealthTesting": null,
                "hadMentalHealthCounselling": null
            },
            "diagnosis": "",
            "prognosis": null,
            "impaired": {
                "response": null,
                "physically": null,
                "cognitively": null,
                "mentally": null
            },
            "disabled": {
                "response": null,
                "physically": null,
                "cognitively": null,
                "mentally": null
            },
            "additionalInformation": ""
        },
        "psychological": {
            "emotional": [
                { "response": null, "value": "sadness" },
                { "response": null, "value": "overwhelmed" },
                { "response": null, "value": "hopelessness" },
                { "response": null, "value": "depression" },
                { "response": null, "value": "helplessness" },
                { "response": null, "value": "labile" },
                { "response": null, "value": "worthlessness" },
                { "response": null, "value": "frustrated" },
                { "response": null, "value": "guilt" },
                { "response": null, "value": "withdrawn" },
                { "response": null, "value": "dependency" },
                { "response": null, "value": "irritable" },
                { "response": null, "value": "lessIndependent" },
                { "response": null, "value": "cryEasily" },
                { "response": null, "value": "anhedonia" },
                { "response": null, "value": "burden" },
                { "response": null, "value": "apathy" },
                { "response": null, "value": "amotivation" }
            ],
            "lettingFamilyDown": null,
            "selfHarm": {
                "pastThoughts": { "response": null },
                "currentThoughts": { "response": null },
                "planToAct": { "response": null },
                "toldDoctor": { "response": null },
                "hurtSelfOnPurpose": { "response": null },
                "attemptedToEndLife": { "response": null },
                "interestedInTreatment": { "response": null }
            },
            "depressionSymptoms": [
                { "response": null, "value": "more irritable" },
                { "response": null, "value": "easily upset" },
                { "response": null, "value": "less tolerant" },
                { "response": null, "value": "less patient" }
            ],
            "neurosisSymptoms": {
                "anxiety": null,
                "stress": null,
                "inabilityToRelax": null,
                "fearOfWorst": null
            },
            "worry": [
                { "response": null, "value": "future" },
                { "response": null, "value": "recovery" },
                { "response": null, "value": "finances" }
            ],
            "dontKnowAmountOfDebt": false,
            "amountOfDebt": null,
            "panicAttacksCurrent": null,
            "panicAttacksPrior": null,
            "heightenedStartleResponse": null,
            "flashbacksAfter": null,
            "flashbacksCurrent": null,
            "nightmaresAfter": null,
            "nightmaresCurrent": null,
            "delusionalIdeation": null,
            "hallucinations": null,
            "hallucinationsAuditory": null,
            "hallucinationsVisual": null,
            "hallucinationsCommand": null,
            "feelSurveilled": null,
            "stressors": [
                { "self": null, "family": null, "value": "relationshipBreakup" },
                { "self": null, "family": null, "value": "deathInFamily" },
                { "self": null, "family": null, "value": "legalIssues" },
                { "self": null, "family": null, "value": "lossOfEmployment" },
                { "self": null, "family": null, "value": "majorIllness" },
                { "self": null, "family": null, "value": "majorFinancialProblems" },
                { "self": null, "family": null, "value": "otherAccidents" }
            ],
            "otherStressors": [
                { "self": null, "family": null, "value": "" }
            ],
            "travel": {
                "abilityToTravel": null,
                "travelIssues": [],
                "ableToDrive": null,
                "nervousDriver": null,
                "anxiousDriver": null,
                "nervousPassenger": null,
                "anxiousPassenger": null,
                "nervousPedestrian": null,
                "anxiousPedestrian": null,
                "usePhantomBrake": null,
                "vigilantWhenTravelling": null,
                "avoidSceneOfAccident": null,
                "travelPreference": null
            }
        },
        "neuropsychological": {
            "problems": {
                "concentration": null,
                "memory": null,
                "shortTermMemory": null
            },
            "memory": {
                "visual": {
                    "forgetWhereaboutsOfObjects": null,
                    "forgetWhereaboutsOf": [],
                    "additionalWhereaboutsObjects": [""]
                },
                "working": {
                    "walkIntoRoomAndForgetWhyFrequently": null,
                    "loseTrackOfWhatYouWantedToSayFrequently": null
                },
                "aids": {
                    "useAids": null,
                    "aidsUsed": [],
                    "familyUsed": null
                },
                "autobiographical": {
                    "personalInfo": null
                },
                "medication": {
                    "errors": null,
                    "usesDosette": null,
                    "usesBlisterPacks": null
                }
            },
            "language": [
                { "response": null, "value": "lostInConversations" },
                { "response": null, "value": "tipOfTongueIssues" },
                { "response": null, "value": "repeatingYourself" },
                { "response": null, "value": "askingOthersToRepeat" },
                { "response": null, "value": "filtering" },
                { "response": null, "value": "wordSubstitution" }
            ],
            "attention": {
                "abilityToFocus": null,
                "abilityToSustainAttention": null,
                "areMoreDistractible": null,
                "loseTrackWhenReading": null,
                "needToReRead": null,
                "readingIssues": [],
                "loseTrackWhenWatchingTv": null,
                "issuesUsingDevicesWithScreens": null,
                "hadToReduceScreenBrightness": null
            },
            "executive": {
                "issues": [
                    { "response": null, "value": "multiTasking" },
                    { "response": null, "value": "harderToMultiTask" },
                    { "response": null, "value": "organization" },
                    { "response": null, "value": "planning" },
                    { "response": null, "value": "decisionMaking" },
                    { "response": null, "value": "problemSolving" }
                ],
                "inappropriateSocialBehavior": null,
                "inappropriateSocialBehaviors": [
                    { "response": null, "value": "inappropriateSocialBehaviorYellingSwearing" },
                    { "response": null, "value": "inappropriateSocialBehaviorViolence" },
                    { "response": null, "value": "inappropriateSocialBehaviorSexual" }
                ]
            },
            "visualSpatial": [
                { "response": null, "value": "balanceIssues" },
                { "response": null, "value": "weaknessInHands" },
                { "response": null, "value": "dizzinessIssues" },
                { "response": null, "value": "tinnitus" },
                { "response": null, "value": "changeInTaste" },
                { "response": null, "value": "changeInSmell" },
                { "response": null, "value": "seizures" },
                { "response": null, "value": "fainting" },
                { "response": null, "value": "lightSensitivity" },
                { "response": null, "value": "noiseSensitivity" },
                { "response": null, "value": "blurryVision" },
                { "response": null, "value": "doubleVision" }
            ],
            "atypical": [
                { "response": null, "value": "itchyFingernails" },
                { "response": null, "value": "blackAndWhiteTransientVision" }
            ],
            "physical": {
                "weight": {
                    "appetiteAffected": null,
                    "changed": null,
                    "changeType": null,
                    "changeAmount": null
                },
                "energy": {
                    "lessEnergy": null,
                    "libidoAffected": null
                },
                "sleep": {
                    "sleepAffected": null,
                    "problemsSleepingPriorToAccident": null,
                    "skipAmountOfSleepBeforeAccident": false,
                    "amountOfSleepBeforeAccident": null,
                    "skipAmountOfSleepCurrent": false,
                    "amountOfSleepCurrent": null,
                    "brokenSleep": null,
                    "issues": [
                        { "response": null, "value": "attaining" },
                        { "response": null, "value": "sustaining" },
                        { "response": null, "value": "regaining" }
                    ],
                    "issueCauses": [],
                    "fatiguedWhenWaking": null,
                    "takeNaps": null
                },
                "headaches": {
                    "experienceHeadachesCurrent": null,
                    "experienceHeadachesPriorToAccident": null,
                    "changesInHeadachesSinceAccident": null,
                    "experienceMigrainesCurrent": null,
                    "experienceMigrainesPriorToAccident": null,
                    "changesInMigrainesSinceAccident": null
                },
                "pain": {
                    "currentlyExperiencePain": null,
                    "currentPainAreas": [""],
                    "experiencePainPriorToAccident": null
                },
                "changes": {
                    "changeInCognition": null,
                    "changeInMood": null
                }
            },
            "currentState": {
                "tasks": [
                    { "ability": null, "issues": [], "isNA": false, "value": "personalCare" },
                    { "ability": null, "issues": [], "isNA": false, "value": "housekeeping" },
                    { "ability": null, "issues": [], "isNA": false, "value": "outdoorChores" },
                    { "ability": null, "issues": [], "isNA": false, "value": "watchingTv" },
                    { "ability": null, "issues": [], "isNA": false, "value": "banking" },
                    { "ability": null, "issues": [], "isNA": false, "value": "caregiving", "isCaregiving": true },
                    { "ability": null, "issues": [], "isNA": false, "value": "alone" }
                ],
                "caregivingCasInvolved": null,
                "preAccidentRecreationalActivities": [
                    "",
                    "",
                    ""
                ],
                "moreSocialBeforeAccident": null
            }
        },
        "treatment": {
            "initial": {
                "providers": [
                    { "past": null, "current": null, "beneficial": null, "value": "physiotherapist" },
                    { "past": null, "current": null, "beneficial": null, "value": "chiropractor" },
                    { "past": null, "current": null, "beneficial": null, "value": "massageTherapist" },
                    { "past": null, "current": null, "beneficial": null, "value": "acupuncturist" },
                    { "past": null, "current": null, "beneficial": null, "value": "osteopathicProvider" },
                    { "past": null, "current": null, "beneficial": null, "value": "naturopathicProvider" },
                    { "past": null, "current": null, "beneficial": null, "value": "occupationalTherapist" },
                    { "past": null, "current": null, "beneficial": null, "value": "rehabilitationWorker" },
                    { "past": null, "current": null, "beneficial": null, "value": "supportWorker" },
                    { "past": null, "current": null, "beneficial": null, "value": "speechLanguagePathologist" },
                    { "past": null, "current": null, "beneficial": null, "value": "caseManager" }
                ],
                "programs": [
                    { "past": null, "current": null, "beneficial": null, "value": "painProgram" },
                    { "past": null, "current": null, "beneficial": null, "value": "driversRehab" }
                ]
            }
        }
    };
}