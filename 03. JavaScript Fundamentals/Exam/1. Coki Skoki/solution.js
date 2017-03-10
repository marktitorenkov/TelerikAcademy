function solve(args) {
	let n = +args[0];
	let nums = args.slice(1).map(Number);
	let result;

	if (nums[0] % 2 === 0) {
		result = 0;
	}
	else {
		result = 1;
	}

	for (let i = 0; i < nums.length; i += 1) {
		if (nums[i] % 2 === 0) {
			result += nums[i];
			i += 1;
		}
		else {
			result *= nums[i];
		}
		result %= 1024;
	}

	console.log(result);
}