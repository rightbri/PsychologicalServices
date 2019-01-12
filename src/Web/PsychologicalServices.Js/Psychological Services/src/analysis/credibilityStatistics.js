import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class CredibilityStatistics {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;

        this.visibleTab = 0;
    }

    activate() {
        return this.context.getUser().then(user => {
            this.user = user;

            return this.search();
        });
    }

    search() {
        this.dataRepository.searchCredibilityData({
            'companyId': this.user.company.companyId
        }).then(data => this.credibilityData = data);
    }
    
    showTab(index) {
        this.visibleTab = index;
    }
}