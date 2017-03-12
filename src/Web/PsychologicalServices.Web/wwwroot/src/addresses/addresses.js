import {inject} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';

@inject(DataRepository)
export class Address {
	constructor(dataRepository) {
		this.dataRepository = dataRepository;
		
		this.addresses = [];
		this.addressTypes = [];
		
		this.searchName = null;
		this.searchStreet = null;
		this.searchCity = null;
		this.searchAddressTypes = [];
		this.searchActive = true;
	}
	
	activate() {
		
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
			.then(data => this.addresses = data);
	}
}