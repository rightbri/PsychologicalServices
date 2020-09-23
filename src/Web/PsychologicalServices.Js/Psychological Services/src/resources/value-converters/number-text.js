import {inject} from 'aurelia-framework';
import 'number-to-words';

@inject(numberToWords)
export class NumberTextValueConverter {

	constructor(numberToWords) {
		this.numberToWords = numberToWords;
	}

	toView(value) {
		return value ? this.numberToWords.toWords(value) : value;
	}
}
