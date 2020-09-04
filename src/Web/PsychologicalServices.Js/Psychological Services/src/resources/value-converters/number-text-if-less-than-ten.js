import {inject} from 'aurelia-framework';
import 'number-to-words';

@inject(numberToWords)
export class NumberTextIfLessThanTenValueConverter {

	constructor(numberToWords) {
		this.numberToWords = numberToWords;
	}

	toView(value) {
		return value < 10 ? this.numberToWords.toWords(value) : value;
	}
}
