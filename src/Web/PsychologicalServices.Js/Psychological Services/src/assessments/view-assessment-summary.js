import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {Config} from 'common/config';

@inject(Config)
export class ViewAssessmentSummaryCustomElement {
	@bindable({ defaultBindingMode: bindingMode.oneTime }) model;
	@bindable({ defaultBindingMode: bindingMode.oneTime }) containerId;
	
	constructor(config) {
		this.config = config;
	}
	
	modelChanged(newValue, oldValue) {
		let appointment = newValue;
		
		this.modalId = `assessment-summary-${appointment.appointmentId}`;
		
		let psychiatristAttributes = appointment.assessment.attributes.filter(attr =>
			attr.attribute.attributeType.attributeTypeId === this.config.assessmentSummaryDefaults.attributeTypeIds.psychiatrist &&
			attr.attribute.name.indexOf('Psychiatrist') > -1
		);
		
		this.psychiatrist = psychiatristAttributes.length > 0 ? psychiatristAttributes[0] : { value: null };
		
		let readerAttributes = appointment.attributes.filter(attr =>
			attr.attribute.attributeType.attributeTypeId === this.config.assessmentSummaryDefaults.attributeTypeIds.reader &&
			attr.attribute.name.indexOf('Reader') > -1
		);
		
		this.reader = readerAttributes.length > 0 ? readerAttributes[0] : { value: null };
		
		let translatorAttributes = appointment.attributes.filter(attr =>
			attr.attribute.attributeType.attributeTypeId === this.config.assessmentSummaryDefaults.attributeTypeIds.translator &&
			attr.attribute.name.indexOf('Translator') > -1
		);
		
		this.translator = translatorAttributes.length > 0 ? translatorAttributes[0] : { value: null };
		
		this.colors = appointment.assessment.colors;
		
		if (this.colors.length === 0) {
			this.colors.push({ 'hexCode': '#666666' });
		}
		
		while (this.colors.length < 3) {
			this.colors.push(this.colors[this.colors.length - 1]);
		}

		this.claim = null;
		
		for (let claim of appointment.assessment.claims) {
			this.claim = claim;
			break;
		}
		
		this.issuesInDispute = [];
		
		for (let report of appointment.assessment.reports) {
			for (let issueInDispute of report.issuesInDispute) {
				if (!this.issuesInDispute.some(iid => iid.issueInDisputeId === issueInDispute.issueInDisputeId)) {
					this.issuesInDispute.push(issueInDispute);
				}
			}
		}
	
		this.summary = appointment.assessment.summary ? appointment.assessment.summary.noteText : '';
	}
}
