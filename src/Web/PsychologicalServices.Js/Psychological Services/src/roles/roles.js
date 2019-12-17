import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {inject} from 'aurelia-framework';

@inject(DataRepository, Context)
export class Roles {
	constructor(dataRepository, context) {
		this.dataRepository = dataRepository;
		this.context = context;
		
		this.roles = [];
	}
	
	activate() {
		return this.context.getUser().then(user => {
			return this.getData();
		});
		
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getRoles().then(data => this.roles = data)
		]);
	}
}