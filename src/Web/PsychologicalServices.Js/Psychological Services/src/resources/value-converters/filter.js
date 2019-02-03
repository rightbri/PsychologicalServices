import {inject, Parser} from 'aurelia-framework'

@inject(Parser)
export class FilterValueConverter {
	constructor(parser) {
		this.parser = parser;
	}

	toView(array, property, exp) {

		if (typeof(property) === "function") {
			return array.filter(item => property(item));
		}

		
		let expression = this.parser.parse(property);
		return array.filter((item) => expression.evaluate({bindingContext:item}) === exp);
	}
}