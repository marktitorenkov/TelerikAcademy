function solve(args) {
	let arr = args.map(Number).slice(1);
	let maxcount = 1;
	let maxcountnum;
	
	for (let i = 0; i < arr.length; i++) {
		let currnum = arr[i];
		let currcount = 0;
		for (let j = 0; j < arr.length; j++) {
			if (arr[j] == currnum) {
				currcount++;
			}
		}
		if (currcount > maxcount) {
			maxcount = currcount;
			maxcountnum = arr[i];
		}
	}
	
	console.log(maxcountnum + ' (' + maxcount + ' times)');
}