namespace BankAccounts.Accounts
{
    using BankAccounts.Customers;

    public class LoanAccount : Account, IAccount
    {
        public LoanAccount(Customer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override double CalculateInterestAmount(int months)
        {
            this.ValidateMonths(months);

            if (Customer.CustomerType == CustomerType.Individual)
            {
                if (months <= 3)
                {
                    return 0;
                }
                else
                {
                    return (months - 3) * this.InterestRate;
                }
            }
            else
            {
                if (months <= 2)
                {
                    return 0;
                }
                else
                {
                    return (months - 2) * this.InterestRate;
                }
            }
        }
    }
}
