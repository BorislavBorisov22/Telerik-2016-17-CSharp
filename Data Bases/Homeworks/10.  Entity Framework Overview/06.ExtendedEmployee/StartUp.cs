using NorthwindEnitiesDbContext;
using System;
using System.Linq;

namespace _06.ExtendedEmployee
{
    public class StartUp
    {
        public static void Main()
        {
            using (var dbContext = new NorthwindEntities())
            {
                var employee = dbContext.Employees.First();

                Console.WriteLine(employee.FirstName + " " + employee.LastName);

                foreach (var terr in employee.TerritoriesSet)
                {
                    Console.WriteLine(terr.TerritoryDescription);
                }
            }
        }
    }
}
