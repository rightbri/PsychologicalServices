import {Context} from 'common/context';
import {inject} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {computedFrom} from 'aurelia-framework';

@inject(BindingSignaler, Context)
export class Psychological {

    constructor(signaler, context) {
        this.signaler = signaler;
        this.context = context;

        this.results = {
            claimant: null,
            gender: null,
            pronoun: null,
            isCredible: false,
            overallCredibility: null,
            psychologicalTests: [],
            accidentFearQuestionnaire: {
                aggregateResult: null
            },
            beckAnxietyInventory: {
                aggregateResult: null
            },
            beckDepressionInventory: {
                aggregateResult: null
            },
            beckScaleOfSuicidalIdeation: {
                thoughtsOfSelfHarm: null
            },
            hamiltonRatingScaleForAnxiety: {
                aggregateResult: null
            },
            hamiltonRatingScaleForDepression: {
                aggregateResult: null
            },
            illnessBehaviorQuestionnaire: {
                //may be like the rivermead
            },
            minnesotaMultiphasicPersonalityInventory: {
                reactions: [],
                credibilityIssues: null,
                credibility: null,
                exaggeration: null,
                trends: [],
                exaggerationConcerns: [],
                
                aggregateResultForPain: null,
                aggregateResultForAnxiety: null,
                aggregateResultForDepression: null
            },
            painIssues: {
                visualScale: {
                    currentRating: null,
                    currentNumber: null,
                    badDayNumber: null,
                    goodDayNumber: null,
                    comparedToChronicRating: null
                },
                disabilityIndex: {
                    perceivedDisability: null,
                    dysfunctionRatings: []
                }
            },
            painPatientProfile: {
                credibilityIssues: null
            },
            personalityAssessmentInventory: {
                credibilityIssues: null,
                aggregateResultForPain: null,
                aggregateResultForAnxiety: null,
                aggregateResultForDepression: null
            },
            traumaSymptomInventory: {
                credibilityIssues: null,
                aggregateResultForPain: null,
                aggregateResultForAnxiety: null,
                aggregateResultForDepression: null
            },
            neurocognitiveTests: [],
            concussionSymptoms: {
                perceivedDisability: null,
                currentSymptoms: [],
                additionalSymptoms: []
            }
        };

        this.pronouns = [
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

        this.painScaleMin = 1;
        this.painScaleMax = 10;
        this.yesNo = [];
        this.genders = [];
        this.credibilities = [];
        this.psychologicalTests = [];
        this.neurocognitiveTests = [];
        this.aggregateResultRatings = [];
        this.painRatings = [];
        this.painScale = [];
        this.painDisabilityRanges = [];
        this.comparisonRatings = [];
        this.areasOfDysfunction = [];
        this.dysfunctionRatings = [];
        this.concussionDisabilityRatings = [];
        this.concussionSymptoms = [];

        this.cognitiveAssessment = {
            effortLevel: null,
            tests: []
        };
        this.cognitiveAssessmentEffortLevels = [];
        this.cognitiveAssessmentTestResultRatings = [];
        this.cognitiveAssessmentTestCategories = [];

        this.minnesotaMultiphasicInventoryReactions = [];
        this.minnesotaMultiphasicInventoryTrends = [];
        this.minnesotaMultiphasicInventoryExaggerationConcerns = [];

        this.becksRatings = [];
        this.hamiltonDepressionRatings = [];
        this.hamiltonAnxietyRatings = [];
        this.accidentFearQuestionnaireRatings = [];
    }

    isRated(test) {
        return test.rating;
    }

    claimantSelected(e) {
        let gender = e.detail.claimant.gender;

        this.results.gender = this.genders.find(g => {
            return g.abbreviation === gender;
        });

        this.genderChanged(this.results.gender);
    }

    genderChanged(gender) {
        var pronoun = this.pronouns.filter(p => p.gender === gender.abbreviation);

        this.results.pronoun = pronoun.length > 0 ? pronoun[0] : null;
    }

    addAdditionalConcussionSymptom() {
        this.results.concussionSymptoms.additionalSymptoms.push('');
        this.concussionAdditionalSymptomChange();
    }

    removeAdditionalConcussionSymptom(symptom) {
        if (confirm('Remove symptom\nAre you sure?')) {
            this.results.concussionSymptoms.additionalSymptoms.splice(this.results.concussionSymptoms.additionalSymptoms.indexOf(symptom), 1);
            this.concussionAdditionalSymptomChange();
        }
    }

    concussionAdditionalSymptomChange() {
        this.signaler.signal('concussion-additional-symptoms-updated');
    }

    getConcussionSymptomText(concussionSymptom) {
        return concussionSymptom.description;
    }

    concussionSymptomChange(symptom) {
        this.signaler.signal('concussion-symptoms-updated');
    }

    activate() {
		return this.getData();
    }

    getData() {
        return this.context.getUser()
            .then(user => {
                this.user = user;
        
                return Promise.all([
                    this.getYesNo().then(data => this.yesNo = data),
                    this.getGenders().then(data => this.genders = data),
                    this.getCredibilities().then(data => this.credibilities = data),
                    this.getPsychologicalTests().then(data => {
                        this.psychologicalTests = data;

                        this.updatePerformedPsychologicalTests();
                    }),
                    this.getAggregateResultRatings().then(data => this.aggregateResultRatings = data),
                    this.getPainRatings().then(data => this.painRatings = data),
                    this.getPainScale().then(data => this.painScale = data),
                    this.getPainDisabilityRanges().then(data => this.painDisabilityRanges = data),
                    this.getComparisonRatings().then(data => this.comparisonRatings = data),
                    this.getAreasOfDysfunction().then(data => {
                        this.areasOfDysfunction = data;

                        this.results.painIssues.disabilityIndex.dysfunctionRatings =
                            data.map(function(area) {
                                return { "area": area, "rating": null }
                            });
                    }),
                    this.getDysfunctionRatings().then(data => this.dysfunctionRatings = data),
                    this.getNeurocognitiveTests().then(data => {
                        this.neurocognitiveTests = data;
                        
                        this.updatePerformedNeurocognitiveTests();
                    }),
                    this.getConcussionDisabilityRatings().then(data => this.concussionDisabilityRatings = data),
                    this.getConcussionSymptoms().then(data => this.concussionSymptoms = data),
                    this.getCognitiveAssessmentEffortLevels().then(data => this.cognitiveAssessmentEffortLevels = data),
                    this.getCognitiveAssessmentTestResultRatings().then(data => this.cognitiveAssessmentTestResultRatings = data),
                    this.getCognitiveAssessmentTestCategories().then(data => {
                        this.cognitiveAssessmentTestCategories = data;

                        this.cognitiveAssessment.tests =
                            data.map(function(category) {
                                return { "category": category.description, "rating": null }
                            });
                    }),

                    this.getMinnesotaMultiphasicPersonalityInventoryReactions().then(data => this.minnesotaMultiphasicInventoryReactions = data),
                    this.getMinnesotaMultiphasicPersonalityInventoryTrends().then(data => this.minnesotaMultiphasicInventoryTrends = data),
                    this.getMinnesotaMultiphasicPersonalityInventoryExaggerationConcerns().then(data => this.minnesotaMultiphasicInventoryExaggerationConcerns = data),

                    this.getBecksRatings().then(data => this.becksRatings = data),
                    this.getHamiltonDepressionRatings().then(data => this.hamiltonDepressionRatings = data),
                    this.getHamiltonAnxietyRatings().then(data => this.hamiltonAnxietyRatings = data),
                    this.getAccidentFearQuestionnaireRatings().then(data => this.accidentFearQuestionnaireRatings = data)
                ]);
            });
    }

    getYesNo() {
        var data = [
            { "description": "Yes", "value": true },
            { "description": "No", "value": false }
        ];

        return getPromise(data);
    }

    getGenders() {
        var data = [
            { "abbreviation": "M", "description": "Male", "title": "Mr." },
            { "abbreviation": "F", "description": "Female", "title": "Ms." }
        ];

        return getPromise(data);
    }

    getCredibilities() {
        var data = [
            { "id": 1, "description": "credible", "isCredible": true },
            { "id": 2, "description": "not credible", "isCredible": false },
            { "id": 3, "description": "questionable", "isCredible": false }
        ];

        return getPromise(data);
    }

    getPsychologicalTests() {
        var data = [
            { "id": 1, "name": "Accident Fear Questionnaire (AFQ)" },
            { "id": 2, "name": "Beck Anxiety Inventory (BAI)" },
            { "id": 3, "name": "Beck Depression Inventory – 2nd Edition (BDI-II)" },
            { "id": 4, "name": "Beck Scale of Suicidal Ideation (BSSI)" },
            { "id": 5, "name": "Hamilton Rating Scale for Anxiety" },
            { "id": 6, "name": "Hamilton Rating Scale for Depression" },
            { "id": 7, "name": "Illness Behaviour Questionnaire (IBQ)" },
            { "id": 8, "name": "Minnesota Multiphasic Personality Inventory – 2 – RF (MMPI-2RF)" },
            { "id": 9, "name": "Pain Disability Index" },
            { "id": 10, "name": "Pain Patient Profile (P3)" },
            { "id": 11, "name": "Personality Assessment Inventory (PAI)" },
            { "id": 12, "name": "Trauma Symptom Inventory – 2–A (TSI-2-A)" },
            { "id": 13, "name": "Visual Analogue Pain Scale" }
        ];

        return getPromise(data);
    }

    getPerformedPsychologicalTests() {
        var self = this;

        var data = {
            "accidentFearQuestionnaire": isPerformed(1),
            "beckAnxietyInventory": isPerformed(2),
            "beckDepressionInventory": isPerformed(3),
            "beckScaleOfSuicidalIdeation": isPerformed(4),
            "hamiltonRatingScaleForAnxiety": isPerformed(5),
            "hamiltonRatingScaleForDepression": isPerformed(6),
            "illnessBehaviourQuestionnaire": isPerformed(7),
            "minnesotaMultiphasicPersonalityInventory": isPerformed(8),
            "painDisabilityIndex": isPerformed(9),
            "painPatientProfile": isPerformed(10),
            "personalityAssessmentInventory": isPerformed(11),
            "traumaSymptomInventory": isPerformed(12),
            "visualAnaloguePainScale": isPerformed(13)
        };

        function isPerformed(testId) {
            return self.results.psychologicalTests.some(t => t.id == testId);
        }

        return data;
    }

    updatePerformedPsychologicalTests() {
        this.results.performedPsychologicalTests = this.getPerformedPsychologicalTests();
    }

    getNeurocognitiveTests() {
        var data = [
            { "id": 1, "name": "Boston Naming Test" },
            { "id": 2, "name": "California Verbal Learning Test – 3rd Edition" },
            { "id": 3, "name": "Controlled Oral Word Association Test" },
            { "id": 4, "name": "Finger Tapping Test" },
            { "id": 5, "name": "Judgment of Line Orientation Test" },
            { "id": 6, "name": "Rey Complex Figure Test" },
            { "id": 7, "name": "Rivermead Post-Concussion Symptoms Questionnaire" },
            { "id": 8, "name": "Ruff 2 & 7 Selective Attention Test" },
            { "id": 9, "name": "Ruff Figural Fluency Test" },
            { "id": 10, "name": "Short Category Test" },
            { "id": 11, "name": "Stroop Color Word Test" },
            { "id": 12, "name": "Test of Memory Malingering (TOMM)" },
            { "id": 13, "name": "Trail Making Tests – Parts A and B" },
            { "id": 14, "name": "Wechsler Abbreviated Scale of Intelligence – 2" },
            { "id": 15, "name": "Wechsler Adult Intelligence Scales – 4th Edition (Processing Speed Index and Working Memory Index)" },
            { "id": 16, "name": "Wechsler Memory Scale – 4th Edition (Logical Memory)" },
            { "id": 17, "name": "Wide Range Achievement Test – 4th Edition" }
        ];

        return getPromise(data);
    }

    getPerformedNeurocognitiveTests() {
        var self = this;

        var data = {
            "bostonNamingTest": isPerformed(1),
            "californiaVerbalLearningTest": isPerformed(2),
            "controlledOralWordAssociationTest": isPerformed(3),
            "fingerTappingTest": isPerformed(4),
            "judgementOfLineOrientationTest": isPerformed(5),
            "reyComplexFigureTest": isPerformed(6),
            "rivermeadPostConcussionSymptomsQuestionnaire": isPerformed(7),
            "ruffSelectiveAttentionTest": isPerformed(8),
            "ruffFiguralFluencyTest": isPerformed(9),
            "shortCategoryTest": isPerformed(10),
            "stroopColorWordTest": isPerformed(11),
            "testOfMemoryMalingering": isPerformed(12),
            "trailMakingTests": isPerformed(13),
            "wechslerAbbreviatedScaleOfIntelligence": isPerformed(14),
            "wechslerAdultIntelligenceScales": isPerformed(15),
            "wechslerMemoryScale": isPerformed(16),
            "wideRangeAchievementTest": isPerformed(17)
        };

        function isPerformed(testId) {
            return self.results.neurocognitiveTests.some(t => t.id == testId);
        }

        return data;
    }

    updatePerformedNeurocognitiveTests() {
        this.results.performedNeurocognitiveTests = this.getPerformedNeurocognitiveTests();
    }

    getAggregateResultRatings() {
        var data = [
            { "id": 1, "description": "high average" },
            { "id": 2, "description": "moderate" },
            { "id": 3, "description": "average" },
            { "id": 4, "description": "below average" }
        ];

        return getPromise(data);
    }

    getPainRatings() {
        var data = [
            { "id": 1, "description": "above average", "templatePrefix": "an " },
            { "id": 2, "description": "average", "templatePrefix": "an " },
            { "id": 3, "description": "below average", "templatePrefix": "a " }
        ];

        return getPromise(data);
    }

    getPainScale() {
        var data = getSequentialNumberArray(this.painScaleMin, this.painScaleMax);

        return getPromise(data);
    }

    getPainDisabilityRanges() {
        var data = [
            { "id": 1, "description": "above average range", "templatePrefix": "an " },
            { "id": 2, "description": "average range", "templatePrefix": "an " },
            { "id": 3, "description": "below average range", "templatePrefix": "a " },
            { "id": 4, "description": "extremely low range", "templatePrefix": "an " }
        ];

        return getPromise(data);
    }

    getComparisonRatings() {
        var data = [
            { "id": 1, "description": "less than" },
            { "id": 2, "description": "equal to" },
            { "id": 3, "description": "greater than" }
        ];

        return getPromise(data);
    }

    getAreasOfDysfunction() {
        var data = [
            { "id": 1, "description": "Recreational activities" },
            { "id": 2, "description": "Self-care tasks" },
            { "id": 3, "description": "Social activities" },
            { "id": 4, "description": "Life support activities" },
            { "id": 5, "description": "Sexual behaviors" },
            { "id": 6, "description": "Occupational pursuits" },
            { "id": 7, "description": "Family/home responsibilities" }
        ];

        return getPromise(data);
    }

    getDysfunctionRatings() {
        var data = [
            { "id": 1, "description": "above average" },
            { "id": 2, "description": "average" },
            { "id": 3, "description": "below average" }
        ];

        return getPromise(data);
    }

    getConcussionDisabilityRatings() {
        var data = [
            { "id": 1, "description": "above average range", "templatePrefix": "an " },
            { "id": 2, "description": "average range", "templatePrefix": "an "  },
            { "id": 3, "description": "below average range", "templatePrefix": "a "  }
        ];

        return getPromise(data);
    }

    getConcussionSymptoms() {
        var data = [
            { "id": 1, "description": "headache", "order": 1 },
            { "id": 2, "description": "dizziness", "order": 2 },
            { "id": 3, "description": "nausea", "order": 3 },
            { "id": 4, "description": "noise sensitivity", "order": 4 },
            { "id": 5, "description": "disturbed sleep", "order": 5 },
            { "id": 6, "description": "fatigue", "order": 6 },
            { "id": 7, "description": "irritability", "order": 7 },
            { "id": 8, "description": "depressive issues", "order": 8 },
            { "id": 9, "description": "frustration", "order": 9 },
            { "id": 10, "description": "memory difficulties", "order": 10 },
            { "id": 11, "description": "concentration difficulties", "order": 11 },
            { "id": 12, "description": "slowed information processing", "order": 12 },
            { "id": 13, "description": "blurred vision", "order": 13 },
            { "id": 14, "description": "light sensitivity", "order": 14 },
            { "id": 15, "description": "double vision", "order": 15 },
            { "id": 16, "description": "restlessness", "order": 16 }
        ];

        return getPromise(data);
    }

    cognitiveAssessmentTestResultRatingChange() {
        this.cognitiveAssessmentTestResultGroupings = this.getCognitiveAssessmentTestResultGroupings();
        this.signaler.signal('cognitive-assessment-test-result-rating-updated');
    }

    getCognitiveAssessmentTestResultGroupings() {
        
        let testsWithRatings = this.cognitiveAssessment.tests.filter(t => t.rating);
        
        let ratings = this.cognitiveAssessmentTestResultRatings.filter(rating =>
            testsWithRatings.some(tr => tr.rating.description === rating.description)
        );
        
        let groupings = ratings.reduce((accumulator, current) => {

            let grouping = accumulator.find(item => item.group === current.group);

            if (grouping) {
                let rating = grouping.ratings.find(item => item.description === current.description);

                if (!rating) {
                    grouping.ratings.push(current.description);
                }
            }
            else {
                accumulator.push({ "group": current.group, "opening": current.opening, ratings: [current.description], sort: current.sort });
            }

            return accumulator;
        }, []);

        for (let i = 0; i < groupings.length; i++) {
            let grouping = groupings[i];

            grouping.tests = testsWithRatings.filter(item =>
                grouping.ratings.some(rating => rating === item.rating.description)
            );
        }

        let rangeGroups = groupings;

        return rangeGroups;
    }

    getCognitiveAssessmentTestCategory(test) {
        return test.category;
    }

    getCognitiveAssessmentTestResultRatings() {
        var data = [
            { "description": "Impaired", "group": "impaired", "opening": "in the impaired range", "sort": 3 },
            { "description": "Borderline", "group": "borderline", "opening": "in the borderline range", "sort": 2 },
            { "description": "Normal", "group": "normal", "opening": "within normal limits", "sort": 1 }
        ];

        return getPromise(data);
    }

    getCognitiveAssessmentTestCategories() {
        var data = [
            { "description": "Overall Verbal Skills" },
            { "description": "Overall Visual Skills" },
            { "description": "General Intelligence" },
            { "description": "Pre-Accident Intelligence (Estimate)" },
            { "description": "General Cognitive Functioning" },
            { "description": "Immediate Memory" },
            { "description": "Delayed Memory" },
            { "description": "Immediate Recall of Lists (With and Without Hints)" },
            { "description": "Delayed Recall of Lists (With and Without Hints)" },
            { "description": "Verbal Recognition of the Lists" },
            { "description": "Short-Term Recall of Verbal Prose (Content)" },
            { "description": "Delayed Recall of Verbal Prose (Content)" },
            { "description": "Visual Short-Term Memory" },
            { "description": "Visual Long-Term Memory" },
            { "description": "Visual Recognition" },
            { "description": "Attention" },
            { "description": "Working Memory" },
            { "description": "Processing Speed" },
            { "description": "Hand-Eye Coordination" },
            { "description": "Ability to Sustain Attention" },
            { "description": "Ability to Select Specific Targets Out of Larger Groups" },
            { "description": "Ability to Divide Attention Between Tasks" },
            { "description": "Problem-Solving" },
            { "description": "Ability to Benefit From Feedback" },
            { "description": "Ability to Stay on Task" },
            { "description": "Verbal and Visual Problem Solving" },
            { "description": "Ability to Generate Words for Specific Letters" },
            { "description": "Ability to Generate Words for Specific Categories" },
            { "description": "Ability to Generate Designs" },
            { "description": "Response Inhibition" },
            { "description": "Visuoconstructive Abilities" },
            { "description": "Ability to Copy Pictures" },
            { "description": "Ability to Judge Line Directions" },
            { "description": "Hand Speed" },
            { "description": "Language" },
            { "description": "Ability to Name Objects" },
            { "description": "General Vocabulary" },
            { "description": "General Knowledge" },
            { "description": "Reading Ability" },
            { "description": "Mathematical Ability" },
            { "description": "Spelling" }
        ];

        return getPromise(data);
    }

    getCognitiveAssessmentEffortLevels() {
        var data = [
            { "description": "reliable" },
            { "description": "adequate" },
            { "description": "questionable" },
            { "description": "less than ideal" },
            { "description": "invalid" }
        ];

        return getPromise(data);
    }

    getBecksRatings() {
        var data = [
            { "description": "Normal" },
            { "description": "Mild" },
            { "description": "Moderate" },
            { "description": "Severe" }
        ];

        return getPromise(data);
    }
    
    getHamiltonDepressionRatings() {
        var data = [
            { "description": "Normal" },
            { "description": "Mild" },
            { "description": "Moderate" },
            { "description": "Severe" },
            { "description": "Very Severe" }
        ];

        return getPromise(data);
    }

    getHamiltonAnxietyRatings() {
        var data = [
            { "description": "Normal" },
            { "description": "Mild" },
            { "description": "Moderate" },
            { "description": "High Moderate" },
            { "description": "Severe" },
            { "description": "Very Severe" }
        ];

        return getPromise(data);
    }

    getMinnesotaMultiphasicPersonalityInventoryReactions() {
        var data = [
            { "option": "Understood?", "output": { true: "understood the items of the test", false: "did not understand the items of the test" } },
            { "option": "Was attentive?", "output": { true: "attended to the items of the test", false: "did not attend to the items of the test" } },
            { "option": "Was distracted or confused?", "output": { true: "was distracted or confused while completing the form", false: "was not distracted or confused while completing the form" } },
            { "option": "Responded in a consistent manner?", "output": { true: "responded to the items in a consistent manner throughout the test", false: "did not respond to the items in a consistent manner throughout the test" } }
        ];

        return getPromise(data);
    }

    getMinnesotaMultiphasicPersonalityInventoryTrends() {
        var data = [
            { "description": "Defensiveness" },
            { "description": "Positive Impression Management" },
            { "description": "Negative Impression Management" }
        ];

        return getPromise(data);
    }

    getMinnesotaMultiphasicPersonalityInventoryExaggerationConcerns() {
        var data = [
            { "description": "Cognitive complaints" },
            { "description": "Somatic complaints" },
            { "description": "General Psychopathology" }
        ];

        return getPromise(data);
    }

    getMinnesotaMultiphasicPersonalityInventoryReactionOutput(item) {
        return item.output[true];
    }
    
    getAccidentFearQuestionnaireRatings() {
        var data = [
            { "description": "Below average" },
            { "description": "Low average" },
            { "description": "Average" },
            { "description": "High average" },
            { "description": "Above average" }
        ];

        return getPromise(data);
    }

    clearTestRating(test) {
        test.rating = null;
        this.cognitiveAssessmentTestResultRatingChange();
    }
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}

function getSequentialNumberArray(start, end) {
    var a = [];

    for (let i = start; i <= end; i++) {
        a.push(i);
    }

    return a;
}