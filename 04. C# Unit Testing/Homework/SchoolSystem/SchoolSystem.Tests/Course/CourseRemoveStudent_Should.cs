namespace SchoolSystem.Tests.Course
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SchoolSystem;

	[TestClass]
	public class CourseRemoveStudent_Should
	{
		[TestMethod]
		public void CourseRemoveStudent_Should_ThrowAnArgumentNullException_WhenStudentIsNull()
		{
			var course = new Course("Valid name");

			Assert.ThrowsException<ArgumentNullException>(delegate ()
			{
				course.RemoveStudent(null);
			});
		}

		[TestMethod]
		public void CourseRemoveStudent_Should_ThrowAnException_WhenStudentIsNotInTheCourse()
		{
			var course = new Course("Valid name");
			var studentInCourse = new Student("Valid", "Name", 0);
			var studentNotInCourse = new Student("Valid", "Name", 1);
			course.AddStudent(studentInCourse);

			Assert.ThrowsException<Exception>(delegate ()
			{
				course.RemoveStudent(studentNotInCourse);
			});
		}
	}
}
