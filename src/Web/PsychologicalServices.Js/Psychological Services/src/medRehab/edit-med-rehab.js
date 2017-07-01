import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {Config} from '../common/config';
import {EventHelper} from 'services/eventHelper';

@inject(Element, Config, EventHelper)
export class EditMedRehab {
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
		
		this.eventHelper.fireEvent(this.element, 'edited', { 'medRehab': this.model });
	}
	
	cancel(e) {
		this.eventHelper.fireEvent(this.element, 'canceled', { 'medRehab': this.backup });
	}
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}