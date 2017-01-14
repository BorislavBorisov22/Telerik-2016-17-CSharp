namespace BankAccounts.Customers
{
    using System;
    using System.Text;

    public abstract class Customer : ICustomer
    {
        private string name;

        public Customer(string name, CustomerType customerType)
        {
            this.Name = name;
            this.CustomerType = customerType;
        }

        public CustomerType CustomerType { get; protected set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (!this.IsNameValid(value))
                {
                    throw new ArgumentException("Invalid customer name! Name should contain only letter symbols and be at least 2 symbols long");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            var customerInfo = new StringBuilder();
            customerInfo.AppendFormat("Customer Name: {0}, Customer type: {1}", this.Name, this.CustomerType);
            return customerInfo.ToString().Trim();
        }

        private bool IsNameValid(string name)
        {
            if (name.Length < 2)
            {
                return false;
            }

            foreach (var letter in name)
            {
                if (!char.IsLetter(letter) && letter != ' ')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
