import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';

@inject(DataRepository, Context, Router, Notifier, Scroller)
export class EditRole {
	constructor(dataRepository, context, router, notifier, scroller) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.router = router;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.user = null;

		this.editRole = null;
		this.rights = [];

		this.rightMatcher = (a, b) => a !== null && b !== null && a.rightId === b.rightId;

		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		return this.context.getUser().then(user => {

			this.user = user;

			if (id) {
				return this.dataRepository.getRole(id)
					.then(data => {
						this.editRole = data;
						
						return this.getData();
					});
			}
			else {
				this.editRole = {
					roleId: 0,
					name: "",
					description: "",
					isActive: true
				};

				return this.getData();
			}
		});
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getRights().then(data => this.rights = data)
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
		var isNew = this.editRole.roleId === 0;

		this.dataRepository.saveRole(this.editRole)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.editRole = data.item;

					if (isNew) {
						this.router.navigateToRoute(
							'editRole',
							{ 'id': this.editRole.roleId },
							{ 'trigger': false, replace: true }
						);
						
						this.editType = 'Edit';
					}
					
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
				
				this.saveDisabled = false;
            })
			.catch(err => {
				this.saveDisabled = false;
			});
	}
	
	back() {
		this.router.navigateBack();
	}
}
