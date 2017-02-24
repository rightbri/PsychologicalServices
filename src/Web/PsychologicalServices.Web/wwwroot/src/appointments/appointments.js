import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import moment from 'moment';

@inject(Router, DataRepository, Config, Context)
export class Appointments {
	constructor(router, dataRepository, config, context) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		
		this.showSearch = false;
		this.searchStatus = null;
		this.searchStart = this.shortDateString(this.getMonthBeginDate());
		this.searchEnd = this.shortDateString(this.getMonthEndDate());
		this.searchPsychometrist = null;
		this.searchPsychologist = null;
		this.searchCompany = 0;
		
		this.appointments = null;
		this.psychometrists = null;
		this.psychologists = null;
		this.companies = null;
		this.appointmentStatuses = null;
		this.calendarNotes = null;
		
	}
	
	activate(params) {
		return this.context.getUser()
			.then(user => {
				this.searchCompany = user.company.companyId;
				
				return this.getData();		
			});
	}
	
	getData() {
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
	
	dateRangeChanged(startDate, endDate) {
		this.searchStart = startDate;
		this.searchEnd = endDate;
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
	
	getNotes(day) {
		return (this.calendarNotes || []).filter(function (calendarNote) {
			return this.isNoteForDay(calendarNote, day);
		}, this);
	}
	
	shortDateString(datetime) {
		return moment(datetime).format('MM/DD/YYYY');
	}

	hasMultipleCompanies(companies) {
		return companies && companies.length > 1;
	}

	hasAppointments(appointments) {
		return appointments && appointments.length > 0;
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
	
	isNoteForDay(calendarNote, day) {
		return !moment(calendarNote.fromDate).isAfter(day) && !moment(calendarNote.toDate).isBefore(day);
	}
}