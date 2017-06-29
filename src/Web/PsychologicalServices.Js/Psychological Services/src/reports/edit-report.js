import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {EventHelper} from 'services/eventHelper';

@inject(Element, EventHelper)
export class EditReportCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, eventHelper) {
		this.element = element;
		this.eventHelper = eventHelper;
		
		this.reportTypes = null;
		this.issuesInDispute = null;
		
		this.reportTypeMatcher = (a, b) => a && b && a.reportTypeId === b.reportTypeId;
		this.issueInDisputeMatcher = (a, b) => a && b && a.issueInDisputeId === b.issueInDisputeId;
	}

	modelChanged(oldValue, newValue) {
		this.backup = getBackup(oldValue.report);
		
		this.issuesInDispute = oldValue.issuesInDispute;
		
		this.reportTypes = oldValue.reportTypes;
	}
	
	ok(e) {
		this.backup = getBackup(this.model.report);
		
		this.eventHelper.fireEvent(this.element, 'edited', { 'report': this.model.report });
	}
	
	cancel(e) {
		this.eventHelper.fireEvent(this.element, 'canceled', { 'report': this.backup });
	}
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}