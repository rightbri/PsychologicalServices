import {inject} from 'aurelia-framework';
import {Context} from 'common/context';

@inject(Context)
export class UserSettings {
	
	constructor(context) {
		this.context = context;
	}
	
	setting(settingName, settingValue) {
		return this.context.getUser().then(user => {
			this.user = user;
			
			if (settingValue === undefined) {
				return getValue(this.user, settingName);
			}
			
			setValue(this.user, settingName, settingValue);
		});
	}
}

function getValue(user, settingName) {
	let settings = getUserSettings(user);
	
	return settings[settingName];
}

function setValue(user, settingName, settingValue) {
	let settings = getUserSettings(user);
	
	settings[settingName] = settingValue;
	
	setUserSettings(user, settings);
}

function getUserSettings(user) {
	let userSettings = JSON.parse(window.localStorage.getItem(getUserSettingsKey(user)) || '{}');
	
	return userSettings;
}

function setUserSettings(user, settings) {
	window.localStorage.setItem(getUserSettingsKey(user), JSON.stringify(settings));
}

function getUserSettingsKey(user) {
	return user.firstName + user.lastName + 'PsSettings';
}
