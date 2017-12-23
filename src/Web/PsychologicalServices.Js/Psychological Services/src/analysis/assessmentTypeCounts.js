import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class AssessmentTypeCounts {

    constructor(dataRepository, config, context) {
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;

        this.searchYear = new Date().getFullYear();
        this.searchAssessmentTypeIds = [];
    }

    activate() {
        return Promise.all([
            this.context.getUser().then(user => this.user = user),
            this.dataRepository.getAssessmentTypes().then(data => this.assessmentTypes = data)
        ]);
    }

    search() {
        this.dataRepository.searchAssessmentTypeCounts({
            'companyId': this.user.company.companyId,
            'year': this.searchYear,
            'assessmentTypeIds': this.searchAssessmentTypeIds
        }).then(data => {
            this.assessmentTypeCounts = data;
        });
    }
}