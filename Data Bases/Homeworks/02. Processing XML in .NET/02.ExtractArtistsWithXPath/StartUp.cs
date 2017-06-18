using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ExtractArtistsWithDOM
{
    public class StartUp
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\catalog.xml");

            XmlElement rootElement = doc.DocumentElement;

            var namespaceManager = new XmlNamespaceManager(doc.NameTable);
            namespaceManager.AddNamespace("alb", "catalog");

            var artists = GetDifferentArtists(rootElement, namespaceManager);

            var result = new StringBuilder();
            foreach (var artistInfo in artists)
            {
                result.AppendLine(string.Format("{0} -> {1} present albums in catalog", artistInfo.Key, artistInfo.Value));
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static Dictionary<string, int> GetDifferentArtists(XmlElement root, XmlNamespaceManager namespaceManager)
        {
            var resultArtists = new Dictionary<string, int>();
            string filterQuery = "/alb:catalog/alb:album/alb:artist";
            var artists = root.SelectNodes(filterQuery, namespaceManager);
           
            foreach (XmlElement element in artists)
            {
                if (resultArtists.ContainsKey(element.InnerText))
                {
                    resultArtists[element.InnerText] += 1;
                }
                else
                {
                    resultArtists.Add(element.InnerText, 1);
                }
            }

            return resultArtists;
        }
    }
}
