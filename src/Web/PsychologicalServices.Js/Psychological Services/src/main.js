import environment from './environment';

export function configure(aurelia) {
  let apiRoot = environment.debug ? 'http://localhost:44301/' : 'https://psychologicalservices-test1.azurewebsites.net/';

  console.log('api root: ' + apiRoot);

  aurelia.use
    .instance('apiRoot', apiRoot)
	.standardConfiguration()
    .plugin('aurelia-dialog')
	.feature('resources');

  if (environment.debug) {
    aurelia.use.developmentLogging();
  }

  if (environment.testing) {
    aurelia.use.plugin('aurelia-testing');
  }
  
  aurelia.start().then(() => aurelia.setRoot());
}
