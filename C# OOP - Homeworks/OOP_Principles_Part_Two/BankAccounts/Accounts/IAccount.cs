namespace BankAccounts.Accounts
{
    using BankAccounts.Customers;

    public interface IAccount
    {
        Customer Customer { get; }

        decimal Balance { get; }

        double InterestRate { get; }

        void DepositMoney(decimal moneyForDeposit);

        double CalculateInterestAmount(int months);
    }
}
