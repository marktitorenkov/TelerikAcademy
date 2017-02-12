using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Models.SeasonTests
{
	[TestFixture]
	class SeasonListUsers_Should
	{
		[Test]
		public void IterateOverUsersCollection()
		{
			// Arrange
			var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
			var mockStudent = new Mock<IStudent>();
			var mockTrainer = new Mock<ITrainer>();
			mockStudent.Setup(x => x.ToString());
			mockTrainer.Setup(x => x.ToString());
			season.Students.Add(mockStudent.Object);
			season.Trainers.Add(mockTrainer.Object);

			// Act
			string result = season.ListUsers();

			// Assert
			mockStudent.Verify(x => x.ToString(), Times.Once);
			mockTrainer.Verify(x => x.ToString(), Times.Once);
		}

		[Test]
		public void ReturnMessage_WhenUsersCollectionIsEmpty()
		{
			// Arrange
			var season = new Season(2016, 2017, Initiative.SoftwareAcademy);

			// Act
			string result = season.ListUsers();

			// Assert
			StringAssert.Contains("no users", result.ToLower());
		}
	}
}
