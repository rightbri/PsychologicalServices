import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';

@inject(DataRepository, Context)
export class Arbitrations {

    constructor(dataRepository, context) {
        this.dataRepository = dataRepository;
        this.context = context;
    }

    activate() {
        return this.getData();
    }

    getData() {
        return this.context.getUser().then(user => this.user = user);
    }

    search() {
        this.dataRepository.searchArbitrations({
            'companyId': this.user.company.companyId,
            'claimantId': this.searchClaimant ? this.searchClaimant.claimantId : null
        }).then(data => this.arbitrations = data);
    }
}