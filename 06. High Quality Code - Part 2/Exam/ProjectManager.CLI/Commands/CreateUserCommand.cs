using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Commands
{
    public class CreateUserCommand : ICommand
    {
        private IDatabase database;

        private IModelsFactory factory;

        public CreateUserCommand(IDatabase database, IModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateUserCommand Database")
                .IsNull()
                .Throw();
            Guard.WhenArgument(factory, "CreateUserCommand ModelsFactory")
                .IsNull()
                .Throw();

            this.database = database;
            this.factory = factory;
        }

        public string Execute(IList<string> prms)
        {
            if (prms.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (prms.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            int projectId = int.Parse(prms[0]);
            string username = prms[1];
            string email = prms[2];

            bool usersIsNotEmpty = this.database.Projects[projectId]
                .Users.Any();
            bool userWithSameUsernameExists = this.database.Projects[projectId]
                .Users.Any(x => x.Username == username);
            if (usersIsNotEmpty && userWithSameUsernameExists)
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var user = this.factory.CreateUser(username, email);
            this.database.Projects[projectId].Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}