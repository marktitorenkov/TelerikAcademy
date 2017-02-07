namespace SchoolSystem.Tests.Course
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SchoolSystem;

	[TestClass]
	public class CourseAddStudent_Should
	{
		[TestMethod]
		public void CourseAddStudent_Should_ThrwoAnException_WhenLimitExceded()
		{
			var course = new Course("Valid name");
			var validStudent = new Student("Valid", "Name", 0);

			Assert.ThrowsException<Exception>(delegate ()
			{
				for (int i = 0; i <= 30; i++)
				{
					course.AddStudent(validStudent);
				}
			});
		}

		[TestMethod]
		public void CourseAddStudent_ShouldNot_ThrwoAnException_WhenInLimits()
		{
			var course = new Course("Valid name");
			var validStudent = new Student("Valid", "Name", 0);

			for (int i = 0; i < 30; i++)
			{
				course.AddStudent(validStudent);
			}
		}

		[TestMethod]
		public void CourseAddStudent_Should_ThrowAnArguemtnNullException_WhenStudentIsNull()
		{
			var course = new Course("Valid name");

			Assert.ThrowsException<ArgumentNullException>(delegate ()
			{
				course.AddStudent(null);
			});
		}
	}
}
