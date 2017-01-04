function solve(args) {
	let s = args[0];
	let combinations = 0;
	for (let cars = 0; cars < 100; cars++) {
		for (let trucks = 0; trucks < 100; trucks++) {
			for (let tris = 0; tris < 100; tris++) {
				if ((cars * 4 + trucks * 10 + tris * 3) == s) {
					combinations++;
				}
			}
		}
	}
	console.log(combinations);
}