function solve() {
	class Player {
		constructor(name) {
			this.name = name;
			this.playlists = [];
		}
		
		addPlaylist(playlistToAdd) {
			if (!(playlistToAdd instanceof PlayList)) {
				throw new Error();
			}
			this.playlists.push(playlistToAdd);
			return this;
		}
		
		getPlaylistById(id) {
			const index = this.playlists.findIndex(p => p.id === id);
			const playlistToReturn = this.playlists.slice().splice(index, 1);
			return playlistToReturn;
		}
		
		removePlaylist(id) {
			const index = this.playlists.findIndex(p => p.id === id);
			if (index < 0) {
				throw new Error();
			}
			this.playlists.splice(index, 1);
			return this;
		}
		
		removePlaylist(playlist) {
			const index = this.playlists.findIndex(p => p === playlist);
			if (index < 0) {
				throw new Error();
			}
			this.playlists.splice(index, 1);
			return this;
		}
		
		listPlaylists(page, size) {
			const startIndex = page * size;
			if (startIndex > this.playlists.length || page < 0 || size <= 0) {
				throw new Error();
			}
			const playlistsCopy = this.playlists.slice();
			const playlistsToReturn = playlistsCopy.splice(startIndex, startIndex + size);
			return playlistsToReturn;
		}
		
		contains(playable, playlist) {
			const contains = playlist.playables.find(p =>
				p.id === playable.id &&
				p.title === playable.title &&
				p.author === playable.author
			);
			return contains ? true : false;
		}
		
		search(pattern) {
			const playlistToReturn = this.playlists.filter(playlist => {
				const contains = playlist.find(playable => playable.title.contains(pattern));
				return contains ? true : false;
			});
			return playlistToReturn;
		}
	}

	class PlayList {
		static nextId() {
			PlayList._nextId = (PlayList._nextId || 0) + 1;
			return PlayList._nextId;
		}

		constructor(name) {
			this.id = PlayList.nextId();
			this.name = name;
			this.playables = [];
		}

		addPlayable(playable) {
			this.playables.push(playable);
			return this;
		}

		getPlayableById(id) {
			const playableToReturn = this.playables.find(p => p.id === id);
			if (!playableToReturn) {
				return null;
			}
			return playableToReturn;
		}

		removePlayable(param) {
			let index;
			if (typeof(param) === 'number') {
				const id = param;
				index = this.playables.findIndex(p => p.id === id);
			}
			else {
				const playable = param;
				index = this.playables.findIndex(p => 
					p.id === playable.id &&
					p.title === playable.title &&
					p.author === playable.author
				);
			}
			if (index < 0) {
				throw new Error();
			}
			this.playables.splice(index, 1);
			return this;
		}

		listPlayables(page, size) {
			const startIndex = page * size;
			if (startIndex > this.playables.length || page < 0 || size <= 0) {
				throw new Error();
			}
			const playablesCopy = this.playables.slice();
			const playablesToReturn = playablesCopy.splice(startIndex, size);
			return playablesToReturn;
		}
	}

	class Playable {
		static nextId() {
			Playable._nextId = (Playable._nextId || 0) + 1;
			return Playable._nextId;
		}

		constructor(title, author) {
			this.id = Playable.nextId();
			this.title = title;
			this.author = author;
		}

		play() {
			return `[${this.id}]. [${this.title}] - [${this.author}]`;
		}
	}

	class Audio extends Playable {
		constructor(title, author, length) {
			super(title, author);
			this.length = length
		}

		get length() {
			return this._length; 
		}
		set length(x) {
			if (x < 0) {
				throw new Error();
			}
			this._length = x;
		}

		play() {
			return super.play() + ` - [${this.length}]`;
		}
	}
	
	class Video extends Playable {
		constructor(title, author, imdbRating) {
			super(title, author);
			this.imdbRating = imdbRating;
		}

		get imdbRating() {
			return this._imdbRating; 
		}
		set imdbRating(x) {
			if (x < 1 || x > 5) {
				throw new Error();
			}
			this._imdbRating = x;
		}

		play() {
			return super.play() + ` - [${this.imdbRating}]`;
		}
	}

	const module = {
		getPlayer: function (name){
			// returns a new player instance with the provided name
			return new Player(name);
		},
		getPlaylist: function(name){
			//returns a new playlist instance with the provided name
			return new PlayList(name);
		},
		getAudio: function(title, author, length){
			//returns a new audio instance with the provided title, author and length
			return new Audio(title, author, length);
		},
		getVideo: function(title, author, imdbRating){
			//returns a new video instance with the provided title, author and imdbRating
			return new Video(title, author, imdbRating);
		}
	};

	return module;
}

module.exports = solve;
