using _01.DataAccessObject.Data_Access;
using NorthwindEnitiesDbContext;

namespace _01.DataAccessObject
{
    public class StartUp
    {
        private static ICustomersManager customersManager = new CustomersManager();

        public static void Main()
        {
            // TestAddCustomer();
            // TestUpdateCustomer();
            TestDeleteCustomer();
        }

        private static void TestAddCustomer()
        {

            var customerToAdd = new Customer()
            {
                CustomerID = "IDIDI",
                CompanyName = "SomeCompanyName"
            };

            customersManager.AddCustomer(customerToAdd);
        }

        private static void TestUpdateCustomer()
        {
            var customerToUpdate = new Customer()
            {
                CustomerID = "IDIDI",
                CompanyName = "SomeCompanyName",
                Address = "SomeAddress"
            };

            customersManager.UpdateCustomer(customerToUpdate);
        }

        private static void TestDeleteCustomer()
        {
            var customerToRemoveId = "IDIDI";

            customersManager.DeleteCustomer(customerToRemoveId);
        }
    }
}
