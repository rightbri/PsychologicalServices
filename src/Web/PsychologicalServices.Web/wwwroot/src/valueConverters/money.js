
export class MoneyValueConverter {
	toView(value) {
		var val = value;
		
		val = (val / 100).toLocaleString('en-CA', { style: 'currency', currency: 'CAD' });
		
		return val;
	}
}