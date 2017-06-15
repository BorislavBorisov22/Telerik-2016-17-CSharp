using ProjectManager.Data.Models.Contracts;

namespace ProjectManager.Data.Factories
{
    public interface IUserFactory
    {
        IUser CreateUser(string username, string email);
    }
}
