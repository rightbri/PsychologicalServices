import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {DataRepository} from 'services/dataRepository';
import {Config} from 'common/config';
import {EventHelper} from 'services/eventHelper';

@inject(Element, DataRepository, Config, EventHelper)
export class EditArbitration {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, dataRepository, config, eventHelper) {
		this.element = element;
		this.dataRepository = dataRepository;
		this.config = config;
		this.eventHelper = eventHelper;
		
		this.contactMatcher = (a, b) => a !== null && b !== null && a.contactId === b.contactId;
	}
	
	modelChanged(oldValue, newValue) {
		this.backup = getBackup(oldValue.arbitration);
		
		let model = this.model;
		
		this.defenseLawyers = model.defenseLawyers;
	}

	ok(e) {
		this.backup = getBackup(this.model.arbitration);
		
		this.eventHelper.fireEvent(this.element, 'edited', { 'arbitration': this.model.arbitration });
	}
	
	cancel(e) {
		this.eventHelper.fireEvent(this.element, 'canceled', { 'arbitration': this.backup });
	}
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}