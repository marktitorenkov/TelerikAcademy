function showRedirectPopUp(url, timeout) {
	function waitFor(timeout) {
		return new Promise((resolve) => {
			setTimeout(resolve, timeout);
		});
	}

	function showPopup(url, timeout) {
		const popup = document.createElement('div');
		popup.id = 'popup';
		popup.innerHTML = `You will be redirected to ` +
			`<a href="${url}">${url}</a>` +
			` in ${timeout / 1000}s`;

		document.body.appendChild(popup);
	}

	function redirectTo(url) {
		window.location = url;
	}

	showPopup(url, timeout);
	waitFor(timeout)
		.then(() => {
			redirectTo(url);
		});
}

document
	.getElementById('redirect-btn')
	.addEventListener('click', () => {
		showRedirectPopUp('https://www.google.com', 2000);
	});
