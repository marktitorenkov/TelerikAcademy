function solve(args) {
	let hex = args[0];
	let decimal = 0;

	for	(let i = 0; i < hex.length; i++) {
		let char = hex.charAt(i);
		if (!isNaN(char)) {
			decimal = decimal * 16 + (char | 0);
		}
		else {
			decimal = decimal * 16 + (char.charCodeAt(0) - 'A'.charCodeAt(0) + 10);
		}
	}
	return decimal;
}