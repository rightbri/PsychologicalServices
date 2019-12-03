
export class IntValueConverter {
	fromView(value) {
		return value && /^\d+$/.test(value.toString()) ? parseInt(value, 10) : 0;
	}
}