using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Models.SeasonTests
{
	[TestFixture]
	class SeasonListCourses_Should
	{
		[Test]
		public void IterateOverCoursesCollection()
		{
			// Arrange
			var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
			var mockCourse = new Mock<ICourse>();
			mockCourse.Setup(x => x.ToString());
			season.Courses.Add(mockCourse.Object);

			// Act
			string result = season.ListCourses();

			// Assert
			mockCourse.Verify(x => x.ToString(), Times.Once);
		}

		[Test]
		public void ReturnMessage_WhenCoursesCollectionIsEmpty()
		{
			// Arrange
			var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

			// Act
			string result = season.ListCourses();

			// Assert
			StringAssert.Contains("no courses", result.ToLower());
		}
	}
}
