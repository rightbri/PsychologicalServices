import {DialogService} from 'aurelia-dialog';
import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {inject} from 'aurelia-framework';
import {ClaimantDialog} from './ClaimantDialog';

@inject(DialogService, DialogController, DataRepository, Config)
export class ClaimantSearchDialog {
	constructor(dialogService, dialogController, dataRepository, config) {
		this.dialogService = dialogService;
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;
		this.config = config;
		
		this.claimantSearch = null;
		this.claimantSearchMinLength = 2;
		this.addClaimantEnabled = true;
		
		this.claimants = null;
		this.claimant = null;
	}

	activate(options) {
		this.addClaimantEnabled = options.addClaimantEnabled;
	}
	
	ok() {
		this.dialogController.ok(this.claimant);
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
		this.claimants.forEach(c => c.selected = false);
		
		claimant.selected = true;
		this.claimant = claimant;
	}
	
	addClaimant() {
		return this.editClaimant({ isActive: true })
			.then(data => {
				if (!data.wasCancelled) {
					this.claimant = data.claimant;
				}
			});
	}
	
	editClaimant(claimant) {
		var original = JSON.parse(JSON.stringify(claimant));
		
		return this.dialogService.open({viewModel: ClaimantDialog, model: claimant})
			.then(result => {
				var copyFrom = original;
				
				if (!result.wasCancelled) {
					copyFrom = result.output;
				}
				
				for (var prop in copyFrom) {
					if (copyFrom.hasOwnProperty(prop)) {
						claimant[prop] = copyFrom[prop];
					}
				}
				
				return { wasCancelled: result.wasCancelled, claimant: claimant };
			});
	}
}