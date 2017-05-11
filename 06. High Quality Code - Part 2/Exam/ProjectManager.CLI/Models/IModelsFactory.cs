namespace ProjectManager.Models
{
    /// <summary>
    /// Ensuraes that valid instances of models are created.
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// Creates a new Project
        /// </summary>
        /// <param name="name">Project name</param>
        /// <param name="startingDate">Project starting date</param>
        /// <param name="endingDate">Project ending date</param>
        /// <param name="state">Project state</param>
        /// <returns>A new instance of project</returns>
        IProject CreateProject(string name, string startingDate, string endingDate, string state);

        /// <summary>
        /// Creates a new Task
        /// </summary>
        /// <param name="owner">Task owner</param>
        /// <param name="name">Task name</param>
        /// <param name="state">Task state</param>
        /// <returns>A new instance of Task</returns>
        ITask CreateTask(IUser owner, string name, string state);

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Valid E-mail addresss</param>
        /// <returns></returns>
        IUser CreateUser(string username, string email);
    }
}