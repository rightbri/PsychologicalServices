import {inject} from 'aurelia-framework';
import {EventAggregator} from 'aurelia-event-aggregator';
import {Config} from 'common/config';
import {Notifier} from 'services/notifier';
import {jquery} from 'jquery';

@inject(EventAggregator, Config, Notifier)
export class AuthContext {
	constructor(eventAggregator, config, notifier) {
		this.ea = eventAggregator;
		this.config = config;
		this.notifier = notifier;
		this.authToken = window.localStorage.getItem(this.config.authTokenKey);
		this.signinUser;
		
		let self = this;
		
		this.retryRequest = true;
		
		gapi.load('auth2', () => {
			
			self.auth2 = gapi.auth2.init({
				client_id: '799270231201-1f7g4ichevt8pup7jmbuqaqgj8j6bcm6.apps.googleusercontent.com'
			});
			
			self.auth2.currentUser.listen((user) => {
				
				let signedIn = self.auth2.isSignedIn.get();
				
				console.log('signedIn?: ' + signedIn);
				
				if (signedIn) {
					var profile = self.auth2.currentUser.get().getBasicProfile();
				
					user.email = profile.getEmail();
					
					self.setSigninUser(user);
					
					var id_token = user.getAuthResponse().id_token;
					self.setAuthToken(id_token);
					
					self.retryRequest = true;
				}
				else {
					self.logout();
				}
				self.ea.publish('authStateChanged', { 'user': user });
			});
			
			if (self.auth2.isSignedIn.get() == true) {
				self.auth2.signIn();
			}
		});
	}
	
	clear() {
		this.signinUser = null;
		
		this.authToken = null;
		
		window.localStorage.clear();
	}
	
	setSigninUser(user) {
		this.signinUser = user;
	}
	
	setAuthToken(token) {
		this.authToken = token;
		
		window.localStorage.setItem(this.config.authTokenKey, token);
	}
	
	login() {
		return this.auth2.signIn();
    }
	
	logout() {
		return this.auth2.signOut().then(() => this.clear());
	}
	
	refresh() {
		if (this.retryRequest) {
			this.retryRequest = false;
			
			return this.auth2.currentUser.get().reloadAuthResponse().then(authResponse => {
				return this.setAuthToken(authResponse.id_token);
			});
		}
		//return this.logout().then(() => this.login());
	}
}
