using System.IO;
using System.Xml.Linq;

namespace TraverseDirectoryWithXDocument
{
    public class StartUp
    {
        public static void Main()
        {
            string dirPath = @"D:\TelerikAcademy\C#\Data Bases\Homeworks\02. Processing XML in .NET\ProcessingXML";
            var rootElement = Traverse(dirPath);
            rootElement.Save("../../output.xml");
        }

        private static XElement Traverse(string dir)
        {
            var element = new XElement("dir", new XAttribute("path", dir));
            
            foreach(var directory in Directory.GetDirectories(dir))
            {
                var directoryToAdd = Traverse(directory);
                element.Add(directoryToAdd);
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                var fileToAdd = new XElement("file", new XAttribute("name", Path.GetFileName(file)));
                element.Add(fileToAdd);
            }

            return element;
        }
    }
}
