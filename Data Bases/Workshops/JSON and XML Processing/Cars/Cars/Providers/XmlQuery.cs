using System.Collections.Generic;

namespace Cars.Providers
{
    public class XmlQuery
    {
        public XmlQuery()
        {
            this.WhereClauses = new List<XmlWhereClause>();
        }

        public string Order { get; set; }

        public string OutputFile { get; set; }

        public IList<XmlWhereClause> WhereClauses { get; private set; }
    }
}
