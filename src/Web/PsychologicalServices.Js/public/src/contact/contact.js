import {DataRepository} from 'repository/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class Contact {

    constructor(dataRepository) {
        this.dataRepository = dataRepository;
    }

    activate() {
        return Promise.all([
            this.dataRepository.getContactInfo().then(data => this.contactInfo = data)
        ]);
    }
}