
export class Config {
	constructor() {
		
		this.isoShortDateFormat = 'YYYY-MM-DD';
		this.isoShortTimeFormat = 'HH:mm';
		this.shortDateFormat = 'MM-DD-YYYY';
		this.shortTimeFormat = 'h:mmA';
		
		this.dateRangePickerOptions = {
			'autoApply': true,
			'showDropdowns': true,
			'linkedCalendars': false
		};
		
		this.datePickerOptions = {
			'autoclose': true,
			'clearBtn': true,
			'format': 'mm-dd-yyyy',
			'showOnFocus': true,
			'toggleActive': true
		};
	}
}