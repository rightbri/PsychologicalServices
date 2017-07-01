import {bindable, inject} from 'aurelia-framework';
import Inputmask from 'inputmask/inputmask/inputmask.date.extensions';

@inject(Element)
export class DateMaskCustomAttribute {
	@bindable({ primaryProperty: true }) options;
	
	constructor(element) {
		this.element = element;
	}

	attached() {
		var im = new Inputmask(this.options);
		im.mask(this.element);
	}

	detached() {
		if (this.element.inputmask) {
			this.element.inputmask.remove();
		}
	}
}
