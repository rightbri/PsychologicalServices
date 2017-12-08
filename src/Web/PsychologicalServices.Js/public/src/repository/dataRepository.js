import {inject} from 'aurelia-framework';
import {HttpClient as HttpFetch, json} from 'aurelia-fetch-client';

@inject(HttpFetch, 'apiRoot')
export class DataRepository {
	constructor(httpFetch, apiRoot) {
		this.apiRoot = apiRoot;
		this.httpFetch = httpFetch;
		this.cache = {};
		
		var self = this;
		
		this.httpFetch.configure(config => {
			config
				.withBaseUrl(this.apiRoot + 'api/')
				.withDefaults({
					headers: {
						'Accept': 'application/json',
						'X-Requested-With': 'Fetch'
					}
				});
		});
	}
		
	getEvents(criteria) {
		return this.searchBasic(criteria, 'event');
	}
	
	searchBasic(criteria, type) {
		var promise = this.postBasic(type + '/search', criteria, 'POST');
		return promise;
	}

	postBasic(url, data, method) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(url, {
				method: method || 'POST',
				body: json(data || {})
			})
			.then(response => {
				if (response.ok) {
					return response.json();
				}
				throw new Error({ status: response.status, statusText: response.statusText });
			})
			.then(data => resolve(data))
			.catch(err => reject(err));
		});
		return promise;
	}
	
}
