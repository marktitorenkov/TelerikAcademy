function solve() {
	return function(selector) {
		var $element = typeof selector === 'string' ?
			$(selector) : selector;

		if (!$element.length) {
			throw 'Invdalid selector';
		}

		$element.find('.button').html('hide');

		$element.on('click', '.button', function(e) {
			var $clicked = $(e.target);
			var $content = $clicked.nextAll('.content').first();

			if ($content.length) {
				if ($content.css('display') === 'none') {
					$clicked.html('hide');
					$content.css('display', '');
				} else {
					$clicked.html('show');
					$content.css('display', 'none');
				}
			}
		})
	};
};

module.exports = solve;