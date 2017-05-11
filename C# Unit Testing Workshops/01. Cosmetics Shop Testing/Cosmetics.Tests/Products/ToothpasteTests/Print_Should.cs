namespace Cosmetics.Tests.Products.ToothpasteTest
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;
    using Cosmetics.Common;
    using System.Collections.Generic;
    using Cosmetics.Products;

    [TestFixture]
    public class Print_Should
    {
        [Test]
        public void ReturnToothpasteDetailsCorrectly_WhenCalled()
        {
            // arrange
            string name = "someName";
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            var ingredients = new List<string>() { "koza", "Ovca", "Sudjuk" };

            var toothapaste = new Toothpaste(name, brand, price, gender, ingredients);

            // act
            var returnedString = toothapaste.Print();

            // assert
            StringAssert.Contains(
                $"  * Ingredients: {string.Join(", ", ingredients)}",
                returnedString
                );
        }
    }
}
