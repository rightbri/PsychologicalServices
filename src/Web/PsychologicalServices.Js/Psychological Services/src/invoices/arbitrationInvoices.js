import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';

@inject(DataRepository, Context, Config)
export class ArbitrationInvoices {
	constructor(dataRepository, context, config) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		
		this.invoiceTypeId = this.config.invoiceTypes.arbitration;
	}

	activate() {
		return this.context.getUser().then(user => this.user = user);
	}
	
	createInvoice(arbitration) {
		arbitration.canCreateInvoice = false;
		
		this.dataRepository.createArbitrationInvoice(arbitration.arbitrationId)
			.then(data => {
				let invoice = data;

				arbitration.invoiceId = invoice.invoiceId;
				arbitration.canCreateInvoice = false;
			});
	}
	
	searchInvoices() {
		return this.dataRepository.searchInvoiceableArbitrationData({
				'companyId': this.user.company.companyId
			}).then(data => {
				this.invoiceableArbitrations = data.map(a => {
					a.canCreateInvoice = true;
					return a;
				});
			});
	}
}
