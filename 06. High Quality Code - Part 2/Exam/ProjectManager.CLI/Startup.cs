using ProjectManager.Commands;
using ProjectManager.Common;
using ProjectManager.Common.Providers;
using ProjectManager.Core;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var fileLogger = new FileLogger();

            var console = new ConsoleProvider();

            var database = new Database();

            var modelsFactory = new ModelsFactory();

            var commandsFactory = new CommandsFactory(database, modelsFactory);

            var commandProcessor = new CommandProcessor(commandsFactory);

            var engine = new Engine(fileLogger, console, commandProcessor);
            engine.Start();
        }
    }
}