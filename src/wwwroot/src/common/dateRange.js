import moment from 'moment';

export class DateRange {
	constructor(start, end) {
		this.startDate = moment(start);
		this.endDate = moment(end);
	}
	
	shift(days) {
		this.startDate.add(days, 'days');
		this.endDate.add(days, 'days');
	}
	
	to(start, end) {
		this.startDate = moment(start);
		this.endDate = moment(end);
	}
}