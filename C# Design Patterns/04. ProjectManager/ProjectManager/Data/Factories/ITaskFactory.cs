using ProjectManager.Data.Models.Contracts;

namespace ProjectManager.Data.Factories
{
    public interface ITaskFactory
    {
        ITask GetTask(IUser owner, string name, string state);
    }
}