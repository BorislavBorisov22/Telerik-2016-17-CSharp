using System;
using System.Xml;

namespace _10.ExtractAlbumPricesWithXPath
{
    public class StartUp
    {
        public static void Main()
        {
            var document = new XmlDocument();
            document.Load("../../../catalog.xml");

            var albums = document.SelectNodes("catalog/album/year[. <= 2012 ]");

            foreach (XmlElement album in albums)
            {
                Console.WriteLine(album.InnerXml);
            }
        }
    }
}
