import {DialogController} from 'aurelia-dialog';
import {Config} from '../common/config';
import {inject} from 'aurelia-framework';

@inject(DialogController, Config)
export class MedRehabDialog {
	constructor(dialogController, config) {
		this.dialogController = dialogController;
		this.config = config;
	}
	
	activate(medRehab) {
		this.medRehab = medRehab;
	}
	
	ok() {
		this.dialogController.ok(this.medRehab);
	}
	
	cancel() {
		this.dialogController.cancel();
	}
	
	medRehabDateChanged(e) {
		this.medRehab.date = e.detail.event.date;
	}
}