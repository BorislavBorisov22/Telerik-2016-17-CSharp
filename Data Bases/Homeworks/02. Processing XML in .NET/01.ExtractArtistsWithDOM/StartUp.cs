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

            var artists = GetDifferentArtists(rootElement);

            var result = new StringBuilder();
            foreach (var artistInfo in artists)
            {
                result.AppendLine(string.Format("{0} -> {1} present albums in catalog",artistInfo.Key, artistInfo.Value));
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static Dictionary<string, int> GetDifferentArtists(XmlElement root)
        {
            var artists = new Dictionary<string, int>();
            string artistKey = "artist";

            foreach(XmlElement element in root.ChildNodes)
            {
                string currentArtist = element[artistKey].InnerText;

                if (artists.ContainsKey(currentArtist))
                {
                    artists[currentArtist] += 1;
                }
                else
                {
                    artists.Add(currentArtist, 1);
                }
            }

            return artists;
        }
    }
}
