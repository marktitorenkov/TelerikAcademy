using System;
using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Models.CourseTests
{
	[TestFixture]
	public class CourseToString_Should
	{
		[Test]
		public void IterateOverCollectionOfLectures()
		{
			// Arrange
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));
			var mockLecture = new Mock<ILecture>();
			mockLecture.Setup(x => x.ToString());
			course.Lectures.Add(mockLecture.Object);

			// Act
			course.ToString();

			// Assert
			mockLecture.Verify(x => x.ToString(), Times.Once);
		}

		[Test]
		public void ReturnMessage_WhenLecturesCollectionIsEmpty()
		{
			// Arrange
			var course = new Course("Name", 5, new DateTime(2017, 1, 1), new DateTime(2017, 2, 1));

			// Act
			var result = course.ToString();

			// Assert
			StringAssert.Contains("no lectures", result.ToLower());
		}
	}
}
