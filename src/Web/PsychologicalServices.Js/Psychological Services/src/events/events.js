import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Context} from 'common/context';

@inject(DataRepository, Config, Context)
export class Events {
	constructor(dataRepository, config, context) {
		this.dataRepository = dataRepository;
		this.config = config;
		this.context = context;
	}
	
	activate() {
		return Promise.all([
			this.context.getUser().then(user => this.searchCompanyId = user.company.companyId).then(() => this.search())
		]);
	}

	search() {
		return this.dataRepository.getEvents({
			'companyId': this.searchCompanyId,
			'description': this.searchDescription,
			'location': this.searchLocation,
			'isExpired': this.searchExpired,
			'isActive': this.searchActive
		}).then(data => this.events = data);
	}
}