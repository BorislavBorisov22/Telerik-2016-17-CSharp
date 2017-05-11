namespace Cosmetics.Tests.Products.ShoppingCartTests
{
    using System;

    using NUnit.Framework;
    using Fakes;
    using Contracts;
    using Moq;

    [TestFixture]
    public class ContainsProduct_Should
    {
        [Test]
        public void ReturnTrue_WhenProductIsPresentInTheProductsCollection()
        {
            // arrange
            var cart = new FakeShoppingCart();
            var productStub = new Mock<IProduct>();
            cart.Products.Add(productStub.Object);

            // act
            bool isContained = cart.ContainsProduct(productStub.Object);

            // assert
            Assert.IsTrue(isContained);
        }
    }
}
