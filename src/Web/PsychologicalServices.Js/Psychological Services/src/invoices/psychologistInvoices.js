import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';

@inject(DataRepository, Context, Config)
export class PsychologistInvoices {
	constructor(dataRepository, context, config) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		
		this.invoiceTypeId = this.config.invoiceTypes.psychologist;
	}

	activate() {
		return this.context.getUser().then(user => this.user = user);
	}
	
	createInvoice(appointment) {
		this.dataRepository.createPsychologistInvoice(appointment.appointmentId)
			.then(data => {
				let invoice = data;

				appointment.invoiceId = invoice.invoiceId;
				appointment.canCreateInvoice = false;
			});
	}
	
	searchInvoices() {
		return this.dataRepository.searchInvoiceableAppointmentData({
			'companyId': this.user.company.companyId,
			'invoiceTypeId': this.invoiceTypeId,
			'startDateSearch': this.startDateSearch,
			'endDateSearch': this.endDateSearch
		}).then(data => {
			this.invoiceableAppointments = data.map(a => {
				a.canCreateInvoice = true;
				return a;
			});
		});
	}
	
	startDateChanged(e) {
		this.startDateSearch = e.detail.dates[0];
	}

	endDateChanged(e) {
		this.endDateSearch = e.detail.dates[0];
	}
}
