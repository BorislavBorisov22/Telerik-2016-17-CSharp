using ProjectManager.Data.Models.Contracts;

namespace ProjectManager.Data.Data.Contracts
{
    public interface IAddUser
    {
        void AddUser(int projectId, IUser user);
    }
}
