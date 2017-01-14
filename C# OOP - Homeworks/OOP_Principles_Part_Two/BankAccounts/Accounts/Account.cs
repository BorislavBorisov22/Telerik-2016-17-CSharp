namespace BankAccounts.Accounts
{
    using System;
    using System.Text;
    using BankAccounts.Customers;

    public abstract class Account : IAccount
    { 
        public Account(Customer customer, decimal balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; private set; }

        public decimal Balance { get; protected set; }

        public double InterestRate { get; private set; }

        public void DepositMoney(decimal moneyForDeposit)
        {
            this.Balance += moneyForDeposit;
        }

        public virtual double CalculateInterestAmount(int months)
        {
            this.ValidateMonths(months);
            return this.InterestRate * months;
        }

        public override string ToString()
        {
            var accountInfo = new StringBuilder();
            accountInfo.AppendLine(string.Format("Account Customer: {0}", this.Customer.ToString()))
                .AppendLine(string.Format("Account Balance: {0:F2}", this.Balance))
                .AppendLine(string.Format("Account Interest Rate: {0}%", this.InterestRate));
            return accountInfo.ToString().Trim();
        }

        protected void ValidateMonths(int months)
        {
            if (months <= 0)
            {
                throw new ArgumentOutOfRangeException("Months for calculating interest rate for a give period cannot be zero or less");
            }
        }
    }
}
