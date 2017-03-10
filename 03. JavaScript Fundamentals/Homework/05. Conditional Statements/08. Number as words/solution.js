function solve(args) {
	var num = args[0] | 0;
	
	var result = '';
	var n1 = ['', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
	var n2 = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
	var n3 = ['twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

	if (num == 0) {
		result += 'zero';
	}
	else if ( ((num / 100) | 0) % 10 != 0 ) {
		result += n1[((num / 100) | 0) % 10] + ' hundred';
		if (num % 100 != 0) {
			result += ' and ';
		}
	}
	num %= 100;
	if (num <= 9) {
		result += n1[num];
	}
	else if (num >= 10 && num <= 19) {
		result += n2[num - 10];
	}
	else if (num >= 20 && num <= 99) {
		result += n3[((num / 10) | 0) - 2];
		if (num % 10 != 0) {
			result += ' ';
			result += n1[(num % 10)];
		}
	}

	return result.charAt(0).toUpperCase() + result.slice(1);
}