using ForumSystem.Data.Models;
using ForumSystem.Data.Repositories;
using ForumSystem.Data.SaveContext;
using ForumSystem.Services.Data.Abstractions;
using ForumSystem.Services.Data.Contracts;

namespace ForumSystem.Services.Data
{
    public class PostsService : DataService<Post>, IPostsService
    {
        public PostsService(IEfRepository<Post> postsRepository, ISaveContext saveContext)
            :base(postsRepository, saveContext)
        {
        }
    }
}
