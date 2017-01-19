using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo, IProduct
    {
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price ,gender)
        {
            this.Milliliters = milliliters;
            this.Price = base.Price * this.Milliliters;
            this.Usage = usage;
        }

        public uint Milliliters { get; set; }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }

            set
            {
                Validator.CheckIfNull(value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Usage type"));

                this.usage = value;
            }
        }

        public override string Print()
        {
            var result = new StringBuilder();

            result.AppendLine(base.Print());

            result.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            result.AppendLine(string.Format("  * Usage: {0}", this.Usage));

            return result.ToString().Trim();
        }
    }
}
