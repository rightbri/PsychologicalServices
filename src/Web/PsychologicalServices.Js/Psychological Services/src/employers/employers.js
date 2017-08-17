import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class Employers {
	constructor(dataRepository) {
		this.dataRepository = dataRepository;

		this.employers = [];
		this.employerTypes = [];
		
		this.searchName = null;
		this.searchEmployerTypeIds = [];
		this.searchActive = null;
	}
	
	activate() {
		return Promise.all([
			this.dataRepository.getEmployerTypes().then(data => this.employerTypes = data),
			this.search()
		]);
	}
	
	search() {
		return this.dataRepository.searchEmployers({
			name: this.searchName,
			employerTypeIds: this.searchEmployerTypeIds,
			isActive: this.searchActive
		}).then(data => this.employers = data);
	}
}