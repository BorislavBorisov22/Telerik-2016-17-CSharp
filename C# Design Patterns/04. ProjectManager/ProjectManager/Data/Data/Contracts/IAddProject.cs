using ProjectManager.Data.Models.Contracts;

namespace ProjectManager.Data.Data.Contracts
{
    public interface IAddProject
    {
        void AddProject(IProject project);
    }
}