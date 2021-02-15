import {UIkit} from 'uikit';
import {DataRepository} from 'repository/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class App {
  constructor(dataRepository) {
	this.dataRepository = dataRepository;

	this.year = new Date().getFullYear();
  }

  activate() {
	return Promise.all([
		this.dataRepository.getSiteName().then(data => this.siteName = data),
		this.dataRepository.getContactInfo().then(data => this.contactInfo = data)
	]);
  }

  configureRouter(config, router) {
		this.router = router;
		
		config.title = this.siteName;
		
		config.options.pushState = true;
		config.options.root = '/';
		
		config.map([
			{ route: ['', 'home'], name: 'home', moduleId: 'home/index', title: 'Home', nav: true },
			{ route: 'services', name: 'services', moduleId: 'services/services', title: 'Services', nav: true },
			{ route: 'faq', name: 'faq', moduleId: 'faq/faq', title: 'FAQ', nav: true },
			{ route: 'assessments', name: 'assessments', moduleId: 'assessments/assessments', title: 'About Assessments', nav: true },
			{ route: 'links', name: 'links', moduleId: 'links/links', title: 'Links', nav: true }
		]);
		
	}
}
