using System;
using Bytes2you.Validation;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;

namespace ProjectManager.Core
{
    public class Engine : IEngine
    {
        private const string ExitCommand = "exit";
        private const string ProgramQuitMessage = "Program terminated.";
        private const string UnspecifiedErrorMessage = "Opps, something happened. :(";

        private IFileLogger fileLogger;

        private ICommandProcessor commandProcessor;

        private IConsoleProvider console;

        public Engine(IFileLogger fileLogger, IConsoleProvider console, ICommandProcessor commandProcessor)
        {
            Guard.WhenArgument(fileLogger, "Engine Logger provider")
                .IsNull()
                .Throw();

            Guard.WhenArgument(fileLogger, "Engine Console provider")
                .IsNull()
                .Throw();

            Guard.WhenArgument(commandProcessor, "Engine Processor provider")
                .IsNull()
                .Throw();

            this.fileLogger = fileLogger;

            this.console = console;

            this.commandProcessor = commandProcessor;
        }

        public void Start()
        {
            while (true)
            {
                // read from console
                var inputText = this.console.ReadLine();

                if (inputText.ToLower() == ExitCommand)
                {
                    this.console.WriteLine(ProgramQuitMessage);
                    break;
                }

                try
                {
                    var executionResult = this.commandProcessor.Process(inputText);
                    this.console.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.console.WriteLine(UnspecifiedErrorMessage);
                    this.fileLogger.Error(ex.Message);
                }
            }
        }
    }
}