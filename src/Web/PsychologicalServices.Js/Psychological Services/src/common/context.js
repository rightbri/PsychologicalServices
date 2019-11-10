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
		this.callbacks = [];

		this.subscriber = this.ea.subscribe('authStateChanged', response => {
			this.username = response.user.email;
			this.getUser().then(user => {
				this.loggedIn = user && user.email;

				notifyUserChange(this.user, this.callbacks);

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

	getUser(refetch) {
		var promise = new Promise((resolve, reject) => {
			if (!refetch && this.user) {
				resolve(this.user);
			}
			else {
				return this.dataRepository.getUserByUsername(this.username)
					.then(data => {
						this.user = data;

						this.dataRepository.getUserSpinner(this.user.userId).then(spinner => this.user.spinner = spinner);
						
						notifyUserChange(this.user, this.callbacks);

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

	userChange(callback) {
		if (!this.callbacks.includes(callback)) {
			this.callbacks.push(callback);
		}
	}

	hasPermission(permission) {
		return this.user && this.user.roles.some(userRole =>
			userRole.rights.some(roleRight => roleRight.name === permission)
		);
	}
}

function notifyUserChange(user, callbacks) {
	for (let i = 0; i < callbacks.length; i++) {
		let callback = callbacks[i];
		if (callback && typeof(callback) === "function") {
			callback(user);
		}
	}
}