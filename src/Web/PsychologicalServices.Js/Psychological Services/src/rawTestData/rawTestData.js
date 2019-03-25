import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';

@inject(DataRepository, Context)
export class RawTestData {

    constructor(dataRepository, context) {
        this.dataRepository = dataRepository;
        this.context = context;

        this.rawTestDataStatuses = [];
    }

    activate() {
        return this.getData();
    }

    getData() {
        return this.context.getUser().then(user => {
            this.user = user;

			return this.dataRepository.getRawTestDataStatuses().then(data => this.rawTestDataStatuses = data);
        });
    }

    search() {
        this.dataRepository.searchRawTestData({
            'companyId': this.user.company.companyId,
            'claimantId': this.searchClaimant ? this.searchClaimant.claimantId : null,
            'recipientName': this.searchRecipientName,
            'rawTestDataStatusIds': this.searchStatusIds
        }).then(data => this.rawTestDatas = data);
    }
}