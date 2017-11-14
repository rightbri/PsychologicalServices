import numeral from 'numeral'

export class MoneyValueConverter {
	toView(value, format) {
		var v = numeral(value / 100).format(format || '$0,0.00');
		return v;
	}
	
	fromView(value, format) {
		var v = numeral(value).value() * 100;
		return Math.round(v);
	}
}