using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Data
{
    /// <summary>
    /// Represents a storage database for projects
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Stores all of the projects
        /// </summary>
        IList<IProject> Projects { get; }
    }
}
