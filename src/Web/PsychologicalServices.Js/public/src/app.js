import {UIkit} from 'uikit';
import {DataRepository} from 'repository/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class App {
  constructor(dataRepository) {
	this.dataRepository = dataRepository;

	this.title = "Watson Psychological Services";
	this.year = new Date().getFullYear();
  }

  attached() {
	this.dataRepository.getContactInfo().then(data => this.contactInfo = data);
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
			//{ route: 'seminars', name: 'seminars', moduleId: 'seminars/seminars', title: 'Seminars', nav: true },
			{ route: 'contact', name: 'contact', moduleId: 'contact/contact', title: 'Contact', nav: true },
			{ route: 'links', name: 'links', moduleId: 'links/links', title: 'Links', nav: true },
			{ route: 'what-to-expect', name: 'whatToExpect', moduleId: 'whatToExpect/whatToExpect', title: 'What to expect', nav: true }
		]);
		
	}
}
