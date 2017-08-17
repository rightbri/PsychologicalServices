import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Context} from 'common/context';
import {Config} from 'common/config';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';

@inject(DataRepository, Context, Config, Router, Notifier, Scroller)
export class EditContact {
	constructor(dataRepository, context, config, router, notifier, scroller) {
		this.dataRepository = dataRepository;
		this.context = context;
		this.config = config;
		this.router = router;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.contact = null;
		this.contactTypes = [];
		this.employers = [];
		this.addresses = [];
		
		this.contactTypeMatcher = (a, b) => a !== null && b !== null && a.contactTypeId === b.contactTypeId;
		this.employerMatcher = (a, b) => a !== null && b !== null && a.employerId === b.employerId;
		this.addressMatcher = (a, b) => a !== null && b !== null && a.addressId === b.addressId;
		
		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getContact(id)
				.then(contact => {
					this.contact = contact;
					
					return this.getData();
				});
		}
		else {
			this.contact = {
				contactId: 0,
				isActive: true
			};
			
			return this.context.getUser().then(user => {
				return this.getData();
			});
		}
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.searchAddress({
				'addressTypeIds': [this.config.addressDefaults.contactAddressTypeId]
			}).then(data => this.addresses = data),
			this.dataRepository.getContactTypes().then(data => this.contactTypes = data),
			this.dataRepository.searchEmployers({}).then(data => this.employers = data)
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
		var isNew = this.contact.contactId === 0;

		this.dataRepository.saveContact(this.contact)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.contact = data.item;

					if (isNew) {
						this.router.navigateToRoute(
							'editContact',
							{ 'id': this.contact.contactId },
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
