function solve(args) {
	let arr = args.slice(1, args.length - 1).map(Number);
	let value = +args[args.length - 1];
	
	let l = 0;
	let r = arr.length - 1;
	while (l <= r) {
		let m = ((l + r) / 2) | 0;
		
		if (value > arr[m]) {
			l = m + 1;
		}
		else if (value < arr[m]) {
			r = m - 1;
		}
		else {
			return m + ''; //kys bgcoder
		}
	}
	return -1;
}