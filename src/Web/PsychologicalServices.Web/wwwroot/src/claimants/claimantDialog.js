import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DialogController, DataRepository)
export class ClaimantDialog {
	constructor(dialogController, dataRepository) {
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;

		this.error = null;
		this.validationErrors = null;
	}
	
	activate(claimant) {
		this.claimant = claimant;
		
		return this.dataRepository.getGenders()
			.then(data => {
				this.genders = data;
			});
	}
	
	ok() {
		this.dataRepository.saveClaimant(this.claimant)
			.then(data => {
				
				this.error = data.isError ? data.errorDetails : null;

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (data.isSaved) {
					this.dialogController.ok(data.item);
				}
			});
	}
	
	cancel() {
		this.dialogController.cancel();
	}
}