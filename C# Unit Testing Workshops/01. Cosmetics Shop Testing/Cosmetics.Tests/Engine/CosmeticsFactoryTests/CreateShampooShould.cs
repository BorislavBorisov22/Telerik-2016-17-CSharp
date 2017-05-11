namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;
    using Cosmetics.Engine;
    using Products;
    using Cosmetics.Products;

    [TestFixture]
    public class CreateShampooShould
    {
        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullReferenceException_WhenPassedNameIsNullOrEmpty(string name)
        {
            // arrange
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            uint milliliters = 500;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<NullReferenceException>(
                () => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [TestCase("i")]
        [TestCase("some long logn brand that will throw exception")]
        public void ThrowIndexOutOfRangeException_WhenPassedNameHasInvalidLength(string name)
        {
            // arrange
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            uint milliliters = 500;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<IndexOutOfRangeException>(
                () => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullReferenceException_WhenPassedBrandIsNullOrEmpty(string brand)
        {
            // arrange
            string name = "someName";
            decimal price = 20;
            var gender = GenderType.Men;
            uint milliliters = 500;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<NullReferenceException>(
                () => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [TestCase("i")]
        [TestCase("some long logn brand that will throw exception")]
        public void ThrowIndexOutOfRangeException_WhenPassedBrandHasInvalidLength(string brand)
        {
            // arrange
            string name = "someName";
            decimal price = 20;
            var gender = GenderType.Men;
            uint milliliters = 500;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<IndexOutOfRangeException>(
                () => factory.CreateShampoo(name, brand, price, gender, milliliters, usage));
        }

        [Test]
        public void ReturnNewShampoo_WhenThePAssedParametersAreAllValiid()
        {
            // arrange
            string name = "someName";
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            uint milliliters = 500;
            var usage = UsageType.EveryDay;

            var factory = new CosmeticsFactory();

            // act
            var returendObj = factory.CreateShampoo(name, brand, price, gender, milliliters, usage);

            // assert
            Assert.IsInstanceOf<Shampoo>(returendObj);
        }
    }
}
