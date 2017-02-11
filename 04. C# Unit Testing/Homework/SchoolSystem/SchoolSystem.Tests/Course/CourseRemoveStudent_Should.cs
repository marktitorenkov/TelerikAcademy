namespace SchoolSystem.Tests.Course
{
	using System;
	using Contracts;
	using Moq;
	using NUnit.Framework;
	using SchoolSystem;

	[TestFixture]
	public class CourseRemoveStudent_Should
	{
		[Test]
		public void ThrowArgumentNullException_WhenStudentIsNull()
		{
			// Arrange
			var course = new Course("Valid name");
			var mockStudent = new Mock<IStudent>();
			course.AddStudent(mockStudent.Object);
			
			// Act and Assert
			Assert.Throws<ArgumentNullException>(() => course.RemoveStudent(null));
		}

		[Test]
		public void ThrowException_WhenStudentIsNotInTheCourse()
		{
			// Arrange
			var course = new Course("Valid name");
			var mockStudent = new Mock<IStudent>();
			var mockStudentNotIncourse = new Mock<IStudent>();
			course.AddStudent(mockStudent.Object);

			// Act and Assert
			Assert.Throws<Exception>(() => course.RemoveStudent(mockStudentNotIncourse.Object));
		}
	}
}
