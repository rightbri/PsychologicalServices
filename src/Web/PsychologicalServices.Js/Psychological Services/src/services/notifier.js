import {show, ACTION_TYPE} from 'snackbar';

export class Notifier {

	error(message) {
		show({text: message, pos:'bottom-center'});
	}
	
	info(message) {
		show({text: message, pos:'bottom-center'});
	}
	
}
