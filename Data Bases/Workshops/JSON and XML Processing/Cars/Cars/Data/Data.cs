using Cars.models;
using Cars.Models;
using System.Collections.Generic;

namespace Cars.Data
{
    public static class Data
    {
        static Data()
        {
            Cities = new List<City>();
            Dealers = new List<Dealer>();
        }

        public static IList<City> Cities { get; private set; }
        
        public static IList<Dealer> Dealers { get; private set; }
    }
}
