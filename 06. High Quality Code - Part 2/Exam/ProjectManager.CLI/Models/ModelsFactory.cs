using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using System;
using ProjectManager.Models.Enums;

namespace ProjectManager.Models
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly Validator validator = new Validator();

        public IProject CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;
            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);
            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            ProjectState projectState;
            var projectStateSuccessful = Enum.TryParse<ProjectState>(state, out projectState);
            if (!projectStateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed state!");
            }

            var project = new Project(name, starting, end, projectState);
            this.validator.Validate(project);

            return project;
        }

        public ITask CreateTask(IUser owner, string name, string state)
        {
            TaskState taskState;
            var taskStateSuccesful = Enum.TryParse<TaskState>(state, out taskState);
            if (!taskStateSuccesful)
            {
                throw new UserValidationException("Failed to parse the passed state!");
            }

            var task = new Task(name, owner, taskState);
            this.validator.Validate(task);

            return task;
        }

        public IUser CreateUser(string username, string email)
        {
            var user = new User(username, email);
            this.validator.Validate(user);

            return user;
        }
    }
}