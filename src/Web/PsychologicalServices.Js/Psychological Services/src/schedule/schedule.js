import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {Notifier} from 'services/notifier';
import moment from 'moment';

@inject(DataRepository, Context, Config, Notifier)
export class Schedule {
	constructor(dataRepository, context, config, notifier) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		this.notifier = notifier;
		
		this.users = null;
		
		this.searched = false;
		
		let now = new Date();
		
		this.searchStart = this.weekStart(now);
		this.searchEnd = this.weekEnd(now);
	}
	
	activate() {
		return this.context.getUser().then(user => {
			this.user = user;
	
			return Promise.all([
				this.search()
			]);
		});
	}
	
	search() {
		return this.dataRepository.searchSchedule({
			'startDate': this.searchStart,
			'endDate': this.searchEnd,
			'companyId': this.user.company.companyId
		}).then(data => {
			this.users = data;
			this.searched = true;
		});
	}
	
	sendSchedule(user) {
		this.notifier.info('Sending schedule to ' + user.firstName);
		
		return this.dataRepository.sendSchedule({
			'startDate': this.searchStart,
			'endDate': this.searchEnd,
			'companyId': this.user.company.companyId,
			'psychometristId': user.userId
		}).then(results => {
			
			for (var result of results) {
				if (result.success)
				{
					this.notifier.info('Schedule sent to ' + user.firstName);
				}
				else
				{
					this.notifier.error('Error sending schedule to ' + user.firstName);
				}
			}
		});
	}
	
	weekStart(date) {
		return moment().startOf('week').format();
	}
	
	weekEnd(date) {
		return moment().endOf('week').format();
	}
}