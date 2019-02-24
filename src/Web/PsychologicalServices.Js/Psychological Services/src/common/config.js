
export class Config {
	constructor() {
		
		this.timezone = 'America/Toronto';	//moment-timezone
		
		this.isoShortDateFormat = 'YYYY-MM-DD';
		this.isoShortTimeFormat = 'HH:mm';
		
		this.shortDateFormat = 'DD/MM/YYYY';
		
		this.shortTimeFormat = 'h:mm a';
		
		this.longDateFormat = 'MMMM D, YYYY';
		this.longDateTimeFormat = this.longDateFormat + ' ' + this.shortTimeFormat;
		
		this.datepickerShortDateFormat = 'd/m/Y';
		
		this.datepickerOptions = {
			'altFormat': 'F j, Y',
			'altInput': true
		};
		
		this.monthPickerOptions = {
			'altFormat': 'F, Y',
			'altInput': true
			
		};
		
		this.datemaskOptions = {
			'alias': 'dd/mm/yyyy'
		};
		
		this.timemaskOptions = {
			'alias': 'hh:mm t'
		};
		
		this.calendarDefaults = {
			appointmentStatusIds: [1,2,4,5,6,7,8],	//all except canceled
			defaultView: 'schedule'
		};
		
		this.referralSourceDefaults = {
			largeFileSize: 1000,
			largeFileFeeAmount: 25000,
			lateCancellationRate: 0.30,
			'addressTypeIds': [2]
		};

		this.contactTypes = {
			'defenseLawyer': 1,
			'defenseLawClerk': 2,
			'plaintiffLawyer': 3,
			'plaintiffLawClerk': 4
		};
		
		this.invoiceTypes = {
			'psychologist': 1,
			'psychometrist': 2,
			'arbitration': 3,
			'rawTestData': 4
		}
		
		this.addressDefaults = {
			'province': 'ON',
			'country': 'Canada',
			'userAddressTypeId': 4,
			'contactAddressTypeId': 5
		};
		
		this.appointmentDefaults = {
			'attributeTypeIds': [1,3],
			'addressTypeIds': [3]
		};
		
		this.assessmentDefaults = {
			'attributeTypeIds': [2,4,5,6,11],
			'reportStatusAttributeTypeIds': [9,13],
			'medicalFileAttributeTypeIds': [9],
			'resultsAttributeTypeIds': [7,8],
			'postAssessmentAttributeTypeIds': [12]
		};
		
		this.assessmentSummaryDefaults = {
			'attributeTypeIds': {
				'psychiatrist': 6,
				'reader': 1,
				'translator': 1
			}
		};

		this.rawTestDataDefaults = {
			'referralSourceTypeIds': {
				'psychologist': 5
			}
		};

		this.months = [
            '',//skip index 0, use 1-based indexing
            'January',
            'February',
            'March',
            'April',
            'May',
            'June',
            'July',
            'August',
            'September',
            'October',
            'November',
            'December'
        ];
		
		this.rights = {
			'Psychologist': 1,
			'Psychometrist': 2,
			'WriteDocList': 3,
			'WriteNotes': 4
		};
		
		this.authTokenKey = 'authToken';
	}
}