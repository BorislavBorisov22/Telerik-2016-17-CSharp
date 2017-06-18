using System;
using System.Linq;
using System.Xml.Linq;

namespace ExtractAlbumPricesWithLinq
{
    public class StartUp
    {
        public static void Main()
        {
            int minYear = 2012;
            var document = XDocument.Load("../../../catalog.xml");
            document.Descendants("year")
                .Where(node => int.Parse(node.Value) <= minYear)
                .Select(node => node.Value)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
