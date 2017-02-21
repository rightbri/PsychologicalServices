import moment from 'moment';

export class WeekView {

	constructor() {
		this.today = moment();
		
		this.days = this.getWeekDays(this.today);
	}

	previousWeek() {
		this.days =  this.getWeekDays(this.weekStart.clone().weekday(-7));
	}
	
	nextWeek() {
		this.days = this.getWeekDays(this.weekStart.clone().weekday(7));
	}
	
	getWeekDays(today) {
		var t = this.momentDate(today);
		
		this.weekStart = t.clone().weekday(0);
		this.weekEnd = t.clone().weekday(7);
	
		var days = [];
		
		for (var i = 0; i < 7; i++) {
			days.push(t.clone().weekday(i));
		}
		
		return days;
	}
	
	momentDate(date) {
		return moment.isMoment(date) ? date : moment(date);
	}
}