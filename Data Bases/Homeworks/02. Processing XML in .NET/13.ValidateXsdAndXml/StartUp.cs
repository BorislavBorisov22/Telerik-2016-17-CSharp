using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ValidateXsdAndXml
{
    public class StartUp
    {
        public static void Main()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();

            schemas.Add("catalog", "../../../catalog.xsd");

            XDocument doc = XDocument.Load("../../../catalog.xml");
            string msg = "";
            doc.Validate(schemas, (o, e) =>
            {
                msg += e.Message + Environment.NewLine;
            });
            Console.WriteLine(msg == "" ? "Document is valid" : "Document invalid: " + msg);
        }
    }
}
