import {EventAggregator} from 'aurelia-event-aggregator';
import {Notifier} from 'services/notifier';
import {inject} from 'aurelia-framework';

@inject(EventAggregator, Notifier)
export class AuthContext {
	constructor(eventAggregator, notifier) {
		this.ea = eventAggregator;
		this.notifier = notifier;
		this.authToken = window.sessionStorage.getItem('firebaseAuthToken');
		this.signinUser;
		
		// This mostly gets called on subsequent page loads to determine
        // what the current status of the user is with "user" being an object
        // return by Firebase with credentials and other info inside of it
        firebase.auth().onAuthStateChanged(user => {
			if (user) {//this.authToken) {
				this.setSigninUser(user);
				this.ea.publish('authStateChanged', { 'user': user });
			}
			else {
				this.login();
				//this.logout();
			}
        }, (code, message) => this.notifier.error(code + ': ' + message));
	}
	
	clear() {
		this.signinUser = null;
		this.authToken = null;
		window.sessionStorage.clear();
	}
	
	setSigninUser(user) {
		this.signinUser = user;
	}
	
	setAuthToken(token) {
		this.authToken = token;
		window.sessionStorage.setItem('firebaseAuthToken', token);
	}
	
	login() {
        let provider = new firebase.auth.GoogleAuthProvider();

        return firebase.auth().signInWithPopup(provider).then(result => {
			this.setSigninUser(result.user);
			this.setAuthToken(result.credential.idToken);
			return result;
        }).catch(err => {
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
		return firebase.auth().signOut().then(() => this.clear()).catch(err => {
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