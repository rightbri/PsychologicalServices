import numeral from 'numeral'

export class MoneyValueConverter {
	toView(value, format) {
		return numeral(value / 100).format(format || '$0,0.00');
	}
	
	fromView(value, format) {
		return numeral(value).value() * 100;
	}
}