import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';

@inject(DataRepository, Context, Config)
export class ConsultingInvoices {
	constructor(dataRepository, context, config) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		
		let now = new Date();
		this.currentYear = now.getFullYear();
		this.currentMonth = now.getMonth() + 1;

		this.years = [];
		this.months = [];
		this.filteredMonths = [];
		this.consultingAgreements = [];
		
		this.canCreateInvoice = false;

		this.searchYear = this.currentYear;
		this.searchMonth = this.currentMonth;

		this.valueMatcher = (a, b) => a && b && a.value === b.value;
	}

	activate() {
		return this.context.getUser().then(user => {
			this.user = user;

			return Promise.all([
				this.getMonths().then(data => this.months = data),
				this.getYears(this.currentYear).then(data => this.years = data)
			]).then(() => this.searchYearChanged());
		});
	}
	
	createInvoice(consultingAgreement) {
		this.dataRepository.createConsultingInvoice(consultingAgreement.consultingAgreementId, consultingAgreement.year, consultingAgreement.month)
			.then(data => {
				let invoice = data;

				consultingAgreement.invoiceId = invoice.invoiceId;
				consultingAgreement.canCreateInvoice = false;
			});
	}
	
	searchInvoices() {
		return this.dataRepository.searchInvoiceableConsultingAgreementData({
			'companyId': this.user.company.companyId,
			'year': this.searchYear,
			'month': this.searchMonth
		}).then(data => this.consultingAgreements = data);
	}

	searchYearChanged() {
		let monthFilter = item => (this.searchYear < this.currentYear) || item.value <= this.currentMonth;
		
		this.filteredMonths = this.months.filter(monthFilter);
	}

	getYears(currentYear) {
		let data = [
			currentYear - 1,
			currentYear
		];

		return getPromise(data);
	}

	getMonths() {
		let data = [
			{ "name": "January", "value": 1 },
			{ "name": "February", "value": 2 },
			{ "name": "March", "value": 3 },
			{ "name": "April", "value": 4 },
			{ "name": "May", "value": 5 },
			{ "name": "June", "value": 6 },
			{ "name": "July", "value": 7 },
			{ "name": "August", "value": 8 },
			{ "name": "September", "value": 9 },
			{ "name": "October", "value": 10 },
			{ "name": "November", "value": 11 },
			{ "name": "December", "value": 12 }
		];

		return getPromise(data);
	}
}

function getPromise(data) {
    var promise = new Promise((resolve, reject) => resolve(data));

    return promise;
}
