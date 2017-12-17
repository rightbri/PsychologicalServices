import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import {DataRepository} from 'services/dataRepository';

@inject(Router, DataRepository, Config, Context, Scroller, Notifier)
export class EditEvent {
	constructor(router, dataRepository, config, context, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.event = null;
		
		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;

		this.editType = id ? 'Edit' : 'Add';
		
		return Promise.all([
			this.context.getUser().then(user => this.user = user)
				.then(() => {
					if (id) {
						return this.dataRepository.getEvent(id).then(data => this.event = data);
					}
					else {
						this.event = { eventId: 0, company: this.user.company, expires: new Date(), isActive: true };
						
						return;
					}
				})
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
		var isNew = this.event.eventId === 0;
		
		this.dataRepository.saveEvent(this.event)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.event = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editEvent',
							{ 'id': this.event.eventId },
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