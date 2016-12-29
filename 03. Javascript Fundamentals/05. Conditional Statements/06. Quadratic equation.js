function solve(args) {
	var a = +args[0];
	var b = +args[1];
	var c = +args[2];

	var d = b * b - 4 * a * c;
	if (d < 0) {
		return 'no real roots';
	}
	else if (d == 0) {
		return 'x1=x2=' + (-b / (2 * a)).toFixed(2);
	}
	else {
		var x1 = (-b - Math.sqrt(d)) / (2 * a);
		var x2 = (-b + Math.sqrt(d)) / (2 * a);
		var temp = x1;
		x1 = Math.min(x1, x2);
		x2 = Math.max(temp, x2);

		return 'x1=' + x1.toFixed(2) + '; x2=' + x2.toFixed(2);
	}
}