namespace SchoolSystem.Tests.School
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SchoolSystem;

	[TestClass]
	public class School_Should
	{
		[TestMethod]
		public void School_Should_InitializeNewStudentsAndCourseLists()
		{
			var school = new School();

			Assert.IsTrue(
				school.Students != null &&
				school.Courses != null
			);
		}
	}
}
