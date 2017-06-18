using Cars.Models;
using System.Collections.Generic;

namespace Cars.models
{
    public class Dealer
    {
        public Dealer()
        {
            this.Cities = new List<City>();
        }

        public string Name { get; set; }

        public IList<City> Cities { get; set; }
    }
}
