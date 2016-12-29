function solve(args) {
	let max = 1;
	let currmax = 1;
	for (let i = 1; i < args.length; i++) {
		if (args[i] == args[i - 1]) {
			currmax++;
		}
		else {
			currmax = 1;
		}
		if (currmax > max)
			max = currmax;
	}
	return max;
}