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
            gender: null,
            pronoun: null,
            isCredible: false,
            psychologicalTests: [],
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
            neurocognitiveTests: [],
            includeRivermead: false,
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
        ]

        this.painScaleMin = 1;
        this.painScaleMax = 10;
        this.genders = [];
        this.credibilities = [];
        this.psychologicalTests = [];
        this.neurocognitiveTests = [];
        this.painRatings = [];
        this.painScale = [];
        this.painDisabilityRanges = [];
        this.comparisonRatings = [];
        this.areasOfDysfunction = [];
        this.dysfunctionRatings = [];
        this.concussionDisabilityRatings = [];
        this.concussionSymptoms = [];
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
                    this.getGenders().then(data => this.genders = data),
                    this.getCredibilities().then(data => this.credibilities = data),
                    this.getPsychologicalTests().then(data => this.psychologicalTests = data),
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
                    this.getNeurocognitiveTests().then(data => this.neurocognitiveTests = data),
                    this.getConcussionDisabilityRatings().then(data => this.concussionDisabilityRatings = data),
                    this.getConcussionSymptoms().then(data => this.concussionSymptoms = data)
                ]);
            });
    }

    getGenders() {
        var data = [
            { "abbreviation": "M", "description": "Male" },
            { "abbreviation": "F", "description": "Female" }
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
            { "id": 11, "name": "Trauma Symptom Inventory – 2 – A (TSI-2-A)" },
            { "id": 12, "name": "Visual Analogue Pain Scale" }
        ];

        return getPromise(data);
    }

    getNeurocognitiveTests() {
        var data = [
            { "id": 1, "name": "Rivermead Post-Concussion Symptoms Questionnaire" }
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