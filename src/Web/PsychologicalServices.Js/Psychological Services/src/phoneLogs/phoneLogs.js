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
	
	delete(phoneLog) {
		if (confirm('Delete Phone Log entry\nAre you sure?')) {
			this.dataRepository.deletePhoneLog(phoneLog.phoneLogId).then(data => {
			
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				else {
					this.phoneLogs = this.phoneLogs.filter(value => value.phoneLogId !== phoneLog.phoneLogId);

					this.notifier.info('Deleted');
				}
			});
		}
	}
}