import {EventAggregator} from 'aurelia-event-aggregator';
import {DataRepository} from 'services/dataRepository';
import {AuthContext} from 'common/authContext';
import {inject} from 'aurelia-framework';

@inject(EventAggregator, DataRepository, AuthContext)
export class Context {
	constructor(eventAggregator, dataRepository, authContext) {
		this.ea = eventAggregator;
		this.dataRepository = dataRepository;
		this.authContext = authContext;
		
		this.username = null;
		this.user = null;
		this.loggedIn = false;
		
		this.subscriber = this.ea.subscribe('authStateChanged', response => {
			this.username = response.user.email;
			this.getUser().then(user => {
				this.loggedIn = user && user.email;
			}).catch(err => {
				this.logout();
			});
        });
	}
/*
    detached() {
        this.subscriber.dispose();
    }
*/
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
		this.authContext.login()
			/*
			.then(result => {
				this.username = result.user.email;
				return getUser();
			})
			*/
			.catch(err => {
				/*
				//let email = err.email;
				//let credential = err.credential;
				
				this.dialogService.open({
					viewModel: MessageDialog,
					model: {
						heading: 'Sign In Error',
						message: err.code + ': ' + err.message
					}
				});
				*/
			});
    }
	
	logout() {
		this.authContext.logout()
			.then(() => this.clear())
			.catch(err => {
				/*
				this.dialogService.open({
					viewModel: MessageDialog,
					model: {
						heading: 'Sign Out Error',
						message: err.code + ': ' + err.message
					}
				});
				*/
			});
	}
}