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
                        { "value": "sexualBehaviours", "rating": null, "declinedToAnswer": false },
                        { "value": "occupationalPursuits", "rating": null },
                        { "value": "homeResponsibilities", "rating": null },
                        { "value": "selfCareTasks", "rating": null },
                        { "value": "lifeSupportActivities", "rating": null }
                    ]
                },
                catastrophizingScale: {
                    isValid: null,
                    rumination: 0,
                    helplessness: 0,
                    magnification: 0,
                    totalScore: 0
                },
                bbhi: {
                    isValid: null,
                    somatic: null,
                    pain: null,
                    functional: null
                }
            },
            depression: {
                beck: null,
                hamilton: null,
                tsi2a: null,
                mmpi2rf: null,
                bbhi: {
                    isValid: null,
                    depression: null
                }
            },
            selfHarm: {
                bssi: null,
                bdi2: null,
                tsi2a: null,
                mmpi2rf: null
            },
            anxiety: {
                bai: null,
                hamilton: null,
                mmpi2rf: null,
                tsi2a: null,
                bbhi: {
                    isValid: null,
                    anxiety: null
                }
            },
            postConcussion: {
                rivermead: null
            },
            neurocognitiveTests: []
        };

        this.painScaleMin = 0;
        this.painScaleMax = 10;
        this.dysfunctionScaleMin = 1;
        this.dysfunctionScaleMax = 10;
        this.pronouns = [];
        this.yesNo = [];
        this.genders = [];
        
        this.painRatings = [];
        this.painScale = [];
        this.areasOfDysfunction = [];
        this.dysfunctionScale = [];
        this.dysfunctionRatings = [];
        this.dysfunctionRatingChangedCount = 0;
        
        this.painCatastrophizingScaleElevatedMinValue = 17;

        this.bbhiScaleRatings = [];
        
        this.beckDepressionInventoryRanges = [];
        this.hamiltonRatingScaleForDepressionRanges = [];
        this.tsi2aDepressionResults = [];
        this.mmpi2rfDepressionProfiles = [];

        this.beckAnxietyInventoryRanges = [];
        this.hamiltonRatingScaleForAnxietyRanges = [];
        this.tsi2aAnxietyResults = [];
        this.rivermeadRanges = [];

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
        let pronoun = this.pronouns.hasOwnProperty(gender.abbreviation) ? this.pronouns[gender.abbreviation] : null;
        
        this.results.pronoun = pronoun;
    }

    activate() {
		return this.getData();
    }

    changed(signalName) {
        this.signaler.signal(signalName);
    }

    getData() {
        return this.context.getUser()
            .then(user => {
                this.user = user;
        
                return Promise.all([
                    this.getPronouns().then(data => this.pronouns = data),
                    this.getYesNo().then(data => this.yesNo = data),
                    this.getGenders().then(data => this.genders = data),
                    this.getPainRatings().then(data => this.painRatings = data),
                    this.getPainScale().then(data => this.painScale = data),
                    this.getDysfunctionRatings().then(data => this.dysfunctionRatings = data),
                    this.getDysfunctionScale().then(data => this.dysfunctionScale = data),
                    this.getAreasOfDysfunction().then(data => this.areasOfDysfunction = data),
                    this.getBbhiScaleRatings().then(data => {
                        this.bbhiScaleRatings = this.asArray(data);
                        this.bbhiScaleRatingsMap = data;
                    }),
                    this.getBeckDepressionInventoryRanges().then(data => {
                        this.beckDepressionInventoryRanges = this.asArray(data);
                        this.beckDepressionInventoryRangesMap = data;
                    }),
                    this.getHamiltonRatingScaleForDepressionRanges().then(data => {
                        this.hamiltonRatingScaleForDepressionRanges = this.asArray(data);
                        this.hamiltonRatingScaleForDepressionRangesMap = data;
                    }),
                    this.getTsi2aDepressionResults().then(data => {
                        this.tsi2aDepressionResults = this.asArray(data);
                        this.tsi2aDepressionResultsMap = data;
                    }),
                    this.getMmpi2rfDepressionProfiles().then(data => {
                        this.mmpi2rfDepressionProfiles = this.asArray(data);
                        this.mmpi2rfDepressionProfilesMap = data;
                    }),
                    this.getBeckAnxietyInventoryRanges().then(data => {
                        this.beckAnxietyInventoryRanges = this.asArray(data);
                        this.beckAnxietyInventoryRangesMap = data;
                    }),
                    this.getHamiltonRatingScaleForAnxietyRanges().then(data => {
                        this.hamiltonRatingScaleForAnxietyRanges = this.asArray(data);
                        this.hamiltonRatingScaleForAnxietyRangesMap = data;
                    }),
                    this.getTsi2aAnxietyResults().then(data => {
                        this.tsi2aAnxietyResults = this.asArray(data);
                        this.tsi2aAnxietyResultsMap = data;
                    }),
                    this.getRivermeadRanges().then(data => {
                        this.rivermeadRanges = this.asArray(data);
                        this.rivermeadRangesMap = data;
                    }),
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
            { "abbreviation": "N", "description": "Neutral", "title": "Mx." },
            { "abbreviation": "U", "description": "Unknown", "title": "Mx." }
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

        /*
            Extremely Low (0-1)
            Below average (2-3)
            Average (4-7)
            Above average (8-9)
            Extremely high (10)
        */
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

    getAreasOfDysfunction() {
        var data = {
            "recreationalActivities": { "value": "recreationalActivities", "description": "Recreational activities", "format": function(context) { return `recreational activities`; } },
            "socialActivities": { "value": "socialActivities", "description": "Social activities", "format": function(context) { return `social activities`; } },
            "sexualBehaviours": { "value": "sexualBehaviours", "description": "Sexual behaviours", "canDeclineToAnswer": true, "format": function(context) { return `sexual behaviours`; } },
            "occupationalPursuits": { "value": "occupationalPursuits", "description": "Occupational pursuits", "format": function(context) { return `occupational pursuits`; } },
            "homeResponsibilities": { "value": "homeResponsibilities", "description": "Family/home responsibilities", "format": function(context) { return `family/home responsibilities`; } },
            "selfCareTasks": { "value": "selfCareTasks", "description": "Self-care tasks", "format": function(context) { return `self-care tasks`; } },
            "lifeSupportActivities": { "value": "lifeSupportActivities", "description": "Life support activities", "format": function(context) { return `life support activities`; } }
        };

        return getPromise(data);
    }

    getDysfunctionScale() {
        var data = getSequentialNumberArray(this.dysfunctionScaleMin, this.dysfunctionScaleMax);

        return getPromise(data);
    }

    getDysfunctionRatings() {
        var ratings = {
            "extremelyHigh": { "value": "extremelyHigh", "description": "Extremely High (10)", "format": function(context) { return `an extremely high`; } },
            "aboveAverage": { "value": "aboveAverage", "description": "Above Average (8-9)", "format": function(context) { return `an above average`; } },
            "average": { "value": "average", "description": "Average (4-7)", "format": function(context) { return `an average`; } },
            "belowAverage": { "value": "belowAverage", "description": "Below Average (2-3)", "format": function(context) { return `a below average`; } },
            "extremelyLow": { "value": "extremelyLow", "description": "Extremely Low (0-1)", "format": function(context) { return `an extremely low`; } }
        };

        /*
            Extremely Low (0-1)
            Below average (2-3)
            Average (4-7)
            Above average (8-9)
            Extremely high (10)
        */
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

    getBbhiScaleRatings() {
        let data = {
            "low": { "value": "low", "description": "Low", "format": function(context) { return `low`; } },
            "average": { "value": "average", "description": "Average", "format": function(context) { return `average`; } },
            "moderateHigh": { "value": "moderateHigh", "description": "Moderate High", "format": function(context) { return `moderate high`; } },
            "high": { "value": "high", "description": "High", "format": function(context) { return `high`; } },
            "veryHigh": { "value": "veryHigh", "description": "Very High", "format": function(context) { return `very high`; } },
            "extremelyHigh": { "value": "extremelyHigh", "description": "Extremely High", "format": function(context) { return `extremely high`; } }
        };

        return getPromise(data);
    }

    getBeckDepressionInventoryRanges() {
        let data = {
            "normal": { "value": "normal", "description": "normal", "format": function(context) { return `normal`; } },
            "mild": { "value": "mild", "description": "mild", "format": function(context) { return `mild`; } },
            "moderate": { "value": "moderate", "description": "moderate", "format": function(context) { return `moderate`; } },
            "severe": { "value": "severe", "description": "severe", "format": function(context) { return `severe`; } }
        };

        return getPromise(data);
    }
    
    getHamiltonRatingScaleForDepressionRanges() {
        let data = {
            "normal": { "value": "normal", "description": "normal", "format": function(context) { return `normal`; } },
            "mild": { "value": "mild", "description": "mild", "format": function(context) { return `mild`; } },
            "moderate": { "value": "moderate", "description": "moderate", "format": function(context) { return `moderate`; } },
            "severe": { "value": "severe", "description": "severe", "format": function(context) { return `severe`; } }
        };

        return getPromise(data);
    }

    getTsi2aDepressionResults() {
        let data = {
            "invalid": { "value": "invalid", "description": "INVALID", "format": function(context) { return `invalid`; }, "isInvalid": true },
            "withinNormalLimits": { "value": "withinNormalLimits", "description": "within normal limits", "format": function(context) { return `within normal limits`; } },
            "mildlyElevated": { "value": "mildlyElevated", "description": "mildly elevated", "format": function(context) { return `mildly elevated`; } },
            "severelyElevated": { "value": "severelyElevated", "description": "severely elevated", "format": function(context) { return `severely elevated`; } }
        };

        return getPromise(data);
    }

    getMmpi2rfDepressionProfiles() {
        let data = {
            "invalid": { "value": "invalid", "description": "INVALID", "format": function(context) { return `invalid`; }, "isInvalid": true },
            "notElevated": { "value": "notElevated", "description": "not elevated", "format": function(context) { return `not elevated`; } },
            "clinicallyElevated": { "value": "clinicallyElevated", "description": "clinically elevated", "format": function(context) { return `clinically elevated`; } }
        };

        return getPromise(data);
    }
    
    getBeckAnxietyInventoryRanges() {
        let data = {
            "normal": { "value": "normal", "description": "normal", "format": function(context) { return `normal`; } },
            "mild": { "value": "mild", "description": "mild", "format": function(context) { return `mild`; } },
            "moderate": { "value": "moderate", "description": "moderate", "format": function(context) { return `moderate`; } },
            "severe": { "value": "severe", "description": "severe", "format": function(context) { return `severe`; } }
        };

        return getPromise(data);
    }
    
    getHamiltonRatingScaleForAnxietyRanges() {
        let data = {
            "minimal": { "value": "minimal", "description": "minimal", "format": function(context) { return `minimal`; } },
            "mild": { "value": "mild", "description": "mild", "format": function(context) { return `mild`; } },
            "moderate": { "value": "moderate", "description": "moderate", "format": function(context) { return `moderate`; } },
            "highModerate": { "value": "highModerate", "description": "high moderate", "format": function(context) { return `high moderate`; } },
            "severe": { "value": "severe", "description": "severe", "format": function(context) { return `severe`; } },
            "verySevere": { "value": "verySevere", "description": "very severe", "format": function(context) { return `very severe`; } }
        };

        return getPromise(data);
    }

    getTsi2aAnxietyResults() {
        let data = {
            "invalid": { "value": "invalid", "description": "INVALID", "format": function(context) { return `invalid`; }, "isInvalid": true },
            "withinNormalLimits": { "value": "withinNormalLimits", "description": "within normal limits", "format": function(context) { return `within normal limits`; } },
            "mildlyElevated": { "value": "mildlyElevated", "description": "mildly elevated", "format": function(context) { return `mildly elevated`; } },
            "severelyElevated": { "value": "severelyElevated", "description": "severely elevated", "format": function(context) { return `severely elevated`; } }
        };

        return getPromise(data);
    }

    getRivermeadRanges() {
        let data = {
            "aboveAverage": { "value": "aboveAverage", "description": "Above average", "format": function(context) { return `an above average`; } },
            "average": { "value": "average", "description": "Average", "format": function(context) { return `an average`; } },
            "lowAverage": { "value": "lowAverage", "description": "Low average", "format": function(context) { return `a low average`; } }
        }

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

    dysfunctionRatingChanged() {
        this.dysfunctionRatingChangedCount += 1;
        this.signaler.signal('pain-dysfunction-rating-changed');
    }

    @computedFrom('results.painIssues.disabilityIndex.dysfunctionRatings', 'dysfunctionRatingChangedCount')
    get disabilityRatingOverall() {
        /*
            Extremely Low (0-7)
            Below average (8-14)
            Average (15-49)
            Above average (50-62)
            Extremely highly (63-70)
        */

        let ranges = [
            { "min": 0, "max": 7, "value": "extremelyLow", "description": "Extremely Low (0-7)", "format": function(context) { return `an extremely low`; } },
            { "min": 8, "max": 14, "value": "belowAverage", "description": "Below Average (8-14)", "format": function(context) { return `a below average`; } },
            { "min": 15, "max": 49, "value": "average", "description": "Average (15-49)", "format": function(context) { return `an average`; } },
            { "min": 50, "max": 62, "value": "aboveAverage", "description": "Above Average (50-62)", "format": function(context) { return `an above average`; } },
            { "min": 63, "max": 70, "value": "extremelyHigh", "description": "Extremely High (63-70)", "format": function(context) { return `an extremely high`; } }
        ];

        let rating = this.disabilityRatingTotal;

        let range = ranges.filter(x => rating >= x.min && rating <= x.max);

        let result = range.some(x => x) ? range[0] : ranges[0];

        return result;
    }

    @computedFrom('results.painIssues.disabilityIndex.dysfunctionRatings', 'dysfunctionRatingChangedCount')
    get disabilityRatingTotal() {
        let total = this.results.painIssues.disabilityIndex.dysfunctionRatings.filter(x => !x.declinedToAnswer).map(x => x.rating ? parseInt(x.rating, 10) : 0).reduce(
            (accumulator, currentValue) => accumulator + currentValue,
            0
        );

        return total;
    }

    @computedFrom('results.painIssues.disabilityIndex.dysfunctionRatings', 'dysfunctionRatingChangedCount')
    get declinedToAnswerSexualBehaviors() {
        let rating = this.results.painIssues.disabilityIndex.dysfunctionRatings.filter(x => x.value === "sexualBehaviours");

        let declined = rating.length && rating[0].declinedToAnswer;

        return declined;
    }

    @computedFrom('results.painIssues.disabilityIndex.dysfunctionRatings', 'dysfunctionRatingChangedCount')
    get disabilityRatingGroups() {
        let groupings = [
            { "min": 0, "max": 1, "value": "extremelyLow", "description": "Extremely Low (0-1)", "format": function(context) { return `an extremely low`; }, "areasOfDysfunction": [] },
            { "min": 2, "max": 3, "value": "belowAverage", "description": "Below Average (2-3)", "format": function(context) { return `a below average`; }, "areasOfDysfunction": [] },
            { "min": 4, "max": 7, "value": "average", "description": "Average (4-7)", "format": function(context) { return `an average`; }, "areasOfDysfunction": [] },
            { "min": 8, "max": 9, "value": "aboveAverage", "description": "Above Average (8-9)", "format": function(context) { return `an above average`; }, "areasOfDysfunction": [] },
            { "min": 10, "max": 10, "value": "extremelyHigh", "description": "Extremely High (10)", "format": function(context) { return `an extremely high`; }, "areasOfDysfunction": [] }
        ];

        let dysfunctionRatings = this.results.painIssues.disabilityIndex.dysfunctionRatings.filter(x => !x.declinedToAnswer);

        for (let i = 0; i < dysfunctionRatings.length; i++) {
            let dysfunctionRating = dysfunctionRatings[i];
            let grouping = groupings.filter(x =>
                isInt(dysfunctionRating.rating) &&
                parseInt(dysfunctionRating.rating) >= x.min &&
                parseInt(dysfunctionRating.rating) <= x.max
            );

            if (grouping.some(x => x)) {
                grouping[0].areasOfDysfunction.push(dysfunctionRating.value);
            }
        }

        let results = groupings.filter(x => x.areasOfDysfunction.length > 0);

        return results;
    }

    getSelfHarmResponses() {
        let responses = [
            { "value": this.results.selfHarm.bssi, "description": "BSSI" },
            { "value": this.results.selfHarm.bdi2, "description": "BDI-II" },
            { "value": this.results.selfHarm.tsi2a, "description": "TSI-2-A" },
            { "value": this.results.selfHarm.mmpi2rf, "description": "MMPI-2-RF" }
        ];

        return responses;
    }

    @computedFrom(
        'results.selfHarm.bssi',
        'results.selfHarm.bdi2',
        'results.selfHarm.tsi2a',
        'results.selfHarm.mmpi2rf'
    )
    get selfHarmYesResponses() {
        let responses = this.getSelfHarmResponses();

        let yesResponses = responses.filter(x => x.value === true).map(x => x.description);

        return yesResponses;
    }

    @computedFrom(
        'results.selfHarm.bssi',
        'results.selfHarm.bdi2',
        'results.selfHarm.tsi2a',
        'results.selfHarm.mmpi2rf'
    )
    get anySelfHarmYesResponses() {
        let yesResponses = this.selfHarmYesResponses;

        return yesResponses.some(x => x);
    }

    @computedFrom(
        'results.selfHarm.bssi',
        'results.selfHarm.bdi2',
        'results.selfHarm.tsi2a',
        'results.selfHarm.mmpi2rf'
    )
    get selfHarmNoResponses() {
        let responses = this.getSelfHarmResponses();

        let noResponses = responses.filter(x => x.value === false).map(x => x.description);

        return noResponses;
    }

    @computedFrom(
        'results.selfHarm.bssi',
        'results.selfHarm.bdi2',
        'results.selfHarm.tsi2a',
        'results.selfHarm.mmpi2rf'
    )
    get anySelfHarmNoResponses() {
        let noResponses = this.selfHarmNoResponses;

        return noResponses.some(x => x);
    }

    @computedFrom(
        'results.painIssues.catastrophizingScale.rumination',
        'results.painIssues.catastrophizingScale.helplessness',
        'results.painIssues.catastrophizingScale.magnification'
    )
    get catastrophizingScaleItems() {
        let data = [
            { "description": "rumination", "percentile": this.results.painIssues.catastrophizingScale.rumination },
            { "description": "helplessness", "percentile": this.results.painIssues.catastrophizingScale.helplessness },
            { "description": "magnification", "percentile": this.results.painIssues.catastrophizingScale.magnification }
        ];

        console.log("isValid type: " + typeof(this.results.painIssues.catastrophizingScale.isValid));
        return data;
    }

    @computedFrom(
        'results.painIssues.catastrophizingScale.rumination',
        'results.painIssues.catastrophizingScale.helplessness',
        'results.painIssues.catastrophizingScale.magnification'
    )
    get elevatedCatastrophizingScaleItems() {
        let data = this.catastrophizingScaleItems.filter(x => isInt(x.percentile) && parseInt(x.percentile) >= this.painCatastrophizingScaleElevatedMinValue);

        return data;
    }

    @computedFrom(
        'results.painIssues.catastrophizingScale.rumination',
        'results.painIssues.catastrophizingScale.helplessness',
        'results.painIssues.catastrophizingScale.magnification'
    )
    get anyElevatedCatastrophizingScaleItems() {
        return this.elevatedCatastrophizingScaleItems.some(x => x);
    }

    @computedFrom(
        'results.painIssues.catastrophizingScale.rumination',
        'results.painIssues.catastrophizingScale.helplessness',
        'results.painIssues.catastrophizingScale.magnification'
    )
    get notElevatedCatastrophizingScaleItems() {
        let data = this.catastrophizingScaleItems.filter(x => isInt(x.percentile) && parseInt(x.percentile) < this.painCatastrophizingScaleElevatedMinValue);

        return data;
    }

    @computedFrom(
        'results.painIssues.catastrophizingScale.rumination',
        'results.painIssues.catastrophizingScale.helplessness',
        'results.painIssues.catastrophizingScale.magnification'
    )
    get anyNotElevatedCatastrophizingScaleItems() {
        return this.notElevatedCatastrophizingScaleItems.some(x => x);
    }

    @computedFrom('results.painIssues.catastrophizingScale.totalScore')
    get isCatastrophizingScaleTotalScoreElevated() {
        return isInt(this.results.painIssues.catastrophizingScale.totalScore) && parseInt(this.results.painIssues.catastrophizingScale.totalScore) >= this.painCatastrophizingScaleElevatedMinValue;
    }

    @computedFrom('results.painIssues.catastrophizingScale.totalScore')
    get isCatastrophizingScaleTotalScoreNotElevated() {
        return isInt(this.results.painIssues.catastrophizingScale.totalScore) && parseInt(this.results.painIssues.catastrophizingScale.totalScore) < this.painCatastrophizingScaleElevatedMinValue;
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

function isInt(value) {
    return !isNaN(value) && 
           parseInt(Number(value)) == value && 
           !isNaN(parseInt(value, 10));
}