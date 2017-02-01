function solve(args) {
	let arr1 = args[0].split('');
	let arr2 = args[1].split('');

	for (let i = 0; i < arr1.length && i < arr2.length; i++) {
		if (arr1[i] != arr2[i])	{
			if (arr1[i].charCodeAt(0) > arr2[i].charCodeAt(0))
				return '>';
			else
				return '<';
		}
	}
	
	if (arr1.length == arr2.length) {
		return '=';
	}
	else {
		if (arr1.length > arr2.length)
			return '>';
		else
			return '<';
	}
}