using Cosmetics.Contracts;
using Cosmetics.Tests.Products.ShoppingCartTests.Fakes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Products.ShoppingCartTests
{
    [TestFixture]
    public class TotalPrice_Should
    {
        [Test]
        public void ReturnTotalPriceOfAllProductsInTheProductCollection_WhenCalledWithPresenteProducts()
        {
            // arrange
            var cart = new FakeShoppingCart();
            var productStub = new Mock<IProduct>();

            decimal price = 22;
            productStub.Setup(x => x.Price).Returns(price);

            cart.Products.Add(productStub.Object);

            // act
            var totalPrice = cart.TotalPrice();

            // assert
            Assert.AreEqual(price, totalPrice);
        }

        [Test]
        public void ReturnZero_WhenCalledWithNoProductsInTheCarProductsCollection()
        {
            // arrange
            var cart = new FakeShoppingCart();

            // act
            var totalPrice = cart.TotalPrice();

            // assert
            Assert.AreEqual(0, totalPrice);
        }
    }
}
