import {inject} from 'aurelia-framework';
import {Config} from 'common/config';
import {Timezone} from 'common/timezone';

@inject(Config, Timezone)
export class DateService {

	constructor(config, timezone) {
		this.config = config;
		this.timezone = timezone;
	}
	
	today() {
		let now = this.now();
		
		return new Date(now.getFullYear(), now.getMonth(), now.getDate());
	}
	
	now() {
		return new Date();
	}
	
	utcNow() {
		let date = this.now();
		
		return this.toUtc(date);
	}
	
	timezoneNow(timezone) {
		return this.timezone.fromUtc(this.utcNow(), timezone);
	}
	
	toUtc(date) {
		return new Date(date.toUTCString());
	}
	
	addDays(date, days) {
		let newDate = new Date(date.valueOf());
		
		newDate.setDate(newDate.getDate() + days);
		
		return newDate;
	}
}