function solve(args) {
	function countInArr(arr, x) {
		let count = 0;
		for (var i in arr) {
			if (arr[i] == x) {
				count++;
			}
		}
		return count;
	}

	let arr = args[1].split(' ').map(Number);
	let x = +args[2];

	console.log(countInArr(arr, x));
}