export class AppointmentClassesValueConverter {
	toView(appointment) {
		
		let classes = [];
		
		if (appointment.assessment.docListWriter !== null) {
			classes.push('has-doc-list-writer');
		}
		
		for (var i = 0; i < appointment.attributes.length; i++) {
			classes.push(getAttributeValueClassName(appointment.attributes[i]));
		}
		
		for (var i = 0; i < appointment.assessment.attributes.length; i++) {
			classes.push(getAttributeValueClassName(appointment.assessment.attributes[i]));
		}
		
		return classes.join(' ');
	}
}

function getAttributeValueClassName(value) {
	let name = value.attribute.name.toLowerCase().replace(/[^a-zA-Z0-9 ]/g, '').replace(/ /g,'-');
		
	if (value.value === null) {
		return `${name}-unknown`;
	}
	else if (value.value === true) {
		return `${name}-yes`;
	}
	else {
		return `${name}-no`;
	}
	
	return '';
}