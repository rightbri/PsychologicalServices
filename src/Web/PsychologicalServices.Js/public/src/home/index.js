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
        //this.events = this.getEvents();
    }

    getEvents() {
        /*
        var events = [
            { 'description': 'Dont be CATatonic...', 'location': '20 Toronto Street, Toronto, ON M5C 2B8', 'url': 'http://www.mlst.ca/?page=52', 'time': 'Wed Feb 21 2018 from 9:00 am - 12:30 pm' }
        ];

        return events;
        */

        return this.dataRepository.getEvents({
			isActive: true
        }).then(data => this.events = data).catch(err => console.log(err));
/**/
    }
}