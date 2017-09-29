using ForumSystem.Data.Models;
using ForumSystem.Data.Repositories;
using ForumSystem.Data.SaveContext;
using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForumSystem.Services
{
    public class PostsService : IService, IPostsService
    {
        private readonly IEfRepository<Post> postsRepository;
        private readonly ISaveContext saveContext;

        public PostsService(IEfRepository<Post> postsRepository, ISaveContext saveContext)
        {
            this.postsRepository = postsRepository;
            this.saveContext = saveContext;
        }

        public IEnumerable<Post> GetAll()
        {
            return this.postsRepository.All.ToList();
        }

        public void Add(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("Cannot add null as a post!");
            }

            this.postsRepository.Add(post);
            this.saveContext.Commit();
        }
    }
}
