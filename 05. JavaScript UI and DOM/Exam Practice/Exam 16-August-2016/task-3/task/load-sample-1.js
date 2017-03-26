(function() {
	var template = Handlebars.compile(solve()());

	var data = {
		title: 'Conspiracy Theories',
		posts: [{
			author: '',
			text: 'Dear God,',
			comments: [{
				author: 'G',
				text: 'Yes, my child?'
			}, {
				author: '',
				text: 'I would like to file a bug report.'
			}]
		}, {
			author: 'Cuki',
			text: '<a href="https://xkcd.com/258/">link</a>',
			comments: []
		}]
	};

	document.getElementById('forum-container').innerHTML = template(data);
}());
