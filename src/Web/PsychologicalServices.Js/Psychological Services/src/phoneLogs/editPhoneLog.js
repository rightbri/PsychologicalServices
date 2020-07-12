import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Notifier} from 'services/notifier';
import {Scroller} from 'services/scroller';
import {Timezone} from 'common/timezone';
import moment from 'moment';
import 'moment-timezone';

@inject(Router, DataRepository, Config, Context, Notifier, Scroller, Timezone)
export class EditPhoneLog {

    constructor(router, dataRepository, config, context, notifier, scroller, timezone) {
        this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.notifier = notifier;
		this.scroller = scroller;
		this.timezone = timezone;
		
        this.saveDisabled = false;
		this.validationErrors = null;
    }
    
    activate(params) {
        var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
        return this.context.getUser()
			.then(user => {
				this.user = user;
				
				if (id) {
                    return this.dataRepository.getPhoneLog(id).then(data => {
						this.phoneLog = data;

						this.phoneLog.updateUser = this.user;

						this.callDate = this.phoneLog.callTime;
						this.callTime = this.timezone.convert(moment.utc(this.phoneLog.callTime), this.config.timezone).format(this.config.shortTimeFormat);
		
						this.scroller.scrollTo(0);
                    });
                }
                else {
                    //new phone log
                    this.phoneLog = {
						isAdd: true,
						callTime: new Date(),
						note: this.newNote(),
						createUser: this.user,
						updateUser: this.user
					};

					this.callDate = this.phoneLog.callTime;
					this.callTime = this.timezone.convert(moment.utc(this.phoneLog.callTime), this.config.timezone).format(this.config.shortTimeFormat);
		
					this.scroller.scrollTo(0);
				}
            });
    }

    save() {
		this.saveDisabled = true;
		
		var isNew = this.phoneLog.phoneLogId === 0;
		
		this.phoneLog.callTime =
			moment.tz(
				moment.utc(this.callDate).format(this.config.isoShortDateFormat) + ' ' + this.callTime,
				this.config.isoShortDateFormat + ' ' + this.config.shortTimeFormat,
				this.config.timezone
			).utc().format();

		this.dataRepository.savePhoneLog(this.phoneLog)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
					
                if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.phoneLog = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editPhoneLog',
							{ 'id': this.phoneLog.phoneLogId },
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

	newNote() {
		return { noteId: 0, noteText: '', createUser: this.user, updateUser: this.user };
	}
}