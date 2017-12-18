import {DataRepository} from 'repository/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class Links {

    constructor(dataRepository) {
        this.dataRepository = dataRepository;
    }

    activate() {
        return Promise.all([
            this.dataRepository.getLinks().then(data => this.links = data)
        ]);
    }
}