
export class Shell {
	constructor() {
	
	}
	
	configureRouter(config, router) {
		this.router = router;
		
		config.title = "Psychological Services";
		
		config.map([
			{ route: ['', 'appointments'], name: 'appointments', moduleId: 'appointments/appointments', title: 'Appointments', nav: true },
			{ route: 'appointments/:id/edit', name: 'editAppointment', moduleId: 'appointments/editAppointment', title: 'Edit Appointment', nav: false }/*,
			{ route: 'assessments', moduleId: 'assessments/assessments', title: 'Assessments', nav: true },
			{ route: 'invoices', moduleId: 'invoices/invoices', title: 'Invoices', nav: true },
			{ route: 'reports', moduleId: 'reports/reports', title: 'Reports', nav: true },
			{ route: 'maintenance', moduleId: 'maintenance/maintenance', title: 'Maintenance', nav: true }*/
		]);
	}
}