using ForumSystem.Data.Models;
using ForumSystem.Services.Contracts;
using ForumSystem.Services.Data.Contracts;
using ForumSystem.Web.Models.Posts;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ForumSystem.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IMappingService mappingService;

        public PostsController(IPostsService postsService, IMappingService mappingService)
        {
            if (postsService == null)
            {
                throw new ArgumentNullException("PostsService cannot be null!");
            }

            if (mappingService == null)
            {
                throw new ArgumentNullException("Mappging service cannot be null!");
            }

            this.mappingService = mappingService;
            this.postsService = postsService;
        }

        public ActionResult Index()
        {
            var posts = this.postsService
               .GetAll()
               .Select(p => this.mappingService.Map<PostViewModel>(p))
               .ToList();

            return this.View(posts);
        }

        public ActionResult PostsAsync()
        {
           return this.View();
        }

        public ActionResult GetPostsAsync()
        {
            var posts = this.postsService.GetAll()
                    .Select(this.mappingService.Map<PostViewModel>)
                    .ToList();

            return this.PartialView("PostsTitlesPartial", posts);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
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