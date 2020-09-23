import {inject} from 'aurelia-framework';
import 'number-to-words';

@inject(numberToWords)
export class NumberTextOrdinalValueConverter {

	constructor(numberToWords) {
		this.numberToWords = numberToWords;
	}

	toView(value) {
		return value ? this.numberToWords.toWordsOrdinal(value) : value;
	}
}
