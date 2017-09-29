using ForumSystem.Data.Models;
using ForumSystem.Services.Contracts;
using ForumSystem.Web.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            if (postsService == null)
            {
                throw new ArgumentNullException("PostsService cannot be null!");
            }

            this.postsService = postsService;
        }

        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .Select(p => new PostViewModel()
                {
                    Title = p.Title,
                    Content = p.Content,
                    CreatedOn = p.CreatedOn,
                    AuthorEmail = p.Author?.Email
                });                   

            return this.View(posts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Add(PostViewModel post)
        {
            var postDataModel = new Post()
            {
                Title = post.Title,
                Content = post.Content
            };

            this.postsService.Add(postDataModel);

            return this.RedirectToAction("Index");
        }
    }
}