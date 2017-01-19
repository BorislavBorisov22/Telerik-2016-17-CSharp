namespace Cosmetics.Products
{
    using System;
    using Common;
    using Cosmetics.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class ToothPaste : Product, IProduct, IToothpaste
    {
        private const int MinIngrLength = 4;
        private const int MaxIngrLength = 12;

        private IList<string> ingredients;

        public ToothPaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) 
            : base(name, brand, price, gender)
        {
            ValidateIngredients(ingredients);
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        public override string Print()
        {
            var result = new StringBuilder();
            result.AppendLine(base.Print());
            result.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));

            return result.ToString().Trim();
        }

        private void ValidateIngredients(IList<string> ingredients)
        {
            Validator.CheckIfNull(ingredients,
                string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Ingredients"));

            foreach (var ing in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(ing, MaxIngrLength, MinIngrLength,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", MinIngrLength, MaxIngrLength));
            }
        }
    }
}
