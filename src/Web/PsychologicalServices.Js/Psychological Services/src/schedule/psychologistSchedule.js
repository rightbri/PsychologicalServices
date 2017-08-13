import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {DateService} from 'common/dateService';
import {Notifier} from 'services/notifier';

@inject(DataRepository, Context, Config, DateService, Notifier)
export class PsychologistSchedule {
	constructor(dataRepository, context, config, dateService, notifier) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		this.dateService = dateService;
		this.notifier = notifier;
		
		this.psychologists = [];
		
		this.searchFromDate = new Date();
		this.searchToDate = this.dateService.addDays(this.searchFromDate, 7);
		
		this.fromDate = this.searchFromDate;
		this.toDate = this.searchToDate;
	}
	
	activate() {
		return this.context.getUser().then(user => {
			this.user = user;
			
			return Promise.all([
				this.dataRepository.getPsychologists(this.user.company.companyId).then(psychologists => {
					this.psychologists = psychologists;
				})
			]);
		});
	}
	
	getWeekScheduleDocument() {
		this.notifier.info('Downloading schedule');
		
		let from = new Date(this.fromDate);
		let to = new Date(this.toDate);
		
		let filename = this.user.company.name.replace(/[^A-Za-z0-9]/g, '') + '-Schedule-' + from.getDate() + '-' + (from.getMonth() + 1) + '-' + from.getFullYear() + '-to-' + to.getDate() + '-' + (to.getMonth() + 1) + '-' + to.getFullYear() + '.pdf';

		this.dataRepository.getWeekScheduleDocument({
			'psychologistId': this.psychologists[0].userId,
			'fromDate': this.fromDate,
			'toDate': this.toDate,
			'defaultFilename': filename
		})
		.then(() => this.notifier.info('Schedule downloaded'))
		.catch(err => {
			this.notifier.error(err);
		});
	}
}
