import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Notifier} from 'services/notifier';

@inject(DataRepository, Config, Notifier)
export class CalendarNotes {
	
	constructor(dataRepository, config, notifier) {
		this.dataRepository = dataRepository;
		this.config = config;
		this.notifier = notifier;
	}

	search() {
		this.dataRepository.getCalendarNotes({
			'fromDate': this.fromDate,
			'toDate': this.toDate
		})
		.then(calendarNotes => this.calendarNotes = calendarNotes);
	}
	
	deleteCalendarNote(calendarNote) {
		this.notifier.info('Deleting calendar note');
		
		this.dataRepository.deleteCalendarNote(calendarNote.calendarNoteId)
			.then(result => {
				if (result.isDeleted) {
					
					this.calendarNotes.splice(this.calendarNotes.indexOf(calendarNote), 1);
					
					this.notifier.info('Calendar note deleted');
				}
				else if (result.isError) {
					this.notifier.error(result.errorDetails);
				}
			});
	}
}