/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
	let Validate = {
		title: function (title) {
			if (/^$|^\s|\s$|\s\s+/.test(title)) {
				throw 'Invalid title';
			}
		},
		presentations: function (presentations) {
			if (!presentations || presentations.length === 0) {
				throw 'No presentations';
			}
			presentations.forEach(this.title);
		},
		studentName: function (name) {
			if (!(/^[A-Z][a-z]* [A-Z][a-z]*$/.test(name))) {
				throw 'Invalid name';
			}
		},
		ID: function (id, collection) {
			if (id < 1 || id > collection.length) {
				throw 'Invalid ID';
			}
		}
	};

	let Course = {
		init: function (title, presentations) {
			Validate.title(title);
			Validate.presentations(presentations);

			this.title = title;
			this.presentations = presentations;
			this.students = [];

			return this;
		},
		addStudent: function (name) {
			Validate.studentName(name);

			name = name.split(' ');
			let id = this.students.length + 1;
			this.students.push({
				firstname: name[0],
				lastname: name[1],
				ID: id,
				score: 0,
				submitedHomeworks: 0,
				finalScore: 0
			});
			return id;
		},
		getAllStudents: function () {
			let arr = [];
			this.students.forEach(function (s) {
				arr.push({
					firstname: s.firstname,
					lastname: s.lastname,
					id: s.ID
				});
			});
			return arr;
		},
		submitHomework: function (studentID, homeworkID) {
			Validate.ID(studentID, this.students);
			Validate.ID(homeworkID, this.presentations);
			this.students[studentID - 1].submitedHomeworks += 1;
		},
		pushExamResults: function (results) {
			let students = this.students;
			results.forEach(function(r) {
				let id = r.StudentID;
				let score = Number(r.score);
				Validate.ID(id, students);
				if (!score || students[id - 1].score !== 0) {
					throw 'Cannot add score';
				}
				students[id - 1].score = score;
			});
		},
		getTopStudents: function () {
			let totalHomeworks = this.presentations.length;
			this.students.forEach(function(s) {
				s.finalScore = (function() {
					return (s.score * 0.75) + ((s.submitedHomeworks / totalHomeworks) * 0.25)
				})();
			});
			return this.students.sort(function(a, b) {
				return b.finalScore - a.finalScore;
			});
		}
	};

	return Course;
}

module.exports = solve;
