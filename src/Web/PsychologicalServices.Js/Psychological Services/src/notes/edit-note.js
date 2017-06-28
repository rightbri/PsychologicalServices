import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {Context} from 'common/context';

@inject(Element, Context)
export class EditNoteCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) note;
	
	constructor(element, context) {
		this.element = element;
		this.context = context;
	}
	
	activate() {
		this.backup = JSON.parse(JSON.stringify(this.note));
		
		return this.context.getUser().then(user => {
			this.user = user;
		});
	}
	
	ok() {
		this.note.updateUser = this.user;
		this.note.updateDate = new Date();
		
		fireEvent(this.element, 'edited', this.note);
	}
	
	cancel() {
		fireEvent(this.element, 'canceled', this.backup);
	}
}

function createEvent(name, customData) {
	let customEvent;
	
	if (window.CustomEvent) {
		customEvent = new CustomEvent(name, { bubbles: true, 'detail': { note: customData } });
	}
	else {
		customEvent = document.createEvent('CustomEvent');
		
		customEvent.initCustomEvent(name, true, true, { 'detail': { note: customData } });
	}
	
	return customEvent;
}

function fireEvent(element, name, customData) {  
	var event = createEvent(name, customData);
	element.dispatchEvent(event);
}