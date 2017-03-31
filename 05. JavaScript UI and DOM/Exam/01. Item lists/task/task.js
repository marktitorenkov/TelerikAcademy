function solve() {
	function createLi(text) {
		var li = document.createElement('li');
		li.className = 'entry';
		
		var img = document.createElement('img');
		img.className = 'delete';
		img.src = 'imgs/Remove-icon.png';
		li.appendChild(img);

		var textNode  = document.createTextNode(text);
		li.appendChild(textNode);

		return li;
	}

	return function (selector, defaultLeft, defaultRight) {
		var rootElement = document.querySelector(selector);

		var container = document.createElement('div');
		container.className = 'column-container';

		var leftColumn = document.createElement('div');
		leftColumn.className = 'column';
		var leftSelect = document.createElement('div');
		leftSelect.className = 'select';
		var leftRadio = document.createElement('input');
		leftRadio.type = 'radio';
		leftRadio.name = 'column-select';
		leftRadio.id = 'select-left-column';
		leftRadio.checked = true;
		var leftLabel = document.createElement('label');
		leftLabel.innerHTML = 'Add here';
		leftLabel.htmlFor = 'select-left-column';
		var leftOl = document.createElement('ol');

		var rightColumn = document.createElement('div');
		rightColumn.className = 'column';
		var rightSelect = document.createElement('div');
		rightSelect.className = 'select';
		var rightRadio = document.createElement('input');
		rightRadio.type = 'radio';
		rightRadio.name = 'column-select';
		rightRadio.id = 'select-right-column';
		var rightLabel = document.createElement('label');
		rightLabel.innerHTML = 'Add here';
		rightLabel.htmlFor = 'select-right-column';
		var rightOl = document.createElement('ol');

		var input = document.createElement('input');
		input.size = 40;
		input.autofocus = true;
		var btn = document.createElement('button');
		btn.innerHTML = 'Add';

		defaultLeft = defaultLeft || [];
		defaultRight = defaultRight || [];

		leftSelect.appendChild(leftRadio);
		leftSelect.appendChild(leftLabel);
		leftColumn.appendChild(leftSelect);
		leftColumn.appendChild(leftOl);
		container.appendChild(leftColumn);

		rightSelect.appendChild(rightRadio);
		rightSelect.appendChild(rightLabel);
		rightColumn.appendChild(rightSelect);
		rightColumn.appendChild(rightOl);
		container.appendChild(rightColumn);

		defaultLeft.forEach(function (str) {
			var li = createLi(str);
			leftOl.appendChild(li);
		});

		defaultRight.forEach(function (str) {
			var li = createLi(str);
			rightOl.appendChild(li);
		});

		function addNew() {
			var value = input.value.trim();
			if (value) {
				var li = createLi(value);
				if (leftRadio.checked) {
					leftOl.appendChild(li);
				} else {
					rightOl.appendChild(li);
				}
				input.value = '';
			}
		}

		btn.addEventListener('click', addNew);
		input.addEventListener('keypress', function (e) {
			if (e.key === 'Enter') {
				addNew();
			}
		});

		container.addEventListener('click', function (e) {
			var target = e.target;
			if (target.className.indexOf('delete') > -1) {
				var li = target.parentElement;
				input.value = li.textContent;
				li.parentElement.removeChild(li);				
			}
		});

		// append to dom 
		rootElement.appendChild(container);
		rootElement.appendChild(input);
		rootElement.appendChild(btn);
	};
}

if (typeof module !== 'undefined') {
	module.exports = solve;
}
