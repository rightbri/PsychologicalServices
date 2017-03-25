import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {inject} from 'aurelia-framework';

@inject(DataRepository, Context, Config)
export class Users {
	constructor(dataRepository, context, config) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		
		this.searchFirstName = null;
		this.searchLastName = null;
		this.searchEmail = null;
		this.searchCompanyId = null;
		this.searchRoleId = null;
		this.searchRightId = null;
		this.searchIsActive = null;
		this.searchAvailableDate = null;
		
		this.roles = null;
		//this.rights = null;
		this.users = null;
		
	}
	
	activate() {
		return this.context.getUser().then(user => {
			this.searchCompanyId = user.company.companyId;
			
			return this.getData();
		});
		
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getRoles().then(data => this.roles = data),
			//this.dataRepository.getRights().then(data => this.rights = data),
			this.search()
		]);
	}
	
	search() {
		return this.dataRepository.searchUsers({
			firstName: this.searchFirstName,
			lastName: this.searchLastName,
			email: this.searchEmail,
			companyId: this.searchCompanyId,
			roleId: this.searchRoleId,
			rightId: this.searchRightId,
			isActive: this.searchIsActive,
			availableDate: this.searchAvailableDate
		}).then(data => this.users = data);
	}
}