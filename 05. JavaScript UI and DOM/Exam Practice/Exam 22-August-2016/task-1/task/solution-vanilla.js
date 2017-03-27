function solve() {
	return function(selector, tabs) {
		const rootElement = document.querySelector(selector);
		const tabsNav = document.createElement('ul');
		tabsNav.className = 'tabs-nav';
		const tabsContent = document.createElement('ul');
		tabsContent.className = 'tabs-content';

		tabs.forEach(function(tab, i) {
			// tabsNav
			(function() {
				const li = document.createElement('li');
				const a = document.createElement('a');
				a.className = 'tab-link';
				a.href = '#tab' + i;
				a.innerHTML = tab.title;

				li.appendChild(a);
				tabsNav.appendChild(li);
			})();

			// tabsContent
			(function() {
				const li = document.createElement('li');
				li.className = 'tab-content';
				li.id = 'tab' + i;
				if (i === 0) {
					li.classList.add('visible');
				}
				const p = document.createElement('p');
				p.innerHTML = tab.content;
				const btn = document.createElement('button');
				btn.className = 'btn-edit';
				btn.innerHTML = 'Edit';

				li.appendChild(p);
				li.appendChild(btn);
				tabsContent.appendChild(li);
			})();
		});

		tabsNav.addEventListener('click', function(e) {
			const target = e.target;
			if (target.classList.contains('tab-link')) {
				const id = target.hash.substr(1);
				const tab = document.getElementById(id);
				const tabs = document.getElementsByClassName('tab-content');
				[].slice.call(tabs).forEach(function(tab) {
					tab.classList.remove('visible');
				});
				tab.classList.add('visible');
			}
		});

		tabsContent.addEventListener('click', function(e) {
			const target = e.target;
			
			if (target.classList.contains('btn-edit')) {
				if (target.innerHTML === 'Edit') {
					target.innerHTML = 'Save';

					const currentContent = target
						.previousElementSibling
						.innerHTML;
					const textArea = document.createElement('textarea');
					textArea.className = 'edit-content';
					textArea.value = currentContent;
					target.parentElement.appendChild(textArea);
				} else {
					target.innerHTML = 'Edit';

					const textArea = target.nextElementSibling;
					const textAreaContent = textArea.value;
					target.previousElementSibling.innerHTML = textAreaContent;
					textArea.parentElement.removeChild(textArea);
				}
			}
		});

		rootElement.appendChild(tabsNav);
		rootElement.appendChild(tabsContent);
	}
}

if (typeof module !== 'undefined') {
	module.exports = solve;
}