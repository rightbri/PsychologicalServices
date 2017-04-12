import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';

@inject(Router, DataRepository, Config, Context, Scroller, Notifier)
export class EditInvoice {
    constructor(router, dataRepository, config, context, scroller, notifier) {
        this.router = router;
        this.dataRepository = dataRepository;
        this.config = config;
        this.context = context;
        this.scroller = scroller;
        this.notifier = notifier;

        this.invoice = null;
		this.invoiceStatuses = null;

		this.error = null;
		this.validationErrors = null;
    }

    activate(params) {
        
        if (params.id) {
            return this.dataRepository.getInvoice(params.id)
                .then(data => {
					this.invoice = data;
					this.calculateTotals();
					
					return this.getData();
				});
        }
    }
	
	getData() {
		return Promise.all([
			this.dataRepository.getInvoiceStatuses().then(data => this.invoiceStatuses = data)
		]);
	}

    save() {
		
		this.calculateTotals();
		
		this.dataRepository.saveInvoice(this.invoice)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
					
                if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.invoice = data.item;
					
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

	refreshLines() {
		this.dataRepository.refreshInvoiceLines(this.invoice.appointment)
			.then(data => {
				
				this.invoice.lines = (data || []).concat(this.invoice.lines.filter(e => e.isCustom));
				
			});
	}
	
    removeLine(line) {
		if (confirm('Remove Invoice Line\nAre you sure?')) {
			this.invoice.lines.splice(this.invoice.lines.indexOf(line), 1);
			this.calculateTotals();
		}
    }

    addLine() {
        this.invoice.lines.push({ 'description': '', 'amount': 0, 'isCustom': true });
    }

    calculateTotals() {
        
        this.subtotal =
            this.invoice.lines
                .map(line => line.amount)
                .reduce((accumulator, value) => accumulator + value, 0);

        this.invoice.total = this.subtotal * (1 + this.invoice.taxRate);

        console.log('totals calculated...');
    }
	
	openInvoice() {
		if (confirm('Modify Invoice\nAre you sure?')) {
			for (var i = 0; i < this.invoiceStatuses.length; i++) {
				if (this.invoiceStatuses[i].invoiceStatusId === 1) {
					this.invoice.invoiceStatus = this.invoiceStatuses[i];
					break;
				}
			}
		}
	}
	
	submitInvoice() {
		if (confirm('Submit Invoice\nAre you sure?')) {
			for (var i = 0; i < this.invoiceStatuses.length; i++) {
				if (this.invoiceStatuses[i].invoiceStatusId === 2) {
					this.invoice.invoiceStatus = this.invoiceStatuses[i];
					break;
				}
			}
			
			this.save();
		}
	}
	
	paidInvoice() {
		if (confirm('Mark Invoice Paid\nAre you sure?')) {
			for (var i = 0; i < this.invoiceStatuses.length; i++) {
				if (this.invoiceStatuses[i].invoiceStatusId === 3) {
					this.invoice.invoiceStatus = this.invoiceStatuses[i];
					break;
				}
			}
			
			this.save();
		}
	}
}