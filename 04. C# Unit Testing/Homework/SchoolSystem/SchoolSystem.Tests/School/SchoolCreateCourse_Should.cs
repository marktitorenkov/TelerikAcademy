namespace SchoolSystem.Tests.School
{
	using NUnit.Framework;
	using SchoolSystem;

	[TestFixture]
	public class SchoolCreateCourse_Should
	{
		[Test]
		public void ReturnCourseWithCorrectName_WhenValidNameIsPassed()
		{
			// Arrange
			var school = new School();

			// Act
			var course = school.CreateCourse("Valid name");

			// Assert
			Assert.AreEqual(course.Name, "Valid name");
		}

		[Test]
		public void AddsTheCourseToTheList_WhenValidNameIsPassed()
		{
			// Arrange
			var school = new School();

			// Act
			var course = school.CreateCourse("Valid name");

			// Assert
			Assert.That(school.Courses.Contains(course));
		}
	}
}
