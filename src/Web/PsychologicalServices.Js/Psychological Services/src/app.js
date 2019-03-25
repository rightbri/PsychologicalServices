import {inject} from 'aurelia-framework';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {DateService} from 'common/dateService';
import {UIkit} from 'uikit';

@inject(Context, Config, DateService)
export class App {
  constructor(context, config, dateService) {
    this.context = context;
	this.config = config;
	this.dateService = dateService;
	
	this.title = "Psychological Services";
  }
  
  configureRouter(config, router) {
		this.router = router;
		
		config.title = this.title;
		
		config.options.pushState = true;
		config.options.root = '/';
		
		var calendarNavigationStrategy = (instruction) => {
			let appTime = this.dateService.timezoneNow(this.config.timezone);

			let route = getCalendarRoute(appTime);
			
			instruction.config.redirect = route;
		};
		
		config.map([
			{ route: ['', 'calendar'], navigationStrategy: calendarNavigationStrategy, nav: true },
			{ route: 'calendar/:year/:month/:day?', moduleId: 'calendar/calendar', title: 'Calendar', nav: false },
			{ route: 'assessments', name: 'assessments', moduleId: 'assessments/assessments', title: 'Assessments', nav: true },
			{ route: 'assessments/:id', name: 'editAssessment', moduleId: 'assessments/editAssessment', title: 'Edit Assessment', nav: false },
			{ route: 'assessments/add/:year/:month/:day', name: 'addAssessment', moduleId: 'assessments/editAssessment', title: 'Add Assessment', nav: false },
			{ route: 'invoices', name: 'invoices', moduleId: 'invoices/invoices', title: 'Invoices', nav: true },
			{ route: 'invoices/:id', name: 'editInvoice', moduleId: 'invoices/editInvoice', title: 'Edit Invoice', nav: false },
			{ route: 'invoices/psychometrist', name: 'psychometristInvoices', moduleId: 'invoices/psychometristInvoices', title: 'Create Psychometrist Invoices', nav: false },
			{ route: 'invoices/psychologist', name: 'psychologistInvoices', moduleId: 'invoices/psychologistInvoices', title: 'Create Psychologist Invoices', nav: false },
			{ route: 'invoices/arbitration', name: 'arbitrationInvoices', moduleId: 'invoices/arbitrationInvoices', title: 'Create Arbitration Invoices', nav: true },
			{ route: 'invoices/rawtestdata', name: 'rawTestDataInvoices', moduleId: 'invoices/rawTestDataInvoices', title: 'Create Raw Test Data Invoices', nav: true },
			{ route: 'addresses', name: 'addresses', moduleId: 'addresses/addresses', title: 'Addresses', nav: true },
			{ route: 'addresses/:id', name: 'editAddress', moduleId: 'addresses/editAddress', title: 'Edit Address', nav: false },
			{ route: 'addresses/add', name: 'addAddress', moduleId: 'addresses/editAddress', title: 'Add Address', nav: false },
			{ route: 'cities', name: 'cities', moduleId: 'cities/cities', title: 'Cities', nav: true },
			{ route: 'cities/:id', name: 'editCity', moduleId: 'cities/editCity', title: 'Edit City', nav: false },
			{ route: 'cities/add', name: 'addCity', moduleId: 'cities/editCity', title: 'Add City', nav: false },
			{ route: 'claimants', name: 'claimants', moduleId: 'claimants/claimants', title: 'Claimants', nav: true },
			{ route: 'referralSources', name: 'referralSources', moduleId: 'referralSources/referralSources', title: 'Referral Sources', nav: true },
			{ route: 'referralSources/:id', name: 'editReferralSource', moduleId: 'referralSources/editReferralSource', title: 'Edit Referral Source', nav: false },
			{ route: 'referralSources/add', name: 'addReferralSource', moduleId: 'referralSources/editReferralSource', title: 'Add Referral Source', nav: false },
			{ route: 'schedule/psychometrist', name: 'psychometristSchedule', moduleId: 'schedule/psychometristSchedule', title: 'Psychometrist Schedule', nav: true },
			{ route: 'schedule/psychologist', name: 'psychologistSchedule', moduleId: 'schedule/psychologistSchedule', title: 'Psychologist Schedule', nav: true },
			{ route: 'users', name: 'users', moduleId: 'users/users', title: 'Users', nav: true },
			{ route: 'users/:id', name: 'editUser', moduleId: 'users/editUser', title: 'Edit User', nav: false },
			{ route: 'users/add', name: 'addUser', moduleId: 'users/editUser', title: 'Add User', nav: false },
			{ route: 'calendarNotes', name: 'calendarNotes', moduleId: 'calendarNotes/calendarNotes', title: 'Calendar Notes', nav: true },
			{ route: 'calendarNotes/:id', name: 'editCalendarNote', moduleId: 'calendarNotes/editCalendarNote', title: 'Edit Calendar Note', nav: false },
			{ route: 'calendarNotes/add', name: 'addCalendarNote', moduleId: 'calendarNotes/editCalendarNote', title: 'Add Calendar Note', nav: false },
			{ route: 'employers', name: 'employers', moduleId: 'employers/employers', title: 'Employers', nav: true },
			{ route: 'employers/:id', name: 'editEmployer', moduleId: 'employers/editEmployer', title: 'Edit Employer', nav: false },
			{ route: 'employers/add', name: 'addEmployer', moduleId: 'employers/editEmployer', title: 'Add Employer', nav: false },
			{ route: 'contacts', name: 'contacts', moduleId: 'contacts/contacts', title: 'Contacts', nav: true },
			{ route: 'contacts/:id', name: 'editContact', moduleId: 'contacts/editContact', title: 'Edit Contact', nav: false },
			{ route: 'contacts/add', name: 'addContact', moduleId: 'contacts/editContact', title: 'Add Contact', nav: false },
			{ route: 'analysis/booking-statistics', name: 'bookingStatistics', moduleId: 'analysis/bookingStatistics', title: 'Booking Statistics', nav: true },
			{ route: 'analysis/cancellation-statistics', name: 'cancellationStatistics', moduleId: 'analysis/cancellationStatistics', title: 'Cancellation Statistics', nav: true },
			{ route: 'analysis/completion-statistics', name: 'completionStatistics', moduleId: 'analysis/completionStatistics', title: 'Completion Statistics', nav: true },
			{ route: 'analysis/arbitration-statistics', name: 'arbitrationStatistics', moduleId: 'analysis/arbitrationStatistics', title: 'Arbitration Statistics', nav: true },
			{ route: 'analysis/assessment-type-counts', name: 'assessmentTypeCounts', moduleId: 'analysis/assessmentTypeCounts', title: 'Assessment Type Counts', nav: true },
			{ route: 'analysis/credibility-statistics', name: 'credibilityStatistics', moduleId: 'analysis/credibilityStatistics', title: 'Credibility Statistics', nav: true },
			{ route: 'analysis/non-ab-completions', name: 'nonAbCompletionData', moduleId: 'analysis/nonAbCompletionData', title: 'Non AB Completions', nav: true },
			{ route: 'outstanding/reports', name: 'outstandingReports', moduleId: 'outstanding/outstandingReports', title: 'Outstanding Reports', nav: true },
			{ route: 'events', name: 'events', moduleId: 'events/events', title: 'Events', nav: true },
			{ route: 'events/:id', name: 'editEvent', moduleId: 'events/editEvent', title: 'Edit Event', nav: false },
			{ route: 'events/add', name: 'addEvent', moduleId: 'events/editEvent', title: 'Add Event', nav: false },
			{ route: 'invoiceConfiguration', name: 'invoiceConfiguration', moduleId: 'invoiceConfiguration/invoiceConfiguration', title: 'Invoice Configuration', nav: true },
			{ route: 'arbitrations', name: 'arbitrations', moduleId: 'arbitrations/arbitrations', title: 'Arbitrations', nav: true },
			{ route: 'arbitrations/:id', name: 'editArbitration', moduleId: 'arbitrations/editArbitration', title: 'Edit Arbitration', nav: false },
			{ route: 'arbitrations/add', name: 'addArbitration', moduleId: 'arbitrations/editArbitration', title: 'Add Arbitration', nav: false },
			{ route: 'rawtestdata', name: 'rawTestData', moduleId: 'rawTestData/rawTestData', title: 'Raw Test Data', nav: true },
			{ route: 'rawtestdata/:id', name: 'editRawTestData', moduleId: 'rawTestData/editRawTestData', title: 'Edit Raw Test Data', nav: false },
			{ route: 'rawtestdata/add', name: 'addRawTestData', moduleId: 'rawTestData/editRawTestData', title: 'Add Raw Test Data', nav: false },
			{ route: 'documents', name: 'documents', moduleId: 'documents/documents', title: 'Documents', nav: true },
			{ route: 'documents/:id', name: 'editDocument', moduleId: 'documents/editDocument', title: 'Edit Document', nav: false },
			{ route: 'documents/add', name: 'addDocument', moduleId: 'documents/editDocument', title: 'Add Document', nav: false },
			{ route: 'users/spinner', name: 'userSpinner', moduleId: 'users/userSpinner', title: 'Edit User Spinner', nav: true },
			{ route: 'forms/typicalday', name: 'typicalDay', moduleId: 'forms/typicalDay', title: 'Typical Day', nav: true },
			{ route: 'testingresults/psychological', name: 'psychologicalTestResults', moduleId: 'testingResults/psychological', title: 'Psychological testing results', nav: true },
			{ route: 'testingresults/notes', name: 'notes', moduleId: 'testingResults/notes', title: 'Notes', nav: true }
			//{ route: '', name: '', moduleId: '', title: '', nav: false },
		]);
		
		this.context.getUser().then(user => this.user = user);
	}
}

function getCalendarRoute(date) {
	let year = date.getFullYear();
	let month = date.getMonth() + 1;
	
	return `calendar/${year}/${month}`;
}
