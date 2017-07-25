import {bindable, bindingMode, inject} from 'aurelia-framework';

@inject(Element)
export class CheckboxTriStateCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) value = null;
	
	constructor(element) {
		this.element = element;
		
		this.clickedBound = this.clicked.bind(this);
	}
	
	attached() {
		this.checkbox = this.element.querySelector('input[type="checkbox"]');
		
		this.updateState(this.value);
		
		this.checkbox.addEventListener('click', this.clickedBound);
	}
	
	detached() {
		this.checkbox.removeEventListener('click', this.clickedBound);
	}
	
	clicked(e) {
		
		//value goes from checked (true) to unchecked (false) to indeterminate (null)
		
		if (this.value === true) {
			this.value = false;
		}
		else if (this.value === false) {
			this.value = null;
		}
		else if (this.value === null) {
			this.value = true;
		}
		
		this.updateState(this.value);
	}
	
	updateState(value) {
		this.checkbox.checked = value === true;
		this.checkbox.indeterminate = value === null;
	}
}
