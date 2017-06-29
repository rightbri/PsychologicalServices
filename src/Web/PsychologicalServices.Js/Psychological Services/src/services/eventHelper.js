
export class EventHelper {
	
	fireEvent(element, name, customData) {
		let event = createEvent(name, customData);
		element.dispatchEvent(event);
	}

}

function createEvent(name, customData) {
	let customEvent;
	
	if (window.CustomEvent) {
		customEvent = new CustomEvent(name, { bubbles: true, 'detail': customData });
	}
	else {
		customEvent = document.createEvent('CustomEvent');
		
		customEvent.initCustomEvent(name, true, true, { 'detail': customData });
	}
	
	return customEvent;
}