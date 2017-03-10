import {Context} from 'common/context';
import {inject} from 'aurelia-framework';

@inject(Context)
export class Shell {
	constructor(context) {
		this.context = context;
	}
	
	configureRouter(config, router) {
		this.router = router;
		
		config.title = "Psychological Services";
		
		config.map([
			{ route: ['', 'calendar'], name: 'calendar', moduleId: 'calendar/calendar', title: 'Calendar', nav: true },
			{ route: 'assessments/:id/edit', name: 'editAssessment', moduleId: 'assessments/editAssessment', title: 'Edit Assessment', nav: false },
			{ route: 'assessments/add/:year/:month/:day', name: 'addAssessment', moduleId: 'assessments/editAssessment', title: 'Add Assessment', nav: false },
			{ route: 'addresses', name: 'addresses', moduleId: 'addresses/addresses', title: 'Addresses', nav: true },
			{ route: 'addresses/:id/edit', name: 'editAddress', moduleId: 'addresses/editAddress', title: 'Edit Address', nav: false },
			{ route: 'referralSources', name: 'referralSources', moduleId: 'referralSources/referralSources', title: 'Referral Sources', nav: true }
		]);
	}
}