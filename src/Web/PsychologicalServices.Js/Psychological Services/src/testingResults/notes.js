import {inject} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {Context} from 'common/context';
import {DataRepository} from 'services/dataRepository';
import {Notifier} from 'services/notifier';
import {AgeService} from 'common/ageService';
import 'number-to-words';

@inject(BindingSignaler, DataRepository, Context, Notifier, AgeService, numberToWords)
export class Notes {

    constructor(signaler, dataRepository, context, notifier, ageService, numberToWords) {
        this.signaler = signaler;
        this.dataRepository = dataRepository;
        this.context = context;
        this.notifier = notifier;
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
        this.leisureParticipationRates = [];
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
                    this.getRelationshipStatuses().then(data => this.relationshipStatuses = data),
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
                    this.getWhereaboutsObjects().then(data => this.whereaboutsObjects = data),
                    this.getMemoryAids().then(data => this.memoryAids = data),
                    this.getVisualSpatialIssues().then(data => this.visualSpatialIssues = data),
                    this.getLanguageIssues().then(data => this.languageIssues = data),
                    this.getExecutiveIssues().then(data => this.executiveIssues = data),
                    this.getInappropriateSocialBehaviors().then(data => this.inappropriateSocialBehaviors = data),
                    this.getReadingIssues().then(data => this.readingIssues = data),
                    this.getWeightChangeTypes().then(data => this.weightChangeTypes = data),
                    this.getCognitiveChangeTypes().then(data => this.cognitiveChangeTypes = data),
                    this.getMoodChangeTypes().then(data => this.moodChangeTypes = data),
                    this.getTravelIssues().then(data => this.travelIssues = data),
                    this.getTravelPreferences().then(data => this.travelPreferences = data),
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
                    this.getLeisureParticipationRates().then(data => this.leisureParticipationRates = data),
                    this.getTravelAbilities().then(data => this.travelAbilities = data)
                ]);
            });
    }

    claimantSelected(e) {
        let gender = e.detail.claimant.gender;

        this.gender = this.genders.find(g => g.abbreviation === gender);

        this.genderChanged(this.gender);

        this.search(e.detail.claimant, this.searchCompanyId);
    }

    reset(resetClaimantData) {
        this.assessments = null;
        this.assessment = null;
        this.name = null;
        this.responses = null;
        
        if (resetClaimantData) {
            this.claimants = null;
            this.claimant = null;

            this.changed('claimant-changed');
        }
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
        let data = [
            { "description": "Single", "value": "single" },
            { "description": "Married", "value": "married", "isMarried": true },
            { "description": "Common Law", "value": "in a common law relationship", "isCommonLaw": true },
            { "description": "Separated", "value": "separated" },
            { "description": "Divorced", "value": "divorced" },
            { "description": "a Widow", "value": "a widow" },
            { "description": "a Widower", "value": "a widower" }
        ];

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
        let data = [
            { "description": "Bank card", "value": "bank card" },
            { "description": "Eye Glasses", "value": "eye glasses" },
            { "description": "iPad/tablet", "value": "iPad/tablet" },
            { "description": "Keys", "value": "keys" },
            { "description": "Paperwork", "value": "paperwork" },
            { "description": "Phone", "value": "phone" },
            { "description": "Wallet", "value": "wallet" },
            { "description": "Beverage", "value": "beverage" }
        ];

        return getPromise(data);
    }

    getMemoryAids() {
        let data = [
            { "description": "Alarms", "value": "alarms" },
            { "description": "Calendar", "value": "calendar" },
            { "description": "List", "value": "lists" },
            { "description": "Notes", "value": "notes" },
            { "description": "Phone", "value": "phone" },
            { "description": "Reminders", "value": "reminders" },
            { "description": "Schedules", "value": "schedules" },
            { "description": "Whiteboard", "value": "whiteboard" }
        ];

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
        let data = [
            { "description": "Headaches", "value": "headaches" },
            { "description": "Vision Issues", "value": "visual issues" },
            { "description": "Focus", "value": "ability to focus" }
        ];
        
        return getPromise(data);
    }

    getWeightChangeTypes() {
        let data = [
            { "description": "Don't know", "value": "don't know", "format": function(context) { return `${context.pronoun.subject} does not know how much ${context.pronoun.possessiveAdjective} weight has changed`; } },
            { "description": "Increased", "value": "increased", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has changed, noting an increase of `; }, "isIncreaseOrDecrease": true },
            { "description": "Decreased", "value": "decreased", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has changed, noting a decrease of `; }, "isIncreaseOrDecrease": true },
            { "description": "Fluctuated", "value": "fluctuated", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has fluctuated`; } }
        ];

        return getPromise(data);
    }

    getCognitiveChangeTypes() {
        let data = [
            { "description": "Worse", "value": "worse", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} cognition is worse`; } },
            { "description": "Little improvement", "value": "little improvement", "format": function(context) { return `overall ${context.pronoun.subject} has seen little improvement`; } },
            { "description": "Same", "value": "same", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} cognition is the same`; } },
            { "description": "Better", "value": "better", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} cognitive state is better`; } },
            { "description": "Resolved", "value": "resolved", "format": function(context) { return `${context.pronoun.subject} feels that any cognitive issues have resolved`; } },
            { "description": "Plateaued", "value": "plateaued", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} cognitive recovery has reached a plateau`; } },
            { "description": "Skip", "value": null, "format": null }
        ];

        return getPromise(data);
    }

    getMoodChangeTypes() {
        let data = [
            { "description": "Worse", "value": "worse", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} mood is worse`; } },
            { "description": "Little improvement", "value": "little improvement", "format": function(context) { return `overall ${context.pronoun.subject} has seen little improvement`; } },
            { "description": "Same", "value": "same", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} mood is the same`; } },
            { "description": "Better", "value": "better", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} mood is better`; } },
            { "description": "Resolved", "value": "resolved", "format": function(context) { return `${context.pronoun.subject} feels that any mood issues have resolved`; } },
            { "description": "Plateaued", "value": "plateaued", "format": function(context) { return `${context.pronoun.subject} feels that ${context.pronoun.possessiveAdjective} emotional recovery has reached a plateau`; } },
            { "description": "Skip", "value": null, "format": null }
        ];

        return getPromise(data);
    }

    getTravelIssues() {
        let data = [
            { "description": "Physical", "value": "physical issues" },
            { "description": "Mental", "value": "mental health issues" },
            { "description": "Cognitive", "value": "cognitive state" }
        ];

        return getPromise(data);
    }

    getTravelPreferences() {
        let data = [
            { "description": "Driver", "value": "driver" },
            { "description": "Passenger", "value": "passenger" },
            { "description": "Pedestrian", "value": "pedestrian" },
            { "description": "Skip", "value": null }
        ];
        
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

    getLeisureParticipationRates() {
        let data = [
            { "description": "a bit less (at least half as often)", "value": "a bit less", "format": function(context) { return `participates a bit less than ${context.pronoun.subject} did before the accident`; } },
            { "description": "much less (less than half as often)", "value": "much less", "format": function(context) { return `participates much less than ${context.pronoun.subject} did before the accident`; } },
            { "description": "unable (rarely, if ever)", "value": "unable", "format": function(context) { return `is now unable to participate in those activities`; } }
        ];

        return getPromise(data);
    }

    changed(signalName) {
        this.signaler.signal(signalName);
    }

    @computedFrom(
        'responses.personalHistory.languages'
    )
    get knownLanguages() {
        let data = this.responses ? this.responses.personalHistory.languages.filter(item => item && item.length > 0) : [];

        return data;
    }

    @computedFrom(
        'responses.personalHistory.growingUp.abuse.physical',
        'responses.personalHistory.growingUp.abuse.sexual',
        'responses.personalHistory.growingUp.abuse.mental'
    )
    get yesAbuseTypes() {
        if (!this.responses) { return []; }
        
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
        if (!this.responses) { return []; }
        
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
        if (!this.responses) { return false; }

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
        let status = this.responses ? this.responses.personalHistory.relationship.status : null;

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
        if (!this.responses) { return []; }

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
        return this.responses && this.responses.psychological.emotional.filter(item => this.isAnswered(item.response)).some(item => item);
    }

    getDepressionSymptomsForResponses(criteria) {
        if (!this.responses) { return []; }

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
        if (!this.responses) { return []; }

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
        let any = this.responses && this.responses.psychological.travel.travelIssues.some(item => item);

        return any;
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
            this.responses.neuropsychological.memory.visual.additionalWhereaboutsObjects.filter(item => item && item.length > 0).map(item => { return { "description": item, "value": item }; })
        );

        return data;
    }

    @computedFrom('responses.neuropsychological.memory.aids.aidsUsed')
    get anyNonFamilyMemoryAidsUsed() {
        let any = this.responses && this.responses.neuropsychological.memory.aids.aidsUsed.some(item => item);

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
    
    addAloneIssue() {
        this.responses.neuropsychological.currentState.alone.issues.push("");
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

    getAgeTextForContext(age, context) {
        return age && age.value && age.unit ? (age.value + " " + age.unit) : "";
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
    return "6";
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

function upgrade_1_to_2(responses) {

    if (responses.neuropsychological.physical.sleep.skipHoursOfSleepBeforeAccident) {
        responses.neuropsychological.physical.sleep.skipAmountOfSleepBeforeAccident = responses.neuropsychological.physical.sleep.skipHoursOfSleepBeforeAccident;
        delete responses.neuropsychological.physical.sleep.skipHoursOfSleepBeforeAccident;
    }
    
    if (responses.neuropsychological.physical.sleep.hoursOfSleepBeforeAccident) {
        responses.neuropsychological.physical.sleep.amountOfSleepBeforeAccident = responses.neuropsychological.physical.sleep.hoursOfSleepBeforeAccident;
        delete responses.neuropsychological.physical.sleep.hoursOfSleepBeforeAccident;
    }

    if (responses.neuropsychological.physical.sleep.skipHoursOfSleepCurrent) {
        responses.neuropsychological.physical.sleep.skipAmountOfSleepCurrent = responses.neuropsychological.physical.sleep.skipHoursOfSleepCurrent;
        delete responses.neuropsychological.physical.sleep.skipHoursOfSleepCurrent;
    }
    
    if (responses.neuropsychological.physical.sleep.hoursOfSleepCurrent) {
        responses.neuropsychological.physical.sleep.amountOfSleepCurrent = responses.neuropsychological.physical.sleep.hoursOfSleepCurrent;
        delete responses.neuropsychological.physical.sleep.hoursOfSleepCurrent;
    }

    responses.version = "2";

    return responses;
}

function upgrade_2_to_3(responses) {
    //fix emotional issues, depression symptoms, worries
    for (let issue of responses.psychological.emotional) {
        if (issue.description) {
            delete issue.description;
        }

        if (issue.format) {
            delete issue.format;
        }
    }

    for (let symptom of responses.psychological.depressionSymptoms) {
        if (symptom.description) {
            delete symptom.description;
        }

        if (symptom.format) {
            delete symptom.format;
        }
    }

    for (let worry of responses.psychological.worry) {
        if (worry.description) {
            delete worry.description;
        }

        if (worry.format) {
            delete worry.format;
        }
    }

    //fix inappropriate social behavior
    let inappropriateTarget = [];
    if (responses.neuropsychological.executive.inappropriateSocialBehaviorYellingSwearing) {
        inappropriateTarget.push({ "response": responses.neuropsychological.executive.inappropriateSocialBehaviorYellingSwearing.response, "value": "inappropriateSocialBehaviorYellingSwearing" });
        delete responses.neuropsychological.executive.inappropriateSocialBehaviorYellingSwearing;
    }
    
    if (responses.neuropsychological.executive.inappropriateSocialBehaviorViolence) {
        inappropriateTarget.push({ "response": responses.neuropsychological.executive.inappropriateSocialBehaviorViolence.response, "value": "inappropriateSocialBehaviorViolence" });
        delete responses.neuropsychological.executive.inappropriateSocialBehaviorViolence;
    }
    
    if (responses.neuropsychological.executive.inappropriateSocialBehaviorSexual) {
        inappropriateTarget.push({ "response": responses.neuropsychological.executive.inappropriateSocialBehaviorSexual.response, "value": "inappropriateSocialBehaviorSexual" });
        delete responses.neuropsychological.executive.inappropriateSocialBehaviorSexual;
    }
    responses.neuropsychological.executive.inappropriateSocialBehaviors = inappropriateTarget;
    
    //fix visual spatial issues
    if (!responses.neuropsychological.visualSpatial.length) {
        let visualSpatialTarget = [];
        for (let property in responses.neuropsychological.visualSpatial) {
            visualSpatialTarget.push({ "response": responses.neuropsychological.visualSpatial[property].response, "value": property });
        }
        responses.neuropsychological.visualSpatial = visualSpatialTarget;    
    }

    //fix atypical issues
    if (!responses.neuropsychological.atypical.length) {
        let atypicalTarget = [];
        for (let property in responses.neuropsychological.atypical) {
            atypicalTarget.push({ "response": responses.neuropsychological.atypical[property].response, "value": property });
        }
        responses.neuropsychological.atypical = atypicalTarget;    
    }

    //fix language issues
    if (!responses.neuropsychological.language.length) {
        let languageIssuesTarget = [];
        for (let property in responses.neuropsychological.language) {
            languageIssuesTarget.push({ "response": responses.neuropsychological.language[property].response, "value": property });
        }
        responses.neuropsychological.language = languageIssuesTarget;
    }

    //fix executive issues
    if (!responses.neuropsychological.executive.issues.length) {
        let executiveIssuesTarget = [];
        for (let property in responses.neuropsychological.executive.issues) {
            executiveIssuesTarget.push({ "response": responses.neuropsychological.executive.issues[property].response, "value": property });
        }
        responses.neuropsychological.executive.issues = executiveIssuesTarget;
    }

    responses.version = "3";

    return responses;
}

function getYesNoDontKnowConversion(response) {
    if (response) {
        if (response.isYes) {
            return "yes";
        }
        else if (response.isNo) {
            return "no";
        }
        else if (response.dontKnow) {
            return "dontKnow";
        }  
        else if (response.isSkip) {
            return "skip";
        }  
    }
    
    return null;
}

function upgrade_3_to_4(responses) {

    //fix neurosisSymptoms
    if (responses.psychological.neurosisSymptoms.anxiety && responses.psychological.neurosisSymptoms.anxiety.description) {
        responses.psychological.neurosisSymptoms.anxiety = getYesNoDontKnowConversion(responses.psychological.neurosisSymptoms.anxiety);
    }

    if (responses.psychological.neurosisSymptoms.stress && responses.psychological.neurosisSymptoms.stress.description) {
        responses.psychological.neurosisSymptoms.stress = getYesNoDontKnowConversion(responses.psychological.neurosisSymptoms.stress);
    }

    if (responses.psychological.neurosisSymptoms.inabilityToRelax && responses.psychological.neurosisSymptoms.inabilityToRelax.description) {
        responses.psychological.neurosisSymptoms.inabilityToRelax = getYesNoDontKnowConversion(responses.psychological.neurosisSymptoms.inabilityToRelax);
    }

    if (responses.psychological.neurosisSymptoms.fearOfWorst && responses.psychological.neurosisSymptoms.fearOfWorst.description) {
        responses.psychological.neurosisSymptoms.fearOfWorst = getYesNoDontKnowConversion(responses.psychological.neurosisSymptoms.fearOfWorst);
    }

    if (responses.personalHistory.growingUp.abuse.physical && responses.personalHistory.growingUp.abuse.physical.description) {responses.personalHistory.growingUp.abuse.physical = getYesNoDontKnowConversion(responses.personalHistory.growingUp.abuse.physical);}
    if (responses.personalHistory.growingUp.abuse.sexual && responses.personalHistory.growingUp.abuse.sexual.description) {responses.personalHistory.growingUp.abuse.sexual = getYesNoDontKnowConversion(responses.personalHistory.growingUp.abuse.sexual);}
    if (responses.personalHistory.growingUp.abuse.mental && responses.personalHistory.growingUp.abuse.mental.description) {responses.personalHistory.growingUp.abuse.mental = getYesNoDontKnowConversion(responses.personalHistory.growingUp.abuse.mental);}
    if (responses.personalHistory.growingUp.developmentalMilestoneIssues && responses.personalHistory.growingUp.developmentalMilestoneIssues.description) {responses.personalHistory.growingUp.developmentalMilestoneIssues = getYesNoDontKnowConversion(responses.personalHistory.growingUp.developmentalMilestoneIssues);}
    if (responses.personalHistory.father.isAlive && responses.personalHistory.father.isAlive.description) {responses.personalHistory.father.isAlive = getYesNoDontKnowConversion(responses.personalHistory.father.isAlive);}
    if (responses.personalHistory.mother.isAlive && responses.personalHistory.mother.isAlive.description) {responses.personalHistory.mother.isAlive = getYesNoDontKnowConversion(responses.personalHistory.mother.isAlive);}
    if (responses.personalHistory.didParentsSeparateOrDivorce && responses.personalHistory.didParentsSeparateOrDivorce.description) {responses.personalHistory.didParentsSeparateOrDivorce = getYesNoDontKnowConversion(responses.personalHistory.didParentsSeparateOrDivorce);}
    if (responses.personalHistory.familyHistoryOfNeurologicalOrPsychiatricDisease && responses.personalHistory.familyHistoryOfNeurologicalOrPsychiatricDisease.description) {responses.personalHistory.familyHistoryOfNeurologicalOrPsychiatricDisease = getYesNoDontKnowConversion(responses.personalHistory.familyHistoryOfNeurologicalOrPsychiatricDisease);}
    if (responses.personalHistory.relationship.isAbusive && responses.personalHistory.relationship.isAbusive.description) {responses.personalHistory.relationship.isAbusive = getYesNoDontKnowConversion(responses.personalHistory.relationship.isAbusive);}
    if (responses.personalHistory.relationship.previousRelationshipAbusive && responses.personalHistory.relationship.previousRelationshipAbusive.description) {responses.personalHistory.relationship.previousRelationshipAbusive = getYesNoDontKnowConversion(responses.personalHistory.relationship.previousRelationshipAbusive);}
    if (responses.personalHistory.relationship.hadPriorSeriousRelationship && responses.personalHistory.relationship.hadPriorSeriousRelationship.description) {responses.personalHistory.relationship.hadPriorSeriousRelationship = getYesNoDontKnowConversion(responses.personalHistory.relationship.hadPriorSeriousRelationship);}
    if (responses.psychological.selfHarm.pastThoughts.response && responses.psychological.selfHarm.pastThoughts.response.description) {responses.psychological.selfHarm.pastThoughts.response = getYesNoDontKnowConversion(responses.psychological.selfHarm.pastThoughts.response);}
    if (responses.psychological.selfHarm.currentThoughts.response && responses.psychological.selfHarm.currentThoughts.response.description) {responses.psychological.selfHarm.currentThoughts.response = getYesNoDontKnowConversion(responses.psychological.selfHarm.currentThoughts.response);}
    if (responses.psychological.selfHarm.planToAct.response && responses.psychological.selfHarm.planToAct.response.description) {responses.psychological.selfHarm.planToAct.response = getYesNoDontKnowConversion(responses.psychological.selfHarm.planToAct.response);}
    if (responses.psychological.selfHarm.toldDoctor.response && responses.psychological.selfHarm.toldDoctor.response.description) {responses.psychological.selfHarm.toldDoctor.response = getYesNoDontKnowConversion(responses.psychological.selfHarm.toldDoctor.response);}
    if (responses.psychological.selfHarm.hurtSelfOnPurpose.response && responses.psychological.selfHarm.hurtSelfOnPurpose.response.description) {responses.psychological.selfHarm.hurtSelfOnPurpose.response = getYesNoDontKnowConversion(responses.psychological.selfHarm.hurtSelfOnPurpose.response);}
    if (responses.psychological.selfHarm.attemptedToEndLife.response && responses.psychological.selfHarm.attemptedToEndLife.response.description) {responses.psychological.selfHarm.attemptedToEndLife.response = getYesNoDontKnowConversion(responses.psychological.selfHarm.attemptedToEndLife.response);}
    if (responses.psychological.selfHarm.interestedInTreatment.response && responses.psychological.selfHarm.interestedInTreatment.response.description) {responses.psychological.selfHarm.interestedInTreatment.response = getYesNoDontKnowConversion(responses.psychological.selfHarm.interestedInTreatment.response);}
    if (responses.psychological.neurosisSymptoms.anxiety && responses.psychological.neurosisSymptoms.anxiety.description) {responses.psychological.neurosisSymptoms.anxiety = getYesNoDontKnowConversion(responses.psychological.neurosisSymptoms.anxiety);}
    if (responses.psychological.neurosisSymptoms.stress && responses.psychological.neurosisSymptoms.stress.description) {responses.psychological.neurosisSymptoms.stress = getYesNoDontKnowConversion(responses.psychological.neurosisSymptoms.stress);}
    if (responses.psychological.neurosisSymptoms.inabilityToRelax && responses.psychological.neurosisSymptoms.inabilityToRelax.description) {responses.psychological.neurosisSymptoms.inabilityToRelax = getYesNoDontKnowConversion(responses.psychological.neurosisSymptoms.inabilityToRelax);}
    if (responses.psychological.neurosisSymptoms.fearOfWorst && responses.psychological.neurosisSymptoms.fearOfWorst.description) {responses.psychological.neurosisSymptoms.fearOfWorst = getYesNoDontKnowConversion(responses.psychological.neurosisSymptoms.fearOfWorst);}
    if (responses.psychological.panicAttacksCurrent && responses.psychological.panicAttacksCurrent.description) {responses.psychological.panicAttacksCurrent = getYesNoDontKnowConversion(responses.psychological.panicAttacksCurrent);}
    if (responses.psychological.panicAttacksPrior && responses.psychological.panicAttacksPrior.description) {responses.psychological.panicAttacksPrior = getYesNoDontKnowConversion(responses.psychological.panicAttacksPrior);}
    if (responses.psychological.heightenedStartleResponse && responses.psychological.heightenedStartleResponse.description) {responses.psychological.heightenedStartleResponse = getYesNoDontKnowConversion(responses.psychological.heightenedStartleResponse);}
    if (responses.psychological.flashbacksAfter && responses.psychological.flashbacksAfter.description) {responses.psychological.flashbacksAfter = getYesNoDontKnowConversion(responses.psychological.flashbacksAfter);}
    if (responses.psychological.flashbacksCurrent && responses.psychological.flashbacksCurrent.description) {responses.psychological.flashbacksCurrent = getYesNoDontKnowConversion(responses.psychological.flashbacksCurrent);}
    if (responses.psychological.nightmaresAfter && responses.psychological.nightmaresAfter.description) {responses.psychological.nightmaresAfter = getYesNoDontKnowConversion(responses.psychological.nightmaresAfter);}
    if (responses.psychological.nightmaresCurrent && responses.psychological.nightmaresCurrent.description) {responses.psychological.nightmaresCurrent = getYesNoDontKnowConversion(responses.psychological.nightmaresCurrent);}
    if (responses.psychological.delusionalIdeation && responses.psychological.delusionalIdeation.description) {responses.psychological.delusionalIdeation = getYesNoDontKnowConversion(responses.psychological.delusionalIdeation);}
    if (responses.psychological.hallucinations && responses.psychological.hallucinations.description) {responses.psychological.hallucinations = getYesNoDontKnowConversion(responses.psychological.hallucinations);}
    if (responses.psychological.hallucinationsAuditory && responses.psychological.hallucinationsAuditory.description) {responses.psychological.hallucinationsAuditory = getYesNoDontKnowConversion(responses.psychological.hallucinationsAuditory);}
    if (responses.psychological.hallucinationsVisual && responses.psychological.hallucinationsVisual.description) {responses.psychological.hallucinationsVisual = getYesNoDontKnowConversion(responses.psychological.hallucinationsVisual);}
    if (responses.psychological.hallucinationsCommand && responses.psychological.hallucinationsCommand.description) {responses.psychological.hallucinationsCommand = getYesNoDontKnowConversion(responses.psychological.hallucinationsCommand);}
    if (responses.psychological.travel.abilityToTravel && responses.psychological.travel.abilityToTravel.description) {responses.psychological.travel.abilityToTravel = getYesNoDontKnowConversion(responses.psychological.travel.abilityToTravel);}
    if (responses.psychological.travel.usePhantomBrake && responses.psychological.travel.usePhantomBrake.description) {responses.psychological.travel.usePhantomBrake = getYesNoDontKnowConversion(responses.psychological.travel.usePhantomBrake);}
    if (responses.psychological.travel.vigilantWhenTravelling && responses.psychological.travel.vigilantWhenTravelling.description) {responses.psychological.travel.vigilantWhenTravelling = getYesNoDontKnowConversion(responses.psychological.travel.vigilantWhenTravelling);}
    if (responses.psychological.travel.avoidSceneOfAccident && responses.psychological.travel.avoidSceneOfAccident.description) {responses.psychological.travel.avoidSceneOfAccident = getYesNoDontKnowConversion(responses.psychological.travel.avoidSceneOfAccident);}
    if (responses.neuropsychological.problems.concentration && responses.neuropsychological.problems.concentration.description) {responses.neuropsychological.problems.concentration = getYesNoDontKnowConversion(responses.neuropsychological.problems.concentration);}
    if (responses.neuropsychological.problems.memory && responses.neuropsychological.problems.memory.description) {responses.neuropsychological.problems.memory = getYesNoDontKnowConversion(responses.neuropsychological.problems.memory);}
    if (responses.neuropsychological.problems.shortTermMemory && responses.neuropsychological.problems.shortTermMemory.description) {responses.neuropsychological.problems.shortTermMemory = getYesNoDontKnowConversion(responses.neuropsychological.problems.shortTermMemory);}
    if (responses.neuropsychological.memory.visual.forgetWhereaboutsOfObjects && responses.neuropsychological.memory.visual.forgetWhereaboutsOfObjects.description) {responses.neuropsychological.memory.visual.forgetWhereaboutsOfObjects = getYesNoDontKnowConversion(responses.neuropsychological.memory.visual.forgetWhereaboutsOfObjects);}
    if (responses.neuropsychological.memory.working.walkIntoRoomAndForgetWhyFrequently && responses.neuropsychological.memory.working.walkIntoRoomAndForgetWhyFrequently.description) {responses.neuropsychological.memory.working.walkIntoRoomAndForgetWhyFrequently = getYesNoDontKnowConversion(responses.neuropsychological.memory.working.walkIntoRoomAndForgetWhyFrequently);}
    if (responses.neuropsychological.memory.working.loseTrackOfWhatYouWantedToSayFrequently && responses.neuropsychological.memory.working.loseTrackOfWhatYouWantedToSayFrequently.description) {responses.neuropsychological.memory.working.loseTrackOfWhatYouWantedToSayFrequently = getYesNoDontKnowConversion(responses.neuropsychological.memory.working.loseTrackOfWhatYouWantedToSayFrequently);}
    if (responses.neuropsychological.memory.aids.useAids && responses.neuropsychological.memory.aids.useAids.description) {responses.neuropsychological.memory.aids.useAids = getYesNoDontKnowConversion(responses.neuropsychological.memory.aids.useAids);}
    if (responses.neuropsychological.memory.autobiographical.personalInfo && responses.neuropsychological.memory.autobiographical.personalInfo.description) {responses.neuropsychological.memory.autobiographical.personalInfo = getYesNoDontKnowConversion(responses.neuropsychological.memory.autobiographical.personalInfo);}
    if (responses.neuropsychological.memory.medication.errors && responses.neuropsychological.memory.medication.errors.description) {responses.neuropsychological.memory.medication.errors = getYesNoDontKnowConversion(responses.neuropsychological.memory.medication.errors);}
    if (responses.neuropsychological.memory.medication.usesDosette && responses.neuropsychological.memory.medication.usesDosette.description) {responses.neuropsychological.memory.medication.usesDosette = getYesNoDontKnowConversion(responses.neuropsychological.memory.medication.usesDosette);}
    if (responses.neuropsychological.memory.medication.usesBlisterPacks && responses.neuropsychological.memory.medication.usesBlisterPacks.description) {responses.neuropsychological.memory.medication.usesBlisterPacks = getYesNoDontKnowConversion(responses.neuropsychological.memory.medication.usesBlisterPacks);}
    if (responses.neuropsychological.attention.abilityToFocus && responses.neuropsychological.attention.abilityToFocus.description) {responses.neuropsychological.attention.abilityToFocus = getYesNoDontKnowConversion(responses.neuropsychological.attention.abilityToFocus);}
    if (responses.neuropsychological.attention.abilityToSustainAttention && responses.neuropsychological.attention.abilityToSustainAttention.description) {responses.neuropsychological.attention.abilityToSustainAttention = getYesNoDontKnowConversion(responses.neuropsychological.attention.abilityToSustainAttention);}
    if (responses.neuropsychological.attention.areMoreDistractible && responses.neuropsychological.attention.areMoreDistractible.description) {responses.neuropsychological.attention.areMoreDistractible = getYesNoDontKnowConversion(responses.neuropsychological.attention.areMoreDistractible);}
    if (responses.neuropsychological.attention.loseTrackWhenReading && responses.neuropsychological.attention.loseTrackWhenReading.description) {responses.neuropsychological.attention.loseTrackWhenReading = getYesNoDontKnowConversion(responses.neuropsychological.attention.loseTrackWhenReading);}
    if (responses.neuropsychological.attention.needToReRead && responses.neuropsychological.attention.needToReRead.description) {responses.neuropsychological.attention.needToReRead = getYesNoDontKnowConversion(responses.neuropsychological.attention.needToReRead);}
    if (responses.neuropsychological.attention.loseTrackWhenWatchingTv && responses.neuropsychological.attention.loseTrackWhenWatchingTv.description) {responses.neuropsychological.attention.loseTrackWhenWatchingTv = getYesNoDontKnowConversion(responses.neuropsychological.attention.loseTrackWhenWatchingTv);}
    if (responses.neuropsychological.executive.inappropriateSocialBehavior && responses.neuropsychological.executive.inappropriateSocialBehavior.description) {responses.neuropsychological.executive.inappropriateSocialBehavior = getYesNoDontKnowConversion(responses.neuropsychological.executive.inappropriateSocialBehavior);}
    if (responses.neuropsychological.physical.weight.appetiteAffected && responses.neuropsychological.physical.weight.appetiteAffected.description) {responses.neuropsychological.physical.weight.appetiteAffected = getYesNoDontKnowConversion(responses.neuropsychological.physical.weight.appetiteAffected);}
    if (responses.neuropsychological.physical.weight.changed && responses.neuropsychological.physical.weight.changed.description) {responses.neuropsychological.physical.weight.changed = getYesNoDontKnowConversion(responses.neuropsychological.physical.weight.changed);}
    if (responses.neuropsychological.physical.energy.lessEnergy && responses.neuropsychological.physical.energy.lessEnergy.description) {responses.neuropsychological.physical.energy.lessEnergy = getYesNoDontKnowConversion(responses.neuropsychological.physical.energy.lessEnergy);}
    if (responses.neuropsychological.physical.energy.libidoAffected && responses.neuropsychological.physical.energy.libidoAffected.description) {responses.neuropsychological.physical.energy.libidoAffected = getYesNoDontKnowConversion(responses.neuropsychological.physical.energy.libidoAffected);}
    if (responses.neuropsychological.physical.sleep.sleepAffected && responses.neuropsychological.physical.sleep.sleepAffected.description) {responses.neuropsychological.physical.sleep.sleepAffected = getYesNoDontKnowConversion(responses.neuropsychological.physical.sleep.sleepAffected);}
    if (responses.neuropsychological.physical.sleep.problemsSleepingPriorToAccident && responses.neuropsychological.physical.sleep.problemsSleepingPriorToAccident.description) {responses.neuropsychological.physical.sleep.problemsSleepingPriorToAccident = getYesNoDontKnowConversion(responses.neuropsychological.physical.sleep.problemsSleepingPriorToAccident);}
    if (responses.neuropsychological.physical.sleep.brokenSleep && responses.neuropsychological.physical.sleep.brokenSleep.description) {responses.neuropsychological.physical.sleep.brokenSleep = getYesNoDontKnowConversion(responses.neuropsychological.physical.sleep.brokenSleep);}
    if (responses.neuropsychological.physical.sleep.fatiguedWhenWaking && responses.neuropsychological.physical.sleep.fatiguedWhenWaking.description) {responses.neuropsychological.physical.sleep.fatiguedWhenWaking = getYesNoDontKnowConversion(responses.neuropsychological.physical.sleep.fatiguedWhenWaking);}
    if (responses.neuropsychological.physical.sleep.takeNaps && responses.neuropsychological.physical.sleep.takeNaps.description) {responses.neuropsychological.physical.sleep.takeNaps = getYesNoDontKnowConversion(responses.neuropsychological.physical.sleep.takeNaps);}
    if (responses.neuropsychological.physical.headaches.experienceHeadachesCurrent && responses.neuropsychological.physical.headaches.experienceHeadachesCurrent.description) {responses.neuropsychological.physical.headaches.experienceHeadachesCurrent = getYesNoDontKnowConversion(responses.neuropsychological.physical.headaches.experienceHeadachesCurrent);}
    if (responses.neuropsychological.physical.headaches.experienceHeadachesPriorToAccident && responses.neuropsychological.physical.headaches.experienceHeadachesPriorToAccident.description) {responses.neuropsychological.physical.headaches.experienceHeadachesPriorToAccident = getYesNoDontKnowConversion(responses.neuropsychological.physical.headaches.experienceHeadachesPriorToAccident);}
    if (responses.neuropsychological.physical.headaches.changesInHeadachesSinceAccident && responses.neuropsychological.physical.headaches.changesInHeadachesSinceAccident.description) {responses.neuropsychological.physical.headaches.changesInHeadachesSinceAccident = getYesNoDontKnowConversion(responses.neuropsychological.physical.headaches.changesInHeadachesSinceAccident);}
    if (responses.neuropsychological.physical.headaches.experienceMigrainesCurrent && responses.neuropsychological.physical.headaches.experienceMigrainesCurrent.description) {responses.neuropsychological.physical.headaches.experienceMigrainesCurrent = getYesNoDontKnowConversion(responses.neuropsychological.physical.headaches.experienceMigrainesCurrent);}
    if (responses.neuropsychological.physical.headaches.experienceMigrainesPriorToAccident && responses.neuropsychological.physical.headaches.experienceMigrainesPriorToAccident.description) {responses.neuropsychological.physical.headaches.experienceMigrainesPriorToAccident = getYesNoDontKnowConversion(responses.neuropsychological.physical.headaches.experienceMigrainesPriorToAccident);}
    if (responses.neuropsychological.physical.headaches.changesInMigrainesSinceAccident && responses.neuropsychological.physical.headaches.changesInMigrainesSinceAccident.description) {responses.neuropsychological.physical.headaches.changesInMigrainesSinceAccident = getYesNoDontKnowConversion(responses.neuropsychological.physical.headaches.changesInMigrainesSinceAccident);}
    if (responses.neuropsychological.physical.pain.currentlyExperiencePain && responses.neuropsychological.physical.pain.currentlyExperiencePain.description) {responses.neuropsychological.physical.pain.currentlyExperiencePain = getYesNoDontKnowConversion(responses.neuropsychological.physical.pain.currentlyExperiencePain);}
    if (responses.neuropsychological.physical.pain.experiencePainPriorToAccident && responses.neuropsychological.physical.pain.experiencePainPriorToAccident.description) {responses.neuropsychological.physical.pain.experiencePainPriorToAccident = getYesNoDontKnowConversion(responses.neuropsychological.physical.pain.experiencePainPriorToAccident);}

    let yesNoResponses2 = [
        responses.psychological.emotional,
        responses.psychological.depressionSymptoms,
        responses.psychological.worry,
        responses.neuropsychological.language,
        responses.neuropsychological.executive.issues,
        responses.neuropsychological.executive.inappropriateSocialBehaviors,
        responses.neuropsychological.visualSpatial,
        responses.neuropsychological.atypical
    ];

    for (let i = 0; i < yesNoResponses2.length; i++) {
        for (let j = 0; j < yesNoResponses2[i].length; j++) {
            yesNoResponses2[i][j].response = getYesNoDontKnowConversion(yesNoResponses2[i][j].response);
        }
    }

    responses.version = "4";

    return responses;
}

function upgrade_4_to_5(responses) {
    if (!responses.neuropsychological.memory.visual.hasOwnProperty('additionalWhereaboutsObjects')) {
        responses.neuropsychological.memory.visual.additionalWhereaboutsObjects = [""];
    }

    if (!responses.psychological.hasOwnProperty('lettingFamilyDown')) {
        responses.psychological.lettingFamilyDown = null;
    }

    if (!responses.psychological.hasOwnProperty('feelSurveilled')) {
        responses.psychological.feelSurveilled = null;
    }

    if (!responses.psychological.travel.hasOwnProperty('ableToDrive')) {
        responses.psychological.travel.ableToDrive = null;
    }

    if (!responses.neuropsychological.attention.hasOwnProperty('issuesUsingDevicesWithScreens')) {
        responses.neuropsychological.attention.issuesUsingDevicesWithScreens = null;
    }

    if (!responses.neuropsychological.attention.hasOwnProperty('hadToReduceScreenBrightness')) {
        responses.neuropsychological.attention.hadToReduceScreenBrightness = null;
    }

    if (!responses.neuropsychological.currentState.hasOwnProperty('moreSocialBeforeAccident')) {
        responses.neuropsychological.currentState.moreSocialBeforeAccident = null;
    }

    let emotionalIrritableIndex = responses.psychological.emotional.findIndex(item => item.value === "irritable");

    if (!responses.psychological.emotional.some(item => item.value === "lessIndependent")) {
        responses.psychological.emotional.splice(emotionalIrritableIndex + 1, 0, { "response": null, "value": "lessIndependent" });
    }
    
    if (!responses.psychological.emotional.some(item => item.value === "cryEasily")) {
        responses.psychological.emotional.splice(emotionalIrritableIndex + 1, 0, { "response": null, "value": "cryEasily" });
    }

    if (!responses.neuropsychological.currentState.hasOwnProperty('tasks')) {
        responses.neuropsychological.currentState.tasks = [];

        let props = [
            'personalCare',
            'bathing',
            'grooming',
            'haircare',
            'exercising',
            'indoorChores',
            'outdoorChores',
            'watchingTv',
            'volunteering',
            'religiousActivities',
            'vacationing',
            'banking',
            'caregiving',
            'alone'
        ];

        for (let i = 0; i < props.length; i++) {

            if (responses.neuropsychological.currentState.hasOwnProperty(props[i])) {
                if (!responses.neuropsychological.currentState.tasks.some(item => item.value === props[i])) {
                    responses.neuropsychological.currentState.tasks.splice(i, 0, { "ability": responses.neuropsychological.currentState[props[i]].ability || null, "issues": responses.neuropsychological.currentState[props[i]].issues || [], "isNA": false, "value": props[i] });
                }
    
                delete responses.neuropsychological.currentState[props[i]];
            }
            else {
                if (!responses.neuropsychological.currentState.tasks.some(item => item.value === props[i])) {
                    responses.neuropsychological.currentState.tasks.splice(i, 0, { "ability": null, "issues": [], "isNA": false, "value": props[i] });
                }
            }
        }
    }

    if (!responses.psychological.hasOwnProperty('stressors')) {
        responses.psychological.stressors = [
            { "self": null, "family": null, "value": "relationshipBreakup" },
            { "self": null, "family": null, "value": "deathInFamily" },
            { "self": null, "family": null, "value": "legalIssues" },
            { "self": null, "family": null, "value": "lossOfEmployment" },
            { "self": null, "family": null, "value": "majorIllness" },
            { "self": null, "family": null, "value": "majorFinancialProblems" },
            { "self": null, "family": null, "value": "otherAccidents" }
        ];
    }

    if (!responses.psychological.hasOwnProperty('otherStressors')) {
        responses.psychological.otherStressors = [
            { "self": null, "family": null, "value": "" }
        ];
    }

    responses.version = "5";

    return responses;
}

function upgrade_5_to_6(responses) {

    if (!responses.personalHistory.hasOwnProperty('neurologicalOrPsychiatricDiseases')) {
        responses.personalHistory.neurologicalOrPsychiatricDiseases = [
            { "self": null, "family": null, "value": "adhd" },
            { "self": null, "family": null, "value": "dementia" },
            { "self": null, "family": null, "value": "bipolar" },
            { "self": null, "family": null, "value": "depression" },
            { "self": null, "family": null, "value": "epilepsy" },
            { "self": null, "family": null, "value": "learningDisorder" }
        ];
    }

    let caregiving = responses.neuropsychological.currentState.tasks.find(item => item.value === "caregiving");

    if (caregiving && !caregiving.hasOwnProperty('isCaregiving')) {
        caregiving.isCaregiving = true;
    }
    
    if (!responses.personalHistory.brothers.hasOwnProperty('skip')) {
        responses.personalHistory.brothers.skip = false;
    }

    if (!responses.personalHistory.sisters.hasOwnProperty('skip')) {
        responses.personalHistory.sisters.skip = false;
    }
    
    if (!responses.personalHistory.children.sons.hasOwnProperty('skip')) {
        responses.personalHistory.children.sons.skip = false;
    }
    
    if (!responses.personalHistory.children.daughters.hasOwnProperty('skip')) {
        responses.personalHistory.children.daughters.skip = false;
    }
    
    if (!responses.personalHistory.brothers.hasOwnProperty('skipAges')) {
        responses.personalHistory.brothers.skipAges = false;
    }

    if (!responses.personalHistory.sisters.hasOwnProperty('skipAges')) {
        responses.personalHistory.sisters.skipAges = false;
    }
    
    if (!responses.personalHistory.children.sons.hasOwnProperty('skipAges')) {
        responses.personalHistory.children.sons.skipAges = false;
    }
    
    if (!responses.personalHistory.children.daughters.hasOwnProperty('skipAges')) {
        responses.personalHistory.children.daughters.skipAges = false;
    }
    
    responses.version = "6";

    return responses;
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
                "yearOfBirth": null,
                "isAlive": null,
                "causeOfDeath": null,
                "yearOfDeath": null,
                "educationLevel": null,
                "employmentAreas": null
            },
            "mother": {
                "yearOfBirth": null,
                "isAlive": null,
                "causeOfDeath": null,
                "yearOfDeath": null,
                "educationLevel": null,
                "employmentAreas": null
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