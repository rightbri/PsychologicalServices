import 'bootstrap';

export function configure(aurelia) {
	aurelia.use
		.instance('apiRoot', 'http://localhost:44301/')//'https://localhost:44301/'
		.standardConfiguration()
		.developmentLogging()
		.plugin('aurelia-validation');
		
	aurelia.start().then(a => a.setRoot("shell"));
}