import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';

@inject(DataRepository, Config)
export class Events {
	constructor(dataRepository, config) {
		this.dataRepository = dataRepository;
		this.config = config;
	}
	
	activate() {
		return Promise.all([
			this.search()
		]);
	}

	search() {
		return this.dataRepository.getEvents({
			'description': this.searchDescription,
			'location': this.searchLocation,
			'isExpired': this.searchExpired,
			'isActive': this.searchActive
		}).then(data => this.events = data);
	}
}