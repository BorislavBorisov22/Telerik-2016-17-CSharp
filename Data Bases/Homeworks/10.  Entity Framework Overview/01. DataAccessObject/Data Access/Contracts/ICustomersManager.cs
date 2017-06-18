using NorthwindEnitiesDbContext;

namespace _01.DataAccessObject.Data_Access
{
    public interface ICustomersManager
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(string customerId);
        void UpdateCustomer(Customer customer);
    }
}