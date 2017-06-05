import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {inject} from 'aurelia-framework';

@inject(DialogController, DataRepository, Context)
export class EditNote {
	constructor(dialogController, dataRepository, context) {
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;
		this.context = context;
		
		this.user = null;
		this.users = null;
	}
	
	activate(note) {
		this.note = note;
		
		return this.context.getUser().then(user => {
			this.user = user;
			/*
			return this.dataRepository.searchUsers({
				companyId: this.user.company.companyId
			}).then(data => this.users = data);
			*/
		});
	}
	
	ok() {
		this.note.updateUser = this.user;
		this.note.updateDate = new Date();
		
		this.dialogController.ok(this.note);
	}
	
	cancel() {
		this.dialogController.cancel();
	}
}