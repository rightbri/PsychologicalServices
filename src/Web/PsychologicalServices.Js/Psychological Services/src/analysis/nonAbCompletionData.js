import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';

@inject(DataRepository, Context)
export class NonAbCompletionData {

    constructor(dataRepository, context) {
        this.dataRepository = dataRepository;
        this.context = context;

        this.searchMonths = null;
    }

    activate() {
        return this.context.getUser().then(user => this.user = user);
    }

    search() {
        this.dataRepository.searchNonAbCompletionData({
            'companyId': this.user.company.companyId,
            'months': this.searchMonths
        }).then(data => this.nonAbCompletionData = data);
    }
}