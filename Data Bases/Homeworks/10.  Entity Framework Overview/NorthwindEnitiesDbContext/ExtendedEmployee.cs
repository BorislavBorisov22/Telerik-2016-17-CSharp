using System.Data.Linq;
using NorthwindEnitiesDbContext;

namespace NorthwindEnitiesDbContext
{
    using System.Data.Entity.Core.Metadata.Edm;

    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesSet
        {
            get
            {
                EntitySet<Territory> territoriesSet = new EntitySet<Territory>();
                territoriesSet.AddRange(this.Territories);
                return territoriesSet;
            }
        }
    }
}
