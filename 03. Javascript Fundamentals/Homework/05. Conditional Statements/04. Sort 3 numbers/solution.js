function solve(args) {
	var a = +args[0];
	var b = +args[1];
	var c = +args[2];

	var output = '';
	if (a > b && a > c) {
		output += a;
		output += ' ';
		if (b > c) {
			output += b;
			output += ' ';
			output += c;
		}
		else {
			output += c;
			output += ' ';
			output += b;
		}
	}
	else if (b > a && b > c) {
		output += b;
		output += ' ';
		if (a > c) {
			output += a;
			output += ' ';
			output += c;
		}
		else {
			output += c;
			output += ' ';
			output += a;
		}
	}
	else {
		output += c;
		output += ' ';
		if (a > b) {
			output += a;
			output += ' ';
			output += b;
		}
		else {
			output += b;
			output += ' ';
			output += a;
		}
	}
	return output;
}