using AcademyEcosystem.Models;
using AcademyEcosystem.Models.Contracts;

namespace AcademyEcosystem.Commands
{
    internal abstract class LocationRelatedCommand
    {
        private ILocationParser locationParser;

        public LocationRelatedCommand(ILocationParser locationParser = null)
        {
            if (locationParser == null)
            {
                this.locationParser = new LocationParser();
            }
            else
            {
                this.locationParser = locationParser;
            }
        }

        protected ILocationParser LocationParser
        {
            get
            {
                return this.locationParser;
            }
        }
    }
}
