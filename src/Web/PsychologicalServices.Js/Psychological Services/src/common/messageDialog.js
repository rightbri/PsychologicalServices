import {DialogController} from 'aurelia-dialog';
import {inject} from 'aurelia-framework';

@inject(DialogController)
export class MessageDialog {
	constructor(dialogController) {
		this.dialogController = dialogController;
	}
	
	activate(model) {
		this.heading = model.heading;
		this.message = model.message;
	}
	
	ok() {
		this.dialogController.ok();
	}
}