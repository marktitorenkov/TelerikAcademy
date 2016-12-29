function solve(args) {
	var num = args[0] | 0;
	return (((1 << 3) & num) >> 3);
}