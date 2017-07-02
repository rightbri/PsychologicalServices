import {inject} from 'aurelia-framework';
import {Config} from 'common/config';
import {Timezone} from 'common/timezone';
import * as moment from 'moment';
import 'moment-timezone';

@inject(Config, Timezone)
export class DateFormatValueConverter {
	
	constructor(config, timezone) {
		this.config = config;
		this.timezone = timezone;
		
		moment.tz.add(this.timezone.getTimezones());
	}
	
	toView(value, format) {
		if (!isNaN(Date.parse(value))) {
			return moment.utc(value).tz(this.config.timezone).format(format);
		}
		
		return value;
	}
	
	fromView(value, format) {
		var m = moment.tz(value, format, this.config.timezone).utc();

		if (m.isValid()) {
			return m.format();
		}
		
		return value;
	}
}
