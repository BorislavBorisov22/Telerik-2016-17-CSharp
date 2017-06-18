using System.Collections.Generic;
using System.Text;
using TelerikAcadeymYoutubeRssFeed.Models;

namespace TelerikAcadeymYoutubeRssFeed.Core
{
    public class HTMLProvider
    {
        public string BuildVideoInformationHTML(IList<Video> videos)
        {
            var html = new StringBuilder();

            html.AppendLine(@"<html><head><meta charset=""UTF-8""></head>");
                html.AppendLine("<body>");
                    html.AppendLine("<ul>");
            foreach (var video in videos)
            {
                html.AppendLine("<li>");
                html.AppendLine($"<h3>{video.Title}</h3>");
                html.AppendLine($@"<iframe src=""http://www.youtube.com/embed/{video.Id}?autoplay=0""frameborder=""0"" allowfullscreen></iframe>");
                html.AppendLine($@"<p><a href=""{video.Link.Href}"">Visit video in youtube</a></p>");
                html.AppendLine("</li>");
            }      
                    html.AppendLine("</ul>");                   
                html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString().Trim();
        }
    }
}
