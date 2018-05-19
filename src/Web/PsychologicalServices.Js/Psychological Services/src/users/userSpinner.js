import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';

@inject(DataRepository, Router, Notifier, Scroller)
export class UserSpinner {
	constructor(dataRepository, router, notifier, scroller) {
		this.dataRepository = dataRepository;
		this.router = router;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.selectedUser = null;
		this.selectedDocument = null;
		
		this.userMatcher = (a, b) => a !== null && b !== null && a.userId === b.userId;
		this.documentMatcher = (a, b) => a !== null && b !== null && a.documentId === b.documentId;

		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate() {
		return this.getData();
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.searchUsers({}).then(data => this.users = data),
			this.dataRepository.searchDocuments({}).then(data => this.documents = data)
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
		this.dataRepository.saveUserSpinner(this.selectedUser.userId, this.selectedDocument.documentId)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    
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
