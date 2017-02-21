import 'bootstrap';

export function configure(aurelia) {
	aurelia.use
		.instance('apiRoot', 'http://localhost:44301/')//'https://localhost:44301/'
		.standardConfiguration()
		.developmentLogging()
		.plugin('aurelia-dialog')
		.plugin('aurelia-validation');
		//.plugin('aurelia-bootstrap-datepicker');
		
	aurelia.start().then(a => a.setRoot("shell"));
}