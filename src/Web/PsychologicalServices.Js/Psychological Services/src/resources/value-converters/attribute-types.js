
export class AttributeTypesValueConverter {
	toView(array, types) {
		return array.filter(item => types.some(type => type === item.attribute.attributeType.attributeTypeId));
	}
}