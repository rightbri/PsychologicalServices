import {bindable, bindingMode, inject} from 'aurelia-framework';
import {EventHelper} from 'services/eventHelper'
import flatpickr from 'flatpickr';

@inject(Element, EventHelper)
export class DatePickerCustomAttribute {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) dates;
	@bindable({ primaryProperty: true }) options = {};
	
	constructor(element, eventHelper) {
		this.element = element;
		this.eventHelper = eventHelper;
	}

	attached() {
		
		let eventOptions = {
			'onChange' : (selectedDates, dateStr, instance) =>
				this.eventHelper.fireEvent(this.element, 'datechanged', { dates: selectedDates }),
			'onMonthChange': (selectedDates, dateStr, instance) =>
				this.eventHelper.fireEvent(this.element, 'monthchanged', { dates: selectedDates })
		};
		
		copyValues(eventOptions, this.options);
		
		this.flatpickr = flatpickr(this.element, this.options);
		
		if (this.dates) {
			this.flatpickr.setDate(this.dates);
		}
	}

	detached() {
		this.flatpickr.destroy();
	}
}

function copyValues(copyFrom, copyTo) {
	for (var prop in copyFrom) {
		if (copyFrom.hasOwnProperty(prop)) {
			copyTo[prop] = copyFrom[prop];
		}
	}
}