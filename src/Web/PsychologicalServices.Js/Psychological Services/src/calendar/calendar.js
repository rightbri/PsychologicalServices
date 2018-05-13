import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {BindingSignaler} from 'aurelia-templating-resources';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {UserSettings} from 'services/userSettings';
import {Config} from 'common/config';
import {DateService} from 'common/dateService';
import {Scroller} from 'services/scroller';
import moment from 'moment';

@inject(Router, BindingSignaler, DataRepository, Config, Context, UserSettings, DateService, Scroller)
export class Calendar {
	
	constructor(router, bindingSignaler, dataRepository, config, context, userSettings, dateService, scroller) {
		this.router = router;
		this.bindingSignaler = bindingSignaler;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.userSettings = userSettings;
		this.dateService = dateService;
		this.scroller = scroller;
		
		this.filter = false;
		this.searchStatuses = [];
		this.searchCompany = 0;
		
		this.now = this.dateService.now();
		
		this.userSettings.setting('selectedCalendarView')
			.then(value => this.setView(value || this.config.calendarDefaults.defaultView));
		
		this.appointments = null;
		this.calendarNotes = null;
		this.editCalendarNoteModel = null;
		
		this.popstatebound = this.popstate.bind(this);
	}
	
	activate(params) {
		let year = params.year;
		let month = params.month;
		let day = params.day;
		
		this.searchDate = new Date(year, month - 1, day || 1);
		
		this.calendarDate = this.searchDate;
		
		let fetch =
			!this.year ||
			!this.month ||
			this.year != year ||
			this.month != month;

		this.year = year;
		this.month = month;

		this.userSettings.setting('selectedCalendarMonth', this.searchDate);

		if (day) {
			this.scrollToId = `#_${year}${month}${day}`;
		}
		
		return this.refreshAppointments(this.searchDate);
	}

	determineActivationStrategy() {
		return 'invoke-lifecycle';
	}
	
	setDayState(year, month, day) {
		let state = { 'view': 'calendar', 'year': year, 'month': month, 'day': day };
		
		history.pushState(state, '', `calendar/${year}/${month}/${day}`);
	}
	
	today(date) {
		this.searchDate = date;
		this.calendarDate = this.searchDate;
		
		this.calendarDateChanged(this.searchDate);
	}
	
	popstate(e) {
		if (e.state) {
			let year = e.state.year;
			let month = e.state.month;
			let day = e.state.day;
			
			this.searchDate = year && month
			? new Date(year, month - 1, day || 1)
			: this.getDateFromPath(window);
			
			this.calendarDate = this.searchDate;
			
			this.calendarDateChanged(this.searchDate, false);
		}
	}
	
	getDateFromPath(window) {
		let path = window.location.pathname;
		
		let pathParts = path.split('/').filter(part => /^\d+$/.test(part));
		
		let now = this.now;
		
		let year = pathParts > 0  ? pathParts[0] : now.getFullYear();
		let month = pathParts > 1 ? pathParts[1] : now.getMonth() + 1;
		let day = pathParts > 2 ? pathParts[2] : 1;
		
		return new Date(year, month - 1, day);
	}
	
	attached() {
		if (this.scrollToId) {
			whenExists(this.scrollToId).then(element => scrollTo(this.scroller, element));
		}
		
		window.addEventListener('popstate', this.popstatebound);
	}
	
	detached() {
		window.removeEventListener('popstate', this.popstatebound);
	}
	
	toggleFilter() {
		this.filter = !this.filter;
	}
	
	appointmentStatusClicked(e) {
		this.bindingSignaler.signal('appointment-status-filter');
		
		this.userSettings.setting('calendarAppointmentStatusIds', this.appointmentStatusIds)
	}
	
	setView(viewType) {
		this.currentView = viewType;
		
		this.scheduleView = viewType === 'schedule';
		
		this.uptodateView = viewType === 'uptodate';
		
		this.userSettings.setting('selectedCalendarView', viewType);
	}
	
