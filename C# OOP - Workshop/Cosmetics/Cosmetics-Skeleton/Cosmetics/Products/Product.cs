namespace Cosmetics.Products
{
    using System;
    using Common;
    using Cosmetics.Contracts;
    using System.Text;

    public class Product : IProduct
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 10;
        private const int MinBrandLength = 2;
        private const int MaxBrandLength = 10;

        private string name;
        private string brand;
        private GenderType genderType;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value,
                   string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Brand"));

                Validator.CheckIfStringLengthIsValid(value, MaxBrandLength, MinBrandLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength,"Product brand", MinBrandLength, MaxNameLength));

                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.genderType;
            }

            private set
            {
                Validator.CheckIfNull(value,
                    string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Gender"));

                this.genderType = value;
            }
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
                    string.Format(GlobalErrorMessages.InvalidStringLength,"Product name", MinNameLength, MaxNameLength));

                this.name = value;
            }
        }

        public decimal Price { get; protected set; }
       

        public virtual string Print()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("  * Price: ${0}", this.Price));
            result.AppendLine(string.Format("  * For gender: {0}", this.Gender));

            return result.ToString().Trim();
        }
    }
}
