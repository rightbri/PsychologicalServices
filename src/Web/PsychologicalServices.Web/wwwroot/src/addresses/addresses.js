import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';
import {DataRepository} from 'services/dataRepository';

@inject(Router, DataRepository)
export class Address {
	constructor(router, dataRepository) {
		this.router = router;
		this.dataRepository = dataRepository;
		
		this.addresses = [];
		this.addressTypes = [];
		
		this.searchName = null;
		this.searchStreet = null;
		this.searchCity = null;
		this.searchAddressTypes = [];
		this.searchActive = true;
		
		this.showSearch = false;
	}
	
	activate(params) {
		
		return Promise.all([
			this.dataRepository.getAddressTypes().then(data => this.addressTypes = data),
			this.search()
		]);
	}
	
	search() {
		return this.searchAddresses({
			name: this.searchName,
			street: this.searchStreet,
			city: this.searchCity,
			addressTypeIds: this.searchAddressTypes,
			isActive: this.searchActive
		});
	}

	searchAddresses(criteria) {
		return this.dataRepository.searchAddress(criteria)
			.then(data => {
				this.addresses = data;
				
				this.showSearch = !this.hasAddresses(this.addresses);
			});
	}
	
	add() {
		this.router.navigateToRoute('editAddress', { id: 0 });
	}
	
	edit(id) {
		this.router.navigateToRoute('editAddress', { id: id });
	}
	
	hasAddresses(addresses) {
		return addresses && addresses.length > 0;
	}
}