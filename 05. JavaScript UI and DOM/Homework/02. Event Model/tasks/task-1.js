function solve() {
	return function(selector) {
		const element = typeof selector === 'string' ?
			document.getElementById(selector) : selector;
		if (!element instanceof HTMLElement) {
			throw 'Element does not exist';
		}

		Array.from(element.getElementsByClassName('button'))
			.forEach(b => b.innerHTML = 'hide');

		element.addEventListener('click', function(e) {
			const button = e.target;
			// jsdom does not support classList
			if (button.className.includes('button')) {
				let content = button.nextElementSibling;
				while (content && !content.className.includes('button')) {
					if (content.className.includes('content')) {
						if (content.style.display === 'none') {
							content.style.display = '';
							button.innerHTML = 'hide';
						}
						else {
							content.style.display = 'none';
							button.innerHTML = 'show';
						}
						break;
					}
					content = content.nextElementSibling;
				}
			}
		})
	};
}

module.exports = solve;
