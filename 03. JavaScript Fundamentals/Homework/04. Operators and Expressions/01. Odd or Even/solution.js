function solve(args) {
	var num = args[0] | 0;
	var result;
	if (num % 2 == 0)
		result = 'even';
	else 
		result = 'odd';
	return (result + ' ' + num);
}