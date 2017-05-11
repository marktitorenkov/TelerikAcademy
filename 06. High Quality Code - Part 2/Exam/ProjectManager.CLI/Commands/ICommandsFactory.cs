namespace ProjectManager.Commands
{
    /// <summary>
    /// Initilizes the correct command class based on a given command string
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Initilizes the correct command based on commandName
        /// </summary>
        /// <param name="commandName">String that represents the command</param>
        /// <returns>A command based on the passed string</returns>
        ICommand CreateCommandFromString(string commandName);
    }
}