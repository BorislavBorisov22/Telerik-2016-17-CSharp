namespace BankAccounts.Accounts
{
    using System;
    using BankAccounts.Customers;

    public class DepositAccount : Account, IAccount, IWithdrawable
    {
        public const decimal MinBalanceForInterest = 1000;

        public DepositAccount(Customer customer, decimal balance, double interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public void WithdrawMoney(decimal moneyForWithdraw)
        {
            if (moneyForWithdraw <= 0)
            {
                throw new ArgumentOutOfRangeException("Money for withdraw cannot be zero or less");
            }

            if (this.Balance < moneyForWithdraw)
            {
                throw new ArgumentOutOfRangeException("Insufficient balance. Money for withdrawing must be less than or equal to the ballance of the account!");
            }

            this.Balance -= moneyForWithdraw;
        }

        public override double CalculateInterestAmount(int months)
        {
            this.ValidateMonths(months);

            if (this.Balance > 0 && this.Balance < MinBalanceForInterest)
            {
                return 0;
            }

            return base.CalculateInterestAmount(months);
        }
    }
}
