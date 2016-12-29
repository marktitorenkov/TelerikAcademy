function solve(args) {
	var num = args[0] | 0;
	return ((num % 5 == 0 && num % 7 == 0) + ' ' + num);
}