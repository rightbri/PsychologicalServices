
export class DirtyPrompter {

	initialize(func) {
		this.func = func;
		this.original = JSON.stringify(func());
	}
	
	confirm(prompt) {
		let original = this.original;
		let current = JSON.stringify(this.func());
		
		if (original != current) {
			return confirm(prompt);
		}
		
		return true;
	}
}