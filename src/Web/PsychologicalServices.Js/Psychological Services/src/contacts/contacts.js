import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {inject} from 'aurelia-framework';

@inject(DataRepository, Context, Config)
export class Contacts {
	constructor(dataRepository, context, config) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		
		this.searchFirstName = null;
		this.searchLastName = null;
		this.searchContactTypeId = null;
		this.searchEmployerId = null;
		this.searchIsActive = null;
		
		this.contactTypes = [];
		this.employers = [];
		this.contacts = [];
	}
	
	activate() {
		return this.context.getUser().then(user => {
			
			return this.getData();
		});
		
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getContactTypes().then(data => this.contactTypes = data),
			this.dataRepository.searchEmployers({}).then(data => this.employers = data),
			this.search()
		]);
	}
	
	search() {
		return this.dataRepository.searchContacts({
			firstName: this.searchFirstName,
			lastName: this.searchLastName,
			contactTypeId: this.searchContactTypeId,
			employerId: this.searchEmployerId,
			isActive: this.searchIsActive
		}).then(data => this.contacts = data);
	}
}