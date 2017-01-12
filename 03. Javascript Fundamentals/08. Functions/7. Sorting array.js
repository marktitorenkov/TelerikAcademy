function solve(args) {
	function largest(arr) {
		let max = 0;
		for (let i = 1; i < arr.length; i++) {
			if (arr[i] > arr[max]) {
				max = i;
			}
		}
		return max;
	}
	function sort(arr) {
		for (let i = arr.length - 1; i > 0; i--) {
			let max = largest(arr.slice(0, i));
			if (arr[max] > arr[i]) {
				let temp = arr[i];
				arr[i] = arr[max];
				arr[max] = temp;
			}
		}
	}

	let arr = args[1].split(' ').map(Number);
	sort(arr);

	console.log(arr.join(' '));
}