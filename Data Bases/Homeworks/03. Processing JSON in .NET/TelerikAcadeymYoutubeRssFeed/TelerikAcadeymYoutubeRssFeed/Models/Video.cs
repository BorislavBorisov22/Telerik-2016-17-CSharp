using Newtonsoft.Json;
using System.Text;

namespace TelerikAcadeymYoutubeRssFeed.Models
{
    public class Video
    {
       [JsonProperty("title")]
       public string Title { get; set; }
        
       [JsonProperty("link")]
       public Link Link { get; set; }

        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Title: {this.Title}, Link: {this.Link.Href}");

            return result.ToString().Trim();
        }
    }
}
