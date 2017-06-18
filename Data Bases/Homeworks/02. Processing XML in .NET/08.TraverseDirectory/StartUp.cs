using System;
using System.IO;
using System.Xml;

namespace TraverseDirectory
{
    public class StartUp
    {
        public static void Main()
        {
            // this path works for me -> change it to any valid path in your computer
            string dirPath = @"D:\TelerikAcademy\C#\Data Bases\Homeworks\02. Processing XML in .NET\ProcessingXML";

            string outputPath = "../../output.xml";

            using (var writer = XmlWriter.Create(outputPath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", dirPath);
                Traverse(writer, dirPath);
                writer.WriteEndDocument();
            }
        }

        private static void Traverse(XmlWriter writer, string dir)
        {
            foreach (var directory in Directory.GetDirectories(dir))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", dir);
                Traverse(writer, directory);
                writer.WriteEndElement();
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileName(file));
                writer.WriteEndElement();
            }
        }
    }
}
