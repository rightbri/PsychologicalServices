import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {Config} from 'common/config';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import {DataRepository} from 'services/dataRepository';

@inject(Router, DataRepository, Config, Scroller, Notifier)
export class EditCity {
	constructor(router, dataRepository, config, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.city = null;
		
		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;

		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getCity(id).then(data => this.city = data);
		}
		else {
			this.editType = 'Add';
			
			this.city = { id: 0, province: this.config.addressDefaults.province, country: this.config.addressDefaults.country, isActive: true };
			
			return;
		}
	}
	
	save() {
		this.saveDisabled = true;
		
		var isNew = this.city.cityId === 0;
		
		this.dataRepository.saveCity(this.city)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.city = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editCity',
							{ 'id': this.city.cityId },
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