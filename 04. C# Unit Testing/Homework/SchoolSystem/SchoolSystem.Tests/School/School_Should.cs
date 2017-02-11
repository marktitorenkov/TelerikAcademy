namespace SchoolSystem.Tests.School
{
	using NUnit.Framework;
	using SchoolSystem;
	
	[TestFixture]
	public class School_Should
	{
		[Test]
		public void CorrectlyInitilizeCoursesCollection()
		{
			// Arrange & Act
			var school = new School();

			// Assert
			Assert.IsNotNull(school.Courses);
		}

		[Test]
		public void CorrectlyInitilizeStudentsCollection()
		{
			// Arrange & Act
			var school = new School();

			// Assert
			Assert.IsNotNull(school.Students);
		}
	}
}
