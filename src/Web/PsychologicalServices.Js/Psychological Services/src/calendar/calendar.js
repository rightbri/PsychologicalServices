import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {BindingSignaler} from 'aurelia-templating-resources';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {UserSettings} from 'services/userSettings';
import {Config} from 'common/config';
import moment from 'moment';

@inject(Router, BindingSignaler, DataRepository, Config, Context, UserSettings)
export class Calendar {
	constructor(router, bindingSignaler, dataRepository, config, context, userSettings) {
		this.router = router;
		this.bindingSignaler = bindingSignaler;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.userSettings = userSettings;
		
		this.filter = false;
		this.searchStatuses = [];
		this.searchPsychometrist = null;
		this.searchPsychologist = null;
		this.searchCompany = 0;
		
		//this.setView('up to date');
		this.setView('schedule');
		
		this.appointments = null;
		this.calendarNotes = null;
		this.editCalendarNoteModel = null;
		
		this.userSettings.setting('calendarAppointmentStatusIds')
			.then(value => {
				this.appointmentStatusIds = value || this.config.calendarDefaults.appointmentStatusIds;
			});
		
		this.userSettings.setting('selectedCalendarMonth')
			.then(value => {
				this.searchDate = this.toUtcDate(value ? new Date(value) : new Date());
				
				this.setSearchRange(this.searchDate);
				
				this.days = this.getDays(this.searchDate.getMonth());
			});
	}
	
	activate(params) {
		return this.context.getUser().then(user => {
				this.user = user;
				this.searchCompany = user.company.companyId;
				
				return this.getData();		
			});
	}
	
	toggleFilter() {
		this.filter = !this.filter;
	}
	
	appointmentStatusClicked(e) {
		this.bindingSignaler.signal('appointment-status-filter');
		
		this.userSettings.setting('calendarAppointmentStatusIds', this.appointmentStatusIds)
	}
	
	addMonths(numberOfMonths) {
		this.searchDate = this.toUtcDate(moment(this.searchDate).add(numberOfMonths || 0, 'months').toDate());
		
		this.userSettings.setting('selectedCalendarMonth', this.searchDate);
		
		this.refreshAppointments(this.searchDate)
	}
	
	setView(viewType) {
		this.currentView = viewType;
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getAppointmentStatuses().then(data => this.appointmentStatuses = data),
			this.dataRepository.getCalendarNotes(this.searchStart, this.searchEnd).then(data => this.calendarNotes = data),
			this.searchAppointments({
				appointmentStatusIds: this.searchStatuses,
				appointmentTimeStart: this.searchStart,
				appointmentTimeEnd: this.searchEnd,
				psychometristId: this.searchPsychometrist,
				psychologistId: this.searchPsychologist,
				companyId: this.searchCompany
			}).then(appointments => {
				appointments.forEach(appointment => {
					appointment.summaryModalContainerId = this.getSummaryModalContainerId(appointment);
					
					appointment.summaryModalToggleValue = this.getSummaryModalToggleValue(appointment);
				});
			})
		]);	
	}

	searchAppointments(criteria) {
		return this.dataRepository.searchAppointments(criteria)
			.then(data => this.appointments = data);
	}

	hasNotes(day) {
		return this.calendarNotes.some(function(calendarNote) {
			
			return (
				calendarNote.fromDate === null || 
				!moment.utc(calendarNote.fromDate).isAfter(moment.utc(day).clone().endOf('day'))
			) && (
				calendarNote.ToDate === null ||
				moment.utc(calendarNote.toDate).isAfter(moment.utc(day).clone().startOf('day'))
			);
			
		}, this);
	}
	
	setSearchRange(date) {
		let start = new Date(date.getFullYear(), date.getMonth(), 1);
		let end = new Date(date.getFullYear(), date.getMonth() + 1, 1);
		
		this.searchStart = this.toUtcDate(start);
		this.searchEnd = this.toUtcDate(end);
	}
	
	getDays(month) {
		let endOfMonth = new Date(new Date().getFullYear(), month + 1, 0);
		
		var days = [];
		
		for (var i = 1; i <= endOfMonth.getDate(); i++) {
			days.push(
				new Date(endOfMonth.getFullYear(), endOfMonth.getMonth(), i)
			);
		}
		
		return days;
	}
	
	dateChanged(e) {
		this.searchDate = e.detail.dates[0];
		
		this.refreshAppointments(this.searchDate);
		
		this.userSettings.setting('selectedCalendarMonth', this.searchDate);
	}
	
	refreshAppointments(searchDate) {
		this.setSearchRange(searchDate);
		
		this.getData()
			.then(data => {
				this.days = this.getDays(searchDate.getMonth());
			});
	}
	
	getSummaryModalToggleValue(appointment) {
		return '#' + this.getSummaryModalContainerId(appointment);
	}
	
	getSummaryModalContainerId(appointment) {
		return `assessment-summary-${appointment.appointmentId}`;
	}
	
	addedCalendarNote(e) {
		let calendarNote = e.detail.calendarNote;
		
		this.calendarNotes.push(calendarNote);
		
		//this.days = this.getDays(this.searchStart, this.searchEnd);
	}
	
	hidCalendarNote(e) {
		this.calendarNoteEditModel.calendarNote = null;
		this.calendarNoteEditModel = null;
	}
	
	addCalendarNote(fromDay) {
		this.calendarNoteEditModel = {
			'calendarNote': {
				'fromDate': fromDay,
				'note': {},
				'isAdd': true
			}
		};
	}
	
	editCalendarNote(calendarNote) {
		this.calendarNoteEditModel = {
			'calendarNote': calendarNote
		};
	}
	
	toUtcDate(date) {
		return new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds()));
	}
}