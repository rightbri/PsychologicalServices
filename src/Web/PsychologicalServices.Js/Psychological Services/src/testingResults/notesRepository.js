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
        let data = {
            "M": {
                "gender": "M",
                "value": "M",
                "description": "Male",
                "format": function(context) { return `male`; },
                "subject": "he",
                "object": "him",
                "possessiveAdjective": "his",
                "possessivePronoun": "his"
            },
            "F": {
                "gender": "F",
                "value": "F",
                "description": "Female",
                "format": function(context) { return `female`; },
                "subject": "she",
                "object": "her",
                "possessiveAdjective": "her",
                "possessivePronoun": "hers"
            },
            "N": {
                "gender": "N",
                "value": "N",
                "description": "Neutral",
                "format": function(context) { return `neutral`; },
                "subject": "they",
                "object": "them",
                "possessiveAdjective": "their",
                "possessivePronoun": "theirs"
            },
            "U": {
                "gender": "U",
                "value": "U",
                "description": "Unknown",
                "format": function(context) { return `unknown`; },
                "subject": "they",
                "object": "them",
                "possessiveAdjective": "their",
                "possessivePronoun": "theirs"
            }
        };

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
            "yes": { "description": "Yes", "output": "Yes", "value": "yes", "isYes": true },
            "no": { "description": "No", "output": "No", "value": "no", "isNo": true },
            "dontKnow": { "description": "DK", "output": "Don't know", "value": "dontKnow", "isDontKnow": true },
            "skip": { "description": "Skip", "output": "", "value": "skip", "isSkip": true }
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
            { "abbreviation": "U", "description": "Unkonwn", "title": "Mx." }
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
            "years": { "description": "Years", "value": "years", "format": function(context) { return `year`; } },
            "months": { "description": "Months", "value": "months", "format": function(context) { return `month`; } }
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
            "finances": { "description": "Finances", "format": function(context) { return `finances`; }, "isFinances": true, "disabled": true }
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

    getSafetyConcerns() {
        let data = {
            "leftStoveOn": { "description": "Have you left the stove on?", format: function(context) { return `leaving the stove on`; }, formatPast: function(context) { return `left the stove on`; } },
            "leftOvenOn": { "description": "Have you left the oven on?", format: function(context) { return `leaving the oven on`; }, formatPast: function(context) { return `left the oven on`; } },
            "leftKeysInDoor": { "description": "Have you left keys in the door?", format: function(context) { return `leaving keys in the door`; }, formatPast: function(context) { return `left keys in the door`; } },
            "leftDoorUnlocked": { "description": "Have you accidentally left the door unlocked?", format: function(context) { return `accidentally leaving the door unlocked`; }, formatPast: function(context) { return `accidentally left the door unlocked`; } }
        };

        return getPromise(data);
    }

    getLanguageIssues() {
        let data = {
            "lostInConversations": { "description": "Easily lost in conversations?", "format": function(context) { return `feeling lost in conversations`; } },
            "tipOfTongueIssues": { "description": "Tip of the Tongue issues?", "format": function(context) { return `having tip of the tongue issues`; } },
            "repeatingYourself": { "description": "Repeating yourself?", "format": function(context) { return `times where ${context.pronoun.subject} ${context.verb(context.pronoun, "repeats|repeat")} ${context.pronoun.object}self`; } },
            "askingOthersToRepeat": { "description": "Asking others to repeat?", "format": function(context) { return `times when ${context.pronoun.subject} ${context.verb(context.pronoun, "asks|ask")} others to repeat what they have said`; } },
            "filtering": { "description": "Filtering?", "format": function(context) { return `problems with filtering`; } },
            "wordSubstitution": { "description": "Word substitution?", "format": function(context) { return `times where ${context.pronoun.subject} ${context.verb(context.pronoun, "tends|tend")} to substitute words`; } }
        };

        return getPromise(data);
    }

    getExecutiveIssues() {
        let data = {
            "multiTasking": {
                "description": "Multi-tasking",
                "format": function(context) { return `multi-task${context.harderToMultiTask ? ` (which ${context.pronoun.subject} now ${context.verb(context.pronoun, "finds|find")} harder)` : ``}`; }
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
            "don't know": { "description": "Don't know", "value": "don't know", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "does|do")} not know how much ${context.pronoun.possessiveAdjective} weight has changed`; } },
            "increased": { "description": "Increased", "value": "increased", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has changed, noting an increase of `; }, "isIncreaseOrDecrease": true },
            "decreased": { "description": "Decreased", "value": "decreased", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has changed, noting a decrease of `; }, "isIncreaseOrDecrease": true },
            "fluctuated": { "description": "Fluctuated", "value": "fluctuated", "format": function(context) { return `${context.pronoun.possessiveAdjective} weight has fluctuated`; } }
        };

        return getPromise(data);
    }

    getCognitiveChangeTypes() {
        let data = {
            "worse": { "description": "Worse", "value": "worse", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that ${context.pronoun.possessiveAdjective} cognition is worse`; } },
            "little improvement": { "description": "Little improvement", "value": "little improvement", "format": function(context) { return `overall ${context.pronoun.subject} ${context.verb(context.pronoun, "has|have")} seen little improvement`; } },
            "same": { "description": "Same", "value": "same", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that ${context.pronoun.possessiveAdjective} cognition is the same`; } },
            "better": { "description": "Better", "value": "better", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that ${context.pronoun.possessiveAdjective} cognitive state is better`; } },
            "resolved": { "description": "Resolved", "value": "resolved", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that any cognitive issues have resolved`; } },
            "plateaued": { "description": "Plateaued", "value": "plateaued", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that ${context.pronoun.possessiveAdjective} cognitive recovery has reached a plateau`; } },
            "skip": { "description": "Skip", "value": "skip", "format": function(context) { return ``; }, "isSkip": true }
        };

        return getPromise(data);
    }

    getMoodChangeTypes() {
        let data = {
            "worse": { "description": "Worse", "value": "worse", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that ${context.pronoun.possessiveAdjective} mood is worse`; } },
            "little improvement": { "description": "Little improvement", "value": "little improvement", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "has|have")} seen little improvement overall`; } },
            "same": { "description": "Same", "value": "same", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that ${context.pronoun.possessiveAdjective} mood is the same`; } },
            "better": { "description": "Better", "value": "better", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that ${context.pronoun.possessiveAdjective} mood is better`; } },
            "resolved": { "description": "Resolved", "value": "resolved", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that any mood issues have resolved`; } },
            "plateaued": { "description": "Plateaued", "value": "plateaued", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "feels|feel")} that ${context.pronoun.possessiveAdjective} emotional recovery has reached a plateau`; } },
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

    getCurrentStateTasks(version) {
        if (version && /\d+/.test(version) && parseInt(version, 10) >= 18) {
            let data = {
                "sleep": { "description": "Sleeping/Resting", "value": "sleep" },
                "groom": { "description": "Grooming  (Bathing, brushing teeth, shaving, etc.) ", "value": "groom" },
                "dressing": { "description": "Dressing (Pick your clothes, dressing/undressing yourself, etc.)", "value": "dressing" },
                "prepareBreakfast": { "description": "Prepare Breakfast/Lunch", "value": "prepareBreakfast" },
                "eatBreakfast": { "description": "Eat Breakfast/Lunch", "value": "eatBreakfast" },
                "travelToWork": { "description": "Travel to and from work/school", "value": "travelToWork" },
                "takeCareOfChildren": { "description": "Take care of the children/spending time with them", "value": "takeCareOfChildren" },
                "attendWork": { "description": "Work/Attend school", "value": "attendWork" },
                "runErrands": { "description": "Run errands (Banking, groceries, etc.)", "value": "runErrands" },
                "prepareDinner": { "description": "Prepare Dinner/Clean up after dinner", "value": "prepareDinner" },
                "eatDinner": { "description": "Eat Dinner", "value": "eatDinner" },
                "indoorChores": { "description": "Indoor Household chores (Dishes, laundry, etc.) ", "value": "indoorChores" },
                "outdoorChores": { "description": "Outdoor Chores (Gardening, snow removal, etc.)", "value": "outdoorChores" },
                "petCare": { "description": "Taking care of any pets or animals", "value": "petCare" },
                "exercise": { "description": "Exercise or go to the gym, or be active", "value": "exercise" },
                "read": { "description": "Reading", "value": "read" },
                "watchTv": { "description": "Watching television/movies ", "value": "watchTv" },
                "useInternet": { "description": "Use Internet/Send and get Emails/Text Messages", "value": "useInternet" },
                "financialTasks": { "description": "Perform financial tasks such as banking", "value": "financialTasks" },
                "socialActivities": { "description": "Social activities/games", "value": "socialActivities" },
                "volunteering": { "description": "Volunteering", "value": "volunteering" },
                "religiousActivities": { "description": "Religious Activities ", "value": "religiousActivities" },
                "vacation": { "description": "Travel/vacation", "value": "vacation" }
            };

            return getPromise(data);
        }
        else {
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
            "physiotherapist": { "description": "Physiotherapist", "value": "physiotherapist", "indefiniteArticle": "a", "format": function(context) { return `Physiotherapist`; } },
            "chiropractor": { "description": "Chiropractor", "value": "chiropractor", "indefiniteArticle": "a", "format": function(context) { return `Chiropractor`; } },
            "massageTherapist": { "description": "Massage Therapist", "value": "massageTherapist", "indefiniteArticle": "a", "format": function(context) { return `Massage Therapist`; } },
            "acupuncturist": { "description": "Acupuncturist", "value": "acupuncturist", "indefiniteArticle": "an", "format": function(context) { return `Acupuncturist`; } },
            "osteopathicProvider": { "description": "Osteopathic Provider", "value": "osteopathicProvider", "indefiniteArticle": "an", "format": function(context) { return `Osteopathic Provider`; } },
            "naturopathicProvider": { "description": "Naturopathic Provider", "value": "naturopathicProvider", "indefiniteArticle": "a", "format": function(context) { return `Naturopathic Provider`; } },
            "occupationalTherapist": { "description": "Occupational Therapist", "value": "occupationalTherapist", "indefiniteArticle": "an", "format": function(context) { return `Occupational Therapist`; } },
            "rehabilitationWorker": { "description": "Rehabilitation Worker", "value": "rehabilitationWorker", "indefiniteArticle": "a", "format": function(context) { return `Rehabilitation Worker`; } },
            "supportWorker": { "description": "Support Worker", "value": "supportWorker", "indefiniteArticle": "a", "format": function(context) { return `Support Worker`; } },
            "speechLanguagePathologist": { "description": "Speech Language Pathologist", "value": "speechLanguagePathologist", "indefiniteArticle": "a", "format": function(context) { return `Speech Language Pathologist`; } },
            "caseManager": { "description": "Case Manager", "value": "caseManager", "indefiniteArticle": "a", "format": function(context) { return `Case Manager`; } },
            "neuroOptometrist": { "description": "Neuro-Optometrist", "value": "neuroOptometrist", "indefiniteArticle": "a", "format": function(context) { return `Neuro-Optometrist`; } }
        };

        return getPromise(data);
    }

    getTreatmentPrograms() {
        let data = {
            "painProgram": { "description": "Pain Program", "value": "painProgram", "attendedQuestion": "have you attended", "attendedQuestionOutput": "Have you attended?", "indefiniteArticle": "a", "format": function(context) { return `Pain Program`; }, "isPainProgram": true },
            "driversRehab": { "description": "Driver's Rehab", "value": "driversRehab", "attendedQuestion": "have you completed any", "attendedQuestionOutput": "Have you completed any?", "indefiniteArticle": "", "format": function(context) { return `Driver's Rehab`; }, "isDriversRehab": true },
            "visualTherapy": { "description": "Visual therapy", "value": "visualTherapy", "attendedQuestion": "have you received any", "attendedQuestionOutput": "Have you received any?", "indefiniteArticle": "", "format": function(context) { return `Visual Therapy`; } },
            "vestibularTreatment": { "description": "Vestibular treatment", "value": "vestibularTreatment", "attendedQuestion": "have you received any", "attendedQuestionOutput": "Have you received any?", "indefiniteArticle": "", "format": function(context) { return `Vestibular therapy`; } }
        };

        return getPromise(data);
    }

    getInitialInjuriesAndSymptoms() {
        let data = {
            "fractures": { "description": "Fractures", "value": "fractures", "format": function(context) { return `Fractures` }, "enterDetailsForYes": true, "detailsQuestion": "Where?", "isFractures": true, "isSeparateOutput": true },
            "sti": { "description": "STI", "value": "sti", "format": function(context) { return `soft tissue injuries` } },
            "back": { "description": "Back pain", "value": "back", "format": function(context) { return `back pain` } },
            "neck": { "description": "Neck pain", "value": "neck", "format": function(context) { return `neck pain` } },
            "shoulder": { "description": "Shoulder pain", "value": "shoulder", "format": function(context) { return `shoulder pain` } },
            "lacerations": { "description": "Lacerations", "value": "lacerations", "format": function(context) { return `Lacerations` }, "isLacerations": true, "isSeparateOutput": true },
            "headaches": { "description": "Headache", "value": "headaches", "format": function(context) { return `a headache` } },
            "dizziness": { "description": "Dizziness", "value": "dizziness", "format": function(context) { return `dizziness` } },
            "nausea": { "description": "Nausea", "value": "nausea", "format": function(context) { return `nausea` } },
            "vomiting": { "description": "Vomiting", "value": "vomiting", "format": function(context) { return `vomiting` } },
            "tinnitus": { "description": "Tinnitus", "value": "tinnitus", "format": function(context) { return `tinnitus` } },
            "skip": { "description": "", "value": "skip" }
        };

        return getPromise(data);
    }

    getStudentSelfRatings() {
        let data = {
            "good": { "description": "Good", "value": "good", "format": function(context) { return `a good`; } },
            "average": { "description": "Average", "value": "average", "format": function(context) { return `an average`; } },
            "poor": { "description": "Poor", "value": "poor", "format": function(context) { return `a poor`; } },
            "excellent": { "description": "Excellent", "value": "excellent", "format": function(context) { return `an excellent`; } }
        };

        return getPromise(data);
    }

    getMedicalConditions() {
        let data = {
            "alchoholAbuse": { "description": "Alcohol Abuse", "value": "alchoholAbuse", "format": function(context) { return `alcohol abuse`; } },
            "cancer": { "description": "Cancer", "value": "cancer", "format": function(context) { return `cancer`; } },
            "cholesterol": { "description": "Cholesterol", "value": "cholesterol", "format": function(context) { return `cholesterol`; } },
            "diabetes": { "description": "Diabetes", "value": "diabetes", "format": function(context) { return `diabetes`; } },
            "fibromyalgia": { "description": "Fibromyalgia", "value": "fibromyalgia", "format": function(context) { return `fibromyalgia`; } },
            "heartDisease": { "description": "Heart Disease", "value": "heartDisease", "format": function(context) { return `heart disease`; } },
            "hypertension": { "description": "Hypertension", "value": "hypertension", "format": function(context) { return `hypertension`; } },
            "stroke": { "description": "Stroke", "value": "stroke", "format": function(context) { return `stroke`; } },
            "thyroidDisorder": { "description": "Thyroid Disorder", "value": "thyroidDisorder", "format": function(context) { return `thyroid disorder`; } },
            "other": { "description": "Other", "value": "other", "format": function(context) { return `other`; }, "isOther": true }
        };

        return getPromise(data);
    }

    getAbusedDrugs() {
        let data = {
            "alchohol": { "description": "Alcohol", "value": "alchohol", "format": function(context) { return `alcohol`; } },
            "tobacco": { "description": "Tobacco", "value": "tobacco", "format": function(context) { return `tobacco`; } },
            "thc": { "description": "THC/CBD without a prescription", "value": "thc", "format": function(context) { return `THC`; } },
            "streetDrugs": { "description": "Street drugs", "value": "streetDrugs", "format": function(context) { return `street drugs`; } },
            "prescriptionMeds": { "description": "Prescription medication that was not prescribed to you", "value": "prescriptionMeds", "format": function(context) { return `prescription medication that were not prescribed to ${context.pronoun.object}`; } }
        };

        return getPromise(data);
    }

    getPhysicalStates() {
        let data = {
            "excellent": { "description": "Excellent", "value": "excellent", "format": function(context) { return `excellent`; } },
            "good": { "description": "Good", "value": "good", "format": function(context) { return `good`; } },
            "fair": { "description": "Fair", "value": "fair", "format": function(context) { return `fair`; } },
            "stable": { "description": "Stable", "value": "stable", "format": function(context) { return `stable`; } },
            "poor": { "description": "Poor", "value": "poor", "format": function(context) { return `poor`; } }
        };

        return getPromise(data);
    }

    getPrognosis() {
        let data = {
            "good": { "description": "Good", "value": "good", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "has|have")} a good prognosis`; } },
            "fair": { "description": "Fair", "value": "fair", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "has|have")} a fair prognosis`; } },
            "poor": { "description": "Poor", "value": "poor", "format": function(context) { return `${context.pronoun.subject} ${context.verb(context.pronoun, "has|have")} a poor prognosis`; } },
            "chronic": { "description": "Chronic", "value": "chronic", "format": function(context) { return `${context.pronoun.possessiveAdjective} condition is chronic`; } },
            "plateaued": { "description": "Plateaued", "value": "plateaued", "format": function(context) { return `${context.pronoun.possessiveAdjective} recovery has plateaued`; } },
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
            "neededToRepeatQuestionsOrAnswers": { "description": "6.	Did I have to repeat the questions or choices for answers?", "value": "neededToRepeatQuestionsOrAnswers" },
            "claimantWordFindingOrStuttering": { "description": "7.	Did I notice any issues with word finding/stuttering? (N/A if translator)", "value": "claimantWordFindingOrStuttering", "isNaAllowed": true },
            "claimantIssuesRecallingPreviousState": { "description": "8.	Did the claimant having any issues recalling their previous state? (i.e. Education/work/health)", "value": "claimantIssuesRecallingPreviousState" },
            "claimantIssuesRecallingIncident": { "description": "9.	Did the claimant have any issues recalling the specific details of the incident?", "value": "claimantIssuesRecallingIncident" },
            "claimantIssuesRecallingTreatment": { "description": "10.	Did the claimant have any issues recalling their post-incident treatment?", "value": "claimantIssuesRecallingTreatment" },
            "claimantCriedWhenDiscussingIncident": { "description": "11.	During the interview did the claimant tear up when discussing the incident?", "value": "claimantCriedWhenDiscussingIncident" },
            "claimantCriedWhenDiscussingLifeChanges": { "description": "12.	During the interview did the claimant tear up when discussing any changes in their life?", "value": "claimantCriedWhenDiscussingLifeChanges" },
            "claimantRequestedBreakDuringInterview": { "description": "13.	Did the claimant request a break during the interview?", "value": "claimantRequestedBreakDuringInterview" },
            "claimantRemainedSeatedDuringInterview": { "description": "14.	Was the claimant able to remain seated during the interview without getting up to stretch?", "value": "claimantRemainedSeatedDuringInterview" },
            "claimantIssuesWithExecutiveFunctioning": { "description": "15.	Were any issues with executive functioning noted during the interview?", "value": "claimantIssuesWithExecutiveFunctioning" },
            "claimantAcceptedOfferForDebrief": { "description": "16.    Did they accept the offer for a debrief?", "value": "claimantAcceptedOfferForDebrief" },
            "claimantDeclinedToAnswerAnyQuestions": { "description": "17.   Did they decline to answer any questions?", "value": "claimantDeclinedToAnswerAnyQuestions" }
        };

        return getPromise(data);
    }

    getMonths() {
        let data = [
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        ];

        return getPromise(data);
    }

    getHeadacheDescriptions() {
        let data = {
            "dullAche": { "description": "Dull Ache", "value": "dullAche", "format": function(context) { return `a dull ache`; } },
            "piercing": { "description": "Piercing", "value": "piercing", "format": function(context) { return `piercing`; } },
            "pounding": { "description": "Pounding", "value": "pounding", "format": function(context) { return `pounding`; } },
            "pulsing": { "description": "Pulsing", "value": "pulsing", "format": function(context) { return `pulsing`; } },
            "squeezing": { "description": "Squeezing", "value": "squeezing", "format": function(context) { return `squeezing`; } },
            "throbbing": { "description": "Throbbing", "value": "throbbing", "format": function(context) { return `throbbing`; } }
        };

        return getPromise(data);
    }

    getHeadacheReliefActivities() {
        let data = {
            "medication": { "description": "Medication", "value": "medication", "format": function(context) { return `medication`; } },
            "rest": { "description": "Rest", "value": "rest", "format": function(context) { return `rest`; } },
            "darkness": { "description": "Darkness", "value": "darkness", "format": function(context) { return `darkness`; } }
        };

        return getPromise(data);
    }

    getHeadacheFrequencies() {
        let data = {
            "daily": { "description": "Daily", "value": "daily", "format": function(context) { return `occur daily`; } },
            "severalTimesAWeek": { "description": "Several time a week", "value": "severalTimesAWeek", "format": function(context) { return `occur several times a week`; } },
            "weekly": { "description": "Weekly", "value": "weekly", "format": function(context) { return `occur weekly`; } },
            "monthly": { "description": "Monthly", "value": "monthly", "format": function(context) { return `occur monthly`; } },
            "constantly": { "description": "Constantly", "value": "constantly", "format": function(context) { return `are constant`; } },
            "frequently": { "description": "Frequently", "value": "frequently", "format": function(context) { return `occur frequently`; } },
            "sometimes": { "description": "Sometimes", "value": "sometimes", "format": function(context) { return `occur sometimes`; } },
            "rarely": { "description": "Rarely", "value": "rarely", "format": function(context) { return `occur rarely`; } }
        };

        return getPromise(data);
    }

    getHeadacheFrequencies2() {
        let data = {
            "day": { "description": "per day", "value": "day", "format": function(context) { return `per day`; } },
            "week": { "description": "per week", "value": "week", "format": function(context) { return `per week`; } },
            "month": { "description": "per month", "value": "month", "format": function(context) { return `per month`; } },
            "year": { "description": "per year", "value": "year", "format": function(context) { return `per year`; } }
        };

        return getPromise(data);
    }

    getHobbies() {
        let data = {
            "artsCrafts": { "description": "Arts & Crafts", "value": "artsCrafts", "format": function(context) { return `arts & crafts`; } },
            "computer": { "description": "Computer/Tablet", "value": "computer", "format": function(context) { return `spending time on the computer/tablet`; } },
            "cooking": { "description": "Cooking", "value": "cooking", "format": function(context) { return `cooking`; } },
            "cycling": { "description": "Cycling", "value": "cycling", "format": function(context) { return `cycling`; } },
            "entertaining": { "description": "Entertaining/Hosting", "value": "entertaining", "format": function(context) { return `hosting/entertaining`; } },
            "gardening": { "description": "Gardening", "value": "gardening", "format": function(context) { return `gardening`; } },
            "outdoors": { "description": "Outdoor activities", "value": "outdoors", "format": function(context) { return `outdoor activities`; } },
            "musicListening": { "description": "Listening to music", "value": "musicListening", "format": function(context) { return `listening to music`; } },
            "gamePlaying": { "description": "Playing games", "value": "gamePlaying", "format": function(context) { return `playing games`; } },
            "musicPlaying": { "description": "Playing music", "value": "musicPlaying", "format": function(context) { return `playing music`; } },
            "reading": { "description": "Reading", "value": "reading", "format": function(context) { return `reading`; } },
            "motorcycleRiding": { "description": "Riding motorcycles", "value": "motorcycleRiding", "format": function(context) { return `riding motorcycles`; } },
            "running": { "description": "Running", "value": "running", "format": function(context) { return `running`; } },
            "shopping": { "description": "Shopping", "value": "shopping", "format": function(context) { return `shopping`; } },
            "socialMedia": { "description": "Social media", "value": "socialMedia", "format": function(context) { return `social media`; } },
            "friends": { "description": "Spending time with friends", "value": "friends", "format": function(context) { return `spending time with friends`; } },
            "family": { "description": "Spending time with family", "value": "family", "format": function(context) { return `spending time with family`; } },
            "swimming": { "description": "Swimming", "value": "swimming", "format": function(context) { return `swimming`; } },
            "watchingTv": { "description": "Watching TV", "value": "watchingTv", "format": function(context) { return `watching television`; } },
            "workingOut": { "description": "Working out", "value": "workingOut", "format": function(context) { return `working out`; } },
            "yoga": { "description": "Yoga", "value": "yoga", "format": function(context) { return `doing yoga`; } }
        };

        return getPromise(data);
    }

    getAccidentCategories() {
        let data = {
            "singleVehicleAccident": { "description": "Single Vehicle Accident", "value": "singleVehicleAccident", "format": function(context) { return `single vehicle accident`; } },
            "twoVehicleAccident": { "description": "Two Vehicle Accident", "value": "twoVehicleAccident", "format": function(context) { return `two vehicle accident`; } },
            "multipleVehicleAccident": { "description": "Multiple Vehicle Accident", "value": "multipleVehicleAccident", "format": function(context) { return `multiple vehicle accident`; } },
            "rearEndAccident": { "description": "Rear-end Accident", "value": "rearEndAccident", "format": function(context) { return `rear-end accident`; } },
            "tBoneCollision": { "description": "T-Bone Collision", "value": "tBoneCollision", "format": function(context) { return `T-bone collision`; } },
            "sideSwipe": { "description": "Side swipe", "value": "sideSwipe", "format": function(context) { return `side swipe accident`; } }
        };

        return getPromise(data);
    }

    getTreatmentSessionFormats() {
        let data = {
            "phone": { "description": "Over the Phone", "value": "phone", "format": function(context) { return `over the phone`; } },
            "inPerson": { "description": "In Person", "value": "inPerson", "format": function(context) { return `in person`; } },
            "virtual": { "description": "Virtually", "value": "virtual", "format": function(context) { return `virtually`; } },
            "other": { "description": "Other", "value": "other", "format": function(context) { return `other`; } },
            "skip": { "description": "Skip", "value": "skip", "format": function(context) { return `skip`; }, "isSkip": true }
        };

        return getPromise(data);
    }

    getCounsellingMethods() {
        let data = {
            "phone": { "description": "Over the Phone", "value": "phone", "format": function(context) { return `over the phone`; } },
            "inPerson": { "description": "In Person", "value": "inPerson", "format": function(context) { return `in person`; } },
            "virtual": { "description": "Virtually", "value": "virtual", "format": function(context) { return `virtually`; } },
            "other": { "description": "Other", "value": "other", "format": function(context) { return `other`; } },
            "skip": { "description": "Skip", "value": "skip", "format": function(context) { return `skip`; }, "isSkip": true }
        };

        return getPromise(data);
    }

    getHitHeadOnObjects() {
        let data = {
            "airbag": { "description": "Airbag", "value": "airbag", "format": function(context) { return `airbag`; } },
            "headRest": { "description": "Headrest", "value": "headRest", "format": function(context) { return `headrest`; } },
            "steeringWheel": { "description": "Steering wheel", "value": "steeringWheel", "format": function(context) { return `steering wheel`; } },
            "window": { "description": "Window", "value": "window", "format": function(context) { return `window`; } },
            "other": { "description": "Other", "value": "other", "format": function(context) { return `other`; }, "isOther": true }
        };

        return getPromise(data);
    }

    getIdentificationVerificationMethods() {
        let data = {
            "driversLicense": { "description": "Driver's Licence", "value": "driversLicense", "format": function(context) { return `driver’s licence`; } },
            "healthCard": { "description": "Health card", "value": "healthCard", "format": function(context) { return `health card`; } },
            "passport": { "description": "Passport", "value": "passport", "format": function(context) { return `passport`; } },
            "photocard": { "description": "Photocard", "value": "photocard", "format": function(context) { return `photocard`; } },
            "other": { "description": "Other", "value": "other", "format": function(context) { return `other`; } }
        };

        return getPromise(data);
    }

    getPanicAttackFrequencies() {
        let data = {
            "day": { "description": "per day", "value": "day", "format": function(context) { return `per day`; } },
            "week": { "description": "per week", "value": "week", "format": function(context) { return `per week`; } },
            "month": { "description": "per month", "value": "month", "format": function(context) { return `per month`; } },
            "year": { "description": "per year", "value": "year", "format": function(context) { return `per year`; } }
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
    return "41";
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

    let isFunc = false;

    try {
        isFunc = isFunction(eval(functionName));
    }
    catch (err) {
        console.log(err);
    }

    if (isFunc) {
        return eval(functionName)(responses);
    }
    else {
        responses.version = toVersion;

        return responses;
    }
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

function upgrade_16_to_17(responses) {
    let newResponses = getNewResponses();

    if (!responses.identification.hasOwnProperty('preferredPronoun')) {
        responses.identification.preferredPronoun = newResponses.identification.preferredPronoun;
    }
    
    responses.version = "17";

    return responses;
}

function upgrade_17_to_18(responses) {
    let newResponses = getNewResponses();
    
    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('betterSleepPriorToAccident')) {
        responses.neuropsychological.physical.sleep.betterSleepPriorToAccident = newResponses.neuropsychological.physical.sleep.betterSleepPriorToAccident;
    }

    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('amountOfSleepBeforeAccidentBetween')) {
        responses.neuropsychological.physical.sleep.amountOfSleepBeforeAccidentBetween = newResponses.neuropsychological.physical.sleep.amountOfSleepBeforeAccidentBetween;
    }

    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('amountOfSleepBeforeAccidentBetweenMin')) {
        responses.neuropsychological.physical.sleep.amountOfSleepBeforeAccidentBetweenMin = newResponses.neuropsychological.physical.sleep.amountOfSleepBeforeAccidentBetweenMin;
    }

    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('amountOfSleepBeforeAccidentBetweenMax')) {
        responses.neuropsychological.physical.sleep.amountOfSleepBeforeAccidentBetweenMax = newResponses.neuropsychological.physical.sleep.amountOfSleepBeforeAccidentBetweenMax;
    }

    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('amountOfSleepCurrentBetween')) {
        responses.neuropsychological.physical.sleep.amountOfSleepCurrentBetween = newResponses.neuropsychological.physical.sleep.amountOfSleepCurrentBetween;
    }

    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('amountOfSleepCurrentBetweenMin')) {
        responses.neuropsychological.physical.sleep.amountOfSleepCurrentBetweenMin = newResponses.neuropsychological.physical.sleep.amountOfSleepCurrentBetweenMin;
    }

    if (!responses.neuropsychological.physical.sleep.hasOwnProperty('amountOfSleepCurrentBetweenMax')) {
        responses.neuropsychological.physical.sleep.amountOfSleepCurrentBetweenMax = newResponses.neuropsychological.physical.sleep.amountOfSleepCurrentBetweenMax;
    }

    if (!responses.neuropsychological.physical.weight.hasOwnProperty('changeUnits')) {
        responses.neuropsychological.physical.weight.changeUnits = newResponses.neuropsychological.physical.weight.changeUnits;
    }

    responses.version = "18";

    return responses;
}

