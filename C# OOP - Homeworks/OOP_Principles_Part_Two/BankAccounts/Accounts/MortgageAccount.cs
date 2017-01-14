namespace BankAccounts.Accounts
{
    using BankAccounts.Customers;

    public class MortgageAccount : Account, IAccount
    {
        public MortgageAccount(Customer customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override double CalculateInterestAmount(int months)
        {
            this.ValidateMonths(months);

            if (this.Customer.CustomerType == CustomerType.Individual)
            {
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    return (months - 6) * this.InterestRate;
                }
            }
            else
            {
                if (months <= 12)
                {
                    return (this.InterestRate / 2) * months;
                }
                else
                {
                    double firstTwelveMonthsInterest = (this.InterestRate / 2) * 12;

                    if (months <= 12)
                    {
                        return firstTwelveMonthsInterest;
                    }
                    else
                    {
                        return (firstTwelveMonthsInterest + (this.InterestRate * (months - 12))) / 2;
                    }
                }
            }
        }
    }
}
