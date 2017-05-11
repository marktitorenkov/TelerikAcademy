namespace ProjectManager.Core
{
    /// <summary>
    /// Keeps references to all external dependencies for the CLI application and starts the main read loop
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Starts the main read loop
        /// </summary>
        void Start();
    }
}