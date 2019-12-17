import {inject} from 'aurelia-framework';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {Permissions} from 'common/permissions';
import {DateService} from 'common/dateService';
import {UIkit} from 'uikit';

@inject(Context, Config, DateService, Permissions)
export class App {
  constructor(context, config, dateService, permissions) {
    this.context = context;
	this.config = config;
	this.dateService = dateService;
	this.permissions = permissions;
	this.menuGroups = [];

	this.title = "Psychological Services";
  }
  
  configureRouter(config, router) {
		this.router = router;
		
		config.title = this.title;
		
		config.options.pushState = true;
		config.options.root = '/';
		config.fallbackRoute('home');
		config.mapUnknownRoutes('');

		let self = this;

		var indexNavigationStrategy = (instruction) => {
			if (self.user && self.permissions && userHasPermission(self.user, self.permissions.ViewAssessment)) {
				let appTime = this.dateService.timezoneNow(this.config.timezone);

				let route = getCalendarRoute(appTime);
				
				instruction.config.redirect = route;
			}
			else {
				instruction.config.moduleId = 'home/home';
			}
		};

		config.addPipelineStep('authorize', AuthorizeStep);
		
		let p = this.permissions;

		config.map([
			{ route: ['', 'calendar'], name: '/', navigationStrategy: indexNavigationStrategy, nav: true },
			{ route: 'home', name: 'home', moduleId: 'home/home', nav: true },
			{ route: 'calendar/:year/:month/:day?', moduleId: 'calendar/calendar', title: 'Calendar', nav: false, settings: { permissions: [p.ViewAssessment] } },
			{ route: 'assessments', name: 'assessments', moduleId: 'assessments/assessments', title: 'Assessments', nav: true, settings: { permissions: [p.SearchAssessment] } },
			{ route: 'assessments/:id', name: 'editAssessment', moduleId: 'assessments/editAssessment', title: 'Edit Assessment', nav: false, settings: { permissions: [p.EditAssessment] } },
			{ route: 'assessments/add/:year/:month/:day', name: 'addAssessment', moduleId: 'assessments/editAssessment', title: 'Add Assessment', nav: false, settings: { permissions: [p.EditAssessment] } },
			{ route: 'invoices', name: 'invoices', moduleId: 'invoices/invoices', title: 'Invoices', nav: true, settings: { permissions: [p.SearchInvoice] } },
			{ route: 'invoices/:id', name: 'editInvoice', moduleId: 'invoices/editInvoice', title: 'Edit Invoice', nav: false, settings: { permissions: [p.EditInvoice] } },
			{ route: 'invoices/psychometrist', name: 'psychometristInvoices', moduleId: 'invoices/psychometristInvoices', title: 'Create Psychometrist Invoices', nav: false, settings: { permissions: [p.CreatePsychometristInvoice] } },
			{ route: 'invoices/psychologist', name: 'psychologistInvoices', moduleId: 'invoices/psychologistInvoices', title: 'Create Psychologist Invoices', nav: false, settings: { permissions: [p.CreatePsychologistInvoice] } },
			{ route: 'invoices/arbitration', name: 'arbitrationInvoices', moduleId: 'invoices/arbitrationInvoices', title: 'Create Arbitration Invoices', nav: true, settings: { permissions: [p.CreateArbitrationInvoice] } },
			{ route: 'invoices/rawtestdata', name: 'rawTestDataInvoices', moduleId: 'invoices/rawTestDataInvoices', title: 'Create Raw Test Data Invoices', nav: true, settings: { permissions: [p.CreateRawTestDataInvoice] } },
			{ route: 'invoices/consulting', name: 'consultingInvoices', moduleId: 'invoices/consultingInvoices', title: 'Create Consulting Invoices', nav: true, settings: { permissions: [p.CreateConsultingInvoice] } },
			{ route: 'addresses', name: 'addresses', moduleId: 'addresses/addresses', title: 'Addresses', nav: true, settings: { permissions: [p.SearchAddress] } },
			{ route: 'addresses/:id', name: 'editAddress', moduleId: 'addresses/editAddress', title: 'Edit Address', nav: false, settings: { permissions: [p.EditAddress] } },
			{ route: 'addresses/add', name: 'addAddress', moduleId: 'addresses/editAddress', title: 'Add Address', nav: false, settings: { permissions: [p.EditAddress] } },
			{ route: 'cities', name: 'cities', moduleId: 'cities/cities', title: 'Cities', nav: true },
			{ route: 'cities/:id', name: 'editCity', moduleId: 'cities/editCity', title: 'Edit City', nav: false, settings: { permissions: [p.EditCity] } },
			{ route: 'cities/add', name: 'addCity', moduleId: 'cities/editCity', title: 'Add City', nav: false, settings: { permissions: [p.EditCity] } },
			{ route: 'claimants', name: 'claimants', moduleId: 'claimants/claimants', title: 'Claimants', nav: true, settings: { permissions: [p.SearchClaimant] } },
			{ route: 'referralSources', name: 'referralSources', moduleId: 'referralSources/referralSources', title: 'Referral Sources', nav: true, settings: { permissions: [p.SearchReferralSource] } },
			{ route: 'referralSources/:id', name: 'editReferralSource', moduleId: 'referralSources/editReferralSource', title: 'Edit Referral Source', nav: false, settings: { permissions: [p.EditReferralSource] } },
			{ route: 'referralSources/add', name: 'addReferralSource', moduleId: 'referralSources/editReferralSource', title: 'Add Referral Source', nav: false, settings: { permissions: [p.EditReferralSource] } },
			{ route: 'schedule/psychometrist', name: 'psychometristSchedule', moduleId: 'schedule/psychometristSchedule', title: 'Psychometrist Schedule', nav: true, settings: { permissions: [p.ViewPsychometristSchedule] } },
			{ route: 'schedule/psychologist', name: 'psychologistSchedule', moduleId: 'schedule/psychologistSchedule', title: 'Psychologist Schedule', nav: true, settings: { permissions: [p.ViewPsychologistSchedule] } },
			{ route: 'users', name: 'users', moduleId: 'users/users', title: 'Users', nav: true, settings: { permissions: [p.SearchUser] } },
			{ route: 'users/:id', name: 'editUser', moduleId: 'users/editUser', title: 'Edit User', nav: false, settings: { permissions: [p.EditUser] } },
			{ route: 'users/add', name: 'addUser', moduleId: 'users/editUser', title: 'Add User', nav: false, settings: { permissions: [p.EditUser] } },
			{ route: 'roles', name: 'roles', moduleId: 'roles/roles', title: 'Roles', nav: true, settings: { permissions: [p.ViewRole] } },
			{ route: 'roles/:id', name: 'editRole', moduleId: 'roles/editRole', title: 'Edit Role', nav: false, settings: { permissions: [p.EditRole] } },
			{ route: 'roles/add', name: 'addRole', moduleId: 'roles/editRole', title: 'Add Role', nav: false, settings: { permissions: [p.EditRole] } },
			{ route: 'calendarNotes', name: 'calendarNotes', moduleId: 'calendarNotes/calendarNotes', title: 'Calendar Notes', nav: true, settings: { permissions: [p.SearchCalendarNote] } },
			{ route: 'calendarNotes/:id', name: 'editCalendarNote', moduleId: 'calendarNotes/editCalendarNote', title: 'Edit Calendar Note', nav: false, settings: { permissions: [p.EditCalendarNote] } },
			{ route: 'calendarNotes/add', name: 'addCalendarNote', moduleId: 'calendarNotes/editCalendarNote', title: 'Add Calendar Note', nav: false, settings: { permissions: [p.EditCalendarNote] } },
			{ route: 'employers', name: 'employers', moduleId: 'employers/employers', title: 'Employers', nav: true, settings: { permissions: [p.SearchEmployer] }  },
			{ route: 'employers/:id', name: 'editEmployer', moduleId: 'employers/editEmployer', title: 'Edit Employer', nav: false, settings: { permissions: [p.EditEmployer] } },
			{ route: 'employers/add', name: 'addEmployer', moduleId: 'employers/editEmployer', title: 'Add Employer', nav: false, settings: { permissions: [p.EditEmployer] } },
			{ route: 'contacts', name: 'contacts', moduleId: 'contacts/contacts', title: 'Contacts', nav: true, settings: { permissions: [p.SearchContact] } },
			{ route: 'contacts/:id', name: 'editContact', moduleId: 'contacts/editContact', title: 'Edit Contact', nav: false, settings: { permissions: [p.EditContact] } },
			{ route: 'contacts/add', name: 'addContact', moduleId: 'contacts/editContact', title: 'Add Contact', nav: false, settings: { permissions: [p.EditContact] } },
			{ route: 'analysis/booking-statistics', name: 'bookingStatistics', moduleId: 'analysis/bookingStatistics', title: 'Booking Statistics', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'analysis/cancellation-statistics', name: 'cancellationStatistics', moduleId: 'analysis/cancellationStatistics', title: 'Cancellation Statistics', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'analysis/completion-statistics', name: 'completionStatistics', moduleId: 'analysis/completionStatistics', title: 'Completion Statistics', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'analysis/arbitration-statistics', name: 'arbitrationStatistics', moduleId: 'analysis/arbitrationStatistics', title: 'Arbitration Statistics', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'analysis/assessment-type-counts', name: 'assessmentTypeCounts', moduleId: 'analysis/assessmentTypeCounts', title: 'Assessment Type Counts', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'analysis/credibility-statistics', name: 'credibilityStatistics', moduleId: 'analysis/credibilityStatistics', title: 'Credibility Statistics', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'analysis/non-ab-completions', name: 'nonAbCompletionData', moduleId: 'analysis/nonAbCompletionData', title: 'Non AB Completions', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'analysis/research-consent-obtained-claimants', name: 'researchConsentObtainedClaimants', moduleId: 'analysis/researchConsentObtainedClaimants', title: 'Research Consent Obtained Claimants', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'outstanding/reports', name: 'outstandingReports', moduleId: 'outstanding/outstandingReports', title: 'Outstanding Reports', nav: true, settings: { permissions: [p.ViewReport] } },
			{ route: 'events', name: 'events', moduleId: 'events/events', title: 'Events', nav: true, settings: { permissions: [p.SearchEvent] } },
			{ route: 'events/:id', name: 'editEvent', moduleId: 'events/editEvent', title: 'Edit Event', nav: false, settings: { permissions: [p.EditEvent] } },
			{ route: 'events/add', name: 'addEvent', moduleId: 'events/editEvent', title: 'Add Event', nav: false, settings: { permissions: [p.EditEvent] } },
			{ route: 'invoiceConfiguration', name: 'invoiceConfiguration', moduleId: 'invoiceConfiguration/invoiceConfiguration', title: 'Invoice Configuration', nav: true, settings: { permissions: [p.EditInvoiceConfiguration] } },
			{ route: 'arbitrations', name: 'arbitrations', moduleId: 'arbitrations/arbitrations', title: 'Arbitrations', nav: true, settings: { permissions: [p.SearchArbitration] }  },
			{ route: 'arbitrations/:id', name: 'editArbitration', moduleId: 'arbitrations/editArbitration', title: 'Edit Arbitration', nav: false, settings: { permissions: [p.EditArbitration] } },
			{ route: 'arbitrations/add', name: 'addArbitration', moduleId: 'arbitrations/editArbitration', title: 'Add Arbitration', nav: false, settings: { permissions: [p.EditArbitration] } },
			{ route: 'rawtestdata', name: 'rawTestData', moduleId: 'rawTestData/rawTestData', title: 'Raw Test Data', nav: true, settings: { permissions: [p.SearchRawTestData] } },
			{ route: 'rawtestdata/:id', name: 'editRawTestData', moduleId: 'rawTestData/editRawTestData', title: 'Edit Raw Test Data', nav: false, settings: { permissions: [p.EditRawTestData] } },
			{ route: 'rawtestdata/add', name: 'addRawTestData', moduleId: 'rawTestData/editRawTestData', title: 'Add Raw Test Data', nav: false, settings: { permissions: [p.EditRawTestData] } },
			{ route: 'documents', name: 'documents', moduleId: 'documents/documents', title: 'Documents', nav: true, settings: { permissions: [p.SearchDocument] } },
			{ route: 'documents/:id', name: 'editDocument', moduleId: 'documents/editDocument', title: 'Edit Document', nav: false, settings: { permissions: [p.EditDocument] } },
			{ route: 'documents/add', name: 'addDocument', moduleId: 'documents/editDocument', title: 'Add Document', nav: false, settings: { permissions: [p.EditDocument] } },
			{ route: 'users/spinner', name: 'userSpinner', moduleId: 'users/userSpinner', title: 'Edit User Spinner', nav: true, settings: { permissions: [p.EditUser] } },
			{ route: 'forms/typicalday', name: 'typicalDay', moduleId: 'forms/typicalDay', title: 'Typical Day', nav: true },
			{ route: 'testingresults/psychological', name: 'psychologicalTestResults', moduleId: 'testingResults/psychological', title: 'Psychological testing results', nav: true },
			{ route: 'testingresults/notes', name: 'notes', moduleId: 'testingResults/notes', title: 'Notes', nav: true }
		]);
	}

