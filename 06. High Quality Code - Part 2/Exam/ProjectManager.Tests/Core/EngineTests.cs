using System;
using Moq;
using NUnit.Framework;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Core;

namespace ProjectManager.Tests.Core
{
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Start_ShouldReadSomethingFromTheConsole()
        {
            var fileLoggerMock = new Mock<IFileLogger>();

            var consoleMock = new Mock<IConsoleProvider>();
            consoleMock.Setup(x => x.ReadLine()).Returns("Exit");

            var commandProcessorMock = new Mock<ICommandProcessor>();

            var engine = new Engine(
                fileLoggerMock.Object,
                consoleMock.Object,
                commandProcessorMock.Object);

            engine.Start();

            consoleMock.Verify(x => x.ReadLine(), Times.Once);
        }

        [Test]
        public void Start_ShouldWriteSomethingToTheConsole_WhenCommandExitCommandIsPassed()
        {
            var fileLoggerMock = new Mock<IFileLogger>();

            var consoleMock = new Mock<IConsoleProvider>();
            consoleMock.Setup(x => x.ReadLine()).Returns("Exit");

            var commandProcessorMock = new Mock<ICommandProcessor>();

            var engine = new Engine(
                fileLoggerMock.Object,
                consoleMock.Object,
                commandProcessorMock.Object);

            engine.Start();

            consoleMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Start_ShouldWriteTheCommandExecutionResultToTheConsole()
        {
            var fileLoggerMock = new Mock<IFileLogger>();

            var consoleMock = new Mock<IConsoleProvider>();
            consoleMock.SetupSequence(x => x.ReadLine())
                .Returns("FakeCommand")
                .Returns("Exit");

            var commandProcessorMock = new Mock<ICommandProcessor>();
            commandProcessorMock.Setup(x => x.Process(It.IsAny<string>()))
                .Returns("Expected output");

            var engine = new Engine(
                fileLoggerMock.Object,
                consoleMock.Object,
                commandProcessorMock.Object);

            engine.Start();

            consoleMock.Verify(x => x.WriteLine("Expected output"));
        }

        [Test]
        public void Start_ShouldWriteExceptionMessage_WhenAUserValidationExceptionOccurs()
        {
            var fileLoggerMock = new Mock<IFileLogger>();

            var consoleMock = new Mock<IConsoleProvider>();
            consoleMock.SetupSequence(x => x.ReadLine())
                .Returns("FakeCommand")
                .Returns("Exit");

            var commandProcessorMock = new Mock<ICommandProcessor>();
            commandProcessorMock.Setup(x => x.Process(It.IsAny<string>()))
                .Callback(() => throw new UserValidationException("Expected message"));

            var engine = new Engine(
                fileLoggerMock.Object,
                consoleMock.Object,
                commandProcessorMock.Object);

            engine.Start();

            consoleMock.Verify(x => x.WriteLine(It.IsRegex("Expected message")));
        }

        [Test]
        public void Start_ShoulLogExceptionMessage_WhenGenericExceptionOccurs()
        {
            var fileLoggerMock = new Mock<IFileLogger>();

            var consoleMock = new Mock<IConsoleProvider>();
            consoleMock.SetupSequence(x => x.ReadLine())
                .Returns("FakeCommand")
                .Returns("Exit");

            var commandProcessorMock = new Mock<ICommandProcessor>();
            commandProcessorMock.Setup(x => x.Process(It.IsAny<string>()))
                .Callback(() => throw new Exception("Expected message"));

            var engine = new Engine(
                fileLoggerMock.Object,
                consoleMock.Object,
                commandProcessorMock.Object);

            engine.Start();

            fileLoggerMock.Verify(x => x.Error("Expected message"));
        }

        [Test]
        public void Start_ShoulWriteSomethingHappened_WhenGenericExceptionOccurs()
        {
            var fileLoggerMock = new Mock<IFileLogger>();

            var consoleMock = new Mock<IConsoleProvider>();
            consoleMock.SetupSequence(x => x.ReadLine())
                .Returns("FakeCommand")
                .Returns("Exit");

            var commandProcessorMock = new Mock<ICommandProcessor>();
            commandProcessorMock.Setup(x => x.Process(It.IsAny<string>()))
                .Callback(() => throw new Exception("Expected message"));

            var engine = new Engine(
                fileLoggerMock.Object,
                consoleMock.Object,
                commandProcessorMock.Object);

            engine.Start();

            consoleMock.Verify(x => x.WriteLine(It.IsRegex("something happened")));
        }
    }
}