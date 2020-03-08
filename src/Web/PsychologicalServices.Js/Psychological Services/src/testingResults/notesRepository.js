import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';

@inject(DataRepository)
export class NotesRepository {

    constructor(dataRepository) {
        this.dataRepository = dataRepository;

    }

    searchAssessments(claimantId, companyId) {
        return this.dataRepository.searchAssessments({
			'claimantId': claimantId,
			'companyId': companyId
		});
    }
    
    getNotes(assessmentId) {
        return this.dataRepository.getAssessmentTestingResults(assessmentId, 'notes').then(data => {
            let x = {
                'assessment': data.assessment,
                'responses': getResponses(data.responses)
            };

            return getPromise(x);
        });
    }

    saveNotes(assessmentId, responses) {
        let responseData = getResponsesString(responses);

        return this.dataRepository.saveAssessmentTestingResults({
            "name": 'notes',
            "responses": responseData,
            "assessment": {
                "assessmentId": assessmentId
            }
        });
    }

    deleteNotes(assessmentId) {
        return this.dataRepository.deleteAssessmentTestingResults(assessmentId, 'notes');
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
    return "16";
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

function upgrade_15_to_16(responses) {
    let newResponses = getNewResponses();

    if (!responses.hasOwnProperty('interviewType')) {
        responses.interviewType = newResponses.interviewType;
    }

    if (!responses.hasOwnProperty('ltdInformation')) {
        responses.ltdInformation = newResponses.ltdInformation;
    }

    if (!responses.personalHistory.medical.hasOwnProperty('everUsedDrugs'))
    {
        responses.personalHistory.medical.everUsedDrugs = newResponses.personalHistory.medical.everUsedDrugs;
    }

    let tempNeurologicalOrPsychiatricDiseases = responses.personalHistory.neurologicalOrPsychiatricDiseases.map(x => {
        return {
            "self": x.self || null,
            "family": x.family || null,
            "familyMember": x.familyMember || null,
            "value": x.value || ""
        };
    })

    responses.personalHistory.neurologicalOrPsychiatricDiseases = tempNeurologicalOrPsychiatricDiseases;

    responses.version = "16";

    return responses;
}

function getNewResponses() {
    return {
        "version": getCurrentVersion(),
        "interviewType": "mva",
        "ltdInformation": null,
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
                { "self": null, "family": null, "familyMember": null, "value": "adhd" },
                { "self": null, "family": null, "familyMember": null, "value": "dementia" },
                { "self": null, "family": null, "familyMember": null, "value": "bipolar" },
                { "self": null, "family": null, "familyMember": null, "value": "schizophrenia" },
                { "self": null, "family": null, "familyMember": null, "value": "depression" },
                { "self": null, "family": null, "familyMember": null, "value": "anxiety" },
                { "self": null, "family": null, "familyMember": null, "value": "epilepsy" },
                { "self": null, "family": null, "familyMember": null, "value": "learningDisorder" }
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
                "everUsedDrugs": null,
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