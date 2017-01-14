namespace BankAccounts.Customers
{
    public interface ICustomer
    {
        string Name { get; }

        CustomerType CustomerType { get; }
    }
}
