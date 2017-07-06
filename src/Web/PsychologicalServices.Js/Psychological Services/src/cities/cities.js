import {inject} from 'aurelia-framework';
import {DataRepository} from '../services/dataRepository';

@inject(DataRepository)
export class Cities {
	constructor(dataRepository) {
		this.dataRepository = dataRepository;
	}
	
	activate() {
		return Promise.all([
			this.dataRepository.getCities().then(data => this.cities = data)
		]);
	}
}