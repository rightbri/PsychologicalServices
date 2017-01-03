import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import moment from 'moment';

@inject(Router, DataRepository)
export class Appointments {
	constructor(router, dataRepository) {
		this.router = router;
		this.dataRepository = dataRepository;
		
		this.showSearch = false;
		this.searchStatus = null;
		this.searchStart = this.shortDateString(this.getMonthBeginDate());
		this.searchEnd = this.shortDateString(this.getMonthEndDate());
		this.searchCompany = 1;
		this.searchPsychometrist = null;
		this.searchPsychologist = null;
		
		this.appointments = null;
		this.psychometrists = null;
		this.psychologists = null;
		this.companies = null;
		this.appointmentStatuses = null;
		this.calendarNotes = null;
		
		
	}
	
	activate(params) {
		return Promise.all([
			this.dataRepository.getCompanies().then(data => this.companies = data),
			this.dataRepository.getPsychometrists(this.searchCompany).then(data => this.psychometrists = data),
			this.dataRepository.getPsychologists(this.searchCompany).then(data => this.psychologists = data),
			this.dataRepository.getAppointmentStatuses().then(data => this.appointmentStatuses = data),
			this.dataRepository.getCalendarNotes(this.searchStart, this.searchEnd).then(data => this.calendarNotes = data),
			this.search()
		]);
	}

	search() {
		return this.searchAppointments({
			appointmentStatusId: this.searchStatus,
			appointmentTimeStart: this.searchStart,
			appointmentTimeEnd: this.searchEnd,
			psychometristId: this.searchPsychometrist,
			psychologistId: this.searchPsychologist,
			companyId: this.searchCompany
		});
	}

	searchAppointments(criteria) {
		return this.dataRepository.searchAppointments(criteria)
			.then(data => {
				this.appointments = data;
				
				this.showSearch = !this.hasAppointments(this.appointments);
			});
	}

	toggleSearch() {
		this.showSearch = !this.showSearch;
	}
	
	getAppointments(day) {
		return (this.appointments || []).filter(function (appointment) {
			return this.isAppointmentForDay(appointment, day);
		}, this);
	}
	
	getNotes(day) {
		return (this.calendarNotes || []).filter(function (calendarNote) {
			return this.isNoteForDay(calendarNote, day);
		}, this);
	}
	
	weekday(datetime) {
		return moment(datetime).format('ddd');
	}
	
	dateString(datetime) {
		return moment(datetime).format('MMM DD');
	}
	
	shortDateString(datetime) {
		return moment(datetime).format('MM/DD/YYYY');
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
	
	getMonthBeginDate() {
		return moment().startOf('month');
	}
	
	getMonthEndDate() {
		return moment().endOf('month');
	}
	
	hasNotes(day) {
		return this.calendarNotes.some(function(calendarNote) {
			return this.isNoteForDay(calendarNote, day);
		}, this);
	}
	
	isAppointmentForDay(appointment, day) {
		return moment(appointment.appointmentTime).isAfter(day.clone().startOf('day')) && moment(appointment.appointmentTime).isBefore(day.clone().endOf('day'));
	}
	
	isNoteForDay(calendarNote, day) {
		return !moment(calendarNote.fromDate).isAfter(day) && !moment(calendarNote.toDate).isBefore(day);
	}
	
	hasAny(collection) {
		return collection && collection.length > 0;
	}
}