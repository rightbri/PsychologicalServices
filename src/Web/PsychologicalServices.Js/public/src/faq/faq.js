import {DataRepository} from 'repository/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class Faq {

    constructor(dataRepository) {
        this.dataRepository = dataRepository;
    }

    activate() {
        return Promise.all([
            this.dataRepository.getFaqs().then(data => this.faqs = data)
        ]);
    }

}