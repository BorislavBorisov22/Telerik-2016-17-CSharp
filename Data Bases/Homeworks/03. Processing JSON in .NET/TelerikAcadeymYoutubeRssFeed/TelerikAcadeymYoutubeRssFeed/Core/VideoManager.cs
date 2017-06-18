using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using TelerikAcadeymYoutubeRssFeed.Models;

namespace TelerikAcadeymYoutubeRssFeed.Core
{
    public class VideoManager
    {
        private const string FeedKey = "feed";
        private const string EntryKey = "entry";

        public IList<Video> GetVideosFromJSON(string json)
        {
            var jsonObject = JObject.Parse(json);

            var videos = jsonObject[FeedKey][EntryKey]
                .Select(x => JsonConvert.DeserializeObject<Video>(x.ToString()))
                .ToList();

            return videos;
        }
    }
}
