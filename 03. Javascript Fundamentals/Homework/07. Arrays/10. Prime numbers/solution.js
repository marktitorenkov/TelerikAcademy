function solve(args) {
	let n = +args;
	let primes = new Array();
	
	for (let i = 2; i <= Math.sqrt(n); i++) {
		if (primes[i] !== false) {
			for (let j = 2 * i; j <= n; j += i) {
				primes[j] = false;
			}
		}
	}

	for (let i = n; i => 2; i--) {
		if (primes[i] !== false) {
			return i;
			break;
		}
	}
}