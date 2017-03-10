function solve() {
	// Your classes
	function copyApp(app) {
		const result = {
			name: app.name,
			description: app.description,
			version: app.version,
			rating: app.rating,
		};
		if (app instanceof Store) {
			result.apps = app.apps;
		}
		return result;
	}

	class App {
		constructor(name, description, version, rating) {
			this.name = name;
			this.description = description;
			this.version = version;
			this.rating = rating;
		}

		get name() {
			return this._name;
		}
		set name(x) {
			if (typeof (x) !== 'string') {
				throw new Error();
			}
			if (!/^[A-Za-z0-9\s]{1,24}$/.test(x)) {
				throw new Error();
			}
			this._name = x;
		}

		get description() {
			return this._description;
		}
		set description(x) {
			if (typeof (x) !== 'string') {
				throw new Error();
			}
			this._description = x;
		}

		get version() {
			return this._version;
		}
		set version(x) {
			if (typeof (x) !== 'number') {
				throw new Error();
			}
			if (x <= 0) {
				throw new Error();
			}
			if (x <= this.version) {
				throw new Error();
			}
			this._version = x;
		}

		get rating() {
			return this._rating;
		}
		set rating(x) {
			if (typeof (x) !== 'number') {
				throw new Error();
			}
			if (x < 1 || x > 10) {
				throw new Error();
			}
			this._rating = x;
		}

		release(param) {
			if (typeof (param) === 'number') {
				const version = param;

				if (version <= this.version) {
					throw new Error();
				}
				this.version = version;
			}
			else {
				const options = param;

				if (options.version === undefined) {
					throw new Error();
				}
				this.version = options.version;
				if (options.description !== undefined) {
					this.description = options.description;
				}
				if (options.rating !== undefined) {
					this.rating = options.rating;
				}
			}
			return this;
		}
	}

	class Store extends App {
		constructor(name, description, version, rating) {
			super(name, description, version, rating);
			this.apps = [];
		}

		uploadApp(app) {
			if (!(app instanceof App)) {
				throw new Error();
			}
			const index = this.apps.findIndex(x => x.name === app.name);
			if (index >= 0) {
				this.apps.splice(index, 1);
			}
			this.apps.push(copyApp(app));
			return this;
		}

		takedownApp(name) {
			const index = this.apps.findIndex(x => x.name === name);
			if (index < 0) {
				throw new Error();
			}
			this.apps.splice(index, 1);
			return this;
		}

		search(pattern) {
			const testPattern = new RegExp(pattern, 'i');
			const filtered = this.apps.filter(x => testPattern.test(x.name))
				.sort((a, b) => a.name < b.name ? -1 : a.name > b.name ? 1 : 0);
			return filtered;
		}

		listMostRecentApps(count) {
			count = count || 10;
			const appsCopy = this.apps.slice();

			const recent = appsCopy.slice(-count).reverse();
			return recent;
		}

		listMostPopularApps(count) {
			count = count || 10;
			const appsCopy = this.apps.slice();

			const popular = appsCopy
				.map((app, index) => ({ app, index }))
				.sort((a, b) => a.app.rating !== b.app.rating ? b.app.rating - a.app.rating : b.index - a.index)
				.slice(0, count).map(x => x.app);
			return popular;
		}
	}

	class Device {
		constructor(hostname, apps) {
			this.hostname = hostname;
			this.apps = apps;
			this._stores = apps.filter(x => x instanceof Store).map(x => copyApp(x));
		}

		get hostname() {
			return this._hostname;
		}
		set hostname(x) {
			if (typeof (x) !== 'string') {
				throw new Error();
			}
			if (x.length < 1 || x.length > 12) {
				throw new Error();
			}
			this._hostname = x;
		}

		get apps() {
			return this._apps;
		}
		set apps(x) {
			if (!x.every(x => x instanceof App)) {
				throw new Error();
			}
			this._apps = x.map(x => copyApp(x));
		}

		search(pattern) {
			const testPattern = new RegExp(pattern, 'i');
			const stores = this._stores;
			const appsInstores = [].concat(...stores.map(x => x.apps));
			const filtered = appsInstores.filter(x => testPattern.test(x.name));
			const groupedByname = {};
			filtered.forEach(function (app) {
				const name = app.name;
				if (groupedByname[name] === undefined || app.version > groupedByname[name].version) {
					groupedByname[name] = app;
				}
			});
			const result = Object.values(groupedByname).sort((a, b) => a.name - b.name);

			return result;
		}

		install(name) {
			const stores = this._stores;
			const appversions = [];

			stores.forEach(function (store) {
				const found = store.apps.find(x => x.name == name);
				if (found) {
					appversions.push(found);
				}
			});

			if (appversions.length === 0) {
				throw new Error();
			}

			appversions.sort((a, b) => b.version - a.version);

			const toBeInstalled = appversions[0];

			const installedIndex = this.apps.findIndex(x => x.name === name);

			if (installedIndex < 0) {
				this.apps.push(toBeInstalled);
			}

			return this;
		}

		uninstall(name) {
			const index = this.apps.findIndex(x => x.name === name);

			if (index < 0) {
				throw new Error();
			}

			this.apps.splice(index, 1);

			return this;
		}

		listInstalled() {
			const arrayCopy = this.apps.slice();

			arrayCopy.sort((a, b) => a.name < b.name ? -1 : a.name > b.name ? 1 : 0);

			return arrayCopy;
		}

		update() {
			this.apps.forEach((app, index, apps) => {
				const name = app.name;

				let bestApp = app;
				this._stores.forEach(store => {
					const currApp = store.apps.find(x => x.name === name);
					if (currApp !== undefined && bestApp.version < currApp.version) {
						bestApp = currApp;
					}
				});

				apps[index] = bestApp;
			});

			return this;
		}
	}

	return {
		createApp(name, description, version, rating) {
			// returns a new App object
			return new App(name, description, version, rating);
		},
		createStore(name, description, version, rating) {
			// returns a new Store object
			return new Store(name, description, version, rating);
		},
		createDevice(hostname, apps) {
			// returns a new Device object
			return new Device(hostname, apps);
		}
	};
}

// Submit the code above this line in bgcoder.com
module.exports = solve;
