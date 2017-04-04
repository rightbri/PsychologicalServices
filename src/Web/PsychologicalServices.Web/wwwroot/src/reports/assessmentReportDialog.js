import {DialogController} from 'aurelia-dialog';
import {DataRepository} from 'services/dataRepository';
import {inject} from 'aurelia-framework';

@inject(DialogController, DataRepository)
export class AssessmentReportDialog {
	constructor(dialogController, dataRepository) {
		this.dialogController = dialogController;
		this.dataRepository = dataRepository;
		
		this.reportTypes = null;
		this.issuesInDispute = null;
		
		this.reportTypeMatcher = (a, b) => a && b && a.reportTypeId === b.reportTypeId;
		this.issueInDisputeMatcher = (a, b) => a && b && a.issueInDisputeId === b.issueInDisputeId;
	}
	
	activate(model) {
		this.report = model.report;
		
		this.issuesInDispute = model.issuesInDispute;
		
		return Promise.all([
			this.dataRepository.getReportTypes().then(data => this.reportTypes = data)
		]);
	}
	
	ok() {
		this.dialogController.ok(this.report);
	}
	
	cancel() {
		this.dialogController.cancel();
	}
}