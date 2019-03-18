import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {Notifier} from 'services/notifier';
import moment from 'moment';

@inject(DataRepository, Context, Config, Notifier)
export class PsychometristSchedule {
	constructor(dataRepository, context, config, notifier) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		this.notifier = notifier;
		
		this.scheduleUsers = null;
		
		this.selectedUser = null;
		this.searched = false;
		
		this.recipients = [];
		this.cc = [];
		this.bcc = [];
		
		let now = new Date();
		
		this.searchStart = this.weekStart(now);
		this.searchEnd = this.weekEnd(now);
		
		this.userMatcher = (a, b) => a && b && a.userId === b.userId;
	}
	
	activate() {
		return this.context.getUser().then(user => {
			this.user = user;
	
			return Promise.all([
				this.search(),
				this.dataRepository.searchUsers({
					'isActive': true,
					'rightId': this.config.rights.ReceiveSchedule
				}).then(data => this.users = data)
			]);
		});
	}
	
	search() {
		return this.dataRepository.searchSchedule({
			'startDate': this.searchStart,
			'endDate': this.searchEnd,
			'companyId': this.user.company.companyId
		}).then(data => {
			this.scheduleUsers = data;
			this.searched = true;
		});
	}
	
	selectUser(user) {
		this.selectedUser = user;
		this.recipients = [user];
		this.cc = [];
		this.bcc = [];
	}
	
	sendSchedule() {
		let user = this.selectedUser;
		
		this.notifier.info('Sending schedule to ' + user.firstName);
		
		return this.dataRepository.sendSchedule({
			recipients: getUsersEmailList(this.recipients),
			courtesyCopy: getUsersEmailList(this.cc),
			blindCourtesyCopy: getUsersEmailList(this.bcc),
			criteria: {
				'startDate': this.searchStart,
				'endDate': this.searchEnd,
				'companyId': this.user.company.companyId,
				'psychometristId': user.userId
			}
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

function getUsersEmailList(users) {
	return users.map(user => user.email);
}