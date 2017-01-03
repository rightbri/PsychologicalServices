
export class GenderValueConverter {
	toView(value) {
		var val = value;
		
		if (value === 'M') {
			val = 'Male';
		}
		else if (value === 'F') {
			val = 'Female';
		}
		
		return val;
	}
	
	fromView(value) {
		var val = value;
		
		if (value === 'Male') {
			val = 'M';
		}
		else if (value === 'Female') {
			val = 'F';
		}
		
		return val;
	}
}