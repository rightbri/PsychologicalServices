export class AttributeValueValueConverter {
	toView(value) {
		let name = value.attribute.name;
		
		if (value.value === null) {
			return `${name}?`;
		}
		else if (value.value === true) {
			return name;
		}
		
		return '';
	}
}