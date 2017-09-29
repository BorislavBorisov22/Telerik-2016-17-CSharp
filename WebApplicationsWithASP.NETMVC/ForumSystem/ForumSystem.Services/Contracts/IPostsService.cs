using System.Collections.Generic;
using ForumSystem.Data.Models;

namespace ForumSystem.Services.Contracts
{
    public interface IPostsService
    {
        IEnumerable<Post> GetAll();

        void Add(Post post);
    }
}