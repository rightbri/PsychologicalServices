import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';

@inject(Router, DataRepository, Context, Config, Scroller, Notifier)
export class InvoiceConfiguration {

    constructor(router, dataRepository, context, config, scroller, notifier) {
        this.router = router;
        this.dataRepository = dataRepository;
        this.context = context;
        this.config = config;
        this.scroller = scroller;
        this.notifier = notifier;

        this.visibleTab = 0;
    }

    activate() {

        return this.context.getUser().then(user => {
            this.user = user;

            return Promise.all([
                this.dataRepository.getReferralSources({

                }).then(data => this.referralSources = data),
                this.dataRepository.getInvoiceConfiguration(this.user.company.companyId).then(data => this.invoiceConfiguration = data)
            ]);  
        })
    }

    referralSourceChanged() {

        this.assessmentTypeInvoiceAmounts = this.invoiceConfiguration.assessmentTypeInvoiceAmounts.filter(atia => atia.referralSource.referralSourceId === this.selectedReferralSource.referralSourceId);

        this.referralSourceInvoiceConfigurations = this.invoiceConfiguration.referralSourceInvoiceConfigurations.filter(rsic => rsic.referralSource.referralSourceId === this.selectedReferralSource.referralSourceId);

        this.appointmentStatusInvoiceRates = this.invoiceConfiguration.appointmentStatusInvoiceRates.filter(asir => asir.referralSource.referralSourceId === this.selectedReferralSource.referralSourceId);
    }

    showTab(index) {
        this.visibleTab = index;
    }

    save() {
		
		this.dataRepository.saveInvoiceConfiguration(this.invoiceConfiguration)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
					
                if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.invoiceConfiguration = data.item;
					
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
            });
	}
	
	back() {
		this.router.navigateBack();
	}
}