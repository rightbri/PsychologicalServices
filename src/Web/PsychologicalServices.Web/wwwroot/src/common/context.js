import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DataRepository)
export class Context {
	constructor(dataRepository) {
		this.dataRepository = dataRepository;
		this.username = null;
	}
	
	getUser() {
		var promise = new Promise((resolve, reject) => {
			if (this.user) {
				resolve(this.user);
			}
			else {
				this.dataRepository.getUserByUsername(this.username)
					.then(data => {
						this.user = data;
						resolve(data);
					})
					.catch(err => reject(err));
			}
		});
		return promise;
	}
}