function solve() {
	const nextId = (function() {
		let id = 0;
		return function() {
			return id += 1;
		};
	})();

	const Validate = {
		isInstanceOf: function(value, type) {
			if (!(value instanceof type)) {
				throw Error('Not correct instance');
			}
		},
		isType: function(value, type) {
			if (typeof (value) !== type) {
				throw Error('Not correct type');
			}
		},
		isInRange: function(value, min, max) {
			if (value < min || value > max) {
				throw Error('Must be in range');
			}
		},
		isPositiveNum: function(value) {
			if (value <= 0) {
				throw Error('Must be positive');
			}
		},
		isInteger: function(value) {
			if (!Number.isInteger(value)) {
				throw Error('Not integer');
			}
		},
		isMicQuality: function(value) {
			if (!/^(high|mid|low)$/.test(value)) {
				throw Error('Not mic quality');
			}
		}
	}

	// Your classes
	class Product {
		constructor(manufacturer, model, price) {
			this.id = nextId();
			this.manufacturer = manufacturer;
			this.model = model;
			this.price = price;
		}

		get manufacturer() {
			return this._manufacturer;
		}
		set manufacturer(value) {
			Validate.isType(value, 'string');
			Validate.isInRange(value.length, 1, 20);
			this._manufacturer = value;
		}

		get model() {
			return this._model;
		}
		set model(value) {
			Validate.isType(value, 'string');
			Validate.isInRange(value.length, 1, 20);
			this._model = value;
		}

		get price() {
			return this._price;
		}
		set price(value) {
			Validate.isType(value, 'number');
			Validate.isPositiveNum(value);
			this._price = value;
		}

		getLabel() {
			return this.constructor.name + ' - ' + this.manufacturer + ' ' + this.model + ' - **' + this.price + '**';
		}
	}

	class SmartPhone extends Product {
		constructor(manufacturer, model, price, screenSize, operatingSystem) {
			super(manufacturer, model, price);
			this.screenSize = screenSize;
			this.operatingSystem = operatingSystem;
		}

		get screenSize() {
			return this._screenSize;
		}
		set screenSize(value) {
			Validate.isType(value, 'number');
			Validate.isPositiveNum(value);
			this._screenSize = value;
		}

		get operatingSystem() {
			return this._operatingSystem;
		}
		set operatingSystem(value) {
			Validate.isType(value, 'string');
			Validate.isInRange(value.length, 1, 10);
			this._operatingSystem = value;
		}
	}

	class Charger extends Product {
		constructor(manufacturer, model, price, outputVoltage, outputCurrent) {
			super(manufacturer, model, price);
			this.outputVoltage = outputVoltage;
			this.outputCurrent = outputCurrent;
		}

		get outputVoltage() {
			return this._outputVoltage;
		}
		set outputVoltage(value) {
			Validate.isType(value, 'number');
			Validate.isInRange(value, 5, 20);
			this._outputVoltage = value;
		}

		get outputCurrent() {
			return this._outputCurrent;
		}
		set outputCurrent(value) {
			Validate.isType(value, 'number');
			Validate.isInRange(value, 100, 3000);
			this._outputCurrent = value;
		}
	}

	class Router extends Product {
		constructor(manufacturer, model, price, wifiRange, lanPorts) {
			super(manufacturer, model, price);
			this.wifiRange = wifiRange;
			this.lanPorts = lanPorts
		}

		get wifiRange() {
			return this._wifiRange;
		}
		set wifiRange(value) {
			Validate.isType(value, 'number');
			Validate.isPositiveNum(value);
			this._wifiRange = value;
		}

		get lanPorts() {
			return this._lanPorts;
		}
		set lanPorts(value) {
			Validate.isType(value, 'number');
			Validate.isPositiveNum(value);
			Validate.isInteger(value);
			this._lanPorts = value;
		}
	}

	class Headphones extends Product {
		constructor(manufacturer, model, price, quality, hasMicrophone) {
			super(manufacturer, model, price);
			this.quality = quality;
			this.hasMicrophone = hasMicrophone;
		}

		get quality() {
			return this._quality;
		}
		set quality(value) {
			Validate.isType(value, 'string');
			Validate.isMicQuality(value);
			this._quality = value;
		}

		get hasMicrophone() {
			return this._hasMicrophone;
		}
		set hasMicrophone(value) {
			this._hasMicrophone = Boolean(value);
		}
	}

	class HardwareStore {
		constructor(name) {
			this._products = [];
			this._earned = 0;
			this.name = name;
		}

		get products() {
			const result = [];

			this._products.forEach(function(el) {
				const index = result.findIndex(x => x === el);

				if (index < 0) {
					result.push(el);
				}
			});

			return result;
		}

		get name() {
			return this._name;
		}
		set name(value) {
			Validate.isType(value, 'string');
			Validate.isInRange(value.length, 1, 20);
			this._name = value;
		}

		stock(product, quantity) {
			Validate.isInstanceOf(product, Product);

			Validate.isType(quantity, 'number');
			Validate.isPositiveNum(quantity);
			Validate.isInteger(quantity);

			for (var i = 0; i < quantity; i++) {
				this._products.push(product);
			}

			return this;
		}

		sell(productId, quantity) {
			Validate.isType(productId, 'number');

			Validate.isType(quantity, 'number');
			Validate.isPositiveNum(quantity);
			Validate.isInteger(quantity);

			const numOfProductsWithId = this._products.filter(x => x.id === productId).length;

			if (quantity > numOfProductsWithId) {
				throw Error('Not enough products');
			}

			let productsleft = quantity;

			do {
				const index = this._products.findIndex(x => x.id === productId);
				this._earned += this._products[index].price;
				this._products.splice(index, 1);
				productsleft -= 1;
			} while (productsleft > 0);

			return this;
		}

		getSold() {
			return this._earned;
		}

		search(arg) {
			let filtered = this._products.slice();
			if (typeof (arg) === 'string') {
				const str = arg;
				const pattern = new RegExp(str, 'i');

				filtered = filtered.filter(x => pattern.test(x.manufacturer) || pattern.test(x.model));
			}
			else {
				const options = arg;

				if (options.hasOwnProperty('manufacturerPattern')) {
					const value = options.manufacturerPattern;

					filtered = filtered.filter(x => x.manufacturer.indexOf(value) > -1);
				}
				if (options.hasOwnProperty('modelPattern')) {
					const value = options.modelPattern;

					filtered = filtered.filter(x => x.model.indexOf(value) > -1);
				}
				if (options.hasOwnProperty('type')) {
					const value = options.type;

					let type;

					switch (value) {
						case "SmartPhone": type = SmartPhone; break;
						case "Charger": type = Charger; break;
						case "Router": type = Router; break;
						case "Headphones": type = Headphones; break;
						default: type = {}; break;
					}

					filtered = filtered.filter(x => x instanceof type);
				}
				if (options.hasOwnProperty('minPrice')) {
					const value = options.minPrice;

					filtered = filtered.filter(x => x.price >= value);
				}
				if (options.hasOwnProperty('maxPrice')) {
					const value = options.maxPrice;

					filtered = filtered.filter(x => x.price <= value);
				}
			}

			const result = [];

			filtered.forEach(function(el) {
				const index = result.findIndex(x => x.product === el);

				if (index < 0) {
					result.push({
						product: el,
						quantity: 1
					});
				}
				else {
					result[index].quantity += 1;
				}
			});

			return result;
		}
	}

	return {
		getSmartPhone(manufacturer, model, price, screenSize, operatingSystem) {
			// returns SmarhPhone instance
			return new SmartPhone(manufacturer, model, price, screenSize, operatingSystem);
		},
		getCharger(manufacturer, model, price, outputVoltage, outputCurrent) {
			// returns Charger instance
			return new Charger(manufacturer, model, price, outputVoltage, outputCurrent);
		},
		getRouter(manufacturer, model, price, wifiRange, lanPorts) {
			// returns Router instance
			return new Router(manufacturer, model, price, wifiRange, lanPorts);
		},
		getHeadphones(manufacturer, model, price, quality, hasMicrophone) {
			// returns Headphones instance
			return new Headphones(manufacturer, model, price, quality, hasMicrophone);
		},
		getHardwareStore(name) {
			// returns HardwareStore instance
			return new HardwareStore(name);
		}
	};
}

// Submit the code above this line in bgcoder.com
module.exports = solve; // DO NOT SUBMIT THIS LINE
