function solve(args) {
	function largerThanNeighbours(arr) {
		let count = 0;
		for (let i = 1; i < arr.length - 1; i++) {
			if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) {
				count++;
			}
		}
		return count;
	}

	let arr = args[1].split(' ').map(Number);

	console.log(largerThanNeighbours(arr));
}