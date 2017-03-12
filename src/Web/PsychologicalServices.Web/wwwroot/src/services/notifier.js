import $ from 'bootstrap';
import notify from 'bootstrap-notify';

export class Notifier {

	error(message) {
		_notify({
			//options
			message: message,
			icon: 'fa fa-exclamation fa-lg'
		}, {
			//settings
			type: 'danger'
		});
	}
	
	info(message) {
		_notify({
			//options
			message: message,
			icon: 'fa fa-info fa-lg'
		}, {
			//settings
			type: 'info'
		});
	}
	
}

function _notify(options, settings) {
	$.notify(options, settings);
}