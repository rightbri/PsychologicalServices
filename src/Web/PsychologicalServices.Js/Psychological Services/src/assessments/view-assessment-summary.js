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
	
	modelChanged(oldValue, newValue) {
		let appointment = oldValue;
		
		this.modalId = `assessment-summary-${appointment.appointmentId}`;
		
		this.psychiatrist = appointment.assessment.attributes.some(attr =>
			attr.attributeType.attributeTypeId === this.config.assessmentSummaryDefaults.attributeTypeIds.psychiatrist &&
			attr.name.indexOf('Psychiatrist') > -1
		);
		
		this.reader = appointment.attributes.some(attr =>
			attr.attributeType.attributeTypeId === this.config.assessmentSummaryDefaults.attributeTypeIds.reader &&
			attr.name.indexOf('Reader') > -1
		);
		
		this.translator = appointment.attributes.some(attr =>
			attr.attributeType.attributeTypeId === this.config.assessmentSummaryDefaults.attributeTypeIds.translator &&
			attr.name.indexOf('Translator') > -1
		);
		
		this.colors = appointment.assessment.colors;
		
		if (this.colors.length === 0) {
			this.colors.push({ 'hexCode': '#666666'});
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
