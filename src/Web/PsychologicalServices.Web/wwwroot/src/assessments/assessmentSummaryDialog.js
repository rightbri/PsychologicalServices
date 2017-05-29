import {DialogController} from 'aurelia-dialog';
import {Config} from 'common/config';
import {inject} from 'aurelia-framework';

@inject(DialogController, Config)
export class AssessmentSummaryDialog {
	constructor(dialogController, config) {
		this.dialogController = dialogController;
		this.config = config;
	}
	
	activate(appointment) {
		
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
	
		this.summary = appointment.assessment.summary.noteText;
	}
	
	cancel() {
		this.dialogController.cancel();
	}
}