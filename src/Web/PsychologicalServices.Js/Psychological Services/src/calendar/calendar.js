import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {DialogService} from 'aurelia-dialog';
import {EditCalendarNote} from 'calendarNotes/edit-calendar-note';
import {Context} from 'common/context';
import {Config} from 'common/config';
import moment from 'moment';

@inject(Router, DataRepository, DialogService, Config, Context)
export class Calendar {
	constructor(router, dataRepository, dialogService, config, context) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.dialogService = dialogService;
		this.config = config;
		this.context = context;
		
		this.searchDate = this.context.calendarMonth || new Date();
		
		this.searchStatus = null;
		this.searchStart = new Date(this.searchDate.getFullYear(), this.searchDate.getMonth(), 1);
		this.searchEnd = new Date(this.searchDate.getFullYear(), this.searchDate.getMonth() + 1, 0);
		this.searchPsychometrist = null;
		this.searchPsychologist = null;
		this.searchCompany = 0;
		
		//this.setView('up to date');
		this.setView('schedule');
		
		this.appointments = null;
		this.calendarNotes = null;
		
		this.days = this.getDays(this.searchStart, this.searchEnd);
	}
	
	activate(params) {
		return this.context.getUser()
			.then(user => {
				this.user = user;
				this.searchCompany = user.company.companyId;
				
				return this.getData();		
			});
	}
	
	setView(viewType) {
		this.currentView = viewType;
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getCalendarNotes(this.searchStart, this.searchEnd).then(data => this.calendarNotes = data),
			this.searchAppointments({
				appointmentStatusId: this.searchStatus,
				appointmentTimeStart: this.searchStart,
				appointmentTimeEnd: this.searchEnd,
				psychometristId: this.searchPsychometrist,
				psychologistId: this.searchPsychologist,
				companyId: this.searchCompany
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
				!moment(calendarNote.fromDate).isAfter(moment(day).clone().endOf('day'))
			) && (
				calendarNote.ToDate === null ||
				moment(calendarNote.toDate).isAfter(moment(day).clone().startOf('day'))
			);
			
		}, this);
	}
	
	setSearchRange(date) {
		this.searchDate = date;
		this.searchStart = new Date(this.searchDate.getFullYear(), this.searchDate.getMonth(), 1);
		this.searchEnd = new Date(this.searchDate.getFullYear(), this.searchDate.getMonth() + 1, 0);
	}
	
	getDays(min, max) {
		var maxDays = max.getDate();
		
		var d = min;
		
		var days = [];
		
		for (var i = 1; i <= maxDays; i++) {
			days.push(
				new Date(min.getFullYear(), min.getMonth(), i)
			);
		}
		
		return days;
	}
	
	monthChanged(e) {
		this.context.calendarMonth = e.detail;
		this.refreshAppointments(e.detail);
	}
	
	refreshAppointments(searchDate) {
		this.setSearchRange(searchDate);
		this.getData()
			.then(data => {
				this.days = this.getDays(this.searchStart, this.searchEnd);
			});
	}
	
	addCalendarNote(fromDay) {
		return this.editCalendarNote({ fromDate: fromDay, note: { createUser: this.user, updateUser: this.user } })
			.then(data => {
				if (!data.wasCancelled) {
					this.calendarNotes.push(data.calendarNote);
					
					this.days = this.getDays(this.searchStart, this.searchEnd);
				}
			});
	}
	
	editCalendarNote(calendarNote) {
		var original = JSON.parse(JSON.stringify(calendarNote));
		
		return this.dialogService.open({viewModel: EditCalendarNote, model: calendarNote})
			.then(result => {
				var copyFrom = original;
				
				if (!result.wasCancelled) {
					copyFrom = result.output;
				}
				
				for (var prop in copyFrom) {
					if (copyFrom.hasOwnProperty(prop)) {
						calendarNote[prop] = copyFrom[prop];
					}
				}
				
				return { wasCancelled: result.wasCancelled, calendarNote: calendarNote };
			});
	}
	
	summaryModalToggleValue(appointment) {
		return '#' + this.summaryModalContainerId(appointment);
	}
	
	summaryModalContainerId(appointment) {
		return `assessment-summary-${appointment.appointmentId}`;
	}
}