namespace SchoolSystem.Tests.Course
{
	using System;
	using Contracts;
	using Moq;
	using NUnit.Framework;
	using SchoolSystem;

	[TestFixture]
	public class CourseAddStudent_Should
	{
		[Test]
		public void ThrowArgumentNullException_WhenStudentIsNull()
		{
			// Arrange
			var course = new Course("Valid name");

			// Act and Assert
			Assert.Throws<ArgumentNullException>(() => course.AddStudent(null));
		}

		[Test]
		public void AddStudent_WhenValidStudentIsPassed()
		{
			// Arrange
			var course = new Course("Valid name");
			var mockStudent = new Mock<IStudent>();

			// Act
			course.AddStudent(mockStudent.Object);

			// Assert
			Assert.That(course.Students.Contains(mockStudent.Object));
		}

		[Test]
		public void ThrowArgumentException_WhenMoreThan30StudentsAreAdded()
		{
			// Arrange
			var course = new Course("Valid name");
			var mockStudent = new Mock<IStudent>();

			// Act & Assert
			Assert.Throws<Exception>(() =>
			{
				for (int i = 0; i < 31; i++)
				{
					course.AddStudent(mockStudent.Object);
				}
			});
		}
	}
}
