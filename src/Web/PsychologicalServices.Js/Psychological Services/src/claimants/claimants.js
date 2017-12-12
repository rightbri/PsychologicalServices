import {inject} from 'aurelia-framework';
import {DataRepository} from '../services/dataRepository';
import {Notifier} from 'services/notifier';

@inject(DataRepository, Notifier)
export class Claimants {
	constructor(dataRepository, notifier) {
		this.dataRepository = dataRepository;
		this.notifier = notifier;
		this.claimants = null;
	}
	
	activate() {
		
		return Promise.all([
			this.dataRepository.getGenders().then(data => this.genders = data)
		]);
	}
	
	claimantSelected(e) {
		let claimant = e.detail.claimant;
		
		this.claimant = claimant;
		
		this.claimantEditModel = null;
	}
	
	newClaimant() {
		let claimant = { isAdd: true, isActive: true };
		this.editClaimant(claimant);
	}
	
	editClaimant(claimant) {
		let model = { 'genders': this.genders, 'claimant': claimant };
		this.claimantEditModel = model;
	}
	
	deleteClaimant(claimant) {
		if (confirm('Delete Claimant\nAre you sure?')) {
			this.dataRepository.deleteClaimant(claimant.claimantId).then(data => {
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				else {
					this.removeClaimant(claimant);
					this.claimantEditModel = null;
					this.claimant = null;
					
					this.notifier.info('Deleted');
				}
			});
		}
	}
	
	removeClaimant(claimant) {
		this.claimants.splice(this.claimants.indexOf(claimant), 1);
	}
	
	claimantEdited(e) {
		this.claimantSelected(e);
		
		this.notifier.info('Saved');
	}
	
	claimantCanceled(e) {
		let claimant = e.detail.claimant;
		
		if (!claimant.isAdd) {
			copyValues(claimant, this.claimantEditModel.claimant);
		}
		
		this.claimantEditModel = null;
	}
}

function copyValues(copyFrom, copyTo) {
	for (var prop in copyFrom) {
		if (copyTo.hasOwnProperty(prop)) {
			copyTo[prop] = copyFrom[prop];
		}
	}
}