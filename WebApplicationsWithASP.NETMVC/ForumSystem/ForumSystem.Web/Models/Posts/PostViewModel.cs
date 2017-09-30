using ForumSystem.Data.Models;
using ForumSystem.Web.Infrastructure;
using System;
using AutoMapper;

namespace ForumSystem.Web.Models.Posts
{
    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime? CreatedOn { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(m => m.AuthorEmail, cfg => cfg.MapFrom(c => c.Author.Email));
        }
    }
}