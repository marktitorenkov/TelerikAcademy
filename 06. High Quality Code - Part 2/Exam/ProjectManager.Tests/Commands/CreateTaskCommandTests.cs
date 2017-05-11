using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ProjectManager.Commands;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Tests.Commands
{
    [TestFixture]
    public class CreateTaskCommandTests
    {
        [Test]
        public void Execute_ShouldThrow_WhenInvalidParametersCountArePassed()
        {
            var databaseMock = new Mock<IDatabase>();
            var modelsFactoryMock = new Mock<IModelsFactory>();

            var createTaskCommand = new CreateTaskCommand(databaseMock.Object, modelsFactoryMock.Object);

            Assert.That(() => createTaskCommand.Execute(new string[] { "one", "two" }), Throws.Exception);
        }

        [Test]
        public void Execute_ShouldThrow_WhenEmptyParametersArePassed()
        {
            var databaseMock = new Mock<IDatabase>();
            var modelsFactoryMock = new Mock<IModelsFactory>();

            var createTaskCommand = new CreateTaskCommand(databaseMock.Object, modelsFactoryMock.Object);

            Assert.That(
                () => createTaskCommand.Execute(new string[] { "", "two", "three", "four" }),
                Throws.Exception);
        }

        [Test]
        public void Execute_ShouldCallProjectsPropertysIndexerOfTheDatabaseWithThePassedId()
        {
            int expectedId = 0;

            var userMock = new Mock<IUser>();
            var taskMcok = new Mock<ITask>();
            var projectMock = new Mock<IProject>();
            projectMock.Setup(x => x.Users)
                .Returns(new List<IUser>() { userMock.Object });
            projectMock.Setup(x => x.Tasks)
                .Returns(new List<ITask>());

            var databaseMock = new Mock<IDatabase>();
            var listMock = new Mock<IList<IProject>>();
            listMock.Setup(x => x[expectedId]).Returns(projectMock.Object);
            databaseMock.Setup(x => x.Projects)
                .Returns(listMock.Object);

            var modelsFactoryMock = new Mock<IModelsFactory>();

            var createTaskCommand = new CreateTaskCommand(databaseMock.Object, modelsFactoryMock.Object);

            createTaskCommand.Execute(new string[] { expectedId.ToString(), "0", "name", "state" });

            listMock.Verify(x => x[expectedId]);
        }

        [Test]
        public void Execute_ShouldReturnASuccessMessageContinigSuccessfullyCreated()
        {
            var userMock = new Mock<IUser>();
            var taskMcok = new Mock<ITask>();
            var projectMock = new Mock<IProject>();
            projectMock.Setup(x => x.Users)
                .Returns(new List<IUser>() { userMock.Object });
            projectMock.Setup(x => x.Tasks)
                .Returns(new List<ITask>());

            var databaseMock = new Mock<IDatabase>();
            databaseMock.Setup(x => x.Projects)
                .Returns(new List<IProject>() { projectMock.Object });

            var modelsFactoryMock = new Mock<IModelsFactory>();

            var createTaskCommand = new CreateTaskCommand(databaseMock.Object, modelsFactoryMock.Object);

            var result = createTaskCommand.Execute(new string[] { "0", "0", "name", "state" });

            StringAssert.Contains("Successfully created", result);
        }
    }
}