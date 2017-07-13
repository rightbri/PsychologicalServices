import environment from './environment';
import 'fetch';

export function configure(aurelia) {
  let apiRoot = environment.debug ? 'http://localhost:44301/' : 'https://watsonpsychologicalserviceswebapisql.azurewebsites.net/';

  aurelia.use
    .instance('apiRoot', apiRoot)
	.standardConfiguration()
	.feature('resources');

  if (environment.debug) {
    aurelia.use.developmentLogging();
  }

  if (environment.testing) {
    aurelia.use.plugin('aurelia-testing');
  }
  
  aurelia.start().then(() => aurelia.setRoot());
}
