import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';

@inject(DataRepository, Context)
export class PhoneLogs {

    constructor(dataRepository, context) {
        this.dataRepository = dataRepository;
        this.context = context;

        this.startCallTime = null;
        this.endCallTime = null;
        this.companyName = null;
        this.claimantFirstName = null;
        this.claimantLastName = null;

        this.phoneLogs = null;
        this.user = null;
    }

    activate() {
        return this.getData();
    }

    getData() {
        return this.context.getUser().then(user => this.user = user);
    }

    search() {
        this.dataRepository.searchPhoneLogs({
            "startCallTime": this.startCallTime,
            "endCallTime": this.endCallTime,
            "companyName": this.companyName,
            "claimantFirstName": this.claimantFirstName,
            "claimantLastName": this.claimantLastName
        }).then(data => this.phoneLogs = data);
    }
}