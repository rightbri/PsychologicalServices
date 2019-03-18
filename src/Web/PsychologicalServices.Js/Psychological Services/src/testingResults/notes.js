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
        
        this.responses = {
            "problems": {
                "concentration": null,
                "memory": null,
                "shortTermMemory": null
            },
            "memory": {
                "episodic": {
                    "remindersHintsOrRepetition": null
                },
                "visual": {
                    "whereabouts": null
                },
                "working": {
                    "walkIntoRoomAndForgetWhyOrLoseTrackOfWhatYouWantedToSay": null
                },
                "aids": {
                    "useAids": null,
                    "useNotes": null,
                    "useReminders": null,
                    "usePhone": null,
                    "familyHelps": null
                },
                "prospective": {    /**/
                    "rememberToRemember": null
                },
                "contextual": {     /**/
                    "whereOrWho": null
                },
                "remote": {
                    "distantMemories": null
                },
                "autobiographical": {
                    "personalInfo": null
                },
                "procedural": {     /**/
                    "howTo": null
                },
                "medication": {
                    "errors": null,
                    "useDosette": null
                },
                "safety": {
                    "issuesBeingLeftHome": null,
                    "reportedIssue": null
                }
            },
            "language": {
                "lostInConversations": null,
                "tipOfTongueIssues": null,
                "repeatingYourself": null,
                "askingOthersToRepeat": null,
                "filtering": null,
                "wordSubstitution": null
            },
            "attention": {
                "abilityToFocus": null,
                "abilityToSustainAttention": null,
                "areMoreDistractible": null,
                "loseTrackWhenReading": null,
                "loseTrackWhenWatchingTv": null,
                "abilityToUseDevicesWithScreens": null
            },
            "executive": {
                "multiTasking": null,
                "initiativeSpontaneityAmotivationApathy": null,
                "organization": null,
                "planning": null,
                "judgement": null,
                "decisionMaking": null,
                "problemSolving": null,
                "inappropriateSocialBehavior": null
            },
            "visualSpatial": {
                "balanceIssues": null,
                "seizuresOrFainting": null,
                "lightOrNoiseSensitivity": null,
                "dizzinessIssues": null,
                "tinnitus": null,
                "blurryOrDoubleVision": null,
                "changeInSmellOrTaste": null,
                "tremors": null,
                "alteredSensation": null,
                "motorSpeedOrManualDexterityIssues": null
            },
            "atypical": {
                "itchyFingernails": null,
                "blackAndWhiteTransientVision": null
            }
        };

        this.yesNo = [];
        this.genders = [];
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
                    this.getGenders().then(data => this.genders = data)
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
        var pronoun = this.pronouns.filter(p => p.gender === gender.abbreviation);

        this.pronoun = pronoun.length > 0 ? pronoun[0] : null;
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

    @computedFrom('responses.memory.aids', 'pronoun')
    get selectedMemoryAids() {
        return [
            { "name": "notes", "response": this.responses.memory.aids.useNotes },
            { "name": "reminders", "response": this.responses.memory.aids.useReminders },
            { "name": this.pronoun !== null ? `${this.pronoun.possessiveAdjective} phone` : "phone", "response": this.responses.memory.aids.usePhone },
            { "name": this.pronoun !== null ? `shared that ${this.pronoun.possessiveAdjective} family will remind ${this.pronoun.object}` : "shared that (his|her) family will remind (him/her)", "response": this.responses.memory.aids.familyHelps }
        ].filter(item => item.response !== null && item.response.value);
    }

    formatMemoryAidName(item) {
        return item.name;
    }

    memoryAidsChanged() {
        this.signaler.signal('memory-aids-changed');
    }

    @computedFrom('responses.visualSpatial', 'pronoun')
    get selectedVisualSpatialIssues() {
        try {
            let x = [
                { "name": "balance", "response": this.responses.visualSpatial.balanceIssues },
                { "name": "seizures or fainting", "response": this.responses.visualSpatial.seizuresOrFainting },
                { "name": "light or noise sensitivity", "response": this.responses.visualSpatial.lightOrNoiseSensitivity },
                { "name": "dizziness", "response": this.responses.visualSpatial.dizzinessIssues },
                { "name": "tinnitus", "response": this.responses.visualSpatial.tinnitus },
                { "name": "blurry or double vision", "response": this.responses.visualSpatial.blurryOrDoubleVision },
                { "name": "change in smell or taste", "response": this.responses.visualSpatial.changeInSmellOrTaste },
                { "name": "tremors", "response": this.responses.visualSpatial.tremors },
                { "name": "altered sensation", "response": this.responses.visualSpatial.alteredSensation },
                { "name": "motor speed or manual dexterity", "response": this.responses.visualSpatial.motorSpeedOrManualDexterityIssues }
            ].filter(item => item.response !== null && item.response.value);
    
            return x;
        }
        catch (err) {
            console.log(err);
        }
        
        return [];
    }

    formatVisualSpatialIssue(item) {
        return item.name;
    }

    visualSpatialIssueChanged() {
        this.signaler.signal('visual-spatial-issue-changed');
    }
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}