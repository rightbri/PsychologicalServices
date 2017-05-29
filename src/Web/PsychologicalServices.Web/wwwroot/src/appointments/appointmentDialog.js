import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {inject} from 'aurelia-framework';
import moment from 'moment';

@inject(DialogController, DataRepository, Config, Context)
export class AppointmentDialog {
	constructor(dialogController, dataRepository, config, context) {
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		
		this.psychometristMatcher = (a, b) => a !== null && b !== null && a.userId === b.userId;
		this.psychologistMatcher = (a, b) => a !== null && b !== null && a.userId === b.userId;
		this.appointmentStatusMatcher = (a, b) => a !== null && b !== null && a.appointmentStatusId === b.appointmentStatusId;
		this.addressMatcher = (a, b) => a !== null && b !== null && a.addressId === b.addressId;
		this.attributeMatcher = (a, b) => a !== null && b !== null && a.attributeId === b.attributeId;
	}
	
	activate(model) {
		this.appointment = model.appointment;
		this.appointmentDate = this.appointment.appointmentTime;
		this.appointmentTime = this.time(this.appointment.appointmentTime);

		this.psychometrists = model.psychometrists;
		this.psychologists = model.psychologists;
		this.appointmentStatuses = model.appointmentStatuses;
		this.addresses = model.addresses;
		this.attributes = model.attributes;
	}
	
	ok() {
		this.appointment.appointmentTime = this.parseDateTime(this.appointmentDate, this.appointmentTime);
        
		this.dialogController.ok(this.appointment);
	}
	
	cancel() {
		this.dialogController.cancel();
	}
	
	appointmentDateChanged(e) {
		this.appointmentDate = e.detail.event.date;
	}

	time(datetime) {
		return moment(datetime).format(this.config.shortTimeFormat);
	}

	parseDateTime(date, time) {
		
        var newDate = moment(
			moment(date).format(this.config.isoShortDateFormat) + ' ' + time,
			this.config.isoShortDateFormat + ' ' + this.config.shortTimeFormat
		).format();

		return newDate;
    }
}