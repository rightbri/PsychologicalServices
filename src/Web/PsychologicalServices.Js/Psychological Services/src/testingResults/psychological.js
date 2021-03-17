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
            //isCredible: false,
            //overallCredibility: null,
            psychologicalTests: [],
            /*
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
            */
            painIssues: {
                visualScale: {
                    currentNumber: null,
                    badDayNumber: null,
                    goodDayNumber: null
                },
                disabilityIndex: {
                    perceivedDisability: null,
                    dysfunctionRatings: [
                        { "value": "recreationalActivities", "rating": null },
                        { "value": "socialActivities", "rating": null },
                        { "value": "sexualBehaviors", "rating": null, "declinedToAnswer": false },
                        { "value": "occupationalPursuits", "rating": null },
                        { "value": "homeResponsibilities", "rating": null },
                        { "value": "selfCareTasks", "rating": null },
                        { "value": "lifeSupportActivities", "rating": null }
                    ]
                }
            },
            painPatientProfile: {
                credibilityIssues: null
            },
            /*
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
            */
            neurocognitiveTests: [],
            /*
            concussionSymptoms: {
                perceivedDisability: null,
                currentSymptoms: [],
                additionalSymptoms: []
            }
            */
        };

        this.painScaleMin = 0;
        this.painScaleMax = 10;
        this.dysfunctionScaleMin = 1;
        this.dysfunctionScaleMax = 10;
        this.pronouns = [];
        this.yesNo = [];
        this.genders = [];
        /*
        this.credibilities = [];
        this.psychologicalTests = [];
        this.neurocognitiveTests = [];
        this.aggregateResultRatings = [];
        */
        this.painRatings = [];
        this.painScale = [];
        this.painDisabilityRanges = [];
        /*
        this.comparisonRatings = [];
        */
        this.areasOfDysfunction = [];
        this.dysfunctionScale = [];
        this.dysfunctionRatings = [];
        this.cognitiveAssessment = {
            effortLevel: null,
            tests: []
        };
        this.cognitiveAssessmentEffortLevels = [];
        this.cognitiveAssessmentTestResultRatings = [];
        this.cognitiveAssessmentTestCategories = [];
        
        this.self = this;
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
                    this.getGenders().then(data => this.genders = data),
                    //this.getCredibilities().then(data => this.credibilities = data),
                    //this.getAggregateResultRatings().then(data => this.aggregateResultRatings = data),
                    this.getPainRatings().then(data => this.painRatings = data),
                    this.getPainScale().then(data => this.painScale = data),
                    this.getPainDisabilityRanges().then(data => this.painDisabilityRanges = data),
                    this.getAreasOfDysfunction().then(data => this.areasOfDysfunction = data),
                    this.getDysfunctionScale().then(data => this.dysfunctionScale = data),
                    this.getDysfunctionRatings().then(data => this.dysfunctionRatings = data),
                    //this.getComparisonRatings().then(data => this.comparisonRatings = data),
                    this.getCognitiveAssessmentEffortLevels().then(data => this.cognitiveAssessmentEffortLevels = data),
                    this.getCognitiveAssessmentTestResultRatings().then(data => this.cognitiveAssessmentTestResultRatings = data),
                    this.getCognitiveAssessmentTestCategories().then(data => {
                        this.cognitiveAssessmentTestCategories = data;

                        this.cognitiveAssessment.tests =
                            data.map(function(category) {
                                return { "category": category.description, "rating": null }
                            });
                    })
                ]);
            });
    }

    asArray(map) {
        let a = [];

        for (let key in map) {
            a.push(map[key]);
        }

        return a;
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
        var data = [
            { "description": "Yes", "value": true },
            { "description": "No", "value": false }
        ];

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

    getCredibilities() {
        var data = [
            { "id": 1, "description": "credible", "isCredible": true },
            { "id": 2, "description": "not credible", "isCredible": false },
            { "id": 3, "description": "questionable", "isCredible": false }
        ];

        return getPromise(data);
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
        var ratings = {
            "extremelyHigh": { "value": "extremelyHigh", "description": "Extremely High (10)", "format": function(context) { return `an extremely high`; } },
            "aboveAverage": { "value": "aboveAverage", "description": "Above Average (8-9)", "format": function(context) { return `an above average`; } },
            "average": { "value": "average", "description": "Average (4-7)", "format": function(context) { return `an average`; } },
            "belowAverage": { "value": "belowAverage", "description": "Below Average (2-3)", "format": function(context) { return `a below average`; } },
            "extremelyLow": { "value": "extremelyLow", "description": "Extremely Low (0-1)", "format": function(context) { return `an extremely low`; } }
        };

        var data = [
            ratings["extremelyLow"],
            ratings["extremelyLow"],
            ratings["belowAverage"],
            ratings["belowAverage"],
            ratings["average"],
            ratings["average"],
            ratings["average"],
            ratings["average"],
            ratings["aboveAverage"],
            ratings["aboveAverage"],
            ratings["extremelyHigh"]
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
        var data = {
            "recreationalActivities": { "value": "recreationalActivities", "description": "Recreational activities" },
            "socialActivities": { "value": "socialActivities", "description": "Social activities" },
            "sexualBehaviors": { "value": "sexualBehaviors", "description": "Sexual behaviors", "canDeclineToAnswer": true },
            "occupationalPursuits": { "value": "occupationalPursuits", "description": "Occupational pursuits" },
            "homeResponsibilities": { "value": "homeResponsibilities", "description": "Family/home responsibilities" },
            "selfCareTasks": { "value": "selfCareTasks", "description": "Self-care tasks" },
            "lifeSupportActivities": { "value": "lifeSupportActivities", "description": "Life support activities" }
        };

        return getPromise(data);
    }

    getDysfunctionScale() {
        var data = getSequentialNumberArray(this.dysfunctionScaleMin, this.dysfunctionScaleMax);

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