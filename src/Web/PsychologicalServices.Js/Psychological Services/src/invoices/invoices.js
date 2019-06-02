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
		this.referralSourceMatcher = (a, b) => a && b && a.referralSourceId === b.referralSourceId;
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
					}).then(data => this.payableTos = data),
					this.dataRepository.getReferralSources({}).then(data => this.referralSources = data)
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
			'claimantId': this.searchClaimant ? this.searchClaimant.claimantId : null,
			'referralSourceId': this.searchReferralSource ? this.searchReferralSource.referralSourceId : null,
			'needsRefresh': this.searchNeedsRefresh ? true : null,
			'needsToBeSentToReferralSource': this.searchNeedsToBeSentToReferralSource ? true : null,
			'companyId': this.user.company.companyId
		})
		.then(invoices => this.invoices = invoices)
		.then(invoices => {
			invoices.forEach(invoice => {
				if (invoice.invoiceType.name === 'Psychologist') {
					let lineGroupsWithAppointments = invoice.lineGroups.filter(lineGroup => lineGroup.appointment);
					if (lineGroupsWithAppointments.length > 0) {
						let appointment = lineGroupsWithAppointments[0].appointment;
						let assessment = appointment.assessment;
					
						invoice.referralSource = appointment.assessment.referralSource;
						
						if (assessment.claims) {
							assessment.claims.forEach(claim => {
								invoice.claimant = claim.claimant;
							});
						}
					}
				}
			})
		});
	}
}