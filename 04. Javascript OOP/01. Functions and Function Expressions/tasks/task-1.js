/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function solve() {
	return function sum(nums) {
		if (nums === undefined) {
			throw 'No parameter passed!';
		} 
		if (nums.length === 0) {
			return null;
		} 
		nums = nums.map(Number);
		let result = 0;
		for (let num of nums) {
			if (isNaN(num)) {
				throw 'Array not valid!';
			}
			result += num;
		}
		return result;
	}
}

module.exports = solve;
