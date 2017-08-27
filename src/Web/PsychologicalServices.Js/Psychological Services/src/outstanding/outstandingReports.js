import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class OutstandingReports {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;

    }

    activate() {
        return this.context.getUser().then(user => this.user = user);
    }

    search() {
        this.dataRepository.searchOutstandingReports({
            'companyId': this.user.company.companyId,
            'daysOutstanding': this.daysOutstanding,
            'searchStart': this.searchStart
        }).then(data => {
            this.outstandingReports = data;
        });
    }
    
	dateChanged(e) {
		this.searchStart = e.detail.dates[0];
	}
}