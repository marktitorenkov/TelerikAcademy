function solve(args) {
	let nums = args.map(Number);
	let max = 1;
	let currmax = 1;
	for (let i = 1; i < nums.length; i++) {
		if (nums[i] > nums[i - 1]) {
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