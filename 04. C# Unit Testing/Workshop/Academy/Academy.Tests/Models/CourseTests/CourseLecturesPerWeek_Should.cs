using System;
using Academy.Models;
using NUnit.Framework;

namespace Academy.Tests.Models.CourseTests
{
	[TestFixture]
	public class CourseLecturesPerWeek_Should
	{
		[Test]
		public void ThrowArgumentException_WhenPassedValueIsTooSmall()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Course("Name", 0, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1)));
		}

		[Test]
		public void ThrowArgumentException_WhenPassedValueIsTooBig()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => new Course("Name", 8, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1)));
		}

		[Test]
		public void CorrectlyAssignValidValue()
		{
			// Arrange
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Act
			course.LecturesPerWeek = 4;

			// Assert
			Assert.AreEqual(4, course.LecturesPerWeek);
		}
	}
}
