import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {EventHelper} from 'services/eventHelper';
import {Config} from '../common/config';

@inject(Element, Config, EventHelper)
export class EditClaimCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, config, eventHelper) {
		this.element = element;
		this.config = config;
		this.eventHelper = eventHelper;
	}
	
	modelChanged(oldValue, newValue) {
		this.backup = getBackup(oldValue);
	}
	
	ok(e) {
		this.backup = getBackup(this.model);
		
		this.eventHelper.fireEvent(this.element, 'edited', { 'claim': this.model });
	}
	
	cancel(e) {
		this.eventHelper.fireEvent(this.element, 'canceled', { 'claim': this.backup });
	}
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}