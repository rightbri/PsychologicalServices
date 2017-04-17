import {bindable, inject} from 'aurelia-framework';
import {jquery} from 'jquery';
import datepicker from 'bootstrap-datepicker';

@inject(Element)
export class DatePickerCustomAttribute {
	@bindable dates;
	@bindable({ primaryProperty: true }) options;
	
	constructor(element) {
		this.element = element;
	}

	attached() {
		let $datepicker = $(this.element).datepicker(this.options);
		
		if (this.dates) {
			$datepicker.datepicker('setDates', this.dates);
		}

		$datepicker
			.on('change', e => fireEvent(e.target, 'input'))
			.on('changeDate', e => {
				fireEvent(e.target, 'datechanged', e);
			})
			.on('changeMonth', e => {
				fireEvent(e.target, 'monthchanged', e.date);
			})
			.on('clearDate', e => {
				fireEvent(e.target, 'datecleared', e);
			});
	}

	detached() {
		$(this.element).datepicker('destroy')
			.off('change')
			.off('changeDate')
			.off('changeMonth')
			.off('clearDate');
	}
	
	datesChanged(newValue, oldValue) {
		this.dates = newValue;
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