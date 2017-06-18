using Cars.Providers.Providers;
using System;

namespace Cars.Providers
{
    public class XmlWhereClause
    {
        public string PropertyName { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public WhereType WhereType
        {
            get
            {
                return (WhereType)Enum.Parse(typeof(WhereType), this.Type);
            }
        }
    }
}
