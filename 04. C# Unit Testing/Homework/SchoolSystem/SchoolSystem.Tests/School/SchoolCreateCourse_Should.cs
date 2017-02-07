namespace SchoolSystem.Tests.School
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SchoolSystem;

	[TestClass]
	public class SchoolCreateCourse_Should
	{
		[TestMethod]
		public void SchoolCreateCourse_Should_ReturnAValidCourse()
		{
			var school = new School();
			var validCourse = new Course("Valid name");
			var testCourse = school.CreateCourse("Valid name");

			Assert.IsTrue(
				validCourse.Name == testCourse.Name &&
				testCourse.Students != null
			);
		}
	}
}