function upgrade_18_to_19(responses) {
    let newResponses = getNewResponses();
    
    if (!responses.neuropsychological.memory.hasOwnProperty('safetyConcerns')) {
        responses.neuropsychological.memory.safetyConcerns = newResponses.neuropsychological.memory.safetyConcerns;
    }

    responses.version = "19";

    return responses;
}

function upgrade_19_to_20(responses) {
    let newResponses = getNewResponses();

    if (!responses.personalHistory.hasOwnProperty('arrivalInCanadaType')) {
        responses.personalHistory.arrivalInCanadaType = newResponses.personalHistory.arrivalInCanadaType;
        responses.personalHistory.arrivalInCanadaYear = newResponses.personalHistory.arrivalInCanadaYear;
        responses.personalHistory.arrivalInCanadaAge = newResponses.personalHistory.arrivalInCanadaAge;
    }

    responses.version = "20";

    return responses;
}

function upgrade_20_to_21(responses) {
    let newResponses = getNewResponses();

    if (!responses.neuropsychological.physical.hasOwnProperty('other')) {
        responses.neuropsychological.physical.other = {
            "anyIssues": newResponses.neuropsychological.physical.other.anyIssues,
            "issues": newResponses.neuropsychological.physical.other.issues
        };
    }

    responses.version = "21";

    return responses;
}

