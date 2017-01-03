import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {ValidationRules, ValidationController} from 'aurelia-validation';
import moment from 'moment';

@inject(Router, DataRepository, ValidationController, moment)
export class EditAppointment {
    constructor(router, dataRepository, validationController, moment) {
        this.router = router;
        this.dataRepository = dataRepository;
        this.validationController = validationController;
        this.moment = moment;

        this.companyId = 1;

        this.appointment = null;
        this.psychometrists = null;
		this.psychologists = null;
		this.companies = null;
		this.appointmentStatuses = null;
		this.taskStatuses = null;
		this.addresses = null;
    }

    activate(params) {
        var id = params.id;

		return Promise.all([
			this.dataRepository.getPsychometrists(this.companyId).then(data => this.psychometrists = data),
			this.dataRepository.getPsychologists(this.companyId).then(data => this.psychologists = data),
			this.dataRepository.getCompanies().then(data => this.companies = data),
			this.dataRepository.getAppointmentStatuses().then(data => this.appointmentStatuses = data),
			this.dataRepository.getTaskStatuses().then(data => this.taskStatuses = data),
			this.dataRepository.searchAddress().then(data => this.addresses = data),
			
			this.dataRepository.getAppointment(id)
				.then(data => {
					this.appointment = data;

					this.appointmentDate = this.dateString(this.appointment.appointmentTime);
					this.appointmentTime = this.timeString(this.appointment.appointmentTime);

					this.initValidation();
				})
		]);
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
                    this.appointment = data.item;
					alert('saved');
                }
            });
    }
	
	back() {
		this.router.navigateBack();
	}
	
	editAssessment(id) {
		this.router.navigateToRoute('editAssessment', { id: id });
	}

    initValidation() {
        
        ValidationRules.customRule(
            'validTimeRule',
            (value, object) => {
                var isValid = /^([0-1][0-9]|[2][0-3]):([0-5][0-9])$/.test(value);

                return isValid;
            },
            `incorrect time format for \${$displayName}: \${$value}`
        );

        ValidationRules.customRule(
            'validDateRule',
            (value, object) => {
                var isValid = this.moment(value, 'YYYY-MM-DD').isValid();

                return isValid;
            },
            `incorrect date format for \${$displayName}: \${$value}`
        );

        
        ValidationRules
        .ensure(a => a.appointmentDate)
        .required()
        .satisfiesRule('validDateRule')
        .on(this);

        ValidationRules
        .ensure(a => a.appointmentTime)
        .required()
        .satisfiesRule('validTimeRule')
        .on(this);

        ValidationRules
        .ensure(a => a.appointmentStatusId)
        .required()
        .on(this.appointment);

        ValidationRules
        .ensure(a => a.psychometristId)
        .required()
        .on(this.appointment);

        ValidationRules
        .ensure(a => a.psychologistId)
        .required()
        .on(this.appointment);
    }
}