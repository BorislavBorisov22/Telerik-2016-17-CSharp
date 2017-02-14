namespace Cosmetics.Tests.Products
{
    using Contracts;
    using Cosmetics.Common;
    using Cosmetics.Products;
    using Fakes;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Print_WhenCalled_ShouldReturnStringWithCAtegoryDetailsInTheCorrectFormat()
        {
            var category = new Category("Test");

            string expected = "Test category - 0 products in total";

            Assert.AreEqual(expected, category.Print());
        }

        [Test]
        public void AddProduct_WhenProductParameterIsValid_ShouldAddToProducts()
        {
            var mockedCategory = new MockedCategory("test");
            var productStub = new Mock<IProduct>();

            mockedCategory.AddProduct(productStub.Object);

            Assert.AreSame(mockedCategory.Products.First(), productStub.Object);
        }

        [Test]
        public void RemoveCosmetics_WhenProductParameterIsValid_ShouldRemoveProductFromProducts()
        {
            var mockedCategory = new MockedCategory("test");
            var productStub = new Mock<IProduct>();
            mockedCategory.Products.Add(productStub.Object);

            mockedCategory.RemoveProduct(productStub.Object);

            Assert.IsFalse(mockedCategory.Products.Contains(productStub.Object));
        }
    }
}
