function solve(args) {
	function firstLargerThanNeighbours(arr) {
		let index = -1;
		for (let i = 1; i < arr.length - 1; i++) {
			if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) {
				index = i;
				return index;
			}
		}
	}
	
	let arr = args[1].split(' ').map(Number);
	
	console.log(firstLargerThanNeighbours(arr));
}