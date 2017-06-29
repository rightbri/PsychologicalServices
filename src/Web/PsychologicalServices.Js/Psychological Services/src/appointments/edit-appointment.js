import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {EventHelper} from 'services/eventHelper';
import moment from 'moment';

@inject(Element, DataRepository, Config, EventHelper)
export class EditAppointment {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, dataRepository, config, eventHelper) {
		this.element = element;
		this.dataRepository = dataRepository;
		this.config = config;
		this.eventHelper = eventHelper;
		
		this.psychometristMatcher = (a, b) => a !== null && b !== null && a.userId === b.userId;
		this.psychologistMatcher = (a, b) => a !== null && b !== null && a.userId === b.userId;
		this.appointmentStatusMatcher = (a, b) => a !== null && b !== null && a.appointmentStatusId === b.appointmentStatusId;
		this.addressMatcher = (a, b) => a !== null && b !== null && a.addressId === b.addressId;
		this.attributeMatcher = (a, b) => a !== null && b !== null && a.attributeId === b.attributeId;
	}
	
	modelChanged(oldValue, newValue) {
		this.backup = getBackup(oldValue.appointment);
		
		let model = this.model;
		
		this.appointmentDate = model.appointment.appointmentTime;
		this.appointmentTime = time(model.appointment.appointmentTime, this.config.shortTimeFormat);

		this.psychometrists = model.psychometrists;
		this.psychologists = model.psychologists;
		this.appointmentStatuses = model.appointmentStatuses;
		this.addresses = model.addresses;
		this.attributes = model.attributes;
	}
	
	/*
	appointmentDateChanged(e) {
		this.appointmentDate = e.detail.event.date;
	}
	*/

	ok(e) {
		this.model.appointment.appointmentTime =
			parseDateTime(
				this.appointmentDate,
				this.appointmentTime,
				this.config.isoShortDateFormat,
				this.config.shortTimeFormat
			);
        
		this.backup = getBackup(this.model.appointment);
		
		this.eventHelper.fireEvent(this.element, 'edited', { 'appointment': this.model.appointment });
	}
	
	cancel(e) {
		this.eventHelper.fireEvent(this.element, 'canceled', { 'appointment': this.backup });
	}
}

function parseDateTime(date, time, dateFormat, timeFormat) {
	var newDate = moment(
		moment(date).format(dateFormat) + ' ' + time,
		dateFormat + ' ' + timeFormat
	).utc().format();

	return newDate;
}

function time(datetime, format) {
	return moment.utc(datetime).format(format);
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}