function solve() {
	return function(selector, contents) {
		if (!selector || !contents || !Array.isArray(contents)) {
			throw 'Invalid parameters';
		}
		const element = typeof selector === 'string' ?
			document.getElementById(selector) : selector;
		if (!element instanceof HTMLElement) {
			throw new Error('Element does not exist');
		}

		const result = document.createDocumentFragment();
		contents.forEach(function(content) {
			const currDiv = document.createElement('div');
			if (typeof content !== 'string' && typeof content !== 'number') {
				throw 'Invalid contents';
			}
			currDiv.innerHTML = content;
			result.appendChild(currDiv);
		});
		element.innerHTML = '';
		element.appendChild(result);
	};
}

module.exports = solve;
