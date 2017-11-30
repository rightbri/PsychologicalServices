import {UIkit} from 'uikit';

export class App {
  constructor() {
	this.title = "Watson Psychological Services";
	this.year = new Date().getFullYear();
  }

  configureRouter(config, router) {
		this.router = router;
		
		config.title = this.title;
		
		config.options.pushState = true;
		config.options.root = '/';
		
		config.map([
			{ route: ['', 'home'], name: 'home', moduleId: 'home/index', title: 'Home', nav: true },
			{ route: 'about', name: 'about', moduleId: 'about/about', title: 'About', nav: true },
			{ route: 'services', name: 'services', moduleId: 'services/services', title: 'Services', nav: true },
			{ route: 'faq', name: 'faq', moduleId: 'faq/faq', title: 'FAQ', nav: true },
			{ route: 'seminars', name: 'seminars', moduleId: 'seminars/seminars', title: 'Seminars', nav: true },
			{ route: 'contact', name: 'contact', moduleId: 'contact/contact', title: 'Contact', nav: true },
			{ route: 'links', name: 'links', moduleId: 'links/links', title: 'Links', nav: true },
			{ route: 'what-to-expect', name: 'whatToExpect', moduleId: 'whatToExpect/whatToExpect', title: 'What to expect', nav: true }
		]);
		
	}
}
