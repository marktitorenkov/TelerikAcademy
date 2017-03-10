function solve(args) {
	let n = +args[0];

	for (let i = 1; i <= n; i++) {
		let line = '';
		for (let j = i; j < n + i; j++) {
			line += j + ' ';
		}
		console.log(line);
	}
}