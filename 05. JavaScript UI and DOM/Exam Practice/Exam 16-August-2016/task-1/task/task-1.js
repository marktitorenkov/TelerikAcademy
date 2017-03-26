function solve() {
	function createSuggestion(name, suggestions) {
		var suggestionExists = [].slice.call(suggestions).some(function(x) {
			return x.children[0].innerHTML.toLowerCase() === name.toLowerCase();
		});

		if (!suggestionExists) {
			var li = document.createElement('li');
			li.className = 'suggestion';

			var a = document.createElement('a');
			a.className = 'suggestion-link';
			a.href = '#';
			a.innerHTML = name;

			li.appendChild(a);

			return li;
		}
	}

	showElement = function(el) {
		el.style.display = '';
	}

	hideElement = function(el) {
		el.style.display = 'none';
	}

	return function(selector, suggestionsArray) {
		var element = document.querySelector(selector);
		var input = element.getElementsByClassName('tb-pattern')[0];
		var btn = element.getElementsByClassName('btn-add')[0];
		var ul = element.getElementsByClassName('suggestions-list')[0];
		var lis = element.getElementsByClassName('suggestion');

		suggestionsArray = suggestionsArray || [];

		suggestionsArray.forEach(function(str) {
			var li = createSuggestion(str, lis);
			if (li) {
				hideElement(li);
				ul.appendChild(li);
			}
		});

		input.addEventListener('input', function() {
			var inputText = this.value.toLowerCase();
			[].slice.call(lis).forEach(function(el) {
				var aText = el.children[0].innerHTML.toLowerCase();
				if (inputText && aText.indexOf(inputText) > -1) {
					showElement(el);
				}
				else {
					hideElement(el);
				}
			});
		});

		ul.addEventListener('click', function(e) {
			var clicked = e.target;
			if (clicked.className.indexOf('suggestion-link') > -1) {
				input.value = clicked.innerHTML;
			}
		});

		btn.addEventListener('click', function(e) {
			var text = input.value;
			if (text) {
				var li = createSuggestion(text, lis);
				if (li) {
					ul.appendChild(li);
				}
			}
		});
	};
}

module.exports = solve;
