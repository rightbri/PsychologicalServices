import {inject} from 'aurelia-framework';
import {Config} from 'common/config';
import {Timezone} from 'common/timezone';

@inject(Config, Timezone)
export class AgeService {

	constructor(config, timezone) {
		this.config = config;
		this.timezone = timezone;
	}
	
	getAge(dateString) {
		//https://stackoverflow.com/a/7091965
		var today = new Date();
		var birthDate = new Date(dateString);
		var age = today.getFullYear() - birthDate.getFullYear();
		
		var monthDifference = today.getMonth() - birthDate.getMonth();
		
		if (monthDifference < 0 ||
			(monthDifference === 0 && today.getDate() < birthDate.getDate()) ||
			(monthDifference === 0 && today.getDate() === birthDate.getDate() && today.getHours() < birthDate.getHours())) {
			age--;
		}

		return age;
	}
	
	getDateOfBirth(age) {
		let today = new Date();

		let year = today.getFullYear() - age;

		let dateString = new Date('01/01/' + year);

		return this.timezone.getDatetimeInZone(dateString, this.config.timezone);
	}
}
