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
		
		this.psychometrists = null;
		this.psychologists = null;
		this.appointmentStatuses = null;
		this.taskStatuses = null;
		this.addresses = null;
		this.attributes = null;
		
		this.psychometristMatcher = (a, b) => a !== null && b !== null && a.userId === b.userId;
		this.psychologistMatcher = (a, b) => a !== null && b !== null && a.userId === b.userId;
		this.appointmentStatusMatcher = (a, b) => a !== null && b !== null && a.appointmentStatusId === b.appointmentStatusId;
		this.addressMatcher = (a, b) => a !== null && b !== null && a.addressId === b.addressId;
		this.attributeMatcher = (a, b) => {
			return a !== null && b !== null && a.attributeId === b.attributeId;
		};
	}
	
	activate(appointment) {
		this.appointment = appointment;
		this.appointmentDate = this.dateString(this.appointment.appointmentTime);
		this.appointmentTime = this.timeString(this.appointment.appointmentTime);

		return Promise.all([
			this.dataRepository.searchUsers({
				companyId: this.context.user.company.companyId,
				rightId: this.config.rights.Psychometrist,
				availableDate: this.appointmentDate
			}).then(data => this.psychometrists = data),
			this.dataRepository.searchUsers({
				companyId: this.context.user.company.companyId,
				rightId: this.config.rights.Psychologist,
				availableDate: this.appointmentDate
			}).then(data => this.psychologists = data),
			this.dataRepository.getAppointmentStatuses().then(data => this.appointmentStatuses = data),
			this.dataRepository.searchAddress().then(data => this.addresses = data),
			this.dataRepository.searchAttributes({
				companyIds: [this.context.user.company.companyId],
				attributeTypeIds: this.config.appointmentDefaults.attributeTypeIds,
				isActive: true
			}).then(data => this.attributes = data)
		]);
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
	
	dateString(datetime) {
		return moment(datetime).format('MM/DD/YYYY');
	}

	timeString(datetime) {
		return moment(datetime).format('HH:mm');
	}

	parseDateTime(date, time) {
        return moment(date + time, 'MM/DD/YYYY HH:mm A').format();
    }
}