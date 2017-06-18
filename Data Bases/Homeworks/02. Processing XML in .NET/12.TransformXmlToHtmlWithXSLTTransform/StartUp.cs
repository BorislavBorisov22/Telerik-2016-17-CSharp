using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace _12.TransformXmlToHtmlWithXSLTTransform
{
    public class StartUp
    {
        public static void Main()
        {
            var xslTranformator = new XslCompiledTransform();
            xslTranformator.Load("../../../catalog.xslt");

            var xmlDocument = XDocument.Load("../../../catalog.xml");

            xslTranformator.Transform("../../../catalog.xml", "../../tranformed.html");
        }
    }
}
