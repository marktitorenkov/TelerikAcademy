using System;
using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Commands.Adding.AddStudentToSeasonCommandTests
{
	[TestFixture]
	public class AddStudentToSeasonCommandConstructor_Should
	{
		[Test]
		public void ThrowArgumentNullException_WhenPassedFactoryIsNull()
		{
			// Arrange
			var engineMock = new Mock<IEngine>();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new AddStudentToSeasonCommand(null, engineMock.Object)
			);
		}

		[Test]
		public void ThrowArgumentNullException_WhenPassedEngineIsNull()
		{
			// Arrange
			var factoryMock = new Mock<IAcademyFactory>();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new AddStudentToSeasonCommand(factoryMock.Object, null)
			);
		}

		[Test]
		public void CorrectlyAssignPassedFactory()
		{
			// Arrange
			var engineMock = new Mock<IEngine>();
			var factoryMock = new Mock<IAcademyFactory>();

			// Act
			var command = new AddStudentToSeasonCommandFake(factoryMock.Object, engineMock.Object);

			// Assert
			Assert.AreSame(factoryMock.Object, command.Factoy);
		}

		[Test]
		public void CorrectlyAssignPassedEngine()
		{
			// Arrange
			var engineMock = new Mock<IEngine>();
			var factoryMock = new Mock<IAcademyFactory>();

			// Act
			var command = new AddStudentToSeasonCommandFake(factoryMock.Object, engineMock.Object);

			// Assert
			Assert.AreSame(engineMock.Object, command.Engine);
		}
	}
}
