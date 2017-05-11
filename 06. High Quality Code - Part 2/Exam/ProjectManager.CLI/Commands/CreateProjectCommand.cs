using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateProjectCommand : ICommand
    {
        private IDatabase database;

        private IModelsFactory factory;

        public CreateProjectCommand(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database")
                .IsNull()
                .Throw();
            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory")
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

            string name = prms[0];
            string startingDate = prms[1];
            string endingDate = prms[2];
            string state = prms[3];

            if (this.database.Projects.Any(x => x.Name == name))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.factory.CreateProject(name, startingDate, endingDate, state);
            this.database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}