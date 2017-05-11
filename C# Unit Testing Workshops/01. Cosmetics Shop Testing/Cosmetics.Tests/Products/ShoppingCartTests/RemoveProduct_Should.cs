namespace Cosmetics.Tests.Products.ShoppingCartTests
{
    using System;

    using NUnit.Framework;
    using Fakes;
    using Moq;
    using Contracts;

    [TestFixture]
    public class RemoveProduct_Should
    {
        [Test]
        public void RemoveProductFromProductsCollcetionSuccessfully_WhenCalledWithAValidProduct()
        {
            // arrange
            var cart = new FakeShoppingCart();
            var productStub = new Mock<IProduct>();
            cart.Products.Add(productStub.Object);

            // act
            cart.RemoveProduct(productStub.Object);

            // asssert
            Assert.AreEqual(0, cart.Products.Count);
        }
    }
}
