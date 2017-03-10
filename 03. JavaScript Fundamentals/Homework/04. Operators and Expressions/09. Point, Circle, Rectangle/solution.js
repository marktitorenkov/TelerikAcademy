function solve(args)  {
	var x = +args[0];
	var y = +args[1];
	var output = '';

	if ( Math.sqrt( (x - 1) * (x - 1) + (y - 1) * (y - 1) ) <= 1.5 )
		output += 'inside circle';
	else
		output += 'outside circle';	 
	output += ' ';
	if ( x >= -1 && x <= 5 && y >= -1 && y <= 1 )
		output += 'inside rectangle';
	else
		output += 'outside rectangle';

	return output;
}