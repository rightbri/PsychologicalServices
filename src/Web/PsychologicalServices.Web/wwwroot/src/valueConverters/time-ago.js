import moment from 'moment';

export class TimeAgoValueConverter {
	toView(value) {
		if (!isNaN(Date.parse(value))) {
			return moment(value).from(moment());
		}
		
		return "";
	}
}