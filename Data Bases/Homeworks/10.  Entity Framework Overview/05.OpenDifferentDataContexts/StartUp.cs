using NorthwindEnitiesDbContext;
using System.Linq;

namespace _05.OpenDifferentDataContexts
{
    public class StartUp
    {
        public static void Main()
        {
            // In this case the first saved change is overriden by the second one
            // because the default concurrency is optimistic in which the latest change wins
            // to avoid such cases we can use a pesimistic concurrency to be sure that each change
            // would be made in time
            var firstContext = new NorthwindEntities();
            firstContext.Employees.First().FirstName = "Ivan";

            var secondContext = new NorthwindEntities();
            secondContext.Employees.First().FirstName = "Petko";

            secondContext.SaveChanges();
            firstContext.SaveChanges();
        }
    }
}
