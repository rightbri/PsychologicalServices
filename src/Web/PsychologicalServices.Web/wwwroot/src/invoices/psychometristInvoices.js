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
		
		this.invoices = null;
		
		this.invoiceTypeId = this.config.invoiceTypes.psychometrist;
		this.invoiceMonth = new Date();
	}

	activate() {
		return this.context.getUser()
			.then(user => {
				this.user = user;
				
				return Promise.all([
					this.searchInvoices(user.company.companyId, this.invoiceTypeId, this.invoiceMonth).then(data => this.invoices = data)
				]);
			});
	}
	
	createInvoices() {
		this.dataRepository.createPsychometristInvoices(this.user.company.companyId, this.invoiceMonth)
			.then(data => this.invoices = data);
	}
	
	searchInvoices(companyId, invoiceTypeId, invoiceMonth) {
		return this.dataRepository.getInvoices({
				'companyId': companyId,
				'invoiceTypeId': invoiceTypeId,
				'invoiceMonth': invoiceMonth
			});
	}
	
	monthChanged(e) {
		this.invoiceMonth = e.detail;
		
		this.searchInvoices(this.user.company.companyId, this.invoiceTypeId, this.invoiceMonth)
			.then(data => this.invoices = data);
	}
}
