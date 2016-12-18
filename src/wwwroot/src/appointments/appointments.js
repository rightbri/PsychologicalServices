import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import moment from 'moment';

@inject(Router, DataRepository, moment)
export class Appointments {
	constructor(router, dataRepository, moment) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.moment = moment;

		this.searchStatus = null;
		this.searchStart = "";
		this.searchEnd = "";
		this.searchCompany = 1;
		this.searchPsychometrist = null;
		this.searchPsychologist = null;
		
		this.appointments = null;
		this.psychometrists = null;
		this.psychologists = null;
		this.companies = null;
		this.appointmentStatuses = null;

		this.dataRepository.getCompanies()
			.then(data => this.companies = data);

		this.dataRepository.getPsychometrists(this.searchCompany)
			.then(data => this.psychometrists = data);

		this.dataRepository.getPsychologists(this.searchCompany)
			.then(data => this.psychologists = data);

		this.dataRepository.getAppointmentStatuses()
			.then(data => this.appointmentStatuses = data);

		this.searchAppointments({
			companyId: this.searchCompany
		});
	}

	search() {
		this.searchAppointments({
			appointmentStatusId: this.searchStatus,
			appointmentTimeStart: this.searchStart,
			appointmentTimeEnd: this.searchEnd,
			psychometristId: this.searchPsychometrist,
			psychologistId: this.searchPsychologist,
			companyId: this.searchCompany
		});
	}

	searchAppointments(criteria) {
		this.dataRepository.searchAppointments(criteria)
			.then(data => {
				this.appointments = data;
			});
	}

	dateString(datetime) {
		return moment(datetime).format('Do MMM YYYY');
	}

	timeString(datetime) {
		return moment(datetime).format('h:mmA');
	}

	hasMultipleCompanies(companies) {
		return companies && companies.length > 1;
	}

	hasAppointments(appointments) {
		return appointments && appointments.length > 0;
	}

	hasSuite(address) {
		return address && address.suite && address.suite.length > 0;
	}

	edit(id) {
		this.router.navigateToRoute('editAppointment', { id: id });
	}
}