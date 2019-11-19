import {inject} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {Context} from 'common/context';
import {DataRepository} from 'services/dataRepository';
import {Notifier} from 'services/notifier';

@inject(BindingSignaler, DataRepository, Context, Notifier)
export class Notes {

    constructor(signaler, dataRepository, context, notifier) {
        this.signaler = signaler;
        this.dataRepository = dataRepository;
        this.context = context;
        this.notifier = notifier;

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
        this.genders = [];
        this.socioeconomicStatuses = [];
        this.relationshipStatuses = [];
        this.relationshipDisruptionFrequencies = [];
        this.ageUnits = [];
        this.whereaboutsObjects = [];
        this.memoryAids = [];
        this.readingIssues = [];
        this.weightChangeTypes = [];
        this.cognitiveChangeTypes = [];
        this.moodChangeTypes = [];
        this.travelIssues = [];
        this.travelPreferences = [];
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

        this.getItemValueForCurrentPronoun = function(item) {
            return this.getItemValueForPronoun(item, this.pronoun);
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
                    this.getYesNo().then(data => this.yesNo = data),
                    this.getYesNoDontKnow().then(data => this.yesNoDontKnow = data),
                    this.getGenders().then(data => this.genders = data),
                    this.getSocioeconomicStatuses().then(data => this.socioeconomicStatuses = data),
                    this.getRelationshipStatuses().then(data => this.relationshipStatuses = data),
                    this.getRelationshipDisruptionFrequencies().then(data => this.relationshipDisruptionFrequencies = data),
                    this.getAgeUnits().then(data => this.ageUnits = data),
                    this.getWhereaboutsObjects().then(data => this.whereaboutsObjects = data),
                    this.getMemoryAids().then(data => this.memoryAids = data),
                    this.getReadingIssues().then(data => this.readingIssues = data),
                    this.getWeightChangeTypes().then(data => this.weightChangeTypes = data),
                    this.getCognitiveChangeTypes().then(data => this.cognitiveChangeTypes = data),
                    this.getMoodChangeTypes().then(data => this.moodChangeTypes = data),
                    this.getTravelIssues().then(data => this.travelIssues = data),
                    this.getTravelPreferences().then(data => this.travelPreferences = data),
                    this.getCurrentStateAbilities().then(data => this.currentStateAbilities = data),
                    this.getCurrentStateIssues().then(data => this.currentStateIssues = data),
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
            this.responses = getResponses(data.responses)
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

    getYesNo() {
        let data = [
            { "description": "Yes", "value": true, "isYes": true },
            { "description": "No", "value": false, "isNo": true },
            { "description": "Skip", "value": null, "isSkip": true }
        ];

        return getPromise(data);
    }

    getYesNoDontKnow() {
        let data = [
            { "description": "Yes", "value": true, "isYes": true },
            { "description": "No", "value": false, "isNo": true },
            { "description": "DK", "value": undefined, "isDontKnow": true },
            { "description": "Skip", "value": null, "isSkip": true }
        ];

        return getPromise(data);
    }

    getGenders() {
        let data = [
            { "abbreviation": "M", "description": "Male", "title": "Mr." },
            { "abbreviation": "F", "description": "Female", "title": "Ms." }
        ];

        return getPromise(data);
    }

    getSocioeconomicStatuses() {
        let data = [
            { "description": "Poor", "value": "poor", "format": function(context) { return `a household that ${context.pronoun.subject} would describe as being poor`; } },
            { "description": "Lower Class", "value": "lower class", "format": function(context) { return `a lower-class socioeconomic household`; } },
            { "description": "Middle Class", "value": "middle class", "format": function(context) { return `a middle-class socioeconomic household`; } },
            { "description": "Upper Class", "value": "upper class", "format": function(context) { return `an upper-class socioeconomic household`; } },
            { "description": "Rich", "value": "rich", "format": function(context) { return `a household that ${context.pronoun.subject} would describe as being rich`; } },
            { "description": "Skip", "value": null, "format": null }
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

    getRelationshipDisruptionFrequencies() {
        let data = [
            { "description": "Occasional (less than weekly)", "value": "occasionally" },
            { "description": "Frequent (once a week or more but not tolerable)", "value": "frequently" },
            { "description": "Constant (daily and intolerable)", "value": "constantly" }
        ];

        return getPromise(data);
    }

    getAgeUnits() {
        let data = [
            { "description": "Years", "value": "years" },
            { "description": "Months", "value": "months" }
        ];

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

    getSelfCareTasks() {
        let data = [
            { "description": "Personal care", "value": "personal care", "ability": null, "issues": [] },
            { "description": "Bathing", "value": "bathing", "ability": null, "issues": [] },
            { "description": "Grooming", "value": "grooming", "ability": null, "issues": [] },
            { "description": "Haircare", "value": "haircare", "ability": null, "issues": [] }
        ];

        return getPromise(data);
    }

    getCurrentStateAbilities() {
        let data = [
            { "description": "Unable", "value": "unable", "isUnable": true },
            { "description": "Partial", "value": "partially able", "isPartiallyAble": true },
            { "description": "Able", "value": "able", "isAble": true },
            { "description": "Skip", "value": null }
        ];

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

    getCurrentStateIssues() {
        let data = [
            { "description": "Physical", "value": "physical", "format": function(context) { return `physical issues`; } },
            { "description": "Pain", "value": "pain", "format": function(context) { return `pain`; } },
            { "description": "Apathy", "value": "apathy", "format": function(context) { return `apathy`; } },
            { "description": "Mental", "value": "mental", "format": function(context) { return `mental health issues`; } },
            { "description": "Cognitive", "value": "cognitive", "format": function(context) { return `cognition`; } }
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
        let data = [
            { "response": this.responses ? this.responses.personalHistory.growingUp.abuse.physical : null, "value": "physical" },
            { "response": this.responses ? this.responses.personalHistory.growingUp.abuse.sexual : null, "value": "sexual" },
            { "response": this.responses ? this.responses.personalHistory.growingUp.abuse.mental : null, "value": "mental" }
        ];

        return data.filter(item => item && item.response && item.response.isYes);
    }

    @computedFrom(
        'responses.personalHistory.growingUp.abuse.physical',
        'responses.personalHistory.growingUp.abuse.sexual',
        'responses.personalHistory.growingUp.abuse.mental'
    )
    get noAbuseTypes() {
        let data = [
            { "response": this.responses ? this.responses.personalHistory.growingUp.abuse.physical : null, "value": "physical" },
            { "response": this.responses ? this.responses.personalHistory.growingUp.abuse.sexual : null, "value": "sexual" },
            { "response": this.responses ? this.responses.personalHistory.growingUp.abuse.mental : null, "value": "mental" }
        ];

        return data.filter(item => item && item.response && item.response.isNo);
    }

    @computedFrom(
        'responses.personalHistory.growingUp.abuse.physical',
        'responses.personalHistory.growingUp.abuse.sexual',
        'responses.personalHistory.growingUp.abuse.mental'
    )
    get noAbuseGrowingUp() {
        let all = [
            this.responses ? this.responses.personalHistory.growingUp.abuse.physical : null,
            this.responses ? this.responses.personalHistory.growingUp.abuse.sexual : null,
            this.responses ? this.responses.personalHistory.growingUp.abuse.mental : null
        ].every(item => item && item.isNo);

        return all;
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
                : 0) : 0;
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

    @computedFrom(
        'responses.personalHistory.relationship.status'
    )
    get isMarriedOrCommonLaw() {
        let status = this.responses ? this.responses.personalHistory.relationship.status : null;

        return status && (status.isMarried || status.isCommonLaw);
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get yesEmotionalIssues() {
        let data = this.responses ? this.responses.psychological.emotional.filter(item => item.response != null && item.response.isYes) : [];

        return data;
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get noEmotionalIssues() {
        let data = this.responses ? this.responses.psychological.emotional.filter(item => item.response != null && item.response.isNo) : [];

        return data;
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get dontKnowEmotionalIssues() {
        let data = this.responses ? this.responses.psychological.emotional.filter(item => item.response != null && item.response.isDontKnow) : [];

        return data;
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get anyYesEmotionalIssues() {
        let any = this.yesEmotionalIssues.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get anyNoEmotionalIssues() {
        let any = this.noEmotionalIssues.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get anyDontKnowEmotionalIssues() {
        let any = this.dontKnowEmotionalIssues.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get anyEmotionalIssues() {
        let any = this.responses && this.responses.psychological.emotional.filter(item => item.response != null && item.response.value !== null).some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get yesDepressionSymptoms() {
        let data = this.responses ? this.responses.psychological.depressionSymptoms.filter(item => item.response != null && item.response.isYes) : [];

        return data;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get noDepressionSymptoms() {
        let data = this.responses ? this.responses.psychological.depressionSymptoms.filter(item => item.response != null && item.response.isNo) : [];

        return data;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get dontKnowDepressionSymptoms() {
        let data = this.responses ? this.responses.psychological.depressionSymptoms.filter(item => item.response != null && item.response.isDontKnow) : [];

        return data;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get anyDepressionSymptoms() {
        let any = this.responses && this.responses.psychological.depressionSymptoms.filter(item => item.response != null && item.response.value != null).some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get anyYesDepressionSymptoms() {
        let any = this.yesDepressionSymptoms.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get anyNoDepressionSymptoms() {
        let any = this.noDepressionSymptoms.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get anyDontKnowDepressionSymptoms() {
        let any = this.dontKnowDepressionSymptoms.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.worry'
    )
    get yesWorries() {
        let data = this.responses ? this.responses.psychological.worry.filter(item => item.response != null && item.response.isYes) : [];

        return data;
    }

    @computedFrom(
        'responses.psychological.worry'
    )
    get noWorries() {
        let data = this.responses ? this.responses.psychological.worry.filter(item => item.response != null && item.response.isNo) : [];

        return data;
    }

    @computedFrom(
        'responses.psychological.worry'
    )
    get anyWorries() {
        let any = this.responses && this.responses.psychological.worry.filter(item => item.response != null && item.response.value != null).some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.worry'
    )
    get anyYesWorries() {
        let any = this.yesWorries.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.worry'
    )
    get anyNoWorries() {
        let any = this.noWorries.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.worry'
    )
    get worriesAboutFinances() {
        let worry = this.yesWorries.some(item => item.isFinances);

        return worry;
    }

    @computedFrom(
        'responses.psychological.hallucinationsAuditory',
        'responses.psychological.hallucinationsVisual',
        'responses.psychological.hallucinationsCommand'
    )
    get hallucinationCharacteristics() {
        let data = [
            { "response": this.responses ? this.responses.psychological.hallucinationsAuditory : null, "value": function(context) { return `auditory`; } },
            { "response": this.responses ? this.responses.psychological.hallucinationsVisual : null, "value": function(context) { return `visual`; } },
            { "response": this.responses ? this.responses.psychological.hallucinationsCommand : null, "value": function(context) { return `command`; } }
        ].filter(item => item.response !== null && item.response.isYes);

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

    @computedFrom(
        'responses.psychological.travel.travelIssues'
    )
    get anyTravelIssues() {
        let any = this.responses && this.responses.psychological.travel.travelIssues.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.memory.visual.forgetWhereaboutsOf'
    )
    get anyForgottenWhereaboutsObjects() {
        let any =
            this.responses &&
            this.responses.neuropsychological.memory.visual.forgetWhereaboutsOfObjects.value &&
            this.responses.neuropsychological.memory.visual.forgetWhereaboutsOf.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.memory.aids.aidsUsed'
    )
    get anyNonFamilyMemoryAidsUsed() {
        let any = this.responses && this.responses.neuropsychological.memory.aids.aidsUsed.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.language.lostInConversations.response',
        'responses.neuropsychological.language.tipOfTongueIssues.response',
        'responses.neuropsychological.language.repeatingYourself.response',
        'responses.neuropsychological.language.askingOthersToRepeat.response',
        'responses.neuropsychological.language.filtering.response',
        'responses.neuropsychological.language.wordSubstitution.response'
    )
    get selectedLanguageIssues() {
        let data = this.getLanguageIssues().filter(item => item.response != null && item.response.value);

        return data;
    }

    @computedFrom(
        'responses.neuropsychological.language.lostInConversations.response',
        'responses.neuropsychological.language.tipOfTongueIssues.response',
        'responses.neuropsychological.language.repeatingYourself.response',
        'responses.neuropsychological.language.askingOthersToRepeat.response',
        'responses.neuropsychological.language.filtering.response',
        'responses.neuropsychological.language.wordSubstitution.response'
    )
    get anySelectedLanguageIssues() {
        let any = this.selectedLanguageIssues.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.language.lostInConversations.response',
        'responses.neuropsychological.language.tipOfTongueIssues.response',
        'responses.neuropsychological.language.repeatingYourself.response',
        'responses.neuropsychological.language.askingOthersToRepeat.response',
        'responses.neuropsychological.language.filtering.response',
        'responses.neuropsychological.language.wordSubstitution.response'
    )
    get unselectedLanguageIssues() {
        let data = this.getLanguageIssues().filter(item => item.response != null && item.response.value === false);

        return data;
    }

    getLanguageIssues() {
        if (!this.responses) {
            return [];
        }

        let data = [
            this.responses.neuropsychological.language.lostInConversations,
            this.responses.neuropsychological.language.tipOfTongueIssues,
            this.responses.neuropsychological.language.repeatingYourself,
            this.responses.neuropsychological.language.askingOthersToRepeat,
            this.responses.neuropsychological.language.filtering,
            this.responses.neuropsychological.language.wordSubstitution
        ];

        return data;
    }

    @computedFrom(
        'responses.neuropsychological.language.lostInConversations.response',
        'responses.neuropsychological.language.tipOfTongueIssues.response',
        'responses.neuropsychological.language.repeatingYourself.response',
        'responses.neuropsychological.language.askingOthersToRepeat.response',
        'responses.neuropsychological.language.filtering.response',
        'responses.neuropsychological.language.wordSubstitution.response'
    )
    get anyUnselectedLanguageIssues() {
        let any = this.unselectedLanguageIssues.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.visualSpatial.balanceIssues.response',
        'responses.neuropsychological.visualSpatial.seizures.response',
        'responses.neuropsychological.visualSpatial.weaknessInHands.response',
        'responses.neuropsychological.visualSpatial.fainting.response',
        'responses.neuropsychological.visualSpatial.dizzinessIssues.response',
        'responses.neuropsychological.visualSpatial.lightSensitivity.response',
        'responses.neuropsychological.visualSpatial.tinnitus.response',
        'responses.neuropsychological.visualSpatial.noiseSensitivity.response',
        'responses.neuropsychological.visualSpatial.changeInTaste.response',
        'responses.neuropsychological.visualSpatial.blurryVision.response',
        'responses.neuropsychological.visualSpatial.changeInSmell.response',
        'responses.neuropsychological.visualSpatial.doubleVision.response'
    )
    get anySelectedVisualSpatialIssues() {
        return this.selectedVisualSpatialIssues.some(item => item);
    }

    @computedFrom(
        'responses.neuropsychological.visualSpatial.balanceIssues.response',
        'responses.neuropsychological.visualSpatial.seizures.response',
        'responses.neuropsychological.visualSpatial.weaknessInHands.response',
        'responses.neuropsychological.visualSpatial.fainting.response',
        'responses.neuropsychological.visualSpatial.dizzinessIssues.response',
        'responses.neuropsychological.visualSpatial.lightSensitivity.response',
        'responses.neuropsychological.visualSpatial.tinnitus.response',
        'responses.neuropsychological.visualSpatial.noiseSensitivity.response',
        'responses.neuropsychological.visualSpatial.changeInTaste.response',
        'responses.neuropsychological.visualSpatial.blurryVision.response',
        'responses.neuropsychological.visualSpatial.changeInSmell.response',
        'responses.neuropsychological.visualSpatial.doubleVision.response'
    )
    get anyUnselectedVisualSpatialIssues() {
        return this.unselectedVisualSpatialIssues.some(item => item);
    }

    @computedFrom(
        'responses.neuropsychological.visualSpatial.balanceIssues.response',
        'responses.neuropsychological.visualSpatial.seizures.response',
        'responses.neuropsychological.visualSpatial.weaknessInHands.response',
        'responses.neuropsychological.visualSpatial.fainting.response',
        'responses.neuropsychological.visualSpatial.dizzinessIssues.response',
        'responses.neuropsychological.visualSpatial.lightSensitivity.response',
        'responses.neuropsychological.visualSpatial.tinnitus.response',
        'responses.neuropsychological.visualSpatial.noiseSensitivity.response',
        'responses.neuropsychological.visualSpatial.changeInTaste.response',
        'responses.neuropsychological.visualSpatial.blurryVision.response',
        'responses.neuropsychological.visualSpatial.changeInSmell.response',
        'responses.neuropsychological.visualSpatial.doubleVision.response'
    )
    get selectedVisualSpatialIssues() {
        return this.getVisualSpatialIssues().filter(item => item.response !== null && item.response.value);
    }

    @computedFrom(
        'responses.neuropsychological.visualSpatial.balanceIssues.response',
        'responses.neuropsychological.visualSpatial.seizures.response',
        'responses.neuropsychological.visualSpatial.weaknessInHands.response',
        'responses.neuropsychological.visualSpatial.fainting.response',
        'responses.neuropsychological.visualSpatial.dizzinessIssues.response',
        'responses.neuropsychological.visualSpatial.lightSensitivity.response',
        'responses.neuropsychological.visualSpatial.tinnitus.response',
        'responses.neuropsychological.visualSpatial.noiseSensitivity.response',
        'responses.neuropsychological.visualSpatial.changeInTaste.response',
        'responses.neuropsychological.visualSpatial.blurryVision.response',
        'responses.neuropsychological.visualSpatial.changeInSmell.response',
        'responses.neuropsychological.visualSpatial.doubleVision.response'
    )
    get unselectedVisualSpatialIssues() {
        return this.getVisualSpatialIssues().filter(item => item.response !== null && item.response.value === false);
    }

    getVisualSpatialIssues() {
        if (!this.responses) {
            return [];
        }

        let data = [
            this.responses.neuropsychological.visualSpatial.balanceIssues,
            this.responses.neuropsychological.visualSpatial.seizures,
            this.responses.neuropsychological.visualSpatial.weaknessInHands,
            this.responses.neuropsychological.visualSpatial.fainting,
            this.responses.neuropsychological.visualSpatial.dizzinessIssues,
            this.responses.neuropsychological.visualSpatial.lightSensitivity,
            this.responses.neuropsychological.visualSpatial.tinnitus,
            this.responses.neuropsychological.visualSpatial.noiseSensitivity,
            this.responses.neuropsychological.visualSpatial.changeInTaste,
            this.responses.neuropsychological.visualSpatial.blurryVision,
            this.responses.neuropsychological.visualSpatial.changeInSmell,
            this.responses.neuropsychological.visualSpatial.doubleVision,
            this.responses.neuropsychological.atypical.itchyFingernails,
            this.responses.neuropsychological.atypical.blackAndWhiteTransientVision
        ];

        return data;
    }
    
    @computedFrom(
        'responses.neuropsychological.atypical.itchyFingernails.response',
        'responses.neuropsychological.atypical.blackAndWhiteTransientVision.response'
    )
    get selectedAtypicalSymptomology() {
        return this.getAtypicalSymptomology().filter(item => item.response !== null && item.response.value);
    }

    @computedFrom(
        'responses.neuropsychological.atypical.itchyFingernails.response',
        'responses.neuropsychological.atypical.blackAndWhiteTransientVision.response'
    )
    get anySelectedAtypicalSymptomology() {
        return this.selectedAtypicalSymptomology.some(item => item);
    }

    getAtypicalSymptomology() {
        if (!this.responses) {
            return [];
        }

        let data = [
            this.responses.neuropsychological.atypical.itchyFingernails,
            this.responses.neuropsychological.atypical.blackAndWhiteTransientVision
        ];

        return data;
    }

    @computedFrom(
        'responses.neuropsychological.executive.issues.multiTasking.response',
        'responses.neuropsychological.executive.issues.harderToMultiTask.response',
        'responses.neuropsychological.executive.issues.organization.response',
        'responses.neuropsychological.executive.issues.planning.response',
        'responses.neuropsychological.executive.issues.decisionMaking.response',
        'responses.neuropsychological.executive.issues.problemSolving.response'
    )
    get anySelectedExecutiveFunctionIssues() {
        return this.selectedExecutiveFunctionIssues.some(item => item);
    }

    @computedFrom(
        'responses.neuropsychological.executive.issues.multiTasking.response',
        'responses.neuropsychological.executive.issues.harderToMultiTask.response',
        'responses.neuropsychological.executive.issues.organization.response',
        'responses.neuropsychological.executive.issues.planning.response',
        'responses.neuropsychological.executive.issues.decisionMaking.response',
        'responses.neuropsychological.executive.issues.problemSolving.response'
    )
    get anyUnselectedExecutiveFunctionIssues() {
        return this.unselectedExecutiveFunctionIssues.some(item => item);
    }

    @computedFrom(
        'responses.neuropsychological.executive.issues.multiTasking.response',
        'responses.neuropsychological.executive.issues.harderToMultiTask.response',
        'responses.neuropsychological.executive.issues.organization.response',
        'responses.neuropsychological.executive.issues.planning.response',
        'responses.neuropsychological.executive.issues.decisionMaking.response',
        'responses.neuropsychological.executive.issues.problemSolving.response'
    )
    get selectedExecutiveFunctionIssues() {
        let data = this.getExecutiveFunctionIssues().filter(item => item.response !== null && item.response.value);

        return data;
    }

    @computedFrom(
        'responses.neuropsychological.executive.issues.multiTasking.response',
        'responses.neuropsychological.executive.issues.organization.response',
        'responses.neuropsychological.executive.issues.planning.response',
        'responses.neuropsychological.executive.issues.decisionMaking.response',
        'responses.neuropsychological.executive.issues.problemSolving.response'
    )
    get unselectedExecutiveFunctionIssues() {
        let data = this.getExecutiveFunctionIssues().filter(item => item.response !== null && item.response.value === false);

        return data;
    }

    getExecutiveFunctionIssues() {
        if (!this.responses) {
            return [];
        }

        let data = [
            this.responses.neuropsychological.executive.issues.multiTasking,
            this.responses.neuropsychological.executive.issues.harderToMultiTask,
            this.responses.neuropsychological.executive.issues.planning,
            this.responses.neuropsychological.executive.issues.organization,
            this.responses.neuropsychological.executive.issues.decisionMaking,
            this.responses.neuropsychological.executive.issues.problemSolving
        ];

        return data;
    }

    @computedFrom(
        'responses.neuropsychological.executive.inappropriateSocialBehaviorYellingSwearing.response',
        'responses.neuropsychological.executive.inappropriateSocialBehaviorViolence.response',
        'responses.neuropsychological.executive.inappropriateSocialBehaviorSexual.response'
    )
    get selectedInappropriateSocialBehavior() {
        let data = this.getInappropriateSocialBehaviors().filter(item => item.response !== null && item.response.value);

        return data;
    }

    getInappropriateSocialBehaviors() {
        if (!this.responses) {
            return [];
        }

        let data = [
            this.responses.neuropsychological.executive.inappropriateSocialBehaviorYellingSwearing,
            this.responses.neuropsychological.executive.inappropriateSocialBehaviorViolence,
            this.responses.neuropsychological.executive.inappropriateSocialBehaviorSexual
        ];

        return data;
    }

    any(items) {
        let any = items && items.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.currentState.alone.issues'
    )
    get aloneIssues() {
        let aloneAbilityProblem =
            this.responses &&
            this.responses.neuropsychological.currentState.alone.ability &&
            (this.responses.neuropsychological.currentState.alone.ability.isUnable ||
            this.responses.neuropsychological.currentState.alone.ability.isPartiallyAble);

        let data = aloneAbilityProblem ? this.responses.neuropsychological.currentState.alone.issues.filter(item => aloneAbilityProblem) : [];

        return data;
    }

    @computedFrom(
        'responses.neuropsychological.currentState.alone.issues'
    )
    get anyAloneIssues() {
        let any = this.aloneIssues.some(item => item);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.currentState.travel.before',
        'responses.neuropsychological.currentState.travel.current',
        'responses.neuropsychological.currentState.travel.taxi'
    )
    get anyCurrentStateTravelAbility() {
        if (!this.responses) {
            return [];
        }

        let data = [
            this.responses.neuropsychological.currentState.travel.before,
            this.responses.neuropsychological.currentState.travel.current,
            this.responses.neuropsychological.currentState.travel.taxi
        ];

        let any = data.some(item => item && item.value);

        return any;
    }

    @computedFrom(
        'responses.neuropsychological.currentState.preAccidentRecreationalActivities'
    )
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
    
    addAloneIssue() {
        this.responses.neuropsychological.currentState.alone.issues.push("");
    }

    addPreAccidentRecreationalActivity() {
        this.responses.neuropsychological.currentState.preAccidentRecreationalActivities.push("");
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

    getItemValueForPronoun(item, pronoun) {
        return item.value(pronoun);
    }

    getItemValue(item) {
        return item.value;
    }

    getItemDescription(item) {
        return item.description;
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
    return JSON.stringify(responses, replacer, 2);
}

function getResponses(responsesData) {
    return responsesData ? JSON.parse(responsesData, reviver) : getNewResponses();
}

function getNewResponses() {
    return {
        "version": "1",
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
                "howMany": 0,
                "ages": []
            },
            "sisters": {
                "howMany": 0,
                "ages": []
            },
            "birthPosition": null,
            "familyHistoryOfNeurologicalOrPsychiatricDisease": null,
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
                    "howMany": 0,
                    "ages": []
                },
                "daughters": {
                    "howMany": 0,
                    "ages": []
                },
                "howManyLiveWithYou": null
            },
            "isFamilySupportive": null,
            "relationshipDisruptionDueToPsychProblems": null,
            "extentOfDisruption": null
        },
        "psychological": {
            "emotional": [
                { "description": "Sadness", "response": null, "value": "sadness", "format": function(context) { return `sadness`; } },
                { "description": "Overwhelmed", "response": null, "value": "overwhelmed", "format": function(context) { return `feeling of being overwhelmed`; } },
                { "description": "Hopelessness","response": null, "value": "hopelessness", "format": function(context) { return `hopelessness`; } },
                { "description": "Depression", "response": null, "value": "depression", "format": function(context) { return `depression`; } },
                { "description": "Helplessness", "response": null, "value": "helplessness", "format": function(context) { return `helplessness`; } },
                { "description": "Labile", "response": null, "value": "labile", "format": function(context) { return `a rapidly changing mood`; } },
                { "description": "Worthlessness", "response": null, "value": "worthlessness", "format": function(context) { return `worthlessness`; } },
                { "description": "Frustrated", "response": null, "value": "frustrated", "format": function(context) { return `frustration`; } },
                { "description": "Guilt", "response": null, "value": "guilt", "format": function(context) { return `guilt`; } },
                { "description": "Withdrawn", "response": null, "value": "withdrawn", "format": function(context) { return `social withdrawal`; } },
                { "description": "Dependency", "response": null, "value": "dependency", "format": function(context) { return `feeling of dependence on others`; } },
                { "description": "Irritable", "response": null, "value": "irritable", "format": function(context) { return `irritability`; } },
                { "description": "Anhedonia", "response": null, "value": "anhedonia", "format": function(context) { return `an inability to feel pleasure`; } },
                { "description": "Burden", "response": null, "value": "burden", "format": function(context) { return `issues with feeling like a burden on others`; } },
                { "description": "Apathy", "response": null, "value": "apathy", "format": function(context) { return `lack of interest`; } },
                { "description": "Amotivation", "response": null, "value": "amotivation", "format": function(context) { return `lack of motivation`; } }
            ],
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
                { "description": "More irritable?", "response": null, "value": "more irritable", "format": function(context) { return `more irritable`; } },
                { "description": "Easily upset?", "response": null, "value": "easily upset", "format": function(context) { return `less tolerant`; } },
                { "description": "Less tolerant?", "response": null, "value": "less tolerant", "format": function(context) { return `easily upset`; } },
                { "description": "Less patient?", "response": null, "value": "less patient", "format": function(context) { return `less patient`; } }
            ],
            "neurosisSymptoms": {
                "anxiety": null,
                "stress": null,
                "inabilityToRelax": null,
                "fearOfWorst": null
            },
            "worry": [
                { "description": "Future", "response": null, "value": "future", "format": function(context) { return `future`; } },
                { "description": "Recovery", "response": null, "value": "recovery", "format": function(context) { return `recovery`; } },
                { "description": "Finances", "response": null, "value": "finances", "format": function(context) { return `finances`; }, "isFinances": true }
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
            "travel": {
                "abilityToTravel": null,
                "travelIssues": [],
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
                    "forgetWhereaboutsOf": []
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
            "language": {
                "lostInConversations": { "response": null, "value": "lost in conversations", "format": function(pronoun) { return `easily getting lost in conversations`; } },
                "tipOfTongueIssues": { "response": null, "value": "tip of tongue issues", "format": function(pronoun) { return `having tip of the tongue issues`; } },
                "repeatingYourself": { "response": null, "value": "repeating yourself", "format": function(pronoun) { return `times where ${pronoun.subject} repeats ${pronoun.object}self`; } },
                "askingOthersToRepeat": { "response": null, "value": "asking others to repeat", "format": function(pronoun) { return `times when ${pronoun.subject} asks others to repeat what they have said`; } },
                "filtering": { "response": null, "value": "filtering", "format": function(pronoun) { return `problems with filtering`; } },
                "wordSubstitution": { "response": null, "value": "word substitution", "format": function(pronoun) { return `times where ${pronoun.subject} tends to substitute words`; } }
            },
            "attention": {
                "abilityToFocus": null,
                "abilityToSustainAttention": null,
                "areMoreDistractible": null,
                "loseTrackWhenReading": null,
                "needToReRead": null,
                "readingIssues": [],
                "loseTrackWhenWatchingTv": null
            },
            "executive": {
                "issues": {
                    "multiTasking": {
                        "response": null,
                        "value": "multi-tasking",
                        "format": function(context) {
                            let x = `multi-task ${(
                                    context.responses.neuropsychological.executive.issues.harderToMultiTask.response && 
                                    context.responses.neuropsychological.executive.issues.harderToMultiTask.response.value
                                )
                                ? `(which ${context.pronoun.subject} now finds harder)` 
                                : ``}`;
                            
                            return x;
                        }
                    },
                    "harderToMultiTask": { "response": null, "value": "harder to multi-task", "format": function(context) { return ``; } },
                    "organization": { "response": null, "value": "organization", "format": function(context) { return `organize`; } },
                    "planning": { "response": null, "value": "planning", "format": function(context) { return `plan`; } },
                    "decisionMaking": { "response": null, "value": "decision making", "format": function(context) { return `make decisions`; } },
                    "problemSolving": { "response": null, "value": "problem solving", "format": function(context) { return `problem solve`; } }
                },
                "inappropriateSocialBehavior": null,
                "inappropriateSocialBehaviorYellingSwearing": { "response": null, "value": "yelling or swearing in public" },
                "inappropriateSocialBehaviorViolence": { "response": null, "value": "violence" },
                "inappropriateSocialBehaviorSexual": { "response": null, "value": "sexually inappropriate behaviour" }
            },
            "visualSpatial": {
                "balanceIssues": { "response": null, "value": "balance issues", "format": function(context) { return `balance issues`; } },
                "seizures": { "response": null, "value": "seizures", "format": function(context) { return `seizures`; } },
                "weaknessInHands": { "response": null, "value": "weakness in hands", "format": function(context) { return `weakness in ${context.pronoun.possessiveAdjective} hands`; } },
                "fainting": { "response": null, "value": "fainting", "format": function(context) { return `fainting`; } },
                "dizzinessIssues": { "response": null, "value": "dizziness issues", "format": function(context) { return `dizziness`; } },
                "lightSensitivity": { "response": null, "value": "light sensitivity", "format": function(context) { return `sensitivity to light`; } },
                "tinnitus": { "response": null, "value": "tinnitus", "format": function(context) { return `tinnitus`; } },
                "noiseSensitivity": { "response": null, "value": "noise sensitivity", "format": function(context) { return `sensitivity to noise`; } },
                "changeInTaste": { "response": null, "value": "change in taste", "format": function(context) { return `change in ${context.pronoun.possessiveAdjective} sense of taste`; } },
                "blurryVision": { "response": null, "value": "blurry vision", "format": function(context) { return `blurry vision`; } },
                "changeInSmell": { "response": null, "value": "change in smell", "format": function(context) { return `change in ${context.pronoun.possessiveAdjective} sense of smell`; } },
                "doubleVision": { "response": null, "value": "double vision", "format": function(context) { return `double vision`; } }
            },
            "atypical": {
                "itchyFingernails": { "response": null, "value": "itchy fingernails", "format": function(context) { return `itchy fingernails (atypical symptomology)`; } },
                "blackAndWhiteTransientVision": { "response": null, "value": "black and white transient vision", "format": function(context) { return `black and white transient vision (atypical symptomology)`; } }
            },
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
                    "skipHoursOfSleepBeforeAccident": false,
                    "hoursOfSleepBeforeAccident": null,
                    "skipHoursOfSleepCurrent": false,
                    "hoursOfSleepCurrent": null,
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
                "spendTime": null,
                "personalCare": { "ability": null, "issues": [] },
                "bathing": { "ability": null, "issues": [] },
                "grooming": { "ability": null, "issues": [] },
                "haircare": { "ability": null, "issues": [] },
                "indoorChores": { "ability": null, "issues": [] },
                "outdoorChores": { "ability": null, "issues": [] },
                "caregiving": { "ability": null, "issues": [] },
                "banking": { "ability": null, "issues": [] },
                "alone": {
                    "ability": null,
                    "issues": [""],
                    "inContactFrequently": null,
                    "contactFrequency": null
                },
                "travel": {
                    "before": null,
                    "current": null,
                    "taxi": null
                },
                "preAccidentRecreationalActivities": [
                    "",
                    "",
                    ""
                ],
                "leisureAbility": null,
                "leisureParticipationRate": null
            }
        }
    };
}