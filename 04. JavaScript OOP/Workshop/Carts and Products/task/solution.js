function solve() {
	function getProduct(productType, name, price) {
		return {
			productType: productType,
			name: name,
			price: +price
		};
	}

	function getShoppingCart() {
		return {
			products: [],
			add: function (product) {
				this.products.push(product);
				return this;
			},
			remove: function (product) {
				for (let i in this.products) {
					if (this.products[i].name === product.name &&
						this.products[i].price === product.price &&
						this.products[i].productType === product.productType) {
						this.products.splice(i, 1);
						return this;
					}
				}
				throw "Error";
			},
			showCost: function () {
				let sum = 0;
				for (let i in this.products) {
					sum += this.products[i].price;
				}
				return sum;
			},
			showProductTypes: function () {
				let uniquePT = [];
				for (let i in this.products) {
					let curr = this.products[i].productType;
					if (uniquePT.indexOf(curr) < 0) {
						uniquePT.push(curr);
					}
				}
				return uniquePT.sort();
			},
			getInfo: function () {
				let groups = [];
				for (let p of this.products) {
					let isRepeated = false;
					for (let g of groups) {
						if (p.name === g.name) {
							isRepeated = true;
							g.totalPrice += p.price;
							g.quantity += 1;
							break;
						}
					}
					if (!isRepeated) {
						groups.push({
							name: p.name,
							totalPrice: p.price,
							quantity: 1
						});
					}
				}
				return {
					totalPrice: this.showCost(),
					products: groups
				};
			}
		};
	}

	return {
		getProduct: getProduct,
		getShoppingCart: getShoppingCart
	};
}

module.exports = solve();
