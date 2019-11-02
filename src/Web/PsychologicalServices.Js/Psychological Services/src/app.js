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

		config.addPipelineStep('authorize', AuthorizeStep);
      
		config.map([
			{ route: ['', 'calendar'], navigationStrategy: calendarNavigationStrategy, nav: true },
			{ route: 'calendar/:year/:month/:day?', moduleId: 'calendar/calendar', title: 'Calendar', nav: false, settings: { permissions: ['ViewAssessment'] }  },
			{ route: 'assessments', name: 'assessments', moduleId: 'assessments/assessments', title: 'Assessments', nav: true, settings: { permissions: ['SearchAssessment'] } },
			{ route: 'assessments/:id', name: 'editAssessment', moduleId: 'assessments/editAssessment', title: 'Edit Assessment', nav: false, settings: { permissions: ['EditAssessment'] } },
			{ route: 'assessments/add/:year/:month/:day', name: 'addAssessment', moduleId: 'assessments/editAssessment', title: 'Add Assessment', nav: false, settings: { permissions: ['EditAssessment'] }  },
			{ route: 'invoices', name: 'invoices', moduleId: 'invoices/invoices', title: 'Invoices', nav: true, settings: { permissions: ['SearchInvoices'] } },
			{ route: 'invoices/:id', name: 'editInvoice', moduleId: 'invoices/editInvoice', title: 'Edit Invoice', nav: false, settings: { permissions: ['EditInvoice'] } },
			{ route: 'invoices/psychometrist', name: 'psychometristInvoices', moduleId: 'invoices/psychometristInvoices', title: 'Create Psychometrist Invoices', nav: false, settings: { permissions: ['CreatePsychometristInvoice'] } },
			{ route: 'invoices/psychologist', name: 'psychologistInvoices', moduleId: 'invoices/psychologistInvoices', title: 'Create Psychologist Invoices', nav: false, settings: { permissions: ['CreatePsychologistInvoice'] } },
			{ route: 'invoices/arbitration', name: 'arbitrationInvoices', moduleId: 'invoices/arbitrationInvoices', title: 'Create Arbitration Invoices', nav: true, settings: { permissions: ['CreateArbitrationInvoice'] } },
			{ route: 'invoices/rawtestdata', name: 'rawTestDataInvoices', moduleId: 'invoices/rawTestDataInvoices', title: 'Create Raw Test Data Invoices', nav: true, settings: { permissions: ['CreateRawTestDataInvoice'] } },
			{ route: 'addresses', name: 'addresses', moduleId: 'addresses/addresses', title: 'Addresses', nav: true },
			{ route: 'addresses/:id', name: 'editAddress', moduleId: 'addresses/editAddress', title: 'Edit Address', nav: false, settings: { permissions: ['EditAddress'] } },
			{ route: 'addresses/add', name: 'addAddress', moduleId: 'addresses/editAddress', title: 'Add Address', nav: false, settings: { permissions: ['EditAddress'] } },
			{ route: 'cities', name: 'cities', moduleId: 'cities/cities', title: 'Cities', nav: true },
			{ route: 'cities/:id', name: 'editCity', moduleId: 'cities/editCity', title: 'Edit City', nav: false, settings: { permissions: ['EditCity'] } },
			{ route: 'cities/add', name: 'addCity', moduleId: 'cities/editCity', title: 'Add City', nav: false, settings: { permissions: ['EditCity'] } },
			{ route: 'claimants', name: 'claimants', moduleId: 'claimants/claimants', title: 'Claimants', nav: true, settings: { permissions: ['SearchClaimant'] } },
			{ route: 'referralSources', name: 'referralSources', moduleId: 'referralSources/referralSources', title: 'Referral Sources', nav: true, settings: { permissions: ['SearchReferralSource'] } },
			{ route: 'referralSources/:id', name: 'editReferralSource', moduleId: 'referralSources/editReferralSource', title: 'Edit Referral Source', nav: false, settings: { permissions: ['EditReferralSource'] } },
			{ route: 'referralSources/add', name: 'addReferralSource', moduleId: 'referralSources/editReferralSource', title: 'Add Referral Source', nav: false, settings: { permissions: ['EditReferralSource'] } },
			{ route: 'schedule/psychometrist', name: 'psychometristSchedule', moduleId: 'schedule/psychometristSchedule', title: 'Psychometrist Schedule', nav: true, settings: { permissions: ['ViewPsychometristSchedule'] } },
			{ route: 'schedule/psychologist', name: 'psychologistSchedule', moduleId: 'schedule/psychologistSchedule', title: 'Psychologist Schedule', nav: true, settings: { permissions: ['ViewPsychologistSchedule'] } },
			{ route: 'users', name: 'users', moduleId: 'users/users', title: 'Users', nav: true, settings: { permissions: ['SearchUser'] }  },
			{ route: 'users/:id', name: 'editUser', moduleId: 'users/editUser', title: 'Edit User', nav: false, settings: { permissions: ['EditUser'] }  },
			{ route: 'users/add', name: 'addUser', moduleId: 'users/editUser', title: 'Add User', nav: false, settings: { permissions: ['EditUser'] }  },
			{ route: 'calendarNotes', name: 'calendarNotes', moduleId: 'calendarNotes/calendarNotes', title: 'Calendar Notes', nav: true, settings: { permissions: ['SearchCalendarNote'] }  },
			{ route: 'calendarNotes/:id', name: 'editCalendarNote', moduleId: 'calendarNotes/editCalendarNote', title: 'Edit Calendar Note', nav: false, settings: { permissions: ['EditCalendarNote'] }  },
			{ route: 'calendarNotes/add', name: 'addCalendarNote', moduleId: 'calendarNotes/editCalendarNote', title: 'Add Calendar Note', nav: false, settings: { permissions: ['EditCalendarNote'] }  },
			{ route: 'employers', name: 'employers', moduleId: 'employers/employers', title: 'Employers', nav: true, settings: { permissions: ['SearchEmployer'] }  },
			{ route: 'employers/:id', name: 'editEmployer', moduleId: 'employers/editEmployer', title: 'Edit Employer', nav: false, settings: { permissions: ['EditEmployer'] }  },
			{ route: 'employers/add', name: 'addEmployer', moduleId: 'employers/editEmployer', title: 'Add Employer', nav: false, settings: { permissions: ['EditEmployer'] }  },
			{ route: 'contacts', name: 'contacts', moduleId: 'contacts/contacts', title: 'Contacts', nav: true, settings: { permissions: ['SearchContact'] }  },
			{ route: 'contacts/:id', name: 'editContact', moduleId: 'contacts/editContact', title: 'Edit Contact', nav: false, settings: { permissions: ['EditContact'] }  },
			{ route: 'contacts/add', name: 'addContact', moduleId: 'contacts/editContact', title: 'Add Contact', nav: false, settings: { permissions: ['EditContact'] }  },
			{ route: 'analysis/booking-statistics', name: 'bookingStatistics', moduleId: 'analysis/bookingStatistics', title: 'Booking Statistics', nav: true, settings: { permissions: ['ViewReport'] } },
			{ route: 'analysis/cancellation-statistics', name: 'cancellationStatistics', moduleId: 'analysis/cancellationStatistics', title: 'Cancellation Statistics', nav: true, settings: { permissions: ['ViewReport'] } },
			{ route: 'analysis/completion-statistics', name: 'completionStatistics', moduleId: 'analysis/completionStatistics', title: 'Completion Statistics', nav: true, settings: { permissions: ['ViewReport'] } },
			{ route: 'analysis/arbitration-statistics', name: 'arbitrationStatistics', moduleId: 'analysis/arbitrationStatistics', title: 'Arbitration Statistics', nav: true, settings: { permissions: ['ViewReport'] } },
			{ route: 'analysis/assessment-type-counts', name: 'assessmentTypeCounts', moduleId: 'analysis/assessmentTypeCounts', title: 'Assessment Type Counts', nav: true, settings: { permissions: ['ViewReport'] } },
			{ route: 'analysis/credibility-statistics', name: 'credibilityStatistics', moduleId: 'analysis/credibilityStatistics', title: 'Credibility Statistics', nav: true, settings: { permissions: ['ViewReport'] } },
			{ route: 'analysis/non-ab-completions', name: 'nonAbCompletionData', moduleId: 'analysis/nonAbCompletionData', title: 'Non AB Completions', nav: true, settings: { permissions: ['ViewReport'] }  },
			{ route: 'analysis/research-consent-obtained-claimants', name: 'researchConsentObtainedClaimants', moduleId: 'analysis/researchConsentObtainedClaimants', title: 'Research Consent Obtained Claimants', nav: true, settings: { permissions: ['ViewReport'] }  },
			{ route: 'outstanding/reports', name: 'outstandingReports', moduleId: 'outstanding/outstandingReports', title: 'Outstanding Reports', nav: true, settings: { permissions: ['ViewReport'] }  },
			{ route: 'events', name: 'events', moduleId: 'events/events', title: 'Events', nav: true },
			{ route: 'events/:id', name: 'editEvent', moduleId: 'events/editEvent', title: 'Edit Event', nav: false, settings: { permissions: ['EditEvent'] }  },
			{ route: 'events/add', name: 'addEvent', moduleId: 'events/editEvent', title: 'Add Event', nav: false, settings: { permissions: ['EditEvent'] }  },
			{ route: 'invoiceConfiguration', name: 'invoiceConfiguration', moduleId: 'invoiceConfiguration/invoiceConfiguration', title: 'Invoice Configuration', nav: true, settings: { permissions: ['EditInvoiceConfiguration'] }  },
			{ route: 'arbitrations', name: 'arbitrations', moduleId: 'arbitrations/arbitrations', title: 'Arbitrations', nav: true, settings: { permissions: ['SearchArbitration'] }  },
			{ route: 'arbitrations/:id', name: 'editArbitration', moduleId: 'arbitrations/editArbitration', title: 'Edit Arbitration', nav: false, settings: { permissions: ['EditArbitration'] } },
			{ route: 'arbitrations/add', name: 'addArbitration', moduleId: 'arbitrations/editArbitration', title: 'Add Arbitration', nav: false, settings: { permissions: ['EditArbitration'] } },
			{ route: 'rawtestdata', name: 'rawTestData', moduleId: 'rawTestData/rawTestData', title: 'Raw Test Data', nav: true, settings: { permissions: ['SearchRawTestData'] }  },
			{ route: 'rawtestdata/:id', name: 'editRawTestData', moduleId: 'rawTestData/editRawTestData', title: 'Edit Raw Test Data', nav: false, settings: { permissions: ['EditRawTestData'] }  },
			{ route: 'rawtestdata/add', name: 'addRawTestData', moduleId: 'rawTestData/editRawTestData', title: 'Add Raw Test Data', nav: false, settings: { permissions: ['EditRawTestData'] }  },
			{ route: 'documents', name: 'documents', moduleId: 'documents/documents', title: 'Documents', nav: true, settings: { permissions: ['SearchDocument'] }  },
			{ route: 'documents/:id', name: 'editDocument', moduleId: 'documents/editDocument', title: 'Edit Document', nav: false, settings: { permissions: ['EditDocument'] }  },
			{ route: 'documents/add', name: 'addDocument', moduleId: 'documents/editDocument', title: 'Add Document', nav: false, settings: { permissions: ['EditDocument'] }  },
			{ route: 'users/spinner', name: 'userSpinner', moduleId: 'users/userSpinner', title: 'Edit User Spinner', nav: true, settings: { permissions: ['EditUser'] }  },
			{ route: 'forms/typicalday', name: 'typicalDay', moduleId: 'forms/typicalDay', title: 'Typical Day', nav: true },
			{ route: 'testingresults/psychological', name: 'psychologicalTestResults', moduleId: 'testingResults/psychological', title: 'Psychological testing results', nav: true },
			{ route: 'testingresults/notes', name: 'notes', moduleId: 'testingResults/notes', title: 'Notes', nav: true }
			//{ route: '', name: '', moduleId: '', title: '', nav: false },
		]);
		
		return this.context.getUser().then(user => this.user = user);
	}

	hasPermission(user, permission) {
		return user && userHasPermission(user, permission);
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
				//this.user = user;

				var isAuthorized = instructions.some(i => userHasPermissions(user, i.config));

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

function userHasPermissions(user, config) {
	return hasAuthorizationPermissions(config) && config.settings.permissions.some(permission => userHasPermission(user, permission));
}

function userHasPermission(user, permission) {
	return user.roles.some(userRole =>
		userRole.rights.some(roleRight => roleRight.name === permission)
	);
}