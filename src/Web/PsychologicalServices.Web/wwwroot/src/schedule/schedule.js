import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class Schedule {
	constructor(dataRepository) {
		this.dataRepository = dataRepository;
		
		
	}
	
	
}