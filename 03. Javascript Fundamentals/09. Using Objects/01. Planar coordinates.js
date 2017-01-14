function solve(args) {
	let Point = function (x, y) {
		this.x = x;
		this.y = y;
	}
	let Line = function (point1, point2) {
		this.start = point1;
		this.end = point2;
		this.getLength = function () {
			return Math.sqrt(Math.pow(this.start.x - this.end.x, 2) + Math.pow(this.start.y - this.end.y, 2));
		}
	}

	args = args.map(Number);
	let lines = [];
	for (let i = 0; i < args.length; i += 4) {
		lines.push(new Line(
			new Point(args[i], args[i + 1]),
			new Point(args[i + 2], args[i + 3])
		));
	}

	for (let i = 0; i < lines.length; i++) {
		console.log(lines[i].getLength().toFixed(2));
	}
	
	if (lines[0].getLength() + lines[1].getLength() > lines[2].getLength() &&
		lines[0].getLength() + lines[2].getLength() > lines[1].getLength() &&
		lines[1].getLength() + lines[2].getLength() > lines[0].getLength()) 
	{
		console.log('Triangle can be built');
	}
	else {
		console.log('Triangle can not be built');
	}
}