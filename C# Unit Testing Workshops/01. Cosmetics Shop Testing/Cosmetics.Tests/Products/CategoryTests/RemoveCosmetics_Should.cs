namespace Cosmetics.Tests.Products.CategoryTests
{
    using System;

    using NUnit.Framework;
    using Fakes;
    using Contracts;
    using Moq;

    [TestFixture]
    public class RemoveCosmetics_Should
    {
        [Test]
        public void RemoveCosmeticsFromProductsCollection_WhenCalledWithValidParameter()
        {
            // arrange
            string name = "validName";
            var category = new FakeCategory(name);

            var productStub = new Mock<IProduct>();
            category.Products.Add(productStub.Object);

            // act
            category.RemoveProduct(productStub.Object);

            // assert
            Assert.AreEqual(0, category.Products.Count);
        }
    }
} 
