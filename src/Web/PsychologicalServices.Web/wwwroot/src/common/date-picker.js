import {inject} from 'aurelia-framework';
import {datepicker} from 'bootstrap-datepicker';

@inject(Element)
export class DatePickerCustomAttribute {
	
	constructor(element) {
		this.element = element;
	}

	attached() {
		$(this.element).datepicker(this.value)
			.on('change', e => fireEvent(e.target, 'input'))
			.on('changeMonth', e => {
				fireEvent(e.target, 'monthchanged', e.date);
			});
	}

	detached() {
		$(this.element).datepicker('destroy')
			.off('change')
			.off('changeMonth');
	}
}

function createEvent(name, customData) {  
	var event = new CustomEvent(name, { bubbles: true, 'detail': customData });
	return event;
}

function fireEvent(element, name, customData) {  
	var event = createEvent(name, customData);
	element.dispatchEvent(event);
}