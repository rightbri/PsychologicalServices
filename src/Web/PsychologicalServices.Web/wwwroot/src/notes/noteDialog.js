import {DialogController} from 'aurelia-dialog';
import {Context} from 'common/context';
import {inject} from 'aurelia-framework';

@inject(DialogController, Context)
export class NoteDialog {
	constructor(dialogController, context) {
		this.dialogController = dialogController;
		this.context = context;
	}
	
	activate(note) {
		this.note = note;
	}
	
	ok() {
		this.note.updateUser = this.context.user;
		this.note.updateDate = new Date();
		
		this.dialogController.ok(this.note);
	}
	
	cancel() {
		this.dialogController.cancel();
	}
}