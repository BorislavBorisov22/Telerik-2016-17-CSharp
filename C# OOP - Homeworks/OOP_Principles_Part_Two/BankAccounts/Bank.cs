namespace BankAccounts
{
    using System.Collections.Generic;
    using Accounts;

    public class Bank
    {
        private IList<Account> accounts;

        public Bank()
        {
            this.accounts = new List<Account>();
        }

        public IList<Account> Accounts
        {
            get
            {
                return new List<Account>(this.accounts);
            }
        }

        public void AddAccount(Account account)
        {
            this.accounts.Add(account);
        }

        public void RemoveAccount(Account account)
        {
            this.Accounts.Remove(account);
        }
    }
}