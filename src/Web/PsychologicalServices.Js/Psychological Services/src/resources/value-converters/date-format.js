import {inject} from 'aurelia-framework';
import {Config} from 'common/config';
import * as moment from 'moment';
import 'moment-timezone';

@inject(Config)
export class DateFormatValueConverter {
	
	constructor(config) {
		this.config = config;
	}
	
	toView(value, format) {
		if (!isNaN(Date.parse(value))) {
			return moment.tz(value, this.config.timezone).format(format);
		}
		
		return value;
	}
	
	fromView(value, format) {
		var m = moment.tz(value, format, this.config.timezone);

		if (m.isValid()) {
			return m.format();
		}
		
		return value;
	}
}
