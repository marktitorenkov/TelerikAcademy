using ProjectManager.Models.Enums;

namespace ProjectManager.Models
{
    public interface ITask
    {
        string Name { get; set; }

        IUser Owner { get; set; }

        TaskState State { get; set; }
    }
}