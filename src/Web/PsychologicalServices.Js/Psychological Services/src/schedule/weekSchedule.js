import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {Notifier} from 'services/notifier';

@inject(DataRepository, Context, Config, Notifier)
export class WeekSchedule {
	constructor(dataRepository, context, config, notifier) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		this.notifier = notifier;
		
		this.selectedDate = new Date();
		this.weekDate = this.selectedDate;
	}
	
	activate() {
		return this.context.getUser().then(user => {
			this.user = user;
		});
	}
	
	getWeekScheduleDocument() {
		this.notifier.info('Downloading schedule');
		
		this.dataRepository.getWeekScheduleDocument({
			'companyId': this.user.company.companyId,
			'weekDate': this.weekDate
		})
		.then(() => this.notifier.info('Schedule downloaded'))
		.catch(err => {
			this.notifier.error(err);
		});
	}
	
	dateChanged(e) {
		this.weekDate = e.detail.dates[0];
	}
}
