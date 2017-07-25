
export class BooleanValueConverter {
	toView(value, displayIfNull) {
		if (value === null) {
			return displayIfNull || '';
		}
		
		return value ? 'Yes' : 'No';
	}
	
	fromView(value) {
		return value === 'Yes' ? true : false;
	}
}