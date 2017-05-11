namespace Cosmetics.Tests.Products.ShampooTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;
    using Cosmetics.Products;

    [TestFixture]
    public class Print_Should
    {
        [Test]
        public void PrintShampooDetailsInRequiredforamt_WhenCalled()
        {
            // arrange
            string name = "someName";
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            uint milliliters = 500;
            var usage = UsageType.EveryDay;

            var shampoo = new Shampoo(name, brand, price, gender, milliliters, usage);

            // act
            string returnedString = shampoo.Print();

            // assert
            StringAssert.Contains($"* Quantity: {milliliters} ml", returnedString);
            StringAssert.Contains($"  * Usage: {usage}",returnedString);
        }
    }
}
