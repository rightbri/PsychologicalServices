
export class Config {
	constructor() {
		
		this.longDateFormat = 'MMMM Do, YYYY';
		
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
		
		this.appointmentDefaults = {
			'attributeTypeIds': [1,3]
		};
		
		this.assessmentDefaults = {
			'attributeTypeIds': [2,4,5,6]
		};
		
		this.rights = {
			'Psychologist': 1,
			'Psychometrist': 2,
			'WriteDocList': 3,
			'WriteNotes': 4
		};
	}
}