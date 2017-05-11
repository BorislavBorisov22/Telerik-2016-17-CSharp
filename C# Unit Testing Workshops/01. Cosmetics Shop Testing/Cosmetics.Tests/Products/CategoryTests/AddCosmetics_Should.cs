namespace Cosmetics.Tests.Products.CategoryTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Products;
    using Fakes;
    using Moq;
    using Contracts;
    using System.Linq;

    [TestFixture]
    public class AddCosmetics_Should
    {
        [Test]
        public void AddThePassedCosmeticsToTheCosmeticsCollection_WhenCalledWithValidParameters()
        {
            // arrange
            string name = "validName";
            var category = new FakeCategory(name);

            var productStub = new Mock<IProduct>();

            // act
            category.AddProduct(productStub.Object);

            // assert
            Assert.AreSame(productStub.Object, category.Products.First());
        }
    }
}
