function solve(args) {
	var a = +args[0];
	var b = +args[1];
	var c = +args[2];

	if (a > b) {
		if (a > c)
			return a;
		else
			return c;
	}
	else {
		if (b > c)
			return b;
		else
			return c;
	}
}