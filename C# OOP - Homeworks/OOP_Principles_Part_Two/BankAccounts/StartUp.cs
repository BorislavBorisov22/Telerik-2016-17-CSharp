namespace BankAccounts
{
    using System;
    using Accounts;
    using BankAccounts.Customers;

    public class StartUp
    {
        public static void Main()
        {
            TestDepositingAndWithdrawing();
            TestBankAccounts();   
        }

        public static void TestDepositingAndWithdrawing()
        {
            // the test includes only deposit account whtihdrawing and depositing
            // because the output on the console would be too long
            // feel free to test the other components :)

            // creating an instance of an individual type customer
            var peshoCustomer = new IndividualCustomer("Pesho");
           
            // creating a deposit account and printing the information about the account
            var peshoDeposit = new DepositAccount(peshoCustomer, 25000, 2.5);
            Console.WriteLine(peshoDeposit);
            Console.WriteLine("============================");

            // depositing some money in the same account and printing it's information again
            peshoDeposit.DepositMoney(34.50m);
            Console.WriteLine(peshoDeposit);
            Console.WriteLine("=============================");

            // widthdrawing some money and then printing it's information again
            peshoDeposit.WithdrawMoney(120.68m);
            Console.WriteLine(peshoDeposit);
            Console.WriteLine("==============================");
        }

        public static void TestBankAccounts()
        {
            var rnd = new Random();
            var bank = new Bank();

            // customers to add
            var vankataCustomer = new IndividualCustomer("Ivan Ivanov");
            var vankatasCompany = new CompanyCustomer("Vankata Inc");

            // adding accounts with the above customers
            bank.AddAccount(new LoanAccount(vankataCustomer, 2010, 2.05));
            bank.AddAccount(new MortgageAccount(vankataCustomer, 2014, 10.50));
            bank.AddAccount(new DepositAccount(vankataCustomer, 15000, 7.5));
            bank.AddAccount(new LoanAccount(vankatasCompany, 50000, 6));
            bank.AddAccount(new DepositAccount(vankatasCompany, 3000, 8));
            bank.AddAccount(new MortgageAccount(vankatasCompany, 18000, 3.9));

            // foreach account added in our bank printing the total interest rate for a random selected number of month
            foreach (var account in bank.Accounts)
            {
                int months = rnd.Next(1, 15);
                Console.WriteLine(
                    "{0}'s interest rate as a(n) {1} customer for a peroid of {2} months will be {3:F2}%",
                    account.Customer.Name,
                    account.Customer.CustomerType,
                    months,
                    account.CalculateInterestAmount(months));
            }
        }
    }
}
