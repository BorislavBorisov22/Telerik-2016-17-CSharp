namespace Cosmetics.Products
{
    using System;
    using Cosmetics.Contracts;
    using Common;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Category : ICategory
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 15;

        private string name;
        private IList<IProduct> cosmetics;

        public Category(string name)
        {
            this.Name = name;
            this.cosmetics = new List<IProduct>();
        }

        
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,
                    string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Name"));
                Validator.CheckIfStringLengthIsValid(value, MaxNameLength, MinNameLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", MinNameLength, MaxNameLength));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            ValidateNullCosmetics(cosmetics);

            this.cosmetics.Add(cosmetics);
        }

        public string Print()
        {
            var result = new StringBuilder();

            string productOrProducts =
                this.cosmetics.Count == 1 ?
                "{0} category - {1} product in total" :
                "{0} category - {1} products in total";

            result.AppendLine(string.Format(productOrProducts, this.Name, this.cosmetics.Count));

            var sortedCosmetics = this.cosmetics.OrderBy(c => c.Brand).ThenByDescending(c => c.Price).ToList();

            foreach (var cosm in sortedCosmetics)
            {
                result.AppendLine(cosm.Print());
            }

            return result.ToString().Trim();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            ValidateNullCosmetics(cosmetics);

            if (!this.cosmetics.Contains(cosmetics))
            {
                throw new InvalidOperationException(string.Format("Product {0} does not exist in category {1}!.", cosmetics.Name, this.Name));
            }

            this.cosmetics.Remove(cosmetics);
        }

        private void ValidateNullCosmetics(IProduct product)
        {
            Validator.CheckIfNull(cosmetics, string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Cosmetics"));
        }
    }
}
