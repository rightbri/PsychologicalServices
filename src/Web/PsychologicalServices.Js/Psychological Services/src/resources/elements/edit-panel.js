import {inject} from 'aurelia-framework';
import {EventHelper} from 'services/eventHelper';

@inject(Element, EventHelper)
export class EditPanelCustomElement {
	
	constructor(element, eventHelper) {
		this.element = element;
		this.eventHelper = eventHelper;
	}
	
	ok() {
		this.eventHelper.fireEvent(this.element, 'ok');
	}
	
	cancel() {
		this.eventHelper.fireEvent(this.element, 'cancel');
	}
}