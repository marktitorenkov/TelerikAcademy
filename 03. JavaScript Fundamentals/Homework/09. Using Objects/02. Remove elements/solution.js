function solve(args) {
	Array.prototype.remove = function (item) {
		for (let i in this) {
			if (this[i] === item) {
				this.splice(i, 1);
			}
		}
		return this;
	}

	args.remove(args[0]);

	for (let i = 0; i < args.length; i++) {
		console.log(args[i]);
	}
}