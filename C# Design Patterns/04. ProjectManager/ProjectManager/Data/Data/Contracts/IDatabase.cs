using ProjectManager.Data.Data.Contracts;

namespace ProjectManager.Data
{
    public interface IDatabase : IAddProject, IAddTask, IAddUser, IProjectInfo, IProjectsInfo
    {      
    }
}
