
export class Config {
	constructor() {
		
		
		this.isoShortDateFormat = 'YYYY-MM-DD';
		this.isoShortTimeFormat = 'HH:mm';
		
		this.shortDateFormat = 'MM-DD-YYYY';
		this.shortTimeFormat = 'h:mm A';
		
		this.longDateFormat = 'MMMM D YYYY';
		this.longDateTimeFormat = this.longDateFormat + ' ' + this.shortTimeFormat;
		
		this.defaultNewAppointmentHour = 9;
		
		this.dateRangePickerOptions = {
			'autoApply': true,
			'showDropdowns': true,
			'linkedCalendars': false
		};
		
		this.datepickerOptions = {
			'autoclose': true,
			'clearBtn': true,
			'format': 'MM d yyyy',
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
			largeFileFeeAmount: 25000,
			lateCancellationRate: 0.30,
			'addressTypeIds': [2]
		};

		this.invoiceTypes = {
			'psychologist': 1,
			'psychometrist': 2
		}
		
		this.addressDefaults = {
			'province': 'ON',
			'country': 'Canada'
		};
		
		this.appointmentDefaults = {
			'attributeTypeIds': [1,3],
			'addressTypeIds': [3]
		};
		
		this.assessmentDefaults = {
			'attributeTypeIds': [2,4,5,6,7,8]
		};
		
		this.rights = {
			'Psychologist': 1,
			'Psychometrist': 2,
			'WriteDocList': 3,
			'WriteNotes': 4
		};
	}
}