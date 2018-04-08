import {inject} from 'aurelia-framework';
import {EventHelper} from 'services/eventHelper';

@inject(Element, EventHelper)
export class EnterCustomAttribute {
	
	constructor(element, eventHelper) {
		this.element = element;
		this.eventHelper = eventHelper;
	}
	
	attached() {
        this.element.addEventListener('keypress', e => keyPressed(e, this.element, this.eventHelper));
    }

    detached() {
        this.element.removeEventListener('keypress', e => keyPressed(e, this.element, this.eventHelper));
	}
}

function keyPressed(e, element, eventHelper) {
	let key = e.which || e.keyCode;
	if (key == 10 || key === 13) {
		eventHelper.fireEvent(element, 'enterpress');
	}
};