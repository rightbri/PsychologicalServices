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
        this.yesNoOld = [];
        this.yesNoDontKnow = [];
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
                    this.getTravelAbilities().then(data => this.travelAbilities = data)
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

    getGenders() {
        let data = [
            { "abbreviation": "M", "description": "Male", "title": "Mr." },
            { "abbreviation": "F", "description": "Female", "title": "Ms." }
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
            "depression": { "description": "Depression", "value": "depression", "format": function(context) { return `depression`; } },
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
            "bathing": { "description": "Bathing", "value": "bathing" },
            "grooming": { "description": "Grooming", "value": "grooming" },
            "haircare": { "description": "Haircare", "value": "haircare" },
            "exercising": { "description": "Exercising", "value": "exercising" },
            "indoorChores": { "description": "Housekeeping", "value": "indoorChores" },
            "outdoorChores": { "description": "Outdoor chores", "value": "outdoorChores" },
            "watchingTv": { "description": "Watching TV", "value": "watchingTv" },
            "volunteering": { "description": "Volunteering", "value": "volunteering" },
            "religiousActivities": { "description": "Religious Activities", "value": "religiousActivities" },
            "vacationing": { "description": "Vacationing", "value": "vacationing" },
            "banking": { "description": "Banking", "value": "banking" },
            "caregiving": { "description": "Caregiving", "value": "caregiving" },
            "alone": { "description": "Left alone", "value": "alone" }
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

    getCurrentStateIssues() {
        let data = {
            "physical": { "description": "Physical", "value": "physical", "format": function(context) { return `Physical issues`; } },
            "pain": { "description": "Pain", "value": "pain", "format": function(context) { return `Pain`; } },
            "apathy": { "description": "Apathy", "value": "apathy", "format": function(context) { return `Apathy`; } },
            "mental": { "description": "Mental", "value": "mental", "format": function(context) { return `Mental health issues`; } },
            "cognitive": { "description": "Cognitive", "value": "cognitive", "format": function(context) { return `Cognition`; } }
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

    changed(signalName) {
        this.signaler.signal(signalName);
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

    addOtherStressor() {
        this.responses.psychological.otherStressors.push({ "self": null, "family": null, "value": "" });
    }

    addWhereaboutsObject() {
        this.responses.neuropsychological.memory.visual.additionalWhereaboutsObjects.push("");
    }

    addPreAccidentRecreationalActivity() {
        this.responses.neuropsychological.currentState.preAccidentRecreationalActivities.push("");
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
    return "8";
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

function getNewResponses() {
    return {
        "version": getCurrentVersion(),
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
                { "self": null, "family": null, "value": "depression" },
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
            }
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
                    "currentPainArea": "",
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
                    { "ability": null, "issues": [], "isNA": false, "value": "bathing" },
                    { "ability": null, "issues": [], "isNA": false, "value": "grooming" },
                    { "ability": null, "issues": [], "isNA": false, "value": "haircare" },
                    { "ability": null, "issues": [], "isNA": false, "value": "exercising" },
                    { "ability": null, "issues": [], "isNA": false, "value": "indoorChores" },
                    { "ability": null, "issues": [], "isNA": false, "value": "outdoorChores" },
                    { "ability": null, "issues": [], "isNA": false, "value": "watchingTv" },
                    { "ability": null, "issues": [], "isNA": false, "value": "volunteering" },
                    { "ability": null, "issues": [], "isNA": false, "value": "religiousActivities" },
                    { "ability": null, "issues": [], "isNA": false, "value": "vacationing" },
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
        }
    };
}