
export class ArrayToStringValueConverter {
    toView(array, config) {
        let format = config.format || (item => item);
        let delimiter = config.delimiter || ", ";
        let removeEmptyElements = config.removeEmptyElements || true;
        let connector = config.connector || "and";
        let lastConnector = config.lastConnector || true;

        let value = array
        .map(item => isFunction(format) ? format(item) : item)
        .filter(item => !removeEmptyElements || (item && item.length > 0))
        .reduce((accumulator, currentValue, index, array) => {
            let isFirst = index === 0;
            let isLast = index === array.length - 1;
            let useConnector = lastConnector && isLast && !isFirst;
            let useDelimiter = !isLast && array.length > 2;

            return accumulator + (useConnector ? ` ${connector} ` : "") + currentValue + (useDelimiter ? delimiter : "");
        }, "");

        return value;
    }
}

function isFunction(x) {
    return Object.prototype.toString.call(x) == '[object Function]';
}