function solve(args) {
	let [rows, cols] = args[0].split(' ').map(Number);
	let rowsStr = args.slice(1);
	let lastPos = {};
	let pos = 
	{
		r: rows / 2 | 0,
		c: cols / 2 | 0
	};
	let maze = new Array(rows);
	for (let r = 0; r < rows; r += 1) {
		maze[r] = rowsStr[r].split(' ').map(Number);
	}

	function bitAt(num, pos) {
		return (num & (1 << pos)) != 0;
	}
	function notVisited(r, c) {
		try {
			return maze[r][c] !== -1;
		}
		catch(e) {
			return true;
		}
	}

	while(pos.r >= 0 && pos.r < rows && pos.c >= 0 && pos.c < cols) {
		let value = maze[pos.r][pos.c];
		let dr = 0;
		let dc = 0;
		if (bitAt(value, 0) && notVisited(pos.r - 1, pos.c)) {
			dr = -1;
		}
		else if (bitAt(value, 1) && notVisited(pos.r, pos.c + 1)) {
			dc = 1;
		}
		else if (bitAt(value, 2) && notVisited(pos.r + 1, pos.c)) {
			dr = 1;
		}
		else if (bitAt(value, 3) && notVisited(pos.r, pos.c - 1)) {
			dc = -1;
		}
		else {
			console.log(`No JavaScript, only rakiya ${pos.r} ${pos.c}`);
			return;
		}
		maze[pos.r][pos.c] = -1;
		lastPos.r = pos.r;
		lastPos.c = pos.c;
		pos.r += dr;
		pos.c += dc;
	}
	console.log(`No rakiya, only JavaScript ${lastPos.r} ${lastPos.c}`);
}