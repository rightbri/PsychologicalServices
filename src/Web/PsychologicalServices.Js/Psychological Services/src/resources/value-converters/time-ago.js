import moment from 'moment';

export class TimeAgoValueConverter {
	toView(value) {
		if (!isNaN(Date.parse(value))) {
			return moment.utc(value).from(moment.utc());
		}
		
		return "";
	}
}