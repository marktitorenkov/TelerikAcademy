/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/

function solve() {
	let library = (function () {
		let books = [];
		let categories = [];
		function listBooks(arg) {
			if (arg) {
				if (arg.category) {
					return books.filter(function (b) {
						return b.category === arg.category;
					});
				}
				if (arg.author) {
					return books.filter(function (b) {
						return b.author === arg.author;
					});
				}
			}
			else {
				return books;
			}
		}

		function addBook(book) {
			if (typeof (book.title) !== 'string' ||
				book.title.length < 2 ||
				book.title.length > 100) {
				throw 'Invalid title.';
			}
			if (typeof (book.author) !== 'string' ||
				book.author.length === 0) {
				throw 'Invalid author.';
			}
			if (!(/^[0-9]{10}$/.test(book.isbn)) &&
			    !(/^[0-9]{13}$/.test(book.isbn))) {
				throw 'Invalid ISBN';
			}
			if (books.filter(function (b) {
				return b.title === book.title || b.isbn === book.isbn;
			}).length !== 0) {
				throw 'Book already exists.';
			}

			book.ID = books.length + 1;
			books.push(book);
			if (categories.indexOf(book.category) < 0) {
				addCategory(book.category);
			}
			return book;
		}

		function listCategories() {
			return categories;
		}

		function addCategory(category) {
			categories.push(category);
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	}());
	return library;
}

module.exports = solve;
