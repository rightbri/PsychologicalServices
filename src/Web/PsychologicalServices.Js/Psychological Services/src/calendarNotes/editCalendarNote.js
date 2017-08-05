import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import {DateService} from 'common/dateService';

@inject(Router, DataRepository, Config, Context, DateService, Scroller, Notifier)
export class EditCalendarNote {
	
	constructor(router, dataRepository, config, context, dateService, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.dateService = dateService;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		return this.context.getUser()
			.then(user => {
				this.user = user;
				
				if (id) {
					return this.dataRepository.getCalendarNote(id)
						.then(calendarNote => {
							this.calendarNote = calendarNote;
						});
				}
				else {
					let today = this.dateService.today();
					
					this.calendarNote = {
						calendarNoteId: 0,
						fromDate: today,
						toDate: this.dateService.addDays(today, 1),
						note: {
							noteText: 'hello world!'
						},
						isActive: true
					};
				}
			});
	}
	
	save() {
		this.saveDisabled = true;
		
		let now = this.dateService.now();
		
		var isNew = this.calendarNote.calendarNoteId === 0;
		
		if (isNew) {
			this.calendarNote.note.createUser = this.user;
			this.calendarNote.note.createDate = now;
		}
		
		this.calendarNote.note.updateUser = this.user;
		this.calendarNote.note.updateDate = now;

		this.dataRepository.saveCalendarNote(this.calendarNote)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.referralSource = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editCalendarNote',
							{ 'id': this.calendarNote.calendarNoteId },
							{ 'trigger': false, replace: true }
						);
						
						this.editType = 'Edit';
					}
					
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				
				this.saveDisabled = false;
            })
			.catch(err => {
				this.saveDisabled = false;
			});
	}
	
	back() {
		this.router.navigateBack();
	}
}
