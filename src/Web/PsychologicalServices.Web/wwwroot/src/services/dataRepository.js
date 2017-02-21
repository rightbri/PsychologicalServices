import {HttpClient as HttpFetch, json} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';

@inject(HttpFetch, 'apiRoot')
export class DataRepository {
	constructor(httpFetch, apiRoot) {
		this.apiRoot = apiRoot;
		this.httpFetch = httpFetch;
		this.cache = {};
		
		this.httpFetch.configure(config => {
			config
				.withBaseUrl(this.apiRoot + 'api/')
				.withDefaults({
					credentials: 'include',
					headers: {
						'Accept': 'application/json',
						'Authorization': 'Token ' + window.sessionStorage.firebaseAuthToken,
						'X-Requested-With': 'Fetch'
					}
				})
				.withInterceptor({
					request(request) {
						console.log(`Requesting ${request.method} ${request.url}`);
						
						/*
						if (window.sessionStorage.firebaseAuthToken) {
							request.headers.Authorization = 'Token ' + window.sessionStorage.firebaseAuthToken;
						}
						*/
						return request;
					},
					response(response) {
						console.log(`Received ${response.status} ${response.url}`);

						if (response.status === 401) {
							
						}
						return response;
					}
				});
		});
	}

	
	getAppointment(id) {
		return this.getSingleBasic(id, 'appointment');
	}
	
	getNewAppointment(companyId, assessmentId) {
		if (assessmentId) {
			return this.getBasic(`appointment/company/${companyId}/assessment/${assessmentId}`);
		}
		else {
			return this.getBasic(`appointment/company/${companyId}`);
		}
	}
	
	searchAppointments(criteria) {
		return this.searchBasic(criteria, 'appointment');
	}
	
	saveAppointment(appointment) {
		return this.saveBasic(appointment, 'appointment');
	}

	getAppointmentStatuses() {
		return this.getManyBasic('appointmentstatus', true);
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
	
	getAssessmentTypes() {
		return this.getManyBasic('assessmenttype', true);
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

	getAddressTypes() {
		return this.getManyBasic('addresstype', true);
	}
	
	getGenders() {
		return this.getManyBasic('gender', true);
	}
	
	getClaimants(lastName) {
		return this.getManyBasic('claimant/search/' + lastName);
	}
	
	saveClaimant(claimant) {
		return this.saveBasic(claimant, 'claimant');
	}
	
	saveClaim(claim) {
		return this.saveBasic(claim, 'claim');
	}
	
	getIssuesInDispute() {
		return this.getManyBasic('issueindispute', true);
	}
	
	getReferralTypeIssuesInDispute(referralTypeId) {
		return this.getManyBasic('issueindispute/referralType/' + referralTypeId, true);
	}
	
	getReferralSources(criteria) {
		return this.searchBasic(criteria, 'referralsource');
	}
	
	getReferralSourceTypes() {
		return this.getManyBasic('referralsourcetype', true);
	}
	
	getReferralTypes() {
		return this.getManyBasic('referraltype', true);
	}
	
	getReportStatuses() {
		return this.getManyBasic('reportstatus', true);
	}
	
	getReportTypes() {
		return this.getManyBasic('reporttype', true);
	}
	
	getUserByUsername(username) {
		return this.postBasic('user/byUsername', username);
	}
	
	getUser(id) {
		return this.getSingleBasic(id, 'user');
	}

	saveUser(user) {
		return this.saveBasic(user, 'user');
	}

	getPsychometrists(companyId) {
		return this.getManyBasic('user/psychometrists/' + companyId, true);
	}

	getPsychologists(companyId) {
		return this.getManyBasic('user/psychologists/' + companyId, true);
	}

	getDocListWriters(companyId) {
		return this.getManyBasic('user/doclistwriters/' + companyId, true);
	}
	
	getNotesWriters(companyId) {
		return this.getManyBasic('user/noteswriters/' + companyId, true);
	}
	
	getCompany(id) {
		return this.getSingleBasic(id, 'company');
	}
	
	getCompanies() {
		return this.getManyBasic('company', true);
	}
	
	saveCompany(assessment) {
		return this.saveBasic(assessment, 'company');
	}
	
	getCalendarNote(id) {
		return this.getSingleBasic(id, 'calendarNote');
	}
	
	getCalendarNotes(fromDate, toDate) {
		return this.getManyBasic('calendarNote?fromDate=' + fromDate + '&toDate=' + toDate);
	}
	
	saveCalendarNote(calendarNote) {
		return this.saveBasic(calendarNote, 'calendarNote');
	}
	
	getTaskStatuses() {
		return this.getManyBasic('taskStatus', true);
	}

	getBasic(route) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(this.apiRoot + 'api/' + route)
				.then(response => response.json())
				.then(data => resolve(data))
				.catch(err => reject(err));
		});
		return promise;
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

	getManyBasic(type, cache) {
		var promise = new Promise((resolve, reject) => {
			if (cache && this.cache[type]) {
				resolve(this.cache[type]);
			}
			else {
				this.httpFetch.fetch(type)
					.then(response => response.json())
					.then(data => {
						this.cache[type] = data;
						resolve(data);
					})
					.catch(err => reject(err));
			}
		});
		return promise;
	}

	searchBasic(criteria, type) {
		var promise = this.postBasic(type + '/search', criteria, 'POST');
		/*
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(type + '/search', {
				method: 'POST',
				body: json(criteria)
			})
			.then(response => response.json())
			.then(data => resolve(data))
			.catch(err => reject(err));
		});
		*/
		return promise;
	}

	postBasic(url, data, method) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(url, {
				method: method || 'POST',
				body: json(data || {})
			})
			.then(response => response.json())
			.then(data => resolve(data))
			.catch(err => reject(err));
		});
		return promise;
	}
	
	saveBasic(item, type) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(type + '/save', {
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