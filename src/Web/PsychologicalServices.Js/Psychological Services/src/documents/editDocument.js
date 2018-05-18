import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {Config} from 'common/config';
import {Scroller} from 'services/scroller';
import {Notifier} from 'services/notifier';
import {DataRepository} from 'services/dataRepository';

@inject(Router, DataRepository, Config, Scroller, Notifier)
export class EditDocument {
	constructor(router, dataRepository, config, scroller, notifier) {
		this.router = router;
		this.dataRepository = dataRepository;
		this.config = config;
		this.scroller = scroller;
		this.notifier = notifier;
		
		this.document = null;
		
		this.saveDisabled = false;
		this.validationErrors = null;
	}
	
	activate(params) {
		var id = params.id;

		this.editType = id ? 'Edit' : 'Add';
		
		if (id) {
			return this.dataRepository.getDocument(id).then(data => {
				this.document = data;

				this.document.data = 'data:image/jpeg;base64,' + this.document.data;
			});
		}
		else {
			this.editType = 'Add';
			
			this.document = { documentId: 0, name: '' };
		}
	}

	fileChanged(e) {
		let files = e.target['files'];
		
		let hasFile = files && files.length > 0;

		if (hasFile) {
			let reader = new FileReader();

			reader.addEventListener("load", () => {
				let result = reader.result;

				let data = result.substring(result.indexOf(",") + 1);//after "data:image/jpeg;base64,"

				this.document.data = data;

				this.document.originalName = files[0].name;
				
			}, false);
			
			reader.readAsDataURL(files[0]);
		}
	}
	
	save() {
		this.saveDisabled = true;
		
		var isNew = this.document.documentId === 0;
		
		this.dataRepository.saveDocument(this.document)
            .then(data => {

				this.validationErrors = (data.validationResult && data.validationResult.validationErrors && data.validationResult.validationErrors.length > 0)
					? data.validationResult.validationErrors
					: null;
				
				if (this.validationErrors) {
					this.scroller.scrollTo(0);
				}
				
                if (data.isSaved) {
                    this.document = data.item;
					
					if (isNew) {
						this.router.navigateToRoute(
							'editDocument',
							{ 'id': this.document.documentId },
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