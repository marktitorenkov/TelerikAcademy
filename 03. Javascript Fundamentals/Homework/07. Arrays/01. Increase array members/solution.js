function solve(args) {
	let n = +args[0];
	let arr = new Array(n);

	for (let i = 0; i < n; i++) {
		arr[i] = i * 5;
		console.log(arr[i]);
	}
}