
export class Shell {
	constructor() {
		this.userLoggedIn = false,
		this.authToken = null,
		this.user = null;
		
		// This mostly gets called on subsequent page loads to determine
        // what the current status of the user is with "user" being an object
        // return by Firebase with credentials and other info inside of it
        firebase.auth().onAuthStateChanged(user => {
            this.userLoggedIn = user ? true : false;
            this.user = user;
        });
	}
	
	configureRouter(config, router) {
		this.router = router;
		
		config.title = "Psychological Services";
		
		config.map([
			{ route: ['', 'appointments'], name: 'appointments', moduleId: 'appointments/appointments', title: 'Appointments', nav: true },
			{ route: 'appointments/:id/edit', name: 'editAppointment', moduleId: 'appointments/editAppointment', title: 'Edit Appointment', nav: false },
			{ route: 'assessments/:id/edit', name: 'editAssessment', moduleId: 'assessments/editAssessment', title: 'Edit Assessment', nav: false },
			{ route: 'addresses', name: 'addresses', moduleId: 'addresses/addresses', title: 'Addresses', nav: true },
			{ route: 'addresses/:id/edit', name: 'editAddress', moduleId: 'addresses/editAddress', title: 'Edit Address', nav: false }/*,
			{ route: 'assessments', moduleId: 'assessments/assessments', title: 'Assessments', nav: true },
			{ route: 'invoices', moduleId: 'invoices/invoices', title: 'Invoices', nav: true },
			{ route: 'reports', moduleId: 'reports/reports', title: 'Reports', nav: true },
			{ route: 'maintenance', moduleId: 'maintenance/maintenance', title: 'Maintenance', nav: true }*/
		]);
	}
	
	login(type) {
        let provider;

        // Determine which provider to use depending on provided type
        // which is passed through from app.html
        if (type === 'google') {
            provider = new firebase.auth.GoogleAuthProvider();
        }/*else if (type === 'facebook') {
            provider = new firebase.auth.FacebookAuthProvider();
        } else if (type === 'twitter') {
            provider = new firebase.auth.TwitterAuthProvider();
        }*/

        // Call the Firebase signin method for our provider
        // then take the successful or failed result and deal with
        // it accordingly.
        firebase.auth().signInWithPopup(provider).then(result => {
            // The token for this session
            this.authToken = result.credential.idToken;//result.credential.accessToken;

			window.sessionStorage.firebaseAuthToken = this.authToken;
			
            // The user object containing information about the current user
            this.user = result.user;

            // Set a class variable to true to state we are logged in
            this.userLoggedIn = true;
        }).catch(err => {
            let errorCode = err.code;
            let errorMessage = err.message;
            let email = err.email;
            let credential = err.credential;
        });
    }
	
	logout() {
		firebase.auth().signOut().then(() => {
            this.userLoggedIn = false;
        }).catch(err => {
            
        });
	}
}