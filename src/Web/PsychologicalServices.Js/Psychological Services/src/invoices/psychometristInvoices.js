import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';

@inject(DataRepository, Context, Config)
export class PsychometristInvoices {
	constructor(dataRepository, context, config) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		
		this.invoiceTypeId = this.config.invoiceTypes.psychometrist;
	}

	activate() {
		return this.context.getUser().then(user => this.user = user);
	}
	
	createInvoice(psychometristPeriod) {
		psychometristPeriod.canCreateInvoice = false;
		
		this.dataRepository.createPsychometristInvoice(this.user.company.companyId, psychometristPeriod.payableToId, psychometristPeriod.startDate, psychometristPeriod.endDate)
			.then(data => {
				let invoice = data;

				psychometristPeriod.invoiceId = invoice.invoiceId;
				psychometristPeriod.canCreateInvoice = false;
			});
	}
	
	searchInvoices() {
		return this.dataRepository.searchInvoiceableAppointmentData({
				'companyId': this.user.company.companyId,
				'invoiceTypeId': this.invoiceTypeId,
				'startDateSearch': this.startDateSearch,
				'endDateSearch': this.endDateSearch
			}).then(data => {

				this.invoiceableAppointmentData = data;

				this.invoiceablePsychometristPeriods = this.invoiceableAppointmentData.reduce(function(accumulator, currentValue) {
					let psychometristPeriod = accumulator.find(element =>
						element.payableToId === currentValue.payableToId
					);
					
					if (psychometristPeriod === undefined) {
						psychometristPeriod = {
							'payableTo': currentValue.payableTo,
							'payableToId': currentValue.payableToId,
							'year': currentValue.year,
							'month': currentValue.month,
							'startDate': this.startDateSearch,
							'endDate': this.endDateSearch,
							'appointmentCount': 0,
							'canCreateInvoice': true
						};
	
						accumulator.push(psychometristPeriod);
					}
	
					psychometristPeriod.appointmentCount += 1;
	
					return accumulator;
				}.bind(this), []);

			});
	}
	
	startDateChanged(e) {
		this.startDateSearch = e.detail.dates[0];
	}

	endDateChanged(e) {
		this.endDateSearch = e.detail.dates[0];
	}
}
