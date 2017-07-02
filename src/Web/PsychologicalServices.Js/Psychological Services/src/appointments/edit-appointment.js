import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {EventHelper} from 'services/eventHelper';
import {Timezone} from 'common/timezone';
import moment from 'moment';
import 'moment-timezone';

@inject(Element, DataRepository, Config, EventHelper, Timezone)
export class EditAppointment {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, dataRepository, config, eventHelper, timezone) {
		this.element = element;
		this.dataRepository = dataRepository;
		this.config = config;
		this.eventHelper = eventHelper;
		this.timezone = timezone;
		
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
		this.appointmentTime = this.timezone.convert(moment.utc(model.appointment.appointmentTime), this.config.timezone).format(this.config.shortTimeFormat);

		this.psychometrists = model.psychometrists;
		this.psychologists = model.psychologists;
		this.appointmentStatuses = model.appointmentStatuses;
		this.addresses = model.addresses;
		this.attributes = model.attributes;
	}

	ok(e) {
		console.log(this.appointmentDate);
		
		this.model.appointment.appointmentTime =
			moment.tz(
				moment.utc(this.appointmentDate).format(this.config.isoShortDateFormat) + ' ' + this.appointmentTime,
				this.config.isoShortDateFormat + ' ' + this.config.isoShortTimeFormat,
				this.config.timezone
			).utc().format();
		
		this.backup = getBackup(this.model.appointment);
		
		this.eventHelper.fireEvent(this.element, 'edited', { 'appointment': this.model.appointment });
	}
	
	cancel(e) {
		this.eventHelper.fireEvent(this.element, 'canceled', { 'appointment': this.backup });
	}
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}