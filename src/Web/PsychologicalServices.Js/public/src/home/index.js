import {DataRepository} from 'repository/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class Index {
    constructor(dataRepository) {
        this.dataRepository = dataRepository;
    }

    activate() {
        return Promise.all([
			this.getEvents()
        ]);
    }

    getEvents() {
        return this.dataRepository.getEvents({
            'isExpired': false,
			'isActive': true
        }).then(data => this.events = data).catch(err => console.log(err));
    }
}