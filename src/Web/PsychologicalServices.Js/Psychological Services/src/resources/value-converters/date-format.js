import moment from 'moment';

export class DateFormatValueConverter {
	toView(value, format) {
		if (!isNaN(Date.parse(value))) {
			return moment.utc(value).local().format(format);
		}
		
		return value;
	}
	
	fromView(value, format) {
		var m = moment(value, format).utc();

		if (m.isValid()) {
			//return m.toDate();
			return m.format();
		}
		
		return value;
	}
}