function displayUserLocation(options) {
	options = options || {};
	const root = options.appendTo || document.body;
	const size = options.size > 1 ? options.size : 1;
	const zoom = options.zoom > 0 ? options.zoom : 0;

	const getLocation = new Promise((resolve, reject) => {
		navigator.geolocation.getCurrentPosition((pos) => {
			resolve(pos.coords);
		}, (err) => {
			reject(err.message);
		});
	});

	function addMapImg(coords) {
		const lat = coords.latitude;
		const long = coords.longitude;
		const url = 'https://maps.googleapis.com/maps/api/staticmap' +
			`?size=${size}x${size}` +
			`&zoom=${zoom}` +
			`&center=${lat},${long}` +
			`&markers=color:red|${lat},${long}`;

		const img = document.createElement('img');
		img.src = encodeURI(url);

		root.appendChild(img);
	}

	function showError(err) {
		const p = document.createElement('p');
		p.innerHTML = err;
		p.style.color = 'red';

		root.appendChild(p);
	}

	getLocation
		.then(addMapImg, showError);
}

displayUserLocation({
	appendTo: document.getElementById('root'),
	size: 640,
	zoom: 15
});
