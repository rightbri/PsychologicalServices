import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {Config} from 'common/config';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import {DataRepository} from 'services/dataRepository';

@inject(Router, DataRepository, Config, Scroller, Notifier)
export class EditAddress {
	constructor(router, dataRepository, config, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.address = null;
		this.addressTypes = null;
		
		this.error = null;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;

		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getAddress(id).then(data => {
				this.address = data;
				
				return this.getData();
			});
		}
		else {
			this.editType = 'Add';
			
			this.address = { id: 0, province: this.config.addressDefaults.province, country: this.config.addressDefaults.country };
			
			return this.getData();
		}
		return Promise.all([
			this.dataRepository.getAddress(id).then(data => this.address = data)
		]);
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getAddressTypes().then(data => this.addressTypes = data)
		]);
	}
	
	save() {
		var isNew = this.address.addressId === 0;
		
		this.dataRepository.saveAddress(this.address)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.address = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editAddress',
							{ 'id': this.address.addressId },
							{ 'trigger': false, replace: true }
						);
						
						this.editType = 'Edit';
					}
					
					this.notifier.info('Saved');
                }
				
				if (data.isError) {
					this.notifier.error(data.errorDetails);
				}
            });
    }
	
	back() {
		this.router.navigateBack();
	}
}