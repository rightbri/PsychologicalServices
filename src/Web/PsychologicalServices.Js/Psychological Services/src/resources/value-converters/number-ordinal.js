import {inject} from 'aurelia-framework';
import 'number-to-words';

@inject(numberToWords)
export class NumberOrdinalValueConverter {

	constructor(numberToWords) {
		this.numberToWords = numberToWords;
	}

	toView(value) {
		return value ? this.numberToWords.toOrdinal(value) : value;
	}
}
