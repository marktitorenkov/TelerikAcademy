using System;
using System.Collections.Generic;
using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Commands.Adding.AddStudentToCourseCommandTests
{
	[TestFixture]
	public class AddStudentToCourseCommandExecute_Should
	{
		[Test]
		public void ThrowArgumentException_WhentheThePassedCourseFormIsInvalid()
		{
			// Arrange
			var factoryMock = new Mock<IAcademyFactory>();

			var engineMock = new Mock<IEngine>();
			var studentMock = new Mock<IStudent>();
			var seasonMock = new Mock<ISeason>();
			var courseMock = new Mock<ICourse>();

			studentMock.Setup(x => x.Username).Returns("samplename");

			seasonMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
			seasonMock.Setup(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });

			engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
			engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

			var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

			// Act & Assert
			Assert.Throws<ArgumentException>(() =>
				command.Execute(new string[] { "samplename", "0", "0", "WRONG!" }
			));
		}

		[Test]
		public void CorrectlyAddStudentToCourse()
		{
			// Arrange
			var factoryMock = new Mock<IAcademyFactory>();

			var engineMock = new Mock<IEngine>();
			var studentMock = new Mock<IStudent>();
			var seasonMock = new Mock<ISeason>();
			var courseMock = new Mock<ICourse>();

			studentMock.Setup(x => x.Username).Returns("samplename");

			courseMock.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

			seasonMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
			seasonMock.Setup(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });

			engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
			engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

			var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

			// Act
			command.Execute(new string[] { "samplename", "0", "0", "onsite" });

			// Assert
			Assert.That(engineMock.Object.Seasons[0].Courses[0].OnsiteStudents.Count == 1);
		}

		[Test]
		public void ReturnASuccessMessageThatContainsTheStudentsUsernameAndSeasonId()
		{
			// Arrange
			var factoryMock = new Mock<IAcademyFactory>();

			var engineMock = new Mock<IEngine>();
			var studentMock = new Mock<IStudent>();
			var seasonMock = new Mock<ISeason>();
			var courseMock = new Mock<ICourse>();

			studentMock.Setup(x => x.Username).Returns("samplename");

			courseMock.Setup(x => x.OnsiteStudents).Returns(new List<IStudent>());

			seasonMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
			seasonMock.Setup(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });

			engineMock.Setup(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
			engineMock.Setup(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

			var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

			// Act
			var result = command.Execute(new string[] { "samplename", "0", "0", "onsite" });

			// Assert
			StringAssert.Contains("samplename", result);
			StringAssert.Contains("0", result);
		}
	}
}