function upgrade_39_to_40(responses) {
    let newResponses = getNewResponses();

    if (!responses.personalHistory.medical.sinceAccident.hasOwnProperty('injuries')) {
        responses.personalHistory.medical.sinceAccident.injuries = {
            "response": null,
            "details": ""
        };
    }

    if (!responses.personalHistory.medical.sinceAccident.hasOwnProperty('illnesses')) {
        responses.personalHistory.medical.sinceAccident.illnesses = {
            "response": null,
            "details": ""
        };
    }

    if (!responses.personalHistory.medical.beforeAccident.hasOwnProperty('medicalConditionOther')) {
        responses.personalHistory.medical.beforeAccident.medicalConditionOther = "";
    }

    responses.version = "40";

    return responses;
}

function upgrade_40_to_41(responses) {
    let newResponses = getNewResponses();

    for (let i = 0; i < responses.personalHistory.neurologicalOrPsychiatricDiseases.length; i++) {
        if (!responses.personalHistory.neurologicalOrPsychiatricDiseases[i].hasOwnProperty('selfNotes')) {
            responses.personalHistory.neurologicalOrPsychiatricDiseases[i].selfNotes = null;
        }
    }

    responses.version = "41";

    return responses;
}

function getNewResponses() {
    return {
        "version": getCurrentVersion(),
        "createdAtVersion": getCurrentVersion(),
        "interviewType": "mva",
        "ltdInformation": null,
        "identification": {
            "preferredPronoun": null,
            "verifiedWithId": null,
            "verificationMethod": {
                "method": null,
                "otherMethod": ""
            },
            "assistance": {
                "wearsGlasses": null,
                "usesDevices": null,
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
            "priorNightSleepWasGood": null,
            "priorNightSleepNotGoodIsTypical": null,
            "medications": [
                { "name": "", "purpose": "", "whenStarted": "", "usedAtTimeOfAccident": null }
            ],
            "takenMedicationBeforeAssessment": null
        },
        "accidentDetails": {
            "dateOfAccident": null,
            "timeOfAccident": {
                "dontKnow": false,
                "timeType": null,
                "generalValue": null,
                "generalModifier": null,
                "specificValue": null,
                "specificAmPm": null
            },
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
            "surgeryDetails": "",
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
            "fullIntactMemoryBeforeAndAfter": null,
            "lastMemoryBeforeImpact": "",
            "firstMemoryAfterImpact": "",
            "feltCouldHaveDied": null,
            "assessedByAmbulancePersonnel": null,
            "wentToHospital": null,
            "hospitalStayLength": {
                "dontKnow": false,
                "hours": "",
                "days": "",
                "weeks": "",
                "months": ""
            },
            "diagnosedWithConcussion": null,
            "givenConcussionProtocol": null,
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
            "stillAttendingCounselling": null,
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
                    "sessionFormatOther": "",
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
            { "value": "neededToRepeatQuestionsOrAnswers", "response": null },
            { "value": "claimantWordFindingOrStuttering", "response": null },
            { "value": "claimantIssuesRecallingPreviousState", "response": null },
            { "value": "claimantIssuesRecallingIncident", "response": null },
            { "value": "claimantIssuesRecallingTreatment", "response": null },
            { "value": "claimantCriedWhenDiscussingIncident", "response": null },
            { "value": "claimantCriedWhenDiscussingLifeChanges", "response": null },
            { "value": "claimantRequestedBreakDuringInterview", "response": null },
            { "value": "claimantRemainedSeatedDuringInterview", "response": null },
            { "value": "claimantIssuesWithExecutiveFunctioning", "response": null },
            { "value": "claimantAcceptedOfferForDebrief", "response": null },
            { "value": "claimantDeclinedToAnswerAnyQuestions", "response": null }
        ],
        "personalHistory": {
            "locationOfBirth": null,
            "arrivalInCanadaType": null,
            "skipArrivalInCanada": null,
            "arrivalInCanadaYear": null,
            "arrivalInCanadaAge": null,
            "languages": [""],
            "growingUp": {
                "abuse": {
                    "any": null,
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
                "employmentAreas": { "value": null, "skip": false, "dontKnow": false },
                "isRetired": null,
                "isDisabled": null
            },
            "mother": {
                "skip": null,
                "dontKnow": null,
                "age": { "value": null, "skip": false, "dontKnow": false },
                "isAlive": null,
                "causeOfDeath": { "value": null, "skip": false, "dontKnow": false },
                "yearOfDeath": { "value": null, "skip": false, "dontKnow": false },
                "educationLevel": { "value": null, "skip": false, "dontKnow": false },
                "employmentAreas": { "value": null, "skip": false, "dontKnow": false },
                "isRetired": null,
                "isDisabled": null
            },
            "didParentsSeparateOrDivorce": null,
            "skipAgeWhenParentsSeparated": null,
            "ageWhenParentsSeparated": { "value": null, "unit": null },
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
            "halfBrothers": {
                "skip": true,
                "skipAges": false,
                "howMany": 0,
                "ages": []
            },
            "halfSisters": {
                "skip": true,
                "skipAges": false,
                "howMany": 0,
                "ages": []
            },
            "stepBrothers": {
                "skip": true,
                "skipAges": false,
                "howMany": 0,
                "ages": []
            },
            "stepSisters": {
                "skip": true,
                "skipAges": false,
                "howMany": 0,
                "ages": []
            },
            "birthPosition": 0,
            "neurologicalOrPsychiatricDiseases": [
                { "self": null, "selfNotes": null, "family": null, "familyMember": null, "value": "adhd" },
                { "self": null, "selfNotes": null, "family": null, "familyMember": null, "value": "dementia" },
                { "self": null, "selfNotes": null, "family": null, "familyMember": null, "value": "bipolar" },
                { "self": null, "selfNotes": null, "family": null, "familyMember": null, "value": "schizophrenia" },
                { "self": null, "selfNotes": null, "family": null, "familyMember": null, "value": "depression" },
                { "self": null, "selfNotes": null, "family": null, "familyMember": null, "value": "anxiety" },
                { "self": null, "selfNotes": null, "family": null, "familyMember": null, "value": "epilepsy" },
                { "self": null, "selfNotes": null, "family": null, "familyMember": null, "value": "learningDisorder" }
            ],
            "relationship": {
                "status": null,
                "marriageLength": { "value": null, "unit": null },
                "dontKnowMarriageLength": false,
                "partnerAge": null,
                "dontKnowPartnerAge": false,
                "partnerJobTitleOrIndustry": null,
                "partnerJobTitle": null,
                "isAbusive": null,
                "previousRelationshipAbusive": null,
                "hadPriorSeriousRelationship": null,
                "priorSeriousRelationshipLength": { "value": null, "unit": null },
                "priorSeriousRelationshipReasonEnded": null
            },
            "children": {
                "any": null,
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
                "stepSons": {
                    "skip": true,
                    "skipAges": false,
                    "howMany": 0,
                    "ages": []
                },
                "stepDaughters": {
                    "skip": true,
                    "skipAges": false,
                    "howMany": 0,
                    "ages": []
                },
                "howManyLiveWithYou": null
            },
            "education": {
                "completedHighSchool": null,
                "lastCompletedGrade": "",
                "attendedPostSecondaryEducation": null,
                "yearsOfPostSecondaryEducation": null,
                "areaOfStudy": "",
                "selfRating": null,
                "dontKnowSelfRating": false,
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
                    "medicalConditionOther": "",
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
                    "injuries": {
                        "response": null,
                        "details": ""
                    },
                    "illnesses": {
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
                "everConvicted": {
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
                "hadMentalHealthCounselling": null,
                "anythingToAdd": null,
                "additionalInformation": ""
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
            "covid19": {
                "affectOnYou": null
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
                { "response": null, "value": "recovery" }//,
                //{ "response": null, "value": "finances" }
            ],
            "panicAttacksCurrent": null,
            "skipPanicAttackFrequency": false,
            "panicAttackFrequency": null,
            "panicAttackFrequencyExact": null,
            "panicAttackFrequencyBetween": null,
            "panicAttackFrequencyBetweenMin": null,
            "panicAttackFrequencyBetweenMax": null,
            "panicAttackClearTrigger": null,
            "panicAttackTriggersIncludeDiscussingTheAccident": null,
            "panicAttackTriggersIncludeBeingInOrAroundVehicles": null,
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
                "driverLicense": {
                    "haveLicense": null,
                    "isSuspended": null,
                    "suspensionType": null,
                    "medicallySuspendedDueToAccident": null
                },
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
                    "walkIntoRoomAndForgetWhyFrequently": null
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
                },
                "safetyConcerns": [
                    { "response": null, "value": "leftStoveOn" },
                    { "response": null, "value": "leftOvenOn" },
                    { "response": null, "value": "leftKeysInDoor" },
                    { "response": null, "value": "leftDoorUnlocked" }
                ]
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
                    "changeAmount": null,
                    "changeUnits": null
                },
                "energy": {
                    "lessEnergy": null,
                    "libidoAffected": null
                },
                "sleep": {
                    "sleepAffected": null,
                    "problemsSleepingPriorToAccident": null,
                    "betterSleepPriorToAccident": null,
                    "skipAmountOfSleepBeforeAccident": false,
                    "dontKnowAmountOfSleepBeforeAccident": false,
                    "amountOfSleepBeforeAccident": null,
                    "amountOfSleepBeforeAccidentBetween": false,
                    "amountOfSleepBeforeAccidentBetweenMin": null,
                    "amountOfSleepBeforeAccidentBetweenMax": null,
                    "skipAmountOfSleepCurrent": false,
                    "amountOfSleepCurrent": null,
                    "amountOfSleepCurrentBetween": false,
                    "amountOfSleepCurrentBetweenMin": null,
                    "amountOfSleepCurrentBetweenMax": null,
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
                    "skipHeadacheDescription": false,
                    "headacheDescription": [],
                    "skipHeadacheReliefActivities": false,
                    "headacheReliefActivities": [],
                    "skipHeadacheFrequency": false,
                    "headacheFrequencyConstant": null,
                    "headacheFrequency": null,
                    "headacheFrequencyExact": null,
                    "headacheFrequencyBetween": null,
                    "headacheFrequencyBetweenMin": null,
                    "headacheFrequencyBetweenMax": null,
                    "headachesFluctuateWithActivityLevel": null,
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
                "other": {
                    "anyIssues": null,
                    "issues": [""]
                },
                "changes": {
                    "changeInCognition": null,
                    "changeInMood": null
                }
            },
            "currentState": {
                "tasks": [
                    { "ability": null, "issues": [], "isNA": false, "value": "sleep" },
                    { "ability": null, "issues": [], "isNA": false, "value": "groom" },
                    { "ability": null, "issues": [], "isNA": false, "value": "dressing" },
                    { "ability": null, "issues": [], "isNA": false, "value": "prepareBreakfast" },
                    { "ability": null, "issues": [], "isNA": false, "value": "eatBreakfast" },
                    { "ability": null, "issues": [], "isNA": false, "value": "travelToWork" },
                    { "ability": null, "issues": [], "isNA": false, "value": "takeCareOfChildren", "isCaregiving": true },
                    { "ability": null, "issues": [], "isNA": false, "value": "attendWork" },
                    { "ability": null, "issues": [], "isNA": false, "value": "runErrands" },
                    { "ability": null, "issues": [], "isNA": false, "value": "prepareDinner" },
                    { "ability": null, "issues": [], "isNA": false, "value": "eatDinner" },
                    { "ability": null, "issues": [], "isNA": false, "value": "indoorChores" },
                    { "ability": null, "issues": [], "isNA": false, "value": "outdoorChores" },
                    { "ability": null, "issues": [], "isNA": false, "value": "petCare" },
                    { "ability": null, "issues": [], "isNA": false, "value": "exercise" },
                    { "ability": null, "issues": [], "isNA": false, "value": "read" },
                    { "ability": null, "issues": [], "isNA": false, "value": "watchTv" },
                    { "ability": null, "issues": [], "isNA": false, "value": "useInternet" },
                    { "ability": null, "issues": [], "isNA": false, "value": "financialTasks" },
                    { "ability": null, "issues": [], "isNA": false, "value": "socialActivities" },
                    { "ability": null, "issues": [], "isNA": false, "value": "volunteering" },
                    { "ability": null, "issues": [], "isNA": false, "value": "religiousActivities" },
                    { "ability": null, "issues": [], "isNA": false, "value": "vacation" }
                ],
                "caregivingCasInvolved": null,
                "preAccidentRecreationalActivities": [],
                "travel": {
                    "sinceAccident": null,
                    "where": null,
                    "howLong": {
                        "number": null,
                        "period": null
                    }
                }
            }
        },
        "treatment": {
            "initial": {
                "providers": [
                    { 
                        "value": "physiotherapist",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "chiropractor",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "massageTherapist",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "acupuncturist",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "osteopathicProvider",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "naturopathicProvider",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "occupationalTherapist",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "rehabilitationWorker",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "supportWorker",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "speechLanguagePathologist",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "caseManager",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "neuroOptometrist",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    }
                ],
                "programs": [
                    {
                        "isPainProgram": true,
                        "value": "painProgram",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "driversRehab",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "visualTherapy",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    },
                    { 
                        "value": "vestibularTreatment",
                        "sinceAccident": null, 
                        "start": { "month": null, "year": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "current": { "attending": null, "frequency": { "unit": null, "number": null, "rangeStart": null, "rangeEnd": null, "period": null } },
                        "stop": { "month": null, "year": null },
                        "financialIssuesAffectedAbilityToAttend": null
                    }
                ]
            }
        }
    };
}