import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {Config} from '../common/config';
import {inject} from 'aurelia-framework';
import moment from 'moment';

@inject(DialogController, DataRepository, Config)
export class AppointmentDialog {
	constructor(dialogController, dataRepository, config) {
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;
		this.config = config;
		
		this.psychometrists = null;
		this.psychologists = null;
		this.companies = null;
		this.appointmentStatuses = null;
		this.taskStatuses = null;
		this.addresses = null;
		
		this.psychometristMatcher = (a, b) => a.userId === b.userId;
		this.psychologistMatcher = (a, b) => a.userId === b.userId;
		this.companyMatcher = (a, b) => a.companyId === b.companyId;
		this.appointmentStatusMatcher = (a, b) => a.appointmentStatusId === b.appointmentStatusId;
		this.addressMatcher = (a, b) => a.addressId === b.addressId;
		this.taskStatusMatcher = (a, b) => a.taskStatusId === b.taskStatusId;
	}
	
	activate(appointment) {
		this.appointment = appointment;
		this.appointmentDate = this.dateString(this.appointment.appointmentTime);
		this.appointmentTime = this.timeString(this.appointment.appointmentTime);

		return Promise.all([
			this.dataRepository.getPsychometrists(this.appointment.companyId).then(data => this.psychometrists = data),
			this.dataRepository.getPsychologists(this.appointment.companyId).then(data => this.psychologists = data),
			this.dataRepository.getCompanies().then(data => this.companies = data),
			this.dataRepository.getAppointmentStatuses().then(data => this.appointmentStatuses = data),
			this.dataRepository.getTaskStatuses().then(data => this.taskStatuses = data),
			this.dataRepository.searchAddress().then(data => this.addresses = data)
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