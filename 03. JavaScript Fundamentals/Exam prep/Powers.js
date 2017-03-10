function solve(params) {
	function ln(i, n) {
		if (i == 0) {
			return n - 1;
		}
		else {
			return i - 1;
		}
	}
	function rn(i, n) {
		if (i == n - 1) {
			return 0;
		}
		else {
			return i + 1;
		}
	}
	
	let nk = params[0].split(' ').map(Number),
		n = nk[0],
		k = nk[1],
		s = params[1].split(' ').map(Number),
		snew = new Array(),
		result = 0;
	

	for (let j = 0; j < k; j++) {
		for (let i = 0; i < n; i++) {
			if (s[i] == 0) {
				snew[i] = Math.abs(s[ln(i, n)] - s[rn(i, n)]);
			}
			else if (s[i] % 2 == 0) {
				snew[i] = Math.max(s[ln(i, n)], s[rn(i, n)]);
			}
			else if (s[i] == 1) {
				snew[i] = s[ln(i, n)] + s[rn(i, n)];
			}
			else {
				snew[i] = Math.min(s[ln(i, n)], s[rn(i, n)]);
			}
		}
		for (let t = 0; t < n; t++) {
			s[t] = snew[t];
		}
	}

	for (let i = 0; i < n; i++) {
		result += s[i];
	}
	return result;
}