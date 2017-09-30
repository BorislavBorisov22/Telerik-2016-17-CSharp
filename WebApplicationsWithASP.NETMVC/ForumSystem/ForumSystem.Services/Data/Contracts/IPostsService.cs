using ForumSystem.Data.Models;
using ForumSystem.Services.Data.Abstractions.Contracts;

namespace ForumSystem.Services.Data.Contracts
{
    public interface IPostsService : IDataService<Post>
    {
    }
}
