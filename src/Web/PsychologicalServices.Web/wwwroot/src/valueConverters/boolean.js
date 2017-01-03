
export class BooleanValueConverter {
	toView(value) {
		return value ? 'yes' : 'no';
	}
	
	fromView(value) {
		return value === 'yes' ? true : false;
	}
}