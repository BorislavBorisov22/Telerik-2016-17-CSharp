namespace BankAccounts.Customers
{
    public class CompanyCustomer : Customer, ICustomer
    {
        public CompanyCustomer(string name) 
            : base(name, CustomerType.Company)
        {
        }
    }
}
