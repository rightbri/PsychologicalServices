import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {DateService} from 'common/dateService';

@inject(Router, DataRepository, Config, Context, DateService)
export class CalendarNotes {

	constructor(router, dataRepository, config, context, dateService) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
		this.dateService = dateService;
		
		this.searchFromDate = this.dateService.today();
		this.searchToDate = this.dateService.addDays(this.searchFromDate, 1);
		this.fromDate = this.searchFromDate;
		this.toDate = this.searchToDate;
	}

	search() {
		this.dataRepository.getCalendarNotes({
			'fromDate': this.searchFromDate,
			'toDate': this.searchToDate
		})
		.then(calendarNotes => this.calendarNotes = calendarNotes);
	}

	fromDateChanged(e) {
		this.searchFromDate = e.detail.dates[0];
	}
	
	toDateChanged(e) {
		this.searchToDate = e.detail.dates[0];
	}
}