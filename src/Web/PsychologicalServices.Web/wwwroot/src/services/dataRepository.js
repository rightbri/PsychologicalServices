import {HttpClient as HttpFetch, json} from 'aurelia-fetch-client';
import {AuthContext} from 'common/authContext';
import {Notifier} from 'services/notifier';
import {inject} from 'aurelia-framework';

@inject(HttpFetch, AuthContext, Notifier, 'apiRoot')
export class DataRepository {
	constructor(httpFetch, authContext, notifier, apiRoot) {
		this.apiRoot = apiRoot;
		this.httpFetch = httpFetch;
		this.authContext = authContext;
		this.notifier = notifier;
		this.cache = {};
		
		var self = this;
		
		var defaultHeaders = {
			'Accept': 'application/json',
			'X-Requested-With': 'Fetch'
		};
		
		this.httpFetch.configure(config => {
			config
				.withBaseUrl(this.apiRoot + 'api/')
				.withDefaults({
					credentials: 'include',
					headers: {
						'Accept': 'application/json',
						'X-Requested-With': 'Fetch'
					}
				})
				.withInterceptor({
					request(request) {
						if (!request.headers.has('Authorization')) {
							if (self.authContext.authToken) {
								request.headers.append('Authorization','Token ' + self.authContext.authToken);
							}
						}
						
						return request;
					},
					response(response) {
						if (!response.ok) {
							self.notifier.error('Error: ' + response.status + ' - ' + response.statusText);
							
							if (response.status === 403) {
								self.authContext.logout().then(() => self.authContext.login());
							}
						}
						return response;
					}
				});
		});
	}

	getInvoice(id) {
		return this.getSingleBasic(id, 'invoice');
	}
	
	getInvoices(criteria) {
		return this.searchBasic(criteria, 'invoice');
	}
	
	saveInvoice(invoice) {
		return this.saveBasic(invoice, 'invoice');
	}
	
	refreshInvoiceLines(appointment) {
		return this.postBasic('invoice/refresh', appointment);
	}
	
	getInvoiceStatuses() {
		return this.getManyBasic('invoicestatus', true);
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
	
	getCities() {
		return this.getManyBasic('city', true);
	}
	
	searchAttributes(criteria) {
		return this.searchBasic(criteria, 'attribute');
	}
	
	saveAttribute(attribute) {
		return this.saveBasic(attribute, 'attribute');
	}
	
	getAttributeTypes() {
		return this.getManyBasic('attributetype', true);
	}
	
	saveAttributeType(attributeType) {
		return this.saveBasic(attributeType, 'attributetype');
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
	
	getReferralSource(id) {
		return this.getSingleBasic(id, 'referralSource');
	}
	
	saveReferralSource(referralSource) {
		return this.saveBasic(referralSource, 'referralSource');
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
	
	getColor(id) {
		return this.getSingleBasic(id, 'color');
	}
	
	getColors() {
		return this.getManyBasic('color', true);
	}
	
	saveColor(color) {
		return this.saveBasic(color, 'color');
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
	
	searchUsers(criteria) {
		return this.searchBasic(criteria, 'user');
	}
	
	getRoles() {
		return this.getManyBasic('role', true);
	}
	
	getRights() {
		return this.getManyBasic('right', true);
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
	
	getInvoiceDocument(id) {
		var promise = new Promise((resolve, reject) => {
			
			this.httpFetch.fetch(this.apiRoot + 'api/invoicedocument/' + id)
				.then(response => {
					if (response.ok) {
						
						var defaultFileName = "default.pdf";
					
						var disposition = response.headers.has('content-disposition')
							? response.headers.get('content-disposition')
							: response.headers.get('Content-Disposition');
							
						if (disposition) {
							var match = disposition.match(/.*filename=\"?([^;\"]+)\"?.*/);
						
							if (match[1]) {
								defaultFileName = match[1];
							}
						}
						
						defaultFileName = defaultFileName.replace(/[<>:"\/\\|?*]+/g, '_');
						
						return response.blob()
							.then(blob => {
								if (navigator.msSaveBlob) {
									return navigator.msSaveBlob(blob, defaultFileName);
								}
								
								var blobUrl = window.URL.createObjectURL(blob);
								var anchor = document.createElement('a');
								anchor.download = defaultFileName;
								anchor.href = blobUrl;
								document.body.appendChild(anchor);
								anchor.click();
								document.body.removeChild(anchor);
							});
					}
					throw new Error({ status: response.status, statusText: response.statusText });
				})
				.catch(err => reject(err));
		});
		
		return promise;
	}
	
	getBasic(route) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(this.apiRoot + 'api/' + route)
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
	
	getSingleBasic(id, type) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(this.apiRoot + 'api/' + type + '/' + id)
				.then(response => {
					if (response.ok) {
						return response.json();
					}
					throw new Error({ status: response.status, statusText: response.statusText });
				})
				.then(data => resolve(data))
				.catch(err => {
					reject(err);
				});
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
					.then(response => {
						if (response.ok) {
							return response.json();
						}
						throw new Error({ status: response.status, statusText: response.statusText });
					})
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
	
	saveBasic(item, type) {
		var promise = new Promise((resolve, reject) => {
			this.httpFetch.fetch(type + '/save', {
				method: 'PUT',
				body: json(item)
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
