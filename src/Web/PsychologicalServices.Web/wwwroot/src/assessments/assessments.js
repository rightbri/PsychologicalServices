import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';

@inject(DataRepository)
export class Assessments {
	constructor(dataRepository) {
		
		dataRepository.searchAssessments({
			companyId: 1
		}).then(data => this.assessments = data);
		
	}
}