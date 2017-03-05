import {bindable, inject} from 'aurelia-framework';
import {daterangepicker} from 'bootstrap-daterangepicker';

@inject(Element)
export class DateRangePickerCustomAttribute {
	@bindable rangeStart;
	@bindable rangeEnd;
	@bindable options;
	@bindable dateRangeChangedCallback;
	
	constructor(element) {
		this.element = element;
	}
	
	attached() {
		this.options.startDate = this.rangeStart;
		this.options.endDate = this.rangeEnd;
		
		let self = this;
		
		$(this.element).daterangepicker(this.options, function(start, end, label) {
			if (self.dateRangeChangedCallback) {
				self.dateRangeChangedCallback(start.toDate(), end.toDate());
			}
		})
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