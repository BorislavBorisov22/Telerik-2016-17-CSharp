using System;
using Newtonsoft.Json;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TelerikAcadeymYoutubeRssFeed.Models;
using TelerikAcadeymYoutubeRssFeed.Core;

namespace TelerikAcadeymYoutubeRssFeed
{
    public class StartUp
    {
        public static void Main()
        {
            string url = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var webClient = new WebClient();
            string xmlFilePath = "../../info.xml";
            webClient.DownloadFile(url, xmlFilePath);

            var jsonProvider = new JsonProvider();
            var videoManager = new VideoManager();
            var htmlProvider = new HTMLProvider();

            string jsonRssContent = jsonProvider.GetJSONFromXml(xmlFilePath);

            var videos = videoManager.GetVideosFromJSON(jsonRssContent);

            string resultHTML = htmlProvider.BuildVideoInformationHTML(videos);

            string htmlFilePath = "../../result.html";
            File.WriteAllText(htmlFilePath, resultHTML);
            Console.WriteLine("Telerik rss feed videos have been succesfully saved in result.html");
        }
    }
}
