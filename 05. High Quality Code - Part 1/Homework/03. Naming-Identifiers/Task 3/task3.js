function clickHandler(event, args) {
	var	browser = window.navigator.appCodeName;
	var	isMozilla = (browser === 'Mozilla');
	
	if (isMozilla) {
		alert('Yes');
	} else {
		alert('No');
	}
}