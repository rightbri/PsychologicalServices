import moment from 'moment';

export class DayClassValueConverter {
	toView(value) {
		if (!isNaN(Date.parse(value))) {
			return moment(value).isoWeekday() > 5 ? 'active' : '';
		}
		
		return '';
	}
}