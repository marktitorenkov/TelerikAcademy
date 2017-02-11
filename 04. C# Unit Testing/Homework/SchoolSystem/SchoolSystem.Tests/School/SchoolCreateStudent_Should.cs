namespace SchoolSystem.Tests.School
{
	using NUnit.Framework;
	using SchoolSystem;

	[TestFixture]
	public class SchoolCreateStudent_Should
	{
		[Test]
		public void ReturnStudentWithCorrectName_WhenValidNameIsPassed()
		{
			// Arrange
			var school = new School();

			// Act
			var student = school.CreateStudent("Valid", "Name");

			// Assert
			Assert.AreEqual(student.FirstName, "Valid");
			Assert.AreEqual(student.LastName, "Name");
		}

		[Test]
		public void ReturnStudentWithCorrectStartID_WhenValidNameIsPassed()
		{
			// Arrange
			var school = new School();

			// Act
			var student = school.CreateStudent("Valid", "Name");

			// Assert
			Assert.AreEqual(student.Id, 10000);
		}

		[Test]
		public void ReturnStudentsWithConsecutiveIDs_WhenValidNameIsPassed()
		{
			// Arrange
			var school = new School();

			// Act
			var student1 = school.CreateStudent("Valid", "Name");
			var student2 = school.CreateStudent("Valid", "Name");

			// Assert
			Assert.AreEqual(student1.Id, 10000);
			Assert.AreEqual(student2.Id, 10001);
		}

		[Test]
		public void AddsStudentToCourse_WhenValidNameIsPAssed()
		{
			// Arrange
			var school = new School();

			// Act
			var student = school.CreateStudent("Valid", "Name");

			// Assert
			Assert.That(school.Students.Contains(student));
		}
	}
}
