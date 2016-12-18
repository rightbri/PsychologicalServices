import {HttpClient as HttpFetch, json} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';

@inject(HttpFetch, 'apiRoot')
export class DataRepository {
	constructor(httpFetch, apiRoot) {
		this.apiRoot = apiRoot;
		this.httpFetch = httpFetch;
	}

	
	getAppointment(id) {
		return this.getSingleBasic(id, 'appointment');
	}
	
	searchAppointments(criteria) {
		return this.searchBasic(criteria, 'appointment');
	}
	
	saveAppointment(appointment) {
		return this.saveBasic(appointment, 'appointment');
	}

	getAppointmentStatuses() {
		return this.getManyBasic('appointmentstatus');
	}
	
	getAssessment(id) {
		return this.getSingleBasic(id, 'assessment');
	}
	
	searchAssessments(criteria) {
		return this.searchBasic(criteria, 'assessment');
	}
	
	saveAssessment(assessment) {
		return this.saveBasic(assessment, 'assessment');
	}

	getAddress(id) {
		return this.getSingleBasic(id, 'address');
	}

	searchAddress(criteria) {
		return this.searchBasic(criteria, 'address');
	}

	saveAddress(address) {
		return this.saveBasic(address, 'address');
	}

	getUser(id) {
		return this.getSingleBasic(id, 'user');
	}

	saveUser(user) {
		return this.saveBasic(user, 'user');
	}

	getPsychometrists(companyId) {
		return this.getManyBasic('user/psychometrists/' + companyId);
	}

	getPsychologists(companyId) {
		return this.getManyBasic('user/psychologists/' + companyId);
	}

	getCompany(id) {
		return this.getSingleBasic(id, 'company');
	}
	
	getCompanies() {
		return this.getManyBasic('company');
	}
	
	saveCompany(assessment) {
		return this.saveBasic(assessment, 'company');
	}

	getSingleBasic(id, type) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(this.apiRoot + 'api/' + type + '/' + id)
				.then(response => response.json())
				.then(data => resolve(data))
				.catch(err => reject(err));
		});
		return promise;
	}

	getManyBasic(type) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(this.apiRoot + 'api/' + type)
				.then(response => response.json())
				.then(data => resolve(data))
				.catch(err => reject(err));
		});
		return promise;
	}

	searchBasic(criteria, type) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(this.apiRoot + 'api/' + type + '/search', {
				method: 'POST',
				body: json(criteria)
			})
			.then(response => response.json())
			.then(data => resolve(data))
			.catch(err => reject(err));
		});
		return promise;
	}

	saveBasic(item, type) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(this.apiRoot + 'api/' + type + '/save', {
				method: 'PUT',
				body: json(item)
			})
			.then(response => response.json())
			.then(data => resolve(data))
			.catch(err => reject(err));
		});
		return promise;
	}

}