	getData() {
		return this.context.getUser().then(user => {
			this.user = user;
			this.searchCompany = user.company.companyId;
			
			return this.dataRepository.getArbitrationStatuses().then(arbitrationStatuses => {
				this.arbitrationStatuses = arbitrationStatuses;

				return Promise.all([
					this.dataRepository.getAppointmentStatuses().then(data => this.appointmentStatuses = data),
					this.userSettings.setting('calendarAppointmentStatusIds').then(value => this.appointmentStatusIds = value || this.config.calendarDefaults.appointmentStatusIds),
					this.dataRepository.getCalendarNotes({
						'fromDate': this.searchStart,
						'toDate': this.searchEnd,
						'companyId': this.searchCompany
					}).then(data => this.calendarNotes = data),
					this.dataRepository.getArbitrations({
						'startDate': this.searchStart,
						'endDate': this.searchEnd,
						'companyId': this.searchCompany,
						'arbitrationStatusIds': arbitrationStatuses.filter(arbitrationStatus => arbitrationStatus.showOnCalendar).map(arbitrationStatus => arbitrationStatus.arbitrationStatusId)
					}).then(data => this.arbitrations = data),
					this.dataRepository.searchUnavailability({
						'unavailabilityStart': this.searchStart,
						'unavailabilityEnd': this.searchEnd,
						'companyId': this.searchCompany
					}).then(data => this.unavailabilities = data),
					this.dataRepository.searchAppointments({
						'appointmentStatusIds': this.searchStatuses,
						'appointmentTimeStart': this.searchStart,
						'appointmentTimeEnd': this.searchEnd,
						'companyId': this.searchCompany
					}).then(data => this.appointments = data)
					.then(appointments => {
						appointments.forEach(appointment => {
							appointment.summaryModalContainerId = this.getSummaryModalContainerId(appointment);
							
							appointment.summaryModalToggleValue = this.getSummaryModalToggleValue(appointment);
						});
						
						this.days = this.getDays(this.searchDate.getFullYear(), this.searchDate.getMonth());
					})
				]);
			});
		});
	}

	calendarDateChanged(date, addToHistory = true) {
		let year = date.getFullYear();
		let month = date.getMonth() + 1;
		let day = date.getDate();

		let fetch =
			!this.year ||
			!this.month ||
			this.year != year ||
			this.month != month;

		this.year = year;
		this.month = month;
		this.scrollToDay = day;

		this.userSettings.setting('selectedCalendarMonth', date);

		if (addToHistory) {
			this.setDayState(year, month, day);
		}
		
		let id = `#_${year}${month}${day}`;
		
		if (fetch) {
			console.log('fetching...');
			return this.refreshAppointments(date)
				.then(() => {
					console.log('fetched, waiting for render...');
					whenExists(id).then(element => scrollTo(this.scroller, element));
				});
		}
		else {
			whenExists(id).then(element => scrollTo(this.scroller, element));
		}
	}
	
	refreshAppointments(searchDate) {
		this.setSearchRange(searchDate);
		
		return this.getData();
	}
	
	setSearchRange(date) {
		let year = date.getFullYear();
		let month = date.getMonth();
		
		let start = new Date(year, month, 1);
		let end = new Date(year, month + 1, 1);
		
		this.searchStart = this.dateService.toUtc(start);
		this.searchEnd = this.dateService.toUtc(end);
	}
/*
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
*/

	getDays(year, month) {
		let endOfMonth = new Date(year, month + 1, 0);
		
		var days = [];
		
		for (var i = 1; i <= endOfMonth.getDate(); i++) {
			let date = new Date(year, month, i);
			
			days.push({
				'date': date,
				'year': year,
				'month': month + 1,
				'day': i
			});
		}
		
		return days;
	}
	
	dateChanged(e) {
		
		this.searchDate = e.detail.dates[0];
		
		this.calendarDateChanged(this.searchDate);
	}
	
	getSummaryModalToggleValue(appointment) {
		return '#' + this.getSummaryModalContainerId(appointment);
	}
	
	getSummaryModalContainerId(appointment) {
		return `assessment-summary-${appointment.appointmentId}`;
	}
}

function offset(el) {
    var rect = el.getBoundingClientRect(),
    scrollLeft = window.pageXOffset || document.documentElement.scrollLeft,
    scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    return { top: rect.top + scrollTop, left: rect.left + scrollLeft }
}

function height(el) {
	return el.getBoundingClientRect().height;
}

function getFixedElementsHeight() {
	let elements = document.querySelectorAll('.fixed, .uk-sticky-fixed');
	
	let total = 0;
	
	for (let i = 0; i < elements.length; i++) {
		let h = height(elements[i]);
		
		total += h;
	}
	
	return total;
}

function scrollTo(scroller, element) {
	let position = offset(element);
	
	scroller.scrollTo(position.top);
	
	//adjust after scrolling down based on any fixed/sticky elements at the top
	setTimeout(function() {
		let height = getFixedElementsHeight();
		if (height > 0) {
			scroller.scrollTo(position.top - height);
		}
	}, 250);
}

function whenExists(selector, step = 100, timeout = 30000) {
	var promise = new Promise((resolve, reject) => {
		whileNotExistsOrTimeout(selector, step, new Date().getTime() + timeout, resolve, reject);
	});
	return promise;
}

function whileNotExistsOrTimeout(selector, step, timeout, resolve, reject) {
	let element = document.querySelector(selector);

	if (!element) {
		let timedOut =  new Date().getTime() > timeout;
		
		if (timedOut) {
			let err = new Error({ 'selector': selector, 'message': 'timeout waiting for element with selector' });
			reject(err);
		}
		
		setTimeout(function() {
			return whileNotExistsOrTimeout(selector, step, timeout, resolve, reject);
		}, step);
	}
	else {
		resolve(element);
	}
}