using Bytes2you.Validation;
using NorthwindEnitiesDbContext;
using System.Data.Entity.Migrations;
using System.Linq;

namespace _01.DataAccessObject.Data_Access
{
    public class CustomersManager : ICustomersManager
    {
        public void AddCustomer(Customer customer)
        {
            Guard.WhenArgument(customer, "Customer to add").IsNull().Throw();

            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
            }
        }

        public void UpdateCustomer(Customer modifiedCustomer)
        {
            Guard.WhenArgument(modifiedCustomer, "Customer to update").IsNull().Throw();

            var targetCustomer = this.GetCustomerById(modifiedCustomer.CustomerID);

            Guard.WhenArgument(targetCustomer, "Customer ot update").IsNull().Throw();

            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Customers.AddOrUpdate(modifiedCustomer);
                dbContext.SaveChanges();
            }
        }

        public void DeleteCustomer(string customerId)
        {
            Guard.WhenArgument(customerId, "Customer Id").IsNull().Throw();

            using (var dbContext = new NorthwindEntities())
            {
                var targetCustomer = dbContext.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                Guard.WhenArgument(targetCustomer, "Customer to delete").IsNull().Throw();

                dbContext.Customers.Remove(targetCustomer);
                dbContext.SaveChanges();
            }
        }

        private Customer GetCustomerById(string customerId)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var targetCustomer = dbContext.Customers.FirstOrDefault(x => x.CustomerID == customerId);
                return targetCustomer;
            }
        }
    }
}
