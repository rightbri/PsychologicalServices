import numeral from 'numeral'

export class NumericValueConverter {
	toView(value, format) {
		return numeral(value).format(format);
	}
	
	fromView(value, format) {
		return numeral(value).value();
	}
}
