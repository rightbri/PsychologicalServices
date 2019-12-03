
export class ArrayToStringValueConverter {
    toView(array, config) {
        let c = config || {};
        let format = c.format || (item => item);
        let delimiter = c.delimiter || ", ";
        let removeEmptyElements = c.removeEmptyElements || true;
        let connector = c.connector || "and";
        let lastConnector = c.hasOwnProperty('lastConnector') ? !!c.lastConnector : true;

        let value = array
        .map(item => isFunction(format) ? format(item) : item)
        .filter(item => !removeEmptyElements || (item && item.length > 0))
        .reduce((accumulator, currentValue, index, array) => {
            let isFirst = index === 0;
            let isLast = index === array.length - 1;
            let useConnector = lastConnector && isLast && !isFirst;
            let useDelimiter = (!isLast && !useConnector && array.length > 1) || (!isLast && array.length > 2);

            return accumulator + (useConnector ? ` ${connector} ` : "") + currentValue + (useDelimiter ? delimiter : "");
        }, "");

        return value;
    }
}

function isFunction(x) {
    return Object.prototype.toString.call(x) == '[object Function]';
}