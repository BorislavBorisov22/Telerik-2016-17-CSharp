using System.IO;
using System;
using System.Xml;

namespace WritePersonInfoInXML
{
    public class StartUp
    {
        public static void Main()
        {
            string personInfo = File.ReadAllText("../../../person.txt");

            var personTokens = personInfo
                .Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            string personName = personTokens[0];
            string personAddress = personTokens[1];
            string personPhone = personTokens[2];

            var person = new Person
            {
                Name = personName,
                Address = personAddress,
                Phone = personPhone
            };

            using (var writer = XmlWriter.Create("../../person.xml"))
            {
                writer.WriteStartDocument();
                    writer.WriteStartElement("person");
                        writer.WriteAttributeString("id", "1");
                        writer.WriteElementString("name", person.Name);
                        writer.WriteElementString("address", person.Address);
                        writer.WriteElementString("phone", person.Phone);
                    writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
