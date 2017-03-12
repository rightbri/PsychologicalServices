
export class Config {
	constructor() {
		
		this.longDateFormat = 'MM-DD-YYYY h:mmA';
		
		this.isoShortDateFormat = 'YYYY-MM-DD';
		this.isoShortTimeFormat = 'HH:mm';
		this.shortDateFormat = 'MM-DD-YYYY';
		this.shortTimeFormat = 'h:mmA';
		
		this.defaultNewAppointmentHour = 9;
		
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
		
		this.monthPickerOptions = {
			'autoclose': true,
			'clearBtn': true,
			'format': 'MM, yyyy',
			'startView': 'months',
			'minViewMode': 'months',//1,
			'showOnFocus': true,
			'toggleActive': true
		};
		
		this.referralSourceDefaults = {
			largeFileSize: 1000,
			largeFileFeeAmount: 25000
		};
		
		this.addressDefaults = {
			'province': 'ON',
			'country': 'Canada'
		};
	}
}