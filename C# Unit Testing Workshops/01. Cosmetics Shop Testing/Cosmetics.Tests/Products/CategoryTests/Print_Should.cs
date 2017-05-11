namespace Cosmetics.Tests.Products.CategoryTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Products;

    [TestFixture]
    public class Print_Should
    {
        [Test]
        public void RetrunStringDeatilsAboutTheCategory_WhenCalleD()
        {
            // arrange
            string name = "validName";
            var category = new Category(name);
            string expected = $"{name} category - 0 products in total";

            // act
            var returnedString = category.Print();

            // assert
            StringAssert.Contains(expected, returnedString);
        }
    }
}
