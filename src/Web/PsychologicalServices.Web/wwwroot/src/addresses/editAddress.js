import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';

@inject(Router, DataRepository)
export class EditAddress {
	constructor(router, dataRepository) {
		this.router = router;
		this.dataRepository = dataRepository;
		
		this.address = null;
		this.addressTypes = null;
	}
	
	activate(params) {
		var id = params.id;

		return Promise.all([
			this.dataRepository.getAddressTypes().then(data => this.addressTypes = data),
			this.dataRepository.getAddress(id).then(data => this.address = data)
		]);
	}
	
	save() {
        this.dataRepository.saveAddress(this.address)
            .then(data => {

                if (data.isError) {
                    alert(data.errorDetails);
                }

                if (data.isSaved) {
                    this.address = data.item;
                }
            });
    }
	
	back() {
		this.router.navigateBack();
	}
}