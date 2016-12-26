import {DateRange} from 'common/DateRange';
import moment from 'moment';

export class WeekView {
	constructor() {
		this.today = moment();
		
		this.week = new DateRange(this.today.clone().startOf('week'), this.today.clone().endOf('week'));
		
		this.days = this.getDays();
	}
	
	changed() {
		this.days = this.getDays();
	}
	
	next() {
		this.week.shift(7);
		this.changed();
	}
	
	prev() {
		this.week.shift(-7);
		this.changed();
	}
	
	getDays() {
		var days = [];
		
		for (var day = this.week.startDate.clone(); !day.isAfter(this.week.endDate); day.add(1, 'days')) {
			days.push(day.clone());
		}
		
		return days;
	}
}