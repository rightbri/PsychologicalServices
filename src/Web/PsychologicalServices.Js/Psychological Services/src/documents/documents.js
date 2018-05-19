import {inject} from 'aurelia-framework';
import {DataRepository} from '../services/dataRepository';

@inject(DataRepository)
export class Documents {
	constructor(dataRepository) {
		this.dataRepository = dataRepository;
		
		this.searchName = null;
	}
	
	activate() {
		/*
		return Promise.all([
			this.search()
		]);
		*/
	}
	
	search() {
		return this.searchDocuments({
			name: this.searchName
		});
	}

	
	dataUrlFromData(data) {
		return 'data:image/jpeg;base64,' + data;
	}

	searchDocuments(criteria) {
		return this.dataRepository.searchDocuments(criteria)
			.then(data => {
				this.documents = data.map((document) => {
					document.dataUrl = this.dataUrlFromData(document.data);
					return document;
				});

				this.noDocuments = data.length === 0;
			});
	}
}