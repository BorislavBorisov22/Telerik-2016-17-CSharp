using System;
using System.Linq;
using System.Xml.Linq;

namespace _05.ExtractAllSongTitlesWithLinq
{
    public class StartUp
    {
        public static void Main()
        {
            var doc = XDocument.Load("../../../catalog.xml");

            doc.Root.Descendants()
                .Where(node => node.Name == "title")
                .Select(node => node.Value)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
