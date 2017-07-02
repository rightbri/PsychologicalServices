
export class Config {
	constructor() {
		
		this.timezone = 'America/Toronto';	//moment-timezone
		
		this.isoShortDateFormat = 'YYYY-MM-DD';
		this.isoShortTimeFormat = 'HH:mm';
		
		this.shortDateFormat = 'DD/MM/YYYY';
		
		this.shortTimeFormat = 'h:mm A';
		
		this.longDateFormat = 'MMMM D, YYYY';
		this.longDateTimeFormat = this.longDateFormat + ' ' + this.shortTimeFormat;
		
		this.dateRangePickerOptions = {
			'autoApply': true,
			'showDropdowns': true,
			'linkedCalendars': false
		};
		
		this.datepickerOptions = {
			'autoclose': true,
			'clearBtn': true,
			'format': 'MM d, yyyy',
			'showOnFocus': true,
			'toggleActive': true
		};
		
		this.monthPickerOptions = {
			'autoclose': true,
			'clearBtn': true,
			'format': 'MM, yyyy',
			'startView': 'months',
			'minViewMode': 'months',
			'showOnFocus': true,
			'toggleActive': true
		};
		
		this.datemaskOptions = {
			'alias': 'dd/mm/yyyy'
		};
		
		this.timemaskOptions = {
			'alias': 'hh:mm t'
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
			'country': 'Canada',
			'userAddressTypeId': 4
		};
		
		this.appointmentDefaults = {
			'attributeTypeIds': [1,3],
			'addressTypeIds': [3]
		};
		
		this.assessmentDefaults = {
			'attributeTypeIds': [2,4,5,6,7,8]
		};
		
		this.assessmentSummaryDefaults = {
			'attributeTypeIds': {
				'psychiatrist': 6,
				'reader': 1,
				'translator': 1
			}
		};
		
		this.rights = {
			'Psychologist': 1,
			'Psychometrist': 2,
			'WriteDocList': 3,
			'WriteNotes': 4
		};
		
		this.authTokenKey = 'firebaseAuthToken';
	}
}