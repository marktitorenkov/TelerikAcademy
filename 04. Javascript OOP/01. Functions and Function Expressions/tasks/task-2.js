/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {
	return function findPrimes() {
		function isPrime(n) {
			if (n < 2) {
				return false;
			}
			for (let i = 2; i <= Math.sqrt(n); i += 1) {
				if (n % i === 0) {
					return false;
				}
			}
			return true;
		}
		
		let args = [arguments[0], arguments[1]].map(Number);
		for (let a of args) {
			if (a === undefined || isNaN(a)) {
				throw 'Error';
			}
		}
		let start = args[0];
		let end = args[1];

		let primes = [];	
		for (let i = start; i <= end; i += 1) {
			if (isPrime(i)) {
				primes.push(i);
			}
		}

		return primes;
	}
}

module.exports = solve;
