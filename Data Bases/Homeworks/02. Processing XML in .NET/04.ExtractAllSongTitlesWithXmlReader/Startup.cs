  using System;
using System.Text;
using System.Xml;

namespace _04.ExtractAllSongTitlesWithXmlReader
{
    public class Startup
    {
        public static void Main()
        {
            var songTitles = new StringBuilder();
            songTitles.AppendLine("Songs present in the catalog:");
            songTitles.AppendLine("-----------------------------");
            using (XmlReader reader = XmlReader.Create(@"..\..\..\catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        songTitles.AppendLine(reader.ReadInnerXml());
                    }
                }
            }

            Console.WriteLine(songTitles.ToString().Trim());
        }
    }
}
