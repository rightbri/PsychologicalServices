import {inject} from 'aurelia-framework';
import 'number-to-words';

@inject(numberToWords)
export class NumberTextValueConverter {

	constructor(numberToWords) {
		this.numberToWords = numberToWords;
	}

	toView(value) {
		return this.numberToWords.toWords(value);
	}
}
