using ProjectManager.Data.Models.Contracts;

namespace ProjectManager.Data.Factories
{
    public interface IProjectFactory
    {
        IProject GetProject(string name, string startingDate, string endingDate, string state);
    }
}
