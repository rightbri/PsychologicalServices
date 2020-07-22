import {inject} from 'aurelia-framework';
import {BindingSignaler} from 'aurelia-templating-resources';
import {computedFrom} from 'aurelia-framework';
import {Context} from 'common/context';
import {DataRepository} from 'services/dataRepository';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';
import html2canvas from 'html2canvas';

@inject(BindingSignaler, Context, DataRepository, Notifier, Scroller)
export class GoseInterview {

    constructor(signaler, context, dataRepository, notifier, scroller) {
        this.signaler = signaler;
        this.context = context;
        this.dataRepository = dataRepository;
        this.notifier = notifier;
        this.scroller = scroller;

        this.searchCompanyId = null;
        this.interview = null;
        this.claimant = null;
        this.claimants = null;
        this.assessments = null;

        this.yesNo = [];
        this.accidentTimeframes = [];
        this.familyAndFriendshipsDisruptionLevels = [];
        this.respondentTypes = [];
        this.returnToNormalLifeOutcomeFactors = [];
        this.socialAndLeisureRestrictionExtents = [];
        this.workRestrictionLevels = [];

        this.accidentTimeframeMatcher = this.getMatcher(x => x.goseAccidentTimeframeId);
        this.familyAndFriendshipsDisruptionLevelMatcher = this.getMatcher(x => x.goseFamilyAndFriendshipsDisruptionLevelId);
        this.respondentTypeMatcher = this.getMatcher(x => x.goseRespondentTypeId);
        this.returnToNormalLifeOutcomeFactorMatcher = this.getMatcher(x => x.goseReturnToNormalLifeOutcomeFactorId);
        this.socialAndLeisureRestrictionExtentMatcher = this.getMatcher(x => x.goseSocialAndLeisureRestrictionExtentId);
        this.workRestrictionLevelMatcher = this.getMatcher(x => x.goseWorkRestrictionLevelId);
    }

    getMatcher(idFunc) {
        return (a, b) => a && b && idFunc(a) == idFunc(b);
    }

    claimantSelected(e) {
        this.search(e.detail.claimant, this.searchCompanyId);

        this.claimants = null;
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
                    this.getYesNo().then(data => this.yesNo = data),
                    this.dataRepository.getGoseAccidentTimeframes().then(data => {
                        this.accidentTimeframes = this.asArray(data);
                        this.accidentTimeframesMap = data;
                    }),
                    this.dataRepository.getGoseFamilyAndFriendshipsDisruptionLevels().then(data => {
                        this.familyAndFriendshipsDisruptionLevels = this.asArray(data);
                        this.familyAndFriendshipsDisruptionLevelMap = data;
                    }),
                    this.dataRepository.getGoseRespondentTypes().then(data => {
                        this.respondentTypes = this.asArray(data);
                        this.respondentTypesMap = data;
                    }),
                    this.dataRepository.getGoseReturnToNormalLifeOutcomeFactors().then(data => {
                        this.returnToNormalLifeOutcomeFactors = this.asArray(data);
                        this.returnToNormalLifeOutcomeFactorMap = data;
                    }),
                    this.dataRepository.getGoseSocialAndLeisureRestrictionExtents().then(data => {
                        this.socialAndLeisureRestrictionExtents = this.asArray(data);
                        this.socialAndLeisureRestrictionExtentsMap = data;
                    }),
                    this.dataRepository.getGoseWorkRestrictionLevels().then(data => {
                        this.workRestrictionLevels = this.asArray(data);
                        this.workRestrictionLevelsMap = data;
                    })
                ]);
            });
    }

    reset(resetClaimantData) {
        this.interview = null;
        this.assessments = null;
        
        this.claimant = null;
    }

    search(claimant, companyId) {
        this.reset();

        return this.dataRepository.searchAssessments({
            'claimantId': claimant ? claimant.claimantId : null,
            'companyId': companyId
        }).then(data => this.assessments = data);
    }

    select(assessment) {
        this.assessments = null;
        
        return this.dataRepository.getGoseInterview(assessment.assessmentId).then(data => this.interview = data);
    }

    scrollToTop() {
        this.scroller.scrollTo(document.body);
    }

    scrollToBottom() {
        this.scroller.scrollTo(document.getElementById("bottom"));
    }

    @computedFrom(
        'interview',
        'claimants'
    )
    get formVisible() {
        return this.interview && !this.claimants;
    }

    save() {
        try {
            this.interview.updateUser = this.user;

            if (this.interview.goseInterviewId === 0) {
                this.interview.createUser = this.user;
            }

            this.dataRepository.saveGoseInterview(this.interview).then(data => {

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

    delete() {
        if (confirm('Delete Interview\nAre you sure?')) {
            this.dataRepository.deleteGoseInterview(this.interview.goseInterviewId).then(data => {
                if (data.isError) {
                    this.notifier.error(data.errorDetails);
                }
                else {
                    this.reset(true);
                    
                    if (data.isDeleted) {
                        this.notifier.info('Deleted');
                    }
                }
            });
        }
    }

    asArray(map) {
        let a = [];

        for (let key in map) {
            a.push(map[key]);
        }

        return a;
    }

    getYesNo() {
        let data = {
            "yes": { "description": "Yes", "value": true },
            "no": { "description": "No", "value": false },
            "skip": { "description": "Skip", "value": null }
        };

        return getPromise(data);
    }

    screenshot() {
        let fileName = this.claimant.lastName + '_' + this.claimant.firstName + '_GOSE_INTERVIEW_NOTES.png';

        html2canvas(document.getElementById("goseContent")).then(canvas => {
            canvas.toBlob(function(blob) {
                if (navigator.msSaveBlob) {
                    return navigator.msSaveBlob(blob, fileName);
                }
                
                var blobUrl = window.URL.createObjectURL(blob);
                var anchor = document.createElement('a');
                anchor.download = fileName;
                anchor.href = blobUrl;
                document.body.appendChild(anchor);
                anchor.click();
                document.body.removeChild(anchor);
            });
        }).catch(function (error) {
            console.log(error);
        	/* This is fired when the promise executes without the DOM */    
    	});
    }
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}
