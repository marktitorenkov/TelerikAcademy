using System;
using System.Collections.Generic;
using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Commands.Adding.AddStudentToSeasonCommandTests
{
	[TestFixture]
	public class AddStudentToSeasonCommandExecute_Should
	{
		[Test]
		public void ThrowArgumentException_WhenPassedStudentIsPartOftheSeason()
		{
			// Arrange
			var factoryMock = new Mock<IAcademyFactory>();

			var engineMock = new Mock<IEngine>();
			var studentMock = new Mock<IStudent>();
			var seasonMock = new Mock<ISeason>();

			studentMock.Setup(x => x.Username).Returns("samplename");

			seasonMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

			engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });
			engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

			var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);
			
			// Act & Assert
			Assert.Throws<ArgumentException>(() => command.Execute(new string[] { "samplename", "0" }));
		}

		[Test]
		public void CorrectlyAddStudentToSeason()
		{
			// Arrange
			var factoryMock = new Mock<IAcademyFactory>();

			var engineMock = new Mock<IEngine>();
			var studentMock = new Mock<IStudent>();
			var seasonMock = new Mock<ISeason>();

			studentMock.Setup(x => x.Username).Returns("samplename");

			seasonMock.Setup(x => x.Students).Returns(new List<IStudent>());

			engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });
			engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

			var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

			// Act
			command.Execute(new string[] { "samplename", "0" });

			// Assert
			Assert.That(engineMock.Object.Seasons[0].Students.Count == 1);
		}

		[Test]
		public void ReturnSuccessMessageThatContainsStudentsUsernameAndSeasonId()
		{
			// Arrange
			var factoryMock = new Mock<IAcademyFactory>();

			var engineMock = new Mock<IEngine>();
			var studentMock = new Mock<IStudent>();
			var seasonMock = new Mock<ISeason>();

			studentMock.Setup(x => x.Username).Returns("samplename");

			seasonMock.Setup(x => x.Students).Returns(new List<IStudent>());

			engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });
			engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

			var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

			// Act
			var result = command.Execute(new string[] { "samplename", "0" });

			// Assert
			StringAssert.Contains("samplename", result);
			StringAssert.Contains("0", result);
		}
	}
}
