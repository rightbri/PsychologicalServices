import {inject} from 'aurelia-framework';
import {EventAggregator} from 'aurelia-event-aggregator';
import {Config} from 'common/config';
import {Notifier} from 'services/notifier';

@inject(EventAggregator, Config, Notifier)
export class AuthContext {
	constructor(eventAggregator, config, notifier) {
		this.ea = eventAggregator;
		this.config = config;
		this.notifier = notifier;
		this.authToken = window.localStorage.getItem(this.config.authTokenKey);
		this.signinUser;
		
		// This mostly gets called on subsequent page loads to determine
        // what the current status of the user is with "user" being an object
        // return by Firebase with credentials and other info inside of it
        firebase.auth().onAuthStateChanged(user => {
			if (user) {
				this.setSigninUser(user);
				this.ea.publish('authStateChanged', { 'user': user });
			}
			else {
				this.logout();
			}
        }, (code, message) => {
			this.notifier.error('[AuthStateChanged]: ' + code + ': ' + message);
			console.log(code + ' - ' + message);
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
        let provider = new firebase.auth.GoogleAuthProvider();

        return firebase.auth().signInWithPopup(provider).then(result => {
			
			this.setSigninUser(result.user);
			
			this.setAuthToken(result.credential.idToken);
			
			return result;
			
        }).catch(err => {
			this.notifier.error('[Login] ' + err.code + ': ' + err.message);
			
			console.log(err);
        });
    }
	
	logout() {
		return firebase.auth().signOut().then(() => this.clear()).catch(err => {
			this.notifier.error('[Logout] ' + err.code + ': ' + err.message);
			
			console.log(err);
        });
	}
}