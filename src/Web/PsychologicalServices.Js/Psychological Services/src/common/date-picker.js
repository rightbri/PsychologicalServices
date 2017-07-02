import {bindable, bindingMode, inject} from 'aurelia-framework';
import {EventHelper} from 'services/eventHelper'
import {jquery} from 'jquery';
import datepicker from 'bootstrap-datepicker';

@inject(Element, EventHelper)
export class DatePickerCustomAttribute {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) dates;
	@bindable({ primaryProperty: true }) options;
	
	constructor(element, eventHelper) {
		this.element = element;
		this.eventHelper = eventHelper;
	}

	attached() {
		let $datepicker = $(this.element).datepicker(this.options);
		
		if (this.dates) {
			$datepicker.datepicker('setDates', this.dates);
		}

		$datepicker
			.on('change', e => this.eventHelper.fireEvent(e.target, 'input'))
			.on('changeDate', e => {
				this.eventHelper.fireEvent(e.target, 'datechanged', e);
			})
			.on('changeMonth', e => {
				this.eventHelper.fireEvent(e.target, 'monthchanged', e.date);
			})
			.on('clearDate', e => {
				this.eventHelper.fireEvent(e.target, 'datecleared', e);
			});
	}

	detached() {
		$(this.element).datepicker('destroy')
			.off('change')
			.off('changeDate')
			.off('changeMonth')
			.off('clearDate');
	}
}
