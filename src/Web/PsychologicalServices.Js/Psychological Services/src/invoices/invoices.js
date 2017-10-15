import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {inject} from 'aurelia-framework';

@inject(DataRepository, Config, Context)
export class Invoices {
	constructor(dataRepository, config, context) {
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		
		this.invoiceStatusMatcher = (a, b) => a && b && a.invoiceStatusId === b.invoiceStatusId;
		this.invoiceTypeMatcher = (a, b) => a && b && a.invoiceTypeId === b.invoiceTypeId;
		this.payableToMatcher = (a, b) => a && b && a.payableToId === b.payableToId;
	}
	
	activate() {
		return this.context.getUser()
			.then(user => {
				this.user = user;
		
				return Promise.all([
					this.dataRepository.getInvoiceStatuses().then(data => this.invoiceStatuses = data),
					this.dataRepository.getInvoiceTypes().then(data => this.invoiceTypes = data),
					this.dataRepository.searchUsers({
						companyId: user.company.companyId
					}).then(data => this.payableTos = data)
				]);
		
			});
	}
	
	searchInvoices() {
		return this.dataRepository.getInvoices({
			'identifier': this.searchIdentifier,
			'invoiceDate': this.searchDate,
			'invoiceStatusId': this.searchStatus ? this.searchStatus.invoiceStatusId : null,
			'invoiceTypeId': this.searchType ? this.searchType.invoiceTypeId : null,
			'payableToId': this.searchPayableTo ? this.searchPayableTo.userId : null,
			'needsRefresh': this.searchNeedsRefresh ? true : null,
			'companyId': this.user.company.companyId
		})
		.then(invoices => this.invoices = invoices)
		.then(invoices => {
			invoices.forEach(invoice => {
				if (invoice.invoiceType.name === 'Psychologist') {
					let appointment = invoice.appointments[0].appointment;
					let assessment = appointment.assessment;
					
					invoice.referralSource = appointment.assessment.referralSource;
					
					if (assessment.claims) {
						assessment.claims.forEach(claim => {
							invoice.claimant = claim.claimant;
						});
					}
				}
			})
		});
	}
}