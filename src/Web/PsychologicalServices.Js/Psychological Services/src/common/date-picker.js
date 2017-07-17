import {bindable, bindingMode, inject} from 'aurelia-framework';
import {EventHelper} from 'services/eventHelper'
import flatpickr from 'flatpickr';
import {Config} from 'common/config';

@inject(Element, EventHelper, Config)
export class DatePickerCustomAttribute {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) dates;
	@bindable({ primaryProperty: true }) options = {};
	
	constructor(element, eventHelper, config) {
		this.element = element;
		this.eventHelper = eventHelper;
		this.config = config;
	}

	attached() {
		
		let eventOptions = {
			'onChange' : (selectedDates, dateStr, instance) => {
				this.eventHelper.fireEvent(this.element, 'datechanged', { dates: selectedDates });
			},
			'onMonthChange': (selectedDates, dateStr, instance) => {
				this.eventHelper.fireEvent(this.element, 'monthchanged', { dates: selectedDates });
			}
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
	
	datesChanged(newValue, oldValue) {
		//console.log('old: ' + oldValue + ', new: ' + newValue);
		if (this.flatpickr && isDate(newValue)) {
			this.flatpickr.setDate(newValue);
		}
	}
}

function copyValues(copyFrom, copyTo) {
	for (var prop in copyFrom) {
		if (copyFrom.hasOwnProperty(prop)) {
			copyTo[prop] = copyFrom[prop];
		}
	}
}

function isDate(obj) {
	return Object.prototype.toString.call(obj) === "[object Date]";
}