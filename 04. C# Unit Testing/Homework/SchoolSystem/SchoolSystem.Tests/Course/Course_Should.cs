namespace SchoolSystem.Tests.Course
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SchoolSystem;

	[TestClass]
	public class Course_Should
	{
		[TestMethod]
		[DataRow("")]
		[DataRow(" ")]
		[DataRow("    ")]
		public void Course_Should_ThrowAnArgumentException_WhenEmptyNameGiven(string name)
		{
			Assert.ThrowsException<ArgumentException>(delegate ()
			{
				new Course(name);
			});
		}

		[TestMethod]
		public void Course_Should_ThrowAnArgumentNullException_WhenNullNameGiven()
		{
			Assert.ThrowsException<ArgumentNullException>(delegate ()
			{
				new Course(null);
			});
		}
	}
}
