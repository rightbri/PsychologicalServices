import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import {inject} from 'aurelia-framework';

@inject(Router, DataRepository, Config, Scroller, Notifier)
export class EditEmployer {
	constructor(router, dataRepository, config, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.employer = null;
		
		this.employerTypes = [];
		
		this.employerTypeMatcher = (a, b) => a !== null && b !== null && a.employerTypeId === b.employerTypeId;
		
		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;
		
		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getEmployer(id)
				.then(employer => {
					this.employer = employer;
					
					return this.getData();
				});
		}
		else {
			this.employer = {
				employerId: 0,
				name: '',
				isActive: true
			};
			
			return this.getData();
		}
	}
	
	getData() {
		return Promise.all([
			this.dataRepository.getEmployerTypes().then(data => this.employerTypes = data)
		]);
	}
	
	save() {
		this.saveDisabled = true;
		
		var isNew = this.employer.employerId === 0;
		
		this.dataRepository.saveEmployer(this.employer)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.employer = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editEmployer',
							{ 'id': this.employer.employerId },
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
