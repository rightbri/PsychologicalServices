import {inject} from 'aurelia-framework';
import {bindable, bindingMode} from 'aurelia-framework';
import {Context} from 'common/context';
import {EventHelper} from 'services/eventHelper';

@inject(Element, Context, EventHelper)
export class EditNoteCustomElement {
	@bindable({ defaultBindingMode: bindingMode.twoWay }) model;
	
	constructor(element, context, eventHelper) {
		this.element = element;
		this.context = context;
		this.eventHelper = eventHelper;
	}
	
	activate() {
		return this.context.getUser().then(user => {
			this.user = user;
		});
	}
	
	modelChanged(newValue, oldValue) {
		this.backup = getBackup(newValue);
	}
	
	ok(e) {
		this.model.updateUser = this.user;
		this.model.updateDate = new Date();
		
		this.backup = getBackup(this.model);
		
		this.eventHelper.fireEvent(this.element, 'edited', { 'note': this.model });
	}
	
	cancel(e) {
		this.eventHelper.fireEvent(this.element, 'canceled', { 'note': this.backup });
	}
}

function getBackup(obj) {
	return JSON.parse(JSON.stringify(obj));
}
