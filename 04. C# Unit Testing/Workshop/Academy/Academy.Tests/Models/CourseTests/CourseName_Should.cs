using System;
using Academy.Models;
using NUnit.Framework;

namespace Academy.Tests.Models.CourseTests
{
	[TestFixture]
	public class CourseName_Should
	{
		[Test]
		public void ThrowArgumentException_WhenPassedValueIsTooShort()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Course(" ", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1)));
		}

		[Test]
		public void ThrowArgumentException_WhenPassedValueIsTooLong()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Course(new string(' ', 46), 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1)));
		}

		[Test]
		public void CorrectlyAssignValidValue()
		{
			// Arrange
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Act
			course.Name = "New name";

			// Assert
			Assert.AreEqual("New name", course.Name);
		}
	}
}
