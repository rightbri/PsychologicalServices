import {DialogController} from 'aurelia-dialog';
import {inject} from 'aurelia-framework';

@inject(DialogController)
export class ClaimDialog {
	constructor(dialogController) {
		this.dialogController = dialogController;
	}
	
	activate(claim) {
		this.claim = claim;
	}
	
	ok() {
		this.dialogController.ok(this.claim);
	}
	
	cancel() {
		this.dialogController.cancel();
	}
}