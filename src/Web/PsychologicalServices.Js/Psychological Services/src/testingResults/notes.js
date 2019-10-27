import {Context} from 'common/context';
import {inject} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {computedFrom} from 'aurelia-framework';

@inject(BindingSignaler, Context)
export class Notes {

    constructor(signaler, context) {
        this.signaler = signaler;
        this.context = context;

        this.claimant = null;
        this.pronoun = null;
        this.gender = null;
        
        this.responses = {
            "psychological": {
                "emotional": [],
                "selfHarm": {
                    "pastThoughts": { "response": null },
                    "currentThoughts": { "response": null },
                    "planToAct": { "response": null },
                    "toldDoctor": { "response": null },
                    "hurtSelfOnPurpose": { "response": null },
                    "attemptedToEndLife": { "response": null },
                    "interestedInTreatment": { "response": null }
                },
                "depressionSymptoms": [],
                "neurosisSymptoms": {
                    "anxiety": null,
                    "stress": null,
                    "inabilityToRelax": null,
                    "fearOfWorst": null
                },
                "worry": [],
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
                        "forgetWhereaboutsFrequently": null,
                        "forgetWhereaboutsOfObjects": null,
                        "forgetWhereaboutsOf": []
                    },
                    "working": {
                        "walkIntoRoomAndForgetWhyFrequently": null,
                        "loseTrackOfWhatYouWantedToSayFrequently": null
                    },
                    "aids": {
                        "useAids": null,
                        "aidsUsed": []
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
                    "lostInConversations": { "response": null, "value": function(pronoun) { return `easily getting lost in conversations`; } },
                    "tipOfTongueIssues": { "response": null, "value": function(pronoun) { return `having tip of the tongue issues`; } },
                    "repeatingYourself": { "response": null, "value": function(pronoun) { return `times where ${pronoun.subject} repeats ${pronoun.object}self`; } },
                    "askingOthersToRepeat": { "response": null, "value": function(pronoun) { return `times when ${pronoun.subject} asks others to repeat what they have said`; } },
                    "filtering": { "response": null, "value": function(pronoun) { return `problems with filtering`; } },
                    "wordSubstitution": { "response": null, "value": function(pronoun) { return `times where ${pronoun.subject} tends to substitute words`; } }
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
                            "value": function(context) {
                                let x = `multi-task ${(
                                        context.responses.neuropsychological.executive.issues.harderToMultiTask.response && 
                                        context.responses.neuropsychological.executive.issues.harderToMultiTask.response.value
                                    )
                                    ? `(which ${context.pronoun.subject} now finds harder)` 
                                    : ``}`;
                                
                                return x;
                            }
                        },
                        "harderToMultiTask": { "response": null, "value": function(context) { return ``; } },
                        "organization": { "response": null, "value": function(context) { return `organize`; } },
                        "planning": { "response": null, "value": function(context) { return `plan`; } },
                        "decisionMaking": { "response": null, "value": function(context) { return `make decisions`; } },
                        "problemSolving": { "response": null, "value": function(context) { return `problem solve`; } }
                    },
                    "inappropriateSocialBehavior": null,
                    "inappropriateSocialBehaviorYellingSwearing": { "response": null, "value": "yelling or swearing in public" },
                    "inappropriateSocialBehaviorViolence": { "response": null, "value": "violence" },
                    "inappropriateSocialBehaviorSexual": { "response": null, "value": "sexually inappropriate behaviour" }
                },
                "visualSpatial": {
                    "balanceIssues": { "response": null, "value": function(pronoun) { return `balance issues`; } },
                    "seizures": { "response": null, "value": function(pronoun) { return `seizures`; } },
                    "weaknessInHands": { "response": null, "value": function(pronoun) { return `weakness in ${pronoun.possessiveAdjective} hands`; } },
                    "fainting": { "response": null, "value": function(pronoun) { return `fainting`; } },
                    "dizzinessIssues": { "response": null, "value": function(pronoun) { return `dizziness`; } },
                    "lightSensitivity": { "response": null, "value": function(pronoun) { return `sensitivity to light`; } },
                    "tinnitus": { "response": null, "value": function(pronoun) { return `tinnitus`; } },
                    "noiseSensitivity": { "response": null, "value": function(pronoun) { return `sensitivity to noise`; } },
                    "changeInTaste": { "response": null, "value": function(pronoun) { return `change in ${pronoun.possessiveAdjective} sense of taste`; } },
                    "blurryVision": { "response": null, "value": function(pronoun) { return `blurry vision`; } },
                    "changeInSmell": { "response": null, "value": function(pronoun) { return `change in ${pronoun.possessiveAdjective} sense of smell`; } },
                    "doubleVision": { "response": null, "value": function(pronoun) { return `double vision`; } }
                },
                "atypical": {
                    "itchyFingernails": { "response": null, "value": function(pronoun) { return `itchy fingernails (atypical symptomology)`; } },
                    "blackAndWhiteTransientVision": { "response": null, "value": function(pronoun) { return `black and white transient vision (atypical symptomology)`; } }
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
                        "hoursOfSleepBeforeAccident": null,
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
                }
            }
        };

        this.pronouns = [];
        this.yesNo = [];
        this.yesNoDontKnow = [];
        this.genders = [];
        this.whereaboutsObjects = [];
        this.memoryAids = [];
        this.readingIssues = [];
        this.weightChangeTypes = [];
        this.cognitiveChangeTypes = [];
        this.moodChangeTypes = [];
        this.travelIssues = [];
        this.travelPreferences = [];

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
        
                return Promise.all([
                    this.getPronouns().then(data => this.pronouns = data),
                    this.getYesNo().then(data => this.yesNo = data),
                    this.getYesNoDontKnow().then(data => this.yesNoDontKnow = data),
                    this.getGenders().then(data => this.genders = data),
                    this.getWhereaboutsObjects().then(data => this.whereaboutsObjects = data),
                    this.getMemoryAids().then(data => this.memoryAids = data),
                    this.getReadingIssues().then(data => this.readingIssues = data),
                    this.getWeightChangeTypes().then(data => this.weightChangeTypes = data),
                    this.getCognitiveChangeTypes().then(data => this.cognitiveChangeTypes = data),
                    this.getMoodChangeTypes().then(data => this.moodChangeTypes = data),
                    this.getEmotionalIssues().then(data => this.responses.psychological.emotional = data),
                    this.getDepressionSymptoms().then(data => this.responses.psychological.depressionSymptoms = data),
                    this.getWorries().then(data => this.responses.psychological.worry = data),
                    this.getTravelIssues().then(data => this.travelIssues = data),
                    this.getTravelPreferences().then(data => this.travelPreferences = data)
                ]);
            });
    }

    claimantSelected(e) {
        let gender = e.detail.claimant.gender;

        this.gender = this.genders.find(g => {
            return g.abbreviation === gender;
        });

        this.genderChanged(this.gender);
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
            { "description": "Family List", "value": "family list" },
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
            { "description": "Don't know", "value": function(pronoun) { return `${pronoun.subject} does not know how much ${pronoun.possessiveAdjective} weight has changed`; } },
            { "description": "Increased", "value": function(pronoun) { return `${pronoun.possessiveAdjective} weight has changed, noting an increase of `; }, "isIncreaseOrDecrease": true },
            { "description": "Decreased", "value": function(pronoun) { return `${pronoun.possessiveAdjective} weight has changed, noting a decrease of `; }, "isIncreaseOrDecrease": true },
            { "description": "Fluctuated", "value": function(pronoun) { return `${pronoun.possessiveAdjective} weight has fluctuated`; } }
        ];

        return getPromise(data);
    }

    getCognitiveChangeTypes() {
        let data = [
            { "description": "Worse", "value": function(pronoun) { return `${pronoun.subject} feels that ${pronoun.possessiveAdjective} cognition is worse`; } },
            { "description": "Little improvement", "value": function(pronoun) { return `overall ${pronoun.subject} has seen little improvement`; } },
            { "description": "Same", "value": function(pronoun) { return `${pronoun.subject} feels that ${pronoun.possessiveAdjective} cognition is the same`; } },
            { "description": "Better", "value": function(pronoun) { return `${pronoun.subject} feels that ${pronoun.possessiveAdjective} cognitive state is better`; } },
            { "description": "Resolved", "value": function(pronoun) { return `${pronoun.subject} feels that any cognitive issues have resolved`; } },
            { "description": "Plateaued", "value": function(pronoun) { return `${pronoun.subject} feels that ${pronoun.possessiveAdjective} cognitive recovery has reached a plateau`; } },
            { "description": "Skip", "value": null }
        ];

        return getPromise(data);
    }

    getMoodChangeTypes() {
        let data = [
            { "description": "Worse", "value": function(pronoun) { return `${pronoun.subject} feels that ${pronoun.possessiveAdjective} mood is worse`; } },
            { "description": "Little improvement", "value": function(pronoun) { return `overall ${pronoun.subject} has seen little improvement`; } },
            { "description": "Same", "value": function(pronoun) { return `${pronoun.subject} feels that ${pronoun.possessiveAdjective} mood is the same`; } },
            { "description": "Better", "value": function(pronoun) { return `${pronoun.subject} feels that ${pronoun.possessiveAdjective} mood is better`; } },
            { "description": "Resolved", "value": function(pronoun) { return `${pronoun.subject} feels that any mood issues have resolved`; } },
            { "description": "Plateaued", "value": function(pronoun) { return `${pronoun.subject} feels that ${pronoun.possessiveAdjective} emotional recovery has reached a plateau`; } },
            { "description": "Skip", "value": null }
        ];

        return getPromise(data);
    }

    getEmotionalIssues() {
        let data = [
            { "description": "Sadness", "response": null, "value": function(context) { return `sadness`; } },
            { "description": "Overwhelmed", "response": null, "value": function(context) { return `feeling of being overwhelmed`; } },
            { "description": "Hopelessness","response": null, "value": function(context) { return `hopelessness`; } },
            { "description": "Depression", "response": null, "value": function(context) { return `depression`; } },
            { "description": "Helplessness", "response": null, "value": function(context) { return `helplessness`; } },
            { "description": "Labile", "response": null, "value": function(context) { return `a rapidly changing mood`; } },
            { "description": "Worthlessness", "response": null, "value": function(context) { return `worthlessness`; } },
            { "description": "Frustrated", "response": null, "value": function(context) { return `frustration`; } },
            { "description": "Guilt", "response": null, "value": function(context) { return `guilt`; } },
            { "description": "Withdrawn", "response": null, "value": function(context) { return `social withdrawal`; } },
            { "description": "Dependency", "response": null, "value": function(context) { return `feeling of dependence on others`; } },
            { "description": "Irritable", "response": null, "value": function(context) { return `irritability`; } },
            { "description": "Anhedonia", "response": null, "value": function(context) { return `an inability to feel pleasure`; } },
            { "description": "Burden", "response": null, "value": function(context) { return `issues with feeling like a burden on others`; } },
            { "description": "Apathy", "response": null, "value": function(context) { return `lack of interest`; } },
            { "description": "Amotivation", "response": null, "value": function(context) { return `lack of motivation`; } }
        ];

        return getPromise(data);
    }

    getDepressionSymptoms() {
        let data = [
            { "description": "More irritable?", "response": null, "value": function(context) { return `more irritable`; } },
            { "description": "Easily upset?", "response": null, "value": function(context) { return `less tolerant`; } },
            { "description": "Less tolerant?", "response": null, "value": function(context) { return `easily upset`; } },
            { "description": "Less patient?", "response": null, "value": function(context) { return `less patient`; } }
        ];

        return getPromise(data);
    }

    getWorries() {
        let data = [
            { "description": "Future", "response": null, "value": function(context) { return `future`; } },
            { "description": "Recovery", "response": null, "value": function(context) { return `recovery`; } },
            { "description": "Finances", "response": null, "value": function(context) { return `finances`; } }
        ];

        return getPromise(data);
    }

    getTravelIssues() {
        let data = [
            { "description": "Physical", "response": null, "value": function(context) { return `physical issues`; } },
            { "description": "Mental", "response": null, "value": function(context) { return `mental health issues`; } },
            { "description": "Cognitive", "response": null, "value": function(context) { return `cognitive state`; } }
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

    memoryVisualWhereaboutsObjectsChanged() {
        this.signaler.signal('memory-visual-whereabouts-objects-changed');
    }

    memoryAidsUsedChanged() {
        this.signaler.signal('memory-aids-used-changed');
    }

    languageIssuesChanged() {
        this.signaler.signal('language-issues-changed');
    }

    readingIssuesChanged() {
        this.signaler.signal('reading-issues-changed');
    }

    visualSpatialIssueChanged() {
        this.signaler.signal('visual-spatial-issue-changed');
    }

    executiveFunctionIssueChanged() {
        this.signaler.signal('executive-function-issue-changed');
    }

    inappropriateSocialBehaviorChanged() {
        this.signaler.signal('inappropriate-social-behavior-changed');
    }

    weightChangeAmountChanged() {
        this.signaler.signal('weight-change-amount-changed');
    }

    emotionalIssueChanged() {
        this.signaler.signal('emotional-issues-changed');
    }

    depressionSymptomChanged() {
        this.signaler.signal('depression-symptom-changed');
    }

    worryChanged() {
        this.signaler.signal('worry-changed');
    }

    hallucinationsChanged() {
        this.signaler.signal('hallucinations-changed');
    }

    travelChanged() {
        this.signaler.signal('travel-changed');
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get yesEmotionalIssues() {
        let data = this.responses.psychological.emotional.filter(item => item.response != null && item.response.isYes);

        return data;
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get noEmotionalIssues() {
        let data = this.responses.psychological.emotional.filter(item => item.response != null && item.response.isNo);

        return data;
    }

    @computedFrom(
        'responses.psychological.emotional'
    )
    get dontKnowEmotionalIssues() {
        let data = this.responses.psychological.emotional.filter(item => item.response != null && item.response.isDontKnow);

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
        let any = this.responses.psychological.emotional.filter(item => item.response != null && item.response.value !== null).some(item => item);

        return any;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get yesDepressionSymptoms() {
        let data = this.responses.psychological.depressionSymptoms.filter(item => item.response != null && item.response.isYes);

        return data;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get noDepressionSymptoms() {
        let data = this.responses.psychological.depressionSymptoms.filter(item => item.response != null && item.response.isNo);

        return data;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get dontKnowDepressionSymptoms() {
        let data = this.responses.psychological.depressionSymptoms.filter(item => item.response != null && item.response.isDontKnow);

        return data;
    }

    @computedFrom(
        'responses.psychological.depressionSymptoms'
    )
    get anyDepressionSymptoms() {
        let any = this.responses.psychological.depressionSymptoms.filter(item => item.response != null && item.response.value != null).some(item => item);

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
        let data = this.responses.psychological.worry.filter(item => item.response != null && item.response.isYes);

        return data;
    }

    @computedFrom(
        'responses.psychological.worry'
    )
    get noWorries() {
        let data = this.responses.psychological.worry.filter(item => item.response != null && item.response.isNo);

        return data;
    }

    @computedFrom(
        'responses.psychological.worry'
    )
    get anyWorries() {
        let any = this.responses.psychological.worry.filter(item => item.response != null && item.response.value != null).some(item => item);

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
        'responses.psychological.hallucinationsAuditory',
        'responses.psychological.hallucinationsVisual',
        'responses.psychological.hallucinationsCommand'
    )
    get hallucinationCharacteristics() {
        let data = [
            { "response": this.responses.psychological.hallucinationsAuditory, "value": function(context) { return `auditory`; } },
            { "response": this.responses.psychological.hallucinationsVisual, "value": function(context) { return `visual`; } },
            { "response": this.responses.psychological.hallucinationsCommand, "value": function(context) { return `command`; } }
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
    get yesTravelIssues() {
        let data = this.responses.psychological.travel.travelIssues.filter(item => item.response !== null && item.response.isYes);

        return data;
    }

    @computedFrom(
        'responses.psychological.travel.travelIssues'
    )
    get anyYesTravelIssues() {
        let any = this.yesTravelIssues.some(item => item);

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
        let data = [
            this.responses.neuropsychological.executive.inappropriateSocialBehaviorYellingSwearing,
            this.responses.neuropsychological.executive.inappropriateSocialBehaviorViolence,
            this.responses.neuropsychological.executive.inappropriateSocialBehaviorSexual
        ];

        return data;
    }

    getItemValueForContext(item, context) {
        return item.value(context);
    }

    getItemValueForPronoun(item, pronoun) {
        return item.value(pronoun);
    }

    getItemValue(item) {
        return item.value;
    }

    getItemName(item) {
        return item.name;
    }

    getItemDescription(item) {
        return item.description;
    }
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}