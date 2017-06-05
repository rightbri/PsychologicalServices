import {DialogController} from 'aurelia-dialog';
import {Config} from '../common/config';
import {inject} from 'aurelia-framework';

@inject(DialogController, Config)
export class EditClaim {
	constructor(dialogController, config) {
		this.dialogController = dialogController;
		this.config = config;
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