using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Commands
{
    public sealed class CreateTaskCommand : ICommand
    {
        private IDatabase database;

        private IModelsFactory factory;

        public CreateTaskCommand(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateTaskCommand Database")
                .IsNull()
                .Throw();
            Guard.WhenArgument(factory, "CreateTaskCommand ModelsFactory")
                .IsNull()
                .Throw();

            this.database = database;
            this.factory = factory;
        }

        public string Execute(IList<string> prms)
        {
            if (prms.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (prms.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            int projectId = int.Parse(prms[0]);
            int userIndex = int.Parse(prms[1]);
            string name = prms[2];
            string state = prms[3];

            var project = this.database.Projects[projectId];
            var owner = project.Users[userIndex];
            var task = this.factory.CreateTask(owner, name, state);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}