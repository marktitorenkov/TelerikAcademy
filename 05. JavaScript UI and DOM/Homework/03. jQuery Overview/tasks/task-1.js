function solve() {
	return function(selector, count) {
		var count = Number(count);
		if (!count || count < 0) {
			throw 'Invalid count';
		}
		
		if (typeof selector !== 'string') {
			throw 'Invalid selector';
		}

		var element = $(selector);
		if (!element) {
			return;
		}

		var ul = $('<ul class="items-list"></ul>');

		for (var i = 0; i < count; i++) {
			var li = $('<li class="list-item"></li>');
			li.html('List item #' + i);
			ul.append(li);
		}

		$(selector).append(ul);
	};
}

module.exports = solve;
