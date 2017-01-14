namespace BankAccounts.Accounts
{
    public interface IWithdrawable
    {
        void WithdrawMoney(decimal moneyForWithdraw);
    }
}
