
export class ProperValueConverter {
	toView(value) {
		return value && value.length > 0
		? value.slice(0, 1).toUpperCase() + value.slice(1).toLowerCase()
		: "";
	}
}