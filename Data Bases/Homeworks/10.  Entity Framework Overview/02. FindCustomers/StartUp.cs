using _02.FindCustomers.DataTransferObjects;
using NorthwindEnitiesDbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.FindCustomers
{
    public class StartUp
    {
        public static void Main()
        {
            int yearOfOrder = 1997;
            string targetCountry = "Canada";
            var customersWithEF = GetCustomersWithOrdersFor(yearOfOrder, targetCountry);
            
            foreach (var customer in customersWithEF)
            {
                Console.WriteLine(customer.CompanyName + " " + customer.Country);
            }

            Console.WriteLine("-----------------------");

            var customersWithSQL = GetCustomersWithOrdersForWithSQLQuery(yearOfOrder, targetCountry);

            foreach (var customer in customersWithSQL)
            {
                Console.WriteLine(customer.CompanyName + " " + customer.OrderId);
            }
        }

        private static IEnumerable<Customer> GetCustomersWithOrdersFor(int yearOfOrder, string targetCountry)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var targetCustomers = dbContext.Orders
                    .Where(x => x.OrderDate.Value.Year == yearOfOrder && x.ShipCountry == targetCountry)
                    .Select(x => x.Customer);

                return targetCustomers.ToList();
            }
        }

        private static IEnumerable<CustomerDTO> GetCustomersWithOrdersForWithSQLQuery(int yearOfOrder, string targetCountry)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var targetCustomers = dbContext.Database.SqlQuery<CustomerDTO>($@"SELECT c.CompanyName, o.OrderID
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE YEAR(o.OrderDate) = {yearOfOrder} AND o.ShipCountry = '{targetCountry}'");

                return targetCustomers.ToList();
            }
        }
    }
}
