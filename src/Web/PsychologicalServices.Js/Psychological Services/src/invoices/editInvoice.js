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
					
					this.calculateTotals();

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
		this.dataRepository.refreshInvoiceLines(this.invoice)
			.then(data => {
				
				this.invoice.appointments = (data || []);
				
				this.calculateTotals();
			});
	}
	
    removeLine(invoiceAppointment, line) {
		if (confirm('Remove Invoice Line\nAre you sure?')) {
			
			invoiceAppointment.lines.splice(invoiceAppointment.lines.indexOf(line), 1);
			
			this.calculateTotals();
		}
    }

    addLine(invoiceAppointment) {
        invoiceAppointment.lines.push({ 'description': '', 'amount': 0, 'isCustom': true });
    }

    calculateTotals() {
        
		this.subtotal = 0;
		
		this.invoice.appointments.forEach(invoiceAppointment =>
		{
			let appointmentSubtotal = 0;
			
			appointmentSubtotal =
				invoiceAppointment.lines
					.filter(line => !line.applyInvoiceRate)
					.map(line => line.amount)
					.reduce((accumulator, value) => accumulator + value, 0) +
				invoiceAppointment.lines
					.filter(line => line.applyInvoiceRate)
					.map(line => line.amount)
					.reduce((accumulator, value) => accumulator + (value * this.invoice.invoiceRate), 0);

			invoiceAppointment.showStatusLine = this.invoice.invoiceRate !== 1.0;
			
			invoiceAppointment.subtotal = appointmentSubtotal;
			
			this.subtotal += appointmentSubtotal;
		}, this);

        this.invoice.total = Math.round(this.subtotal * (1 + this.invoice.taxRate));
    }
	
	setStatus(nextStatus) {
		if (confirm('Update invoice status to ' + nextStatus.name + '?')) {
			this.invoice.invoiceStatus = nextStatus;
			this.save();
		}
	}

	getInvoiceDocument(invoiceDocument) {
		this.dataRepository.getInvoiceDocument(invoiceDocument);
	}

	sendInvoiceDocument(invoiceDocument) {
		this.dataRepository.sendInvoiceDocument(invoiceDocument.invoiceDocumentId)
			.then(result => {
				if (result.success) {
					this.notifier.info('Invoice sent successfully');
				}
				else {
					this.notifier.error(
						result.errors.reduce((accumulator, value) => "-" + value + '\n')
					);
				}
			});
	}
}