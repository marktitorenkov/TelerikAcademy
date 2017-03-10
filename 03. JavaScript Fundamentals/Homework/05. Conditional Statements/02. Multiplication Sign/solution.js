function solve(args) {
	var a = +args[0];
	var b = +args[1];
	var c = +args[2];

	// any zero
	if (a == 0 || b == 0 || c == 0) {
		return '0';
	}
	// + - []  /  - + []
	else if (a < 0 ^ b < 0) {
		// - -
		if (c < 0) {
			return '+';
		}
		// - +
		else {
			return '-';
		}
	}
	// + + [] / - - []
	else {
		// + -
		if (c < 0) {
			return '-';
		}
		// + +
		else {
			return '+';
		}
	}
}