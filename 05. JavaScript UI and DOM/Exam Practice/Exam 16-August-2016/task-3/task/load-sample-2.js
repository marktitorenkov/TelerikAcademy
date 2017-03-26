(function() {
	var template = Handlebars.compile(solve()());

	var data = {
		title: 'JS UI & DOM 2016',
		posts: [{
			author: 'Cuki',
			text: 'Hello guys',
			comments: [{
				author: 'Kon',
				text: 'Hello'
			}, {
				text: 'Hello'
			}]
		}, {
			author: 'Cuki',
			text: 'This works',
			comments: [{
				author: 'Cuki',
				text: 'Well, ofcourse!\nRegards'
			}, {
				text: 'You are fat',
				deleted: true
			}]
		}, {
			author: 'Pesho',
			text: 'Is anybody out <a href="https://facebook.com/">there</a>?',
			comments: []
		}]
	};

	document.getElementById('forum-container').innerHTML = template(data);
}());