	activate() {
		this.context.userChange(user => {
			this.user = user;
		});

		return this.getData();
	}

	hasAnyItemPermission(user, group) {
		return user && group && group.items && group.items.some(item => this.hasItemPermission(user, item));
	}

	hasItemPermission(user, item) {
		return user && item && userHasPermissions(user, item.permissions);
	}

	getData() {
		return Promise.all([
			this.getMenuData(this.permissions).then(data => this.menuGroups = data)
		]);
	}

	getMenuData(permissions) {
		let p = permissions;

		let data = [
			{
				"name": "Assessments",
				"items": [
					{ "name": "Calendar", "route": "/calendar", "permissions": [p.ViewAssessment] },
					{ "name": "Search", "route": "/assessments", "permissions": [p.SearchAssessment] }
				]
			},
			{
				"name": "Psychologist",
				"permissions": [],
				"items": [
					{ "name": "Psychologist Schedule", "route": "/schedule/psychologist", "permissions": [p.ViewPsychologistSchedule] },
					{ "name": "Create Psychologist Invoices", "route": "/invoices/psychologist", "permissions": [p.CreatePsychologistInvoice] }
				]
			},
			{
				"name": "Psychometrist",
				"items": [
					{ "name": "Psychometrist Schedule", "route": "/schedule/psychometrist", "permissions": [p.ViewPsychometristSchedule] },
					{ "name": "Create Psychometrist Invoices", "route": "/invoices/psychometrist", "permissions": [p.CreatePsychometristInvoice] }
				]
			},
			{
				"name": "Forms",
				"items": [
					{ "name": "Typical Day", "route": "/forms/typicalDay", "permissions": [] },
					{ "name": "Psychological testing results", "route": "/testingResults/psychological", "permissions": [] },
					{ "name": "Notes", "route": "/testingResults/notes", "permissions": [] }
				]
			},
			{
				"name": "Arbitrations",
				"items": [
					{ "name": "Add/Edit Arbitrations", "route": "/arbitrations", "permissions": [p.EditArbitration] },
					{ "name": "Create Arbitration Invoices", "route": "/invoices/arbitration", "permissions": [p.CreateArbitrationInvoice] }
				]
			},
			{
				"name": "Raw Test Data",
				"items": [
					{ "name": "Add/Edit Raw Test Data", "route": "/rawtestdata", "permissions": [p.EditRawTestData] },
					{ "name": "Create Raw Test Data Invoices", "route": "/invoices/rawtestdata", "permissions": [p.CreateRawTestDataInvoice] }
				]
			},
			{
				"name": "Consulting",
				"items": [
					{ "name": "Create Consulting Invoices", "route": "/invoices/consulting", "permissions": [p.CreateConsultingInvoice] }
				]
			},
			{
				"name": "Invoices",
				"items": [
					{ "name": "Search", "route": "/invoices", "permissions": [p.SearchInvoice] }
				]
			},
			{
				"name": "Analysis",
				"items": [
					{ "name": "Arbitration Statistics", "route": "/analysis/arbitration-statistics", "permissions": [p.ViewReport] },
					{ "name": "Assessment Type Counts", "route": "/analysis/assessment-type-counts", "permissions": [p.ViewReport] },
					{ "name": "Booking Statistics", "route": "/analysis/booking-statistics", "permissions": [p.ViewReport] },
					{ "name": "Cancellation Statistics", "route": "/analysis/cancellation-statistics", "permissions": [p.ViewReport] },
					{ "name": "Completion Statistics", "route": "/analysis/completion-statistics", "permissions": [p.ViewReport] },
					{ "name": "Credibility Statistics", "route": "/analysis/credibility-statistics", "permissions": [p.ViewReport] },
					{ "name": "Non AB Completions", "route": "/analysis/non-ab-completions", "permissions": [p.ViewReport] },
					{ "name": "Research Consent Obtained Claimants", "route": "/analysis/research-consent-obtained-claimants", "permissions": [p.ViewReport] }
				]
			},
			{
				"name": "Maintenance",
				"items": [
					{ "name": "Addresses", "route": "/addresses", "permissions": [p.SearchAddress] },
					{ "name": "Calendar Notes", "route": "/calendarNotes", "permissions": [p.SearchCalendarNote] },
					{ "name": "Cities", "route": "/cities", "permissions": [] },
					{ "name": "Claimants", "route": "/claimants", "permissions": [p.SearchClaimant] },
					{ "name": "InvoiceConfiguration", "route": "/invoiceConfiguration", "permissions": [p.ViewInvoiceConfiguration] },
					{ "name": "Contacts", "route": "/contacts", "permissions": [p.SearchContact] },
					{ "name": "Employers", "route": "/employers", "permissions": [p.SearchEmployer] },
					{ "name": "Events", "route": "/events", "permissions": [p.SearchEvent] },
					{ "name": "Referral Sources", "route": "/referralSources", "permissions": [p.SearchReferralSource] },
					{ "name": "Users", "route": "/users", "permissions": [p.SearchUser] },
					{ "name": "Roles", "route": "/roles", "permissions": [p.ViewRole] }
				]
			},
			{
				"name": "Outstanding",
				"items": [
					{ "name": "Reports", "route": "/outstanding/reports", "permissions": [p.ViewReport] }
				]
			}
		];

		return getPromise(data);
	}
}

@inject(Context, Config, DateService)
class AuthorizeStep {
	constructor(context) {
		this.context = context;
	}

    run(navigationInstruction, next) {
		let instructions = navigationInstruction.getAllInstructions();

		if (instructions.some(i => hasAuthorizationPermissions(i.config))) {

			return this.context.getUser().then(user => {
				var isAuthorized = instructions.some(i => hasAuthorizationPermissions(i.config) && userHasPermissions(user, i.config.settings.permissions));

				return isAuthorized ? next() : next.cancel();
			});
      }
  
      return next();
    }
}

function getCalendarRoute(date) {
	let year = date.getFullYear();
	let month = date.getMonth() + 1;
	
	return `calendar/${year}/${month}`;
}

function hasAuthorizationPermissions(config) {
	return config && config.settings && config.settings.permissions && config.settings.permissions.length > 0;
}

function userHasPermissions(user, permissions) {
	return user && permissions && (permissions.length === 0 || permissions.some(permission => userHasPermission(user, permission)));
}

function userHasPermission(user, permission) {
	return user.roles.some(userRole =>
		userRole.rights.some(roleRight => roleRight.name === permission)
	);
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}