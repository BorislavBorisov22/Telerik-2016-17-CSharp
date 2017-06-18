using Newtonsoft.Json;
using System.Xml.Linq;

namespace TelerikAcadeymYoutubeRssFeed.Core
{
    public class JsonProvider
    {
        public string GetJSONFromXml(string xmlFilePath)
        {
            var xmlDocument = XDocument.Load(xmlFilePath);
            string json = JsonConvert.SerializeXNode(xmlDocument);

            return json;
        }
    }
}
