function solve(args) {
	let nums = args.map(Number);
	for (let i = 0; i < nums.length; i++) {
		let min = i;
		for (let j = i + 1; j < nums.length; j++) {
			if (nums[j] < nums[min]) {
				min = j;
			}
		}
		if (i != min) {
			let temp = nums[i];
			nums[i] = nums[min];
			nums[min] = temp;
		}
	}
	// remove duplicates when outputing
	let temp = [];
	for (let i = 0; i < nums.length; i++) {
		if (temp.indexOf(nums[i]) == -1) {
			temp.push(nums[i]);
			console.log(nums[i]);
		}
	}
}