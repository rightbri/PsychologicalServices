import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';
import moment from 'moment';

@inject(DialogController, DataRepository)
export class AppointmentDialog {
	constructor(dialogController, dataRepository) {
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;
		
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
	
	save() {
		this.appointment.appointmentTime = this.parseDateTime(this.appointmentDate, this.appointmentTime);
        
		this.dataRepository.saveAppointment(this.appointment)
			.then(data => {

				if (data.isError) {
					alert(data.errorDetails);
				}

				if (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0) {
					alert('validation errors: ' + data.validationResult.validationErrors.length);
				}

				if (data.isSaved) {
					this.dialogController.ok(data.item);
				}
			});
	}
	
	cancel() {
		this.dialogController.cancel();
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