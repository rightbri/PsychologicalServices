import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {inject} from 'aurelia-framework';

@inject(DialogController, DataRepository, Config, Context)
export class EditCalendarNote {
	constructor(dialogController, dataRepository, config, context) {
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		
		this.error = null;
		this.validationErrors = null;
	}
	
	activate(calendarNote) {
		this.calendarNote = calendarNote;
	}
	
	ok() {
		this.calendarNote.note.updateUser = this.context.user;
		
		this.dataRepository.saveCalendarNote(this.calendarNote)
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