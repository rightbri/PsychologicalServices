import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';
import moment from 'moment';

@inject(DialogController, DataRepository)
export class ClaimDialog {
	constructor(dialogController, dataRepository) {
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;
		
		this.claimantSearch = '';
		this.claimantSearchMinLength = 3;
		
		this.claimants = null;
	}
	
	activate(claim) {
		this.claim = claim;
	}
	
	save() {
		/*
		this.dataRepository.saveAppointment(this.appointment)
			.then(data => {

				if (data.isError) {
					alert(data.errorDetails);
				}

				if (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0) {
					alert('validation errors: ' + data.validationResult.validationErrors.length);
				}

				if (data.isSaved) {
					this.dialogController.ok(data.item);
				}
			});
		*/
		
		this.dialogController.ok(this.claim);
	}
	
	cancel() {
		this.dialogController.cancel();
	}
	
	searchClaimant(lastName) {
		this.dataRepository.getClaimants(lastName).then(data => {
			this.claimants = data;
		});
	}
	
	selectClaimant(claimant) {
		this.claim.claimant = claimant;
	}
}