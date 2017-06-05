
export class GenderValueConverter {
	toView(value) {
		var val = value;
		
		if (value === 'M') {
			val = 'Male';
		}
		else if (value === 'F') {
			val = 'Female';
		}
		else if (value === 'U') {
			val = 'Unknown';
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
		else if (value === 'Unknown') {
			val = 'U';
		}
		
		return val;
	}
}