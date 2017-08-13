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
	
	utcToday() {
		let date = this.today();
		
		return this.toUtc(date);
	}
	
	utcNow() {
		let date = this.now();
		
		return this.toUtc(date);
	}
	
	timezoneNow(timezone) {
		return this.utcToTimezone(this.utcNow(), timezone);
	}
	
	utcToTimezone(utcDate, timezone) {
		return this.timezone.fromUtc(utcDate, timezone);
	}
	
	toZone(date, timezone) {
		let date1 = this.timezone.convertDate(date, timezone);
		
		let date2 = this.timezone.getDatetimeInZone(date, timezone);
		
		return date2;
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