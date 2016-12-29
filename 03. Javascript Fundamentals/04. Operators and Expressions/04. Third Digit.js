function solve(args) {
	var num = args[0] | 0;
	num = (num / 100) | 0;
	var third = num % 10;
	if (third == 7)
		return true;
	else 
		return (false + ' ' + third);
}