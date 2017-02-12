using System;
using Academy.Models;
using NUnit.Framework;

namespace Academy.Tests.Models.CourseTests
{
	[TestFixture]
	public class CourseStartingDate_Should
	{
		[Test]
		public void ThrowArgumentNullException_WhenPassedValueIsNull()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => new Course("Name", 5, null, new DateTime(2017, 2, 1)));
		}

		[Test]
		public void CorrectlyAssignValidValue()
		{
			// Arrange
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Act
			course.StartingDate = new DateTime(2015, 1, 1);

			// Assert
			Assert.AreEqual(new DateTime(2015, 1, 1), course.StartingDate);
		}
	}
}
