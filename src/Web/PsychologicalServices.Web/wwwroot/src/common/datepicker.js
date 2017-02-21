import {inject, customAttribute} from 'aurelia-framework';
import {datepicker} from 'bootstrap-datepicker';

@customAttribute('datepicker')
@inject(Element)
export class DatePicker {  
	constructor(element) {
		this.element = element;
	}

	attached() {
		$(this.element).datepicker(this.value)
			.on('change', e => fireEvent(e.target, 'input'));

	}

	detached() {
		$(this.element).datepicker('destroy')
			.off('change');
	}
}

function createEvent(name) {  
	var event = document.createEvent('Event');
	event.initEvent(name, true, true);
	return event;
}

function fireEvent(element, name) {  
	var event = createEvent(name);
	element.dispatchEvent(event);
}