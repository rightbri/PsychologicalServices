import {inject} from 'aurelia-framework';
import {EventAggregator} from 'aurelia-event-aggregator';
import {DataRepository} from 'services/dataRepository';
import {AuthContext} from 'common/authContext';

@inject(EventAggregator, DataRepository, AuthContext)
export class Context {
	constructor(eventAggregator, dataRepository, authContext) {
		this.ea = eventAggregator;
		this.dataRepository = dataRepository;
		this.authContext = authContext;
		
		this.username = null;
		this.user = null;
		this.loggedIn = false;
		this.session = {};
		
		this.subscriber = this.ea.subscribe('authStateChanged', response => {
			this.username = response.user.email;
			this.getUser().then(user => {
				this.loggedIn = user && user.email;
			}).catch(err => {
				console.log(err);
				this.logout();
			});
        });
	}

	clear() {
		this.username = null;
		this.user = null;
		this.loggedIn = false;
		this.authContext.clear();
	}
	
	getUser() {
		var promise = new Promise((resolve, reject) => {
			if (this.user) {
				resolve(this.user);
			}
			else {
				this.dataRepository.getUserByUsername(this.username)
					.then(data => {
						this.user = data;
						resolve(data);
					})
					.catch(err => {
						reject(err);
					});
			}
		});
		return promise;
	}
	
	login() {
		return this.authContext.login();
    }
	
	logout() {
		return this.authContext.logout()
			.then(() => this.clear());
	}
}