function solve(args) {
	var a = +args[0];
	var b = +args[1];
	var c = +args[2];
	var d = +args[3];
	var e = +args[4];

	if (a > b && a > c && a > d && a > e) {
		return a;
	}
	else if (b > a && b > c && b > d && b > e) {
		return b;
	}
	else if (c > a && c > b && c > d && c > e) {
		return c;
	}
	else if (d > a && d > b && d > c && d > e) {
		return d;
	}
	else {
		return e;
	}
}