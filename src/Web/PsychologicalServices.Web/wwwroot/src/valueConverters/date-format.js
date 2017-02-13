import moment from 'moment';

export class DateFormatValueConverter {
	toView(value, format) {
		if (!isNaN(Date.parse(value))) {
			return moment(value).format(format);
		}
		
		return value;
	}
}