import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class ResearchConsentObtainedClaimantData {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;
    }

    activate() {
        return this.context.getUser().then(user => {
            this.user = user;
            this.search();
        });
    }

    search() {
        this.dataRepository.searchResearchConsentObtainedClaimantData({
            'companyId': this.user.company.companyId
        }).then(data => this.researchConsentObtainedClaimantData = data);
    }
}