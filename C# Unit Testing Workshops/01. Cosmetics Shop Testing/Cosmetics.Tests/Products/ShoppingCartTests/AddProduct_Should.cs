namespace Cosmetics.Tests.Products.ShoppingCartTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Products;
    using Moq;
    using Contracts;
    using Fakes;
    using System.Linq;

    [TestFixture]
    public class AddProduct_Should
    {
        [Test]
        public void AddTheProductSuccessfullyToProductsCollection_WhenCalledWithValidProduct()
        {
            // arrange
            var cart = new FakeShoppingCart();
            var productStub = new Mock<IProduct>();

            // act
            cart.AddProduct(productStub.Object);

            // assert
            Assert.AreSame(productStub.Object, cart.Products.First());
        }
    }
}
