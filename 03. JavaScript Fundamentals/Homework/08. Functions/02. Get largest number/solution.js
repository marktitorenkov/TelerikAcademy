function solve(args) {
	function getMax(a, b) {
		if (a > b) {
			return a;
		}
		else {
			return b;
		}
	}
	
	args = args[0].split(' ');
	let a = +args[0];
	let b = +args[1];
	let c = +args[2];

	console.log(getMax(a, getMax(b, c)));
}