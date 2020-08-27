import {inject} from 'aurelia-framework';
import {computedFrom} from 'aurelia-framework';
import {Context} from 'common/context';
import {DataRepository} from 'services/dataRepository';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';

@inject(Context, DataRepository, Notifier, Scroller)
export class AssessmentProtocolResponse {

    constructor(context, dataRepository, notifier, scroller) {
        this.context = context;
        this.dataRepository = dataRepository;
        this.notifier = notifier;
        this.scroller = scroller;

        this.searchCompanyId = null;
        this.responses = null;
        this.claimant = null;
        this.claimants = null;
        this.assessment = null;
        this.assessments = null;

        this.yesNo = [];
        this.yesNoNa = [];
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
                    this.getYesNo().then(data => this.yesNo = this.asArray(data)),
                    this.getYesNoNa().then(data => this.yesNoNa = this.asArray(data))
                ]);
            });
    }

    reset(resetClaimantData) {
        this.responses = null;
        this.assessments = null;
        this.assessment = null;
        this.claimant = null;
    }

    search(claimant, companyId) {
        this.reset();

        return this.dataRepository.searchAssessments({
            'claimantId': claimant ? claimant.claimantId : null,
            'companyId': companyId
        }).then(data => {
            this.assessments = data;
        });
    }

    select(assessment) {
        this.assessment = assessment;
        this.assessments = null;
        
        return this.dataRepository.getAppointmentProtocolResponse(assessment.appointmentId).then(data => this.responses = data);
    }

    scrollToTop() {
        this.scroller.scrollTo(document.body);
    }

    scrollToBottom() {
        this.scroller.scrollTo(document.getElementById("bottom"));
    }

    @computedFrom(
        'responses',
        'claimants'
    )
    get formVisible() {
        return this.responses && !this.claimants;
    }

    save() {
        try {
            this.responses.createUser = this.user;
            this.responses.updateUser = this.user;

            this.dataRepository.saveAppointmentProtocolResponse(this.responses).then(data => {

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

    asArray(map) {
        let a = [];

        for (let key in map) {
            a.push(map[key]);
        }

        return a;
    }

    getYesNo() {
        let data = {
            "yes": { "description": "Yes", "value": 1 },
            "no": { "description": "No", "value": 2 }
        };

        return getPromise(data);
    }

    getYesNoNa() {
        let data = {
            "yes": { "description": "Yes", "value": 1 },
            "no": { "description": "No", "value": 2 },
            "na": { "description": "N/A", "value": 3 }
        };

        return getPromise(data);
    }
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}
