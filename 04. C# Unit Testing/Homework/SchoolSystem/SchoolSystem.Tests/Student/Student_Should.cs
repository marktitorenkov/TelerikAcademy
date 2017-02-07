namespace SchoolSystem.Tests.Student
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SchoolSystem;

	[TestClass]
	public class Student_Should
	{
		[TestMethod]
		public void Student_Should_ThrowAnArgumentException_WhenFirstNameIsNotValid()
		{
			Assert.ThrowsException<ArgumentException>(delegate ()
			{
				new Student("", "Valid", 0);
			});
		}

		[TestMethod]
		public void Student_Should_ThrowAnArgumentException_WhenLastNameIsNotValid()
		{
			Assert.ThrowsException<ArgumentException>(delegate ()
			{
				new Student("Valid", "  ", 0);
			});
		}
	}
}