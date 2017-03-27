function solve() {
	return function(selector, tabs) {
		const $element = $(selector);
		const $tabsNav = $('<ul>').addClass('tabs-nav');
		const $tabsContent = $('<ul>').addClass('.tabs-content');

		tabs.forEach(function(tab, i) {
			// tabsNav
			(function() {
				const $a = $('<a>')
					.addClass('tab-link')
					.attr('href', '#tab' + i)
					.html(tab.title);
				const $li = $('<li>').append($a);
				$tabsNav.append($li);
			})();

			// tabsContent
			(function() {
				const $p = $('<p>').html(tab.content);
				const $btn = $('<button>')
					.addClass('btn-edit')
					.html('Edit');
				const $li = $('<li>')
					.addClass('tab-content')
					.attr('id', 'tab' + i)
					.append($p)
					.append($btn);
				if (i === 0) {
					$li.addClass('visible');
				}

				$tabsContent.append($li);
			})();
		});

		$tabsNav.on('click', '.tab-link', function(e) {
			const id = $(this).attr('href');
			$('.tab-content').removeClass('visible');
			$(id).addClass('visible');
		});

		$tabsContent.on('click', '.btn-edit', function(e) {
			const $btn = $(this);

			if ($btn.html() === 'Edit') {
				$btn.html('Save');

				const currContent = $btn.prev('p').html();
				const $textArea = $('<textarea>')
					.addClass('edit-content')
					.val(currContent);
				$btn.parent().append($textArea);
			}
			else {
				$btn.html('Edit');

				const $textArea = $btn.nextAll('textarea');
				const textAreaContent = $textArea.val();
				$btn.prev('p').html(textAreaContent);
				$textArea.remove();
			}
		});

		$element
			.append($tabsNav)
			.append($tabsContent);
	}
}

if (typeof module !== 'undefined') {
	module.exports = solve;
}