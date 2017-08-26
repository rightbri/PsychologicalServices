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
	
	createInvoice(psychometristMonth) {
		this.dataRepository.createPsychometristInvoice(this.user.company.companyId, psychometristMonth.payableToId, psychometristMonth.year, psychometristMonth.month)
			.then(data => {
				let invoice = data;

				psychometristMonth.invoiceId = invoice.invoiceId;
				psychometristMonth.canCreateInvoice = false;
			});
	}
	
	searchInvoices() {
		return this.dataRepository.searchInvoiceableAppointmentData({
				'companyId': this.user.company.companyId,
				'invoiceTypeId': this.invoiceTypeId,
				'startSearch': this.startSearch
			}).then(data => {

				this.invoiceableAppointmentData = data;

				this.invoiceablePsychometristMonths = this.invoiceableAppointmentData.reduce(function(accumulator, currentValue) {
					let psychometristMonth = accumulator.find(element =>
						element.payableToId === currentValue.payableToId &&
						element.year === currentValue.year &&
						element.month === currentValue.month
					);
					
					if (psychometristMonth === undefined) {
						psychometristMonth = {
							'payableTo': currentValue.payableTo,
							'payableToId': currentValue.payableToId,
							'year': currentValue.year,
							'month': currentValue.month,
							'monthName': this.config.months[currentValue.month],
							'appointmentCount': 0,
							'canCreateInvoice': true
						};
	
						accumulator.push(psychometristMonth);
					}
	
					psychometristMonth.appointmentCount += 1;
	
					return accumulator;
				}.bind(this), []);

			});
	}
	
	dateChanged(e) {
		this.startSearch = e.detail.dates[0];
	}
}
