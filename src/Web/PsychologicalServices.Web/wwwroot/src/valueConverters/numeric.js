
export class NumericValueConverter {
	toView(value) {
		var val = value;
		
		val = val.toLocaleString();
		
		return val;
	}
}