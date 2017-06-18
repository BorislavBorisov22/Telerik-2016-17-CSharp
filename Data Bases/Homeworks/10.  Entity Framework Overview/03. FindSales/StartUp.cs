using System;
using NorthwindEnitiesDbContext;
using System.Linq;
using System.Collections.Generic;

namespace _03.FindSales
{
    public class StartUp
    {
        public static void Main()
        {
            string region = "AK";
            DateTime minDate = new DateTime(1998, 1, 1);
            DateTime maxDate = new DateTime(2000, 1, 1);

            var targetOrders = GetSalesByRegionAndPeriodOfTime(region, minDate, maxDate);

            targetOrders.ToList().ForEach(x => Console.WriteLine(x.OrderDate + " " + x.ShipRegion));
        }

        private static IEnumerable<Order> GetSalesByRegionAndPeriodOfTime(string regionName, DateTime minDate, DateTime maxDate)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var targetOrders = dbContext.Orders
                    .Where(x => x.ShipRegion == regionName && x.OrderDate > minDate && x.OrderDate < maxDate);
                
                return targetOrders.ToList();
            }
        }
    }
}
