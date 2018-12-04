
export class ArrayToStringValueConverter {
	toView(array, format, delimiter = ", ", lastAnd = true) {
		let value = array
        .map(item => isFunction(format) ? format(item) : item)
        .reduce((accumulator, currentValue, index, array) => {
            let isFirst = index === 0;
            let isLast = index === array.length - 1;
            let useAnd = lastAnd && isLast && !isFirst;
            let useDelimiter = !isLast && array.length > 2;

            return accumulator + (useAnd ? " and " : "") + currentValue + (useDelimiter ? delimiter : "");
        }, "");

        return value;
	}
}

function isFunction(x) {
    return Object.prototype.toString.call(x) == '[object Function]';
}