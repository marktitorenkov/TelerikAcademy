using ProjectManager.Commands;
using System.Linq;

namespace ProjectManager.Common
{
    public class CommandProcessor : ICommandProcessor
    {
        private ICommandsFactory factory;

        public CommandProcessor(ICommandsFactory factory)
        {
            this.factory = factory;
        }

        public string Process(string commandText)
        {
            if (string.IsNullOrWhiteSpace(commandText))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            var command = this.factory.CreateCommandFromString(commandText.Split(' ')[0]);
            return command.Execute(commandText.Split(' ').Skip(1).ToList());
        }
    }
}
