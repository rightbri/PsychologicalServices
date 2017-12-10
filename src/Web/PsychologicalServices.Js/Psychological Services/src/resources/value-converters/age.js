import {inject} from 'aurelia-framework';
import {AgeService} from 'common/ageService';

@inject(AgeService)
export class AgeValueConverter {
	
	constructor(ageService) {
		this.ageService = ageService;
	}

	toView(value) {
		if (!isNaN(Date.parse(value))) {
			let birthDate = new Date(value);

			return this.ageService.getAge(birthDate);
		}
		
		return value;
	}
}
