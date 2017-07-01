import {inject} from 'aurelia-framework';

@inject(Element)
export class CancelEnterCustomAttribute {
	
	constructor(element) {
		this.element = element;
	}
	
	attached() {
        this.element.addEventListener('keypress', enterPressed);
    }

    detached() {
        this.element.removeEventListener('keypress', enterPressed);
    }
}

function enterPressed(e) {
	let key = e.which || e.keyCode;
	if (key == 10 || key === 13) {
		e.preventDefault();
	}
};