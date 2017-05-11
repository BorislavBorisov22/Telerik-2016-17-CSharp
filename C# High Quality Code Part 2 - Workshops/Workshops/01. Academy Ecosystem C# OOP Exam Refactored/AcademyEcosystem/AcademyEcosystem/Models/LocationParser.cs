using System;
using AcademyEcosystem.Models.Contracts;

namespace AcademyEcosystem.Models
{
    internal class LocationParser : ILocationParser
    {
        public IPoint ParsePoint(string pointString)
        {
            IPoint point = Point.Parse(pointString);
            return point;
        }
    }
}
