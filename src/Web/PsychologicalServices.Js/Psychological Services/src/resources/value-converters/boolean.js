
export class BooleanValueConverter {
	toView(value) {
		return value ? 'Yes' : 'No';
	}
	
	fromView(value) {
		return value === 'Yes' ? true : false;
	}
}