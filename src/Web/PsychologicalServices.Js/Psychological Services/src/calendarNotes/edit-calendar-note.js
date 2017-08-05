import {bindable, bindingMode, inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';
import {Notifier} from 'services/notifier';
import {EventHelper} from 'services/eventHelper';
import moment from 'moment';

@inject(Element, DataRepository, Config, Context, Notifier, EventHelper)
export class EditCalendarNoteCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, dataRepository, config, context, notifier, eventHelper) {
		this.element = element;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.notifier = notifier;
		this.eventHelper = eventHelper;
		
		this.validationErrors = null;
	}
	
	modelChanged(newValue, oldValue) {
		let show = !!newValue;
		
		this.backup = newValue ? getBackup(newValue.calendarNote) : null;
		
		if (!this.user) {
			this.context.getUser().then(user => this.user = user);
		}
		
		if (show) {
			
		}
	}
	
	save() {
		let now = moment.utc().toDate();
		let isAdd = this.model.calendarNote.isAdd;
		
		if (isAdd) {
			this.model.calendarNote.createUser = this.user;
			this.model.calendarNote.createDate = now;
		}
		
		this.model.calendarNote.updateUser = this.user;
		this.model.calendarNote.updateDate = now;

		this.dataRepository.saveCalendarNote(this.model.calendarNote)
			.then(data => {
				
				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				else if (data.isSaved) {
					
					if (isAdd) {
						delete this.model.calendarNote['isAdd'];
					
						this.eventHelper.fireEvent(this.element, 'addedCalendarNote', { 'calendarNote': data.item });
					}
					
					this.eventHelper.fireEvent(this.element, 'hide', {});
				}
			});
	}
	
	cancel() {
		if (!this.model.calendarNote.isAdd) {
			copyValues(this.backup, this.model.calendarNote);
		}
		
		this.eventHelper.fireEvent(this.element, 'hide', {});
	}
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}

function copyValues(copyFrom, copyTo) {
	for (var prop in copyFrom) {
		if (copyTo.hasOwnProperty(prop)) {
			copyTo[prop] = copyFrom[prop];
		}
	}
}
