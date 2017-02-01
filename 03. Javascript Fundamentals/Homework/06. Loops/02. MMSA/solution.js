function solve(args) {
	let nums = args.map(Number);
	
	let min = nums[0];
	let max = nums[0];
	let sum = 0;
	let avg;

	for (let i = 0; i < nums.length; i++) {
		if (nums[i] < min)
			min = nums[i];
		if (nums[i] > max)
			max = nums[i];
		sum += nums[i];
	}
	avg = sum / nums.length;

	console.log('min=' + min.toFixed(2));
	console.log('max=' + max.toFixed(2));
	console.log('sum=' + sum.toFixed(2));
	console.log('avg=' + avg.toFixed(2));
}