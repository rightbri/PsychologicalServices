/**
 * Sort array value converter
 *
 * This value converter takes an array with a config parameter and sorts the array and
 * returns it to the view.
 *
 * Usage:
 *   <require from="sort-array"></require>
 *   <pre>${object | sort:{ property: 'doc_count', direction: 'desc' } }</pre>
 */
export class SortArrayValueConverter {
  /**
   * To View method
   *
   * @param {array} array to sort
   * @param {Object} config sort configuration
   *
   * @return {array} sorted array
   * @example
   * "item of $parent.results.facets[facet.name] | sort: { property: 'doc_count', direction: 'desc' }"
   *
   */
  toView(array, config) {
    return array
      .sort((val1, val2) => {
        var sortTotal = 0;
		
		if (!Array.isArray(config)) {
			config = [config];
		}
		
		config.forEach((sortConfig, i, arr) => {
			let a = val1, b = val2;

			if (sortConfig.direction.toLowerCase() !== 'asc' && sortConfig.direction.toLowerCase() !== 'ascending') {
			  a = val2;
			  b = val1;
			}

			//resolve property reference
			let aValue = resolvePath(a, sortConfig.property, null);
			let bValue = resolvePath(b, sortConfig.property, null);
			
			//weight the sort configuration by order
			let weight = Math.pow(10, arr.length - 1 - i);
			
			let sortValue = aValue > bValue ? 1 : aValue === bValue ? 0 : -1;
			
			sortTotal = sortTotal + (weight * sortValue);
		});
		
		return sortTotal;
      });
  }
}

function resolvePath (object, path, defaultValue) {
	return path.split('.').reduce((o, p) => o ? o[p] : defaultValue, object);
}
