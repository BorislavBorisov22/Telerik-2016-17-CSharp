namespace BankAccounts.Customers
{
    public class IndividualCustomer : Customer, ICustomer
    {
        public IndividualCustomer(string name) 
            : base(name, CustomerType.Individual)
        {
        }
    }
}
