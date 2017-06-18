using NorthwindEnitiesDbContext;

namespace _04.NorthwindTwin
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new NorthwindEntities();

            dbContext.Database.CreateIfNotExists();
        }
    }
}
