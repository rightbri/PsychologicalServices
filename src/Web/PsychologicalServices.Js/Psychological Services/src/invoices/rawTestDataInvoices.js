import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';

@inject(DataRepository, Context, Config)
export class RawTestDataInvoices {
	constructor(dataRepository, context, config) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		
		this.invoiceTypeId = this.config.invoiceTypes.rawTestData;
	}

	activate() {
		return this.context.getUser().then(user => this.user = user);
	}
	
	createInvoice(rawTestData) {
		rawTestData.canCreateInvoice = false;
		
		this.dataRepository.createRawTestDataInvoice(rawTestData.rawTestDataId)
			.then(data => {
				let invoice = data;

				rawTestData.invoiceId = invoice.invoiceId;
				rawTestData.canCreateInvoice = false;
			});
	}
	
	searchInvoices() {
		return this.dataRepository.searchInvoiceableRawTestData({
				'companyId': this.user.company.companyId
			}).then(data => {
				this.invoiceableRawTestData = data.map(a => {
					a.canCreateInvoice = true;
					return a;
				});
			});
	}
}
