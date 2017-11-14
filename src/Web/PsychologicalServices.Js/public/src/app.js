import {UIkit} from 'uikit';

export class App {
  constructor() {
    this.title = "Watson Psychological Services";
  }

  configureRouter(config, router) {
		this.router = router;
		
		config.title = this.title;
		
		config.options.pushState = true;
		config.options.root = '/';
		
		config.map([
			{ route: ['', 'home'], name: 'home', moduleId: 'home/index', title: 'Home', nav: true },
			{ route: 'services', name: 'services', moduleId: 'services/services', title: 'Services', nav: true },
			{ route: 'faq', name: 'faq', moduleId: 'faq/faq', title: 'FAQ', nav: true },
			{ route: 'seminars', name: 'seminars', moduleId: 'seminars/seminars', title: 'Seminars', nav: true },
			{ route: 'contact', name: 'contact', moduleId: 'contact/contact', title: 'Contact', nav: true }/*,
			{ route: 'assessments', name: 'assessments', moduleId: 'assessments/assessments', title: 'Assessments', nav: true },
			{ route: 'assessments/:id', name: 'editAssessment', moduleId: 'assessments/editAssessment', title: 'Edit Assessment', nav: false },
			{ route: 'contacts/:id', name: 'editContact', moduleId: 'contacts/editContact', title: 'Edit Contact', nav: false },
			{ route: 'contacts/add', name: 'addContact', moduleId: 'contacts/editContact', title: 'Add Contact', nav: false }*/
		]);
		
	}
}
