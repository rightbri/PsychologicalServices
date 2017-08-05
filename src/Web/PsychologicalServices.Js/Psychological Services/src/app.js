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
			{ route: 'schedule/week', name: 'weekSchedule', moduleId: 'schedule/weekSchedule', title: 'Week Schedule', nav: true },
			{ route: 'users', name: 'users', moduleId: 'users/users', title: 'Users', nav: true },
			{ route: 'users/:id', name: 'editUser', moduleId: 'users/editUser', title: 'Edit User', nav: false },
			{ route: 'users/add', name: 'addUser', moduleId: 'users/editUser', title: 'Add User', nav: false },
			{ route: 'calendarNotes', name: 'calendarNotes', moduleId: 'calendarNotes/calendarNotes', title: 'Calendar Notes', nav: true },
			{ route: 'calendarNotes/:id', name: 'editCalendarNote', moduleId: 'calendarNotes/editCalendarNote', title: 'Edit Calendar Note', nav: false },
			{ route: 'calendarNotes/add', name: 'addCalendarNote', moduleId: 'calendarNotes/editCalendarNote', title: 'Add Calendar Note', nav: false }
		]);
	}
}

function getCalendarRoute(date) {
	let year = date.getFullYear();
	let month = date.getMonth() + 1;
	
	return `calendar/${year}/${month}`;
}
