import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import {inject} from 'aurelia-framework';

@inject(Router, DataRepository, Config, Scroller, Notifier)
export class EditReferralSource {
	constructor(router, dataRepository, config, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.referralSource = null;
		
		this.addresses = [];
		this.referralSourceTypes = [];
		this.reportTypes = [];
		
		this.addressMatcher = (a, b) => a !== null && b !== null && a.addressId === b.addressId;
		this.referralSourceTypeMatcher = (a, b) => a !== null && b !== null && a.referralSourceTypeId === b.referralSourceTypeId;
		
		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getReferralSource(id)
				.then(referralSource => {
					this.referralSource = referralSource;
					
					return this.getData();
				});
		}
		else {
			this.referralSource = {
				referralSourceId: 0,
				//largeFileSize: this.config.referralSourceDefaults.largeFileSize,
				//largeFileFeeAmount: this.config.referralSourceDefaults.largeFileFeeAmount,
				//lateCancellationRate: this.config.referralSourceDefaults.lateCancellationRate,
				isActive: true,
				//reportTypeInvoiceAmounts: []
			};
			
			return this.getData();
		}
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.searchAddress({
				'addressTypeIds': this.config.referralSourceDefaults.addressTypeIds
			}).then(data => this.addresses = data),
			this.dataRepository.getReferralSourceTypes().then(data => this.referralSourceTypes = data)
			/*,
			this.dataRepository.getReportTypes().then(data => {
				this.reportTypes = data;
				
				this.referralSource.reportTypeInvoiceAmounts = this.referralSource.reportTypeInvoiceAmounts.concat(
					getMissingInvoiceAmounts(data, this.referralSource.reportTypeInvoiceAmounts)
				);
			})*/
			/*,
			this.dataRepository.getAppointmentStatuses().then(appointmentStatuses => {

				return this.dataRepository.getInvoiceTypes().then(invoiceTypes => {
					
					this.referralSource.appointmentStatusSettings = this.referralSource.appointmentStatusSettings.concat(
						getMissingAppointmentStatusSettings(appointmentStatuses, invoiceTypes, this.referralSource.appointmentStatusSettings)
					);
				});
			})*/
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
		var isNew = this.referralSource.referralSourceId === 0;
		
		this.dataRepository.saveReferralSource(this.referralSource)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.referralSource = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editReferralSource',
							{ 'id': this.referralSource.referralSourceId },
							{ 'trigger': false, replace: true }
						);
						
						this.editType = 'Edit';
					}
					
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				
				this.saveDisabled = false;
            })
			.catch(err => {
				this.saveDisabled = false;
			});
	}
	
	back() {
		this.router.navigateBack();
	}
}
/*
function getMissingInvoiceAmounts(reportTypes, invoiceAmounts) {
	return reportTypes.filter(reportType => 
		!invoiceAmounts.some(invoiceAmount => invoiceAmount.reportType.reportTypeId === reportType.reportTypeId)
	).map(function(reportType) { return { reportType: reportType, invoiceAmount: 0 };});
}

function getMissingAppointmentStatusSettings(appointmentStatuses, invoiceTypes, appointmentStatusSettings) {
	return appointmentStatuses.map(function (appointmentStatus) {
		return invoiceTypes.map(function (invoiceType) {
			return {
				'appointmentStatus': appointmentStatus,
				'invoiceType': invoiceType,
				'invoiceRate': 0
			};
		});
	}).reduce((a, b) => a.concat(b))
	.filter(item => !appointmentStatusSettings.some(appointmentStatusSetting =>
		appointmentStatusSetting.appointmentStatus.appointmentStatusId === item.appointmentStatus.appointmentStatusId &&
		appointmentStatusSetting.invoiceType.invoiceTypeId === item.invoiceType.invoiceTypeId
	));
}
*/