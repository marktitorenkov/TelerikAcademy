using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private IModelsFactory factory;

        private IDatabase database;

        public CommandsFactory(IDatabase database, IModelsFactory factory)
        {
            this.database = database;
            this.factory = factory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            var command = this.BuildCommand(commandName);

            switch (command)
            {
                case "createproject":
                    return new CreateProjectCommand(this.database, this.factory);
                case "createuser":
                    return new CreateUserCommand(this.database, this.factory);
                case "createtask":
                    return new CreateTaskCommand(this.database, this.factory);
                case "listprojects":
                    return new ListProjectsCommand(this.database);
                default:
                    throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string BuildCommand(string parameters)
        {
            var command = string.Empty;

            for (int i = 0; i < parameters.Length; i++)
            {
                command += parameters[i].ToString().ToLower();
            }

            return command;
        }
    }
}