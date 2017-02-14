namespace Cosmetics.Tests.Products
{
    using System;
    using Contracts;
    using Cosmetics.Products;
    using Moq;
    using NUnit.Framework;
    using Fakes;
    using System.Linq;

    [TestFixture]
    public class ShoppingCartTests
    {
        
        [Test]
        public void AddProduct_WhenAddingValidProduct_ShouldAddResepctiveProductCorrectly()
        {
            // arrange
            var productStub = new Mock<IProduct>();
            var mockedCart = new MockedShoppingCart();

            mockedCart.AddProduct(productStub.Object);
            var expected = mockedCart.Products.First();

            Assert.AreSame(expected, productStub.Object);
        }

        [Test]
        public void AddProduct_WhenAddingNullProduct_ShouldThrowNullReferenceException()
        {
            IProduct toAdd = null;
            var shoppingCart = new ShoppingCart();

            Assert.Throws<NullReferenceException>(() => shoppingCart.AddProduct(toAdd));
        }

        [Test]
        public void RemoveProduct_WhenRemovingValidProduct_ShouldRemoveResepctiveProductFromProducts()
        {
            var productStub = new Mock<IProduct>();
            var mockedCart = new MockedShoppingCart();

            mockedCart.Products.Add(productStub.Object);

            mockedCart.RemoveProduct(productStub.Object);

            bool returned = mockedCart.Products.Contains(productStub.Object);

            Assert.IsFalse(returned);
        }

        [Test]
        public void RemoveProduct_WhenRemovingWithNullParameter_ShouldThrowNullReferenceExpetion()
        {
            IProduct productToRemove = null;
            var cart = new ShoppingCart();

            Assert.Throws<NullReferenceException>(() => cart.RemoveProduct(productToRemove));
        }

        [Test]
        public void ContainsProduct_WhenParameterProductIsValidAndIsCOntainedInList_ShoulReturnTrue()
        {
            var productStub = new Mock<IProduct>();

            var mockedCart = new MockedShoppingCart();
            mockedCart.Products.Add(productStub.Object);

            bool isContained = mockedCart.ContainsProduct(productStub.Object);

            Assert.IsTrue(isContained);
        }

        [Test]
        public void ContainsProduct_WhenProductParameterIsValidButNotContainedInList_ShouldReturnFalse()
        {
            var productStub = new Mock<IProduct>();
            var cart = new ShoppingCart();

            bool isContained = cart.ContainsProduct(productStub.Object);

            Assert.IsFalse(isContained);
        }

        [Test]
        public void TotalPrice_WhenNoProductsInCart_ShouldReturn0()
        {
            var cart = new ShoppingCart();

            Assert.AreEqual(0, cart.TotalPrice());
        }

        [Test]
        public void TotalPrice_WhenProductsPresentInCart_ShouldREturnCorrectSumOfAllProductPrices()
        {
            var firstProductStub = new Mock<IProduct>();
            var secondProductStub = new Mock<IProduct>();
            var mockedCart = new MockedShoppingCart();

            firstProductStub.SetupGet(x => x.Price).Returns(5.25M);
            secondProductStub.SetupGet(x => x.Price).Returns(10.25M);

            mockedCart.Products.Add(firstProductStub.Object);
            mockedCart.Products.Add(secondProductStub.Object);

            decimal totalPriceReturned = mockedCart.TotalPrice();
            decimal expected = 15.5M;

            Assert.AreEqual(expected, totalPriceReturned);
        }
    }
}
