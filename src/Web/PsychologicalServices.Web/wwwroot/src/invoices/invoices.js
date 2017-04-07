import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {inject} from 'aurelia-framework';

@inject(DataRepository, Config)
export class Invoices {
	constructor(dataRepository, config) {
		this.dataRepository = dataRepository;
		this.config = config;
		
		this.invoiceStatuses = null;
		
		this.invoiceStatusMatcher = (a, b) => a && b && a.invoiceStatusId === b.invoiceStatusId;
	}
	
	activate() {
		return Promise.all([
			this.dataRepository.getInvoiceStatuses().then(data => this.invoiceStatuses = data)
		]);
	}
	
	searchInvoices() {
		return this.dataRepository.getInvoices({
			'identifier': this.searchIdentifier,
			'invoiceDate': this.searchDate,
			'invoiceStatusId': this.searchStatus ? this.searchStatus.invoiceStatusId : null,
		}).then(data => this.invoices = data);
	}
}