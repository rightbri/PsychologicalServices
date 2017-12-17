import {DataRepository} from 'repository/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class Index {
    constructor(dataRepository) {
        this.dataRepository = dataRepository;

        this.noEventsMessage = "Loading upcoming events...";

        this.searchCompanyId = 1;
        this.searchExpired = false;
        this.searchActive = true;
    }

    attached() {
        return Promise.all([
			this.getEvents()
        ]);
    }

    getEvents() {
        return this.dataRepository.getEvents({
            'companyId': this.searchCompanyId,
            'isExpired': this.searchExpired,
			'isActive': this.searchActive
        }).then(data => {
            this.events = data;
            //message to be displayed if data is empty
            this.noEventsMessage = "No upcoming events";
        }).catch(err => {
            console.log(err);
            this.noEventsMessage = "Unable to load events";
        });
    }
}