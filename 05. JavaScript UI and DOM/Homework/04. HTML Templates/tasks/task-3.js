function solve() {
	return function() {
		$.fn.listview = function(data) {
			var $this = $(this);
			var template = handlebars.
							compile($('#' + $this.attr('data-template'))
							.html());

			for (var el of data) {
				$this.append(template(el));
			}
			
			return this;
		};
	};
}

module.exports = solve;