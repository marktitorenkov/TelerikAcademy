function solve(args) {
	var n = args[0] | 0;
	if (n < 2) 
		return false;
	for (var i = 2; i < n; i++) {
		if (n % i == 0)
			return false;
	}
	return true;
}