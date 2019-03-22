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
                "organization": null,
                "planning": null,
                "decisionMaking": null,
                "problemSolving": null,
                "inappropriateSocialBehavior": null,
                "inappropriateSocialBehaviorText": null
            },
            "visualSpatial": {
                "balanceIssues": null,
                "seizures": null,
                "fainting": null,
                "lightSensitivity": null,
                "noiseSensitivity": null,
                "dizzinessIssues": null,
                "tinnitus": null,
                "blurryVision": null,
                "doubleVision": null,
                "changeInSmell": null,
                "changeInTaste": null,
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
            { "description": "No", "value": false },
            { "description": "Skip", "value": null }
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

    memoryAidsChanged() {
        this.signaler.signal('memory-aids-changed');
    }

    @computedFrom(
        'responses.visualSpatial.balanceIssues',
        'responses.visualSpatial.seizures',
        'responses.visualSpatial.fainting',
        'responses.visualSpatial.lightSensitivity',
        'responses.visualSpatial.noiseSensitivity',
        'responses.visualSpatial.dizzinessIssues',
        'responses.visualSpatial.tinnitus',
        'responses.visualSpatial.blurryVision',
        'responses.visualSpatial.doubleVision',
        'responses.visualSpatial.changeInSmell',
        'responses.visualSpatial.changeInTaste',
        'responses.visualSpatial.tremors',
        'responses.visualSpatial.alteredSensation',
        'responses.visualSpatial.motorSpeedOrManualDexterityIssues'
    )
    get anySelectedVisualSpatialIssues() {
        return this.selectedVisualSpatialIssues.some(item => item);
    }

    @computedFrom(
        'responses.visualSpatial.balanceIssues',
        'responses.visualSpatial.seizures',
        'responses.visualSpatial.fainting',
        'responses.visualSpatial.lightSensitivity',
        'responses.visualSpatial.noiseSensitivity',
        'responses.visualSpatial.dizzinessIssues',
        'responses.visualSpatial.tinnitus',
        'responses.visualSpatial.blurryVision',
        'responses.visualSpatial.doubleVision',
        'responses.visualSpatial.changeInSmell',
        'responses.visualSpatial.changeInTaste',
        'responses.visualSpatial.tremors',
        'responses.visualSpatial.alteredSensation',
        'responses.visualSpatial.motorSpeedOrManualDexterityIssues'
    )
    get anyUnselectedVisualSpatialIssues() {
        return this.unselectedVisualSpatialIssues.some(item => item);
    }

    @computedFrom(
        'responses.visualSpatial.balanceIssues',
        'responses.visualSpatial.seizures',
        'responses.visualSpatial.fainting',
        'responses.visualSpatial.lightSensitivity',
        'responses.visualSpatial.noiseSensitivity',
        'responses.visualSpatial.dizzinessIssues',
        'responses.visualSpatial.tinnitus',
        'responses.visualSpatial.blurryVision',
        'responses.visualSpatial.doubleVision',
        'responses.visualSpatial.changeInSmell',
        'responses.visualSpatial.changeInTaste',
        'responses.visualSpatial.tremors',
        'responses.visualSpatial.alteredSensation',
        'responses.visualSpatial.motorSpeedOrManualDexterityIssues'
    )
    get selectedVisualSpatialIssues() {
        return this.getVisualSpatialIssues().filter(item => item.response !== null && item.response.value);
    }

    @computedFrom(
        'responses.visualSpatial.balanceIssues',
        'responses.visualSpatial.seizures',
        'responses.visualSpatial.fainting',
        'responses.visualSpatial.lightSensitivity',
        'responses.visualSpatial.noiseSensitivity',
        'responses.visualSpatial.dizzinessIssues',
        'responses.visualSpatial.tinnitus',
        'responses.visualSpatial.blurryVision',
        'responses.visualSpatial.doubleVision',
        'responses.visualSpatial.changeInSmell',
        'responses.visualSpatial.changeInTaste',
        'responses.visualSpatial.tremors',
        'responses.visualSpatial.alteredSensation',
        'responses.visualSpatial.motorSpeedOrManualDexterityIssues'
    )
    get unselectedVisualSpatialIssues() {
        return this.getVisualSpatialIssues().filter(item => item.response !== null && item.response.value === false);
    }

    getVisualSpatialIssues() {
        return [
            { "name": "balance", "response": this.responses.visualSpatial.balanceIssues },
            { "name": "seizures", "response": this.responses.visualSpatial.seizures },
            { "name": "fainting", "response": this.responses.visualSpatial.fainting },
            { "name": "light sensitivity", "response": this.responses.visualSpatial.lightSensitivity },
            { "name": "noise sensitivity", "response": this.responses.visualSpatial.noiseSensitivity },
            { "name": "dizziness", "response": this.responses.visualSpatial.dizzinessIssues },
            { "name": "tinnitus", "response": this.responses.visualSpatial.tinnitus },
            { "name": "blurry vision", "response": this.responses.visualSpatial.blurryVision },
            { "name": "double vision", "response": this.responses.visualSpatial.doubleVision },
            { "name": "change in smell", "response": this.responses.visualSpatial.changeInSmell },
            { "name": "change in taste", "response": this.responses.visualSpatial.changeInTaste },
            { "name": "tremors", "response": this.responses.visualSpatial.tremors },
            { "name": "altered sensation", "response": this.responses.visualSpatial.alteredSensation },
            { "name": "motor speed or manual dexterity", "response": this.responses.visualSpatial.motorSpeedOrManualDexterityIssues }
        ];
    }

    visualSpatialIssueChanged() {
        this.signaler.signal('visual-spatial-issue-changed');
    }

    @computedFrom(
        'responses.executive.multiTasking',
        'responses.executive.organization',
        'responses.executive.planning',
        'responses.executive.decisionMaking',
        'responses.executive.problemSolving',
        'responses.executive.inappropriateSocialBehavior',
        'responses.executive.inappropriateSocialBehaviorText'
    )
    get anySelectedExecutiveFunctionIssues() {
        return this.selectedExecutiveFunctionIssues.some(item => item);
    }

    @computedFrom(
        'responses.executive.multiTasking',
        'responses.executive.organization',
        'responses.executive.planning',
        'responses.executive.decisionMaking',
        'responses.executive.problemSolving',
        'responses.executive.inappropriateSocialBehavior',
        'responses.executive.inappropriateSocialBehaviorText'
    )
    get multipleSelectedExecutiveFunctionIssues() {
        return this.selectedExecutiveFunctionIssues.length > 1;
    }

    @computedFrom(
        'responses.executive.multiTasking',
        'responses.executive.organization',
        'responses.executive.planning',
        'responses.executive.decisionMaking',
        'responses.executive.problemSolving',
        'responses.executive.inappropriateSocialBehavior',
        'responses.executive.inappropriateSocialBehaviorText'
    )
    get anyUnselectedExecutiveFunctionIssues() {
        return this.unselectedExecutiveFunctionIssues.some(item => item);
    }

    @computedFrom(
        'responses.executive.multiTasking',
        'responses.executive.organization',
        'responses.executive.planning',
        'responses.executive.decisionMaking',
        'responses.executive.problemSolving',
        'responses.executive.inappropriateSocialBehavior',
        'responses.executive.inappropriateSocialBehaviorText'
    )
    get selectedExecutiveFunctionIssues() {
        return this.getExecutiveFunctionIssues().filter(item => item.response !== null && item.response.value);
    }

    @computedFrom(
        'responses.executive.multiTasking',
        'responses.executive.organization',
        'responses.executive.planning',
        'responses.executive.decisionMaking',
        'responses.executive.problemSolving',
        'responses.executive.inappropriateSocialBehavior',
        'responses.executive.inappropriateSocialBehaviorText'
    )
    get unselectedExecutiveFunctionIssues() {
        return this.getExecutiveFunctionIssues().filter(item => item.response !== null && item.response.value === false);
    }

    getExecutiveFunctionIssues() {
        return [
            { "name": "multi-task", "description": "multi-tasking", "response": this.responses.executive.multiTasking },
            { "name": "organize", "description": "organization", "response": this.responses.executive.organization },
            { "name": "plan", "description": "planning", "response": this.responses.executive.planning },
            { "name": "make decisions", "description": "decision making", "response": this.responses.executive.decisionMaking },
            { "name": "problem solve", "description": "problem solving", "response": this.responses.executive.problemSolving },
            { "name": this.responses.executive.inappropriateSocialBehaviorText || "", "description": "inappropriate social behavior", "response": this.responses.executive.inappropriateSocialBehavior }
        ];
    }

    getItemName(item) {
        return item.name;
    }

    getItemDescription(item) {
        return item.description;
    }

    executiveFunctionIssueChanged() {
        this.signaler.signal('executive-function-issue-changed');
    }
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}