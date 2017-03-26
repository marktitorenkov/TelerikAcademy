function solve() {
	return function(fileContentsByName) {
		$('.file-explorer').on('click', '.item', function(e) {
			var $clicked = $(e.target);
			var name = $clicked.html();
			if ($clicked.parent('.file-item').length) {
				$('.file-content').html(fileContentsByName[name]);
			}
			else {
				$clicked.parent('.dir-item').toggleClass('collapsed');
			}
		});

		$('.file-explorer').on('click', '.del-btn', function(e) {
			var $clicked = $(e.target);
			$clicked.parent().remove();
		});

		$('.file-explorer').on('click', '.add-btn', function(e) {
			var $clicked = $(e.target);
			$clicked.removeClass('visible');
			$clicked.next('input').addClass('visible');
		});

		$('.add-wrapper input').on('keydown', function(e) {
			if (e.keyCode === 13) {
				var input = this.value;
				var filename;
				var dir;
				if (input.indexOf('/') > -1) {
					var path = input.split('/');
					filename = path[1];
					dir = path[0];
				} else {
					filename = input;
				}

				var $item = $(`<li class="file-item item"><a class="item-name">${filename}</a>
	                <a class="del-btn"></a>
   		            </li>`);

				if (dir) {
					var foundDir = $('.dir-item').filter(function(i, el) {
						return $(el).children('.item-name').html() === dir;
					});
					$item.appendTo(foundDir.children('.items'));
				} else {
					$item.appendTo('.file-explorer > .items');
				}
				fileContentsByName[filename] = '';
			}
		});
	}
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}