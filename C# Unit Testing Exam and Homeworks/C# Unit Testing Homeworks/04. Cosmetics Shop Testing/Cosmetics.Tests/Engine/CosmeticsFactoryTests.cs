namespace Cosmetics.Tests.Engine
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Engine;
    using Cosmetics.Common;
    using Products;
    using Contracts;
    using System.Collections.Generic;
    using Cosmetics.Products;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
        private ICosmeticsFactory factory;

        private string validProductName;
        private string validBrand;
        private decimal validPrice;
        private GenderType validGenderType;
        [SetUp]
        public void SetValidParameters()
        {
            this.factory = new CosmeticsFactory();

            this.validProductName = "Shampoo";
            this.validBrand = "Nivea";
            this.validPrice = 4.99m;
            this.validGenderType = GenderType.Men;
        }


        [Test]
        public void CreateShampoo_WhenPassedNameParameterIsinvalid_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(
                () => factory.CreateShampoo(
                    null,
                   this.validBrand,
                   this.validPrice,
                   this.validGenderType,
                   22,
                   UsageType.EveryDay
                   ));
        }

        [TestCase("pr")]
        [TestCase("veryLongProductName")]
        public void CreateShampoo_WhenNameParameterLengthIsInvalid_ShouldThrowIndexOutOfRangeException(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(
                 () => factory.CreateShampoo(
                     name,
                     this.validBrand,
                     this.validPrice,
                     this.validGenderType,
                     22,
                     UsageType.Medical
                     )
                );
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_WhenPassedBrandParameterIsNullOrEmpty_ShouldThrowNullReferenceException(string brand)
        {
            Assert.Throws<NullReferenceException>(
                () => factory.CreateShampoo(
                        this.validProductName,
                        brand,
                        this.validPrice,
                        this.validGenderType,
                        22,
                        UsageType.EveryDay
                    ));
        }


        [TestCase("p")]
        [TestCase("symbolslong")]
        public void CreateShampoo_WhenBrandParameterLengthIsInvalid_ShouldThrowIndexOutOfRangeException(string brand)
        {

            Assert.Throws<IndexOutOfRangeException>(
                 () => factory.CreateShampoo(
                     this.validProductName,
                     brand,
                     this.validPrice,
                     this.validGenderType,
                     22,
                     UsageType.Medical
                     )
                );
        }

        [Test]
        public void CreateShampoo_WhenAllParametersPassedAreValid_ShouldReturnNewShampoo()
        {

            var shampoo = factory.CreateShampoo(
                     this.validProductName,
                     this.validBrand,
                     this.validPrice,
                     this.validGenderType,
                     22,
                     UsageType.Medical
                     );

            Assert.IsInstanceOf<Shampoo>(shampoo);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateCategory_WhenPassedNameIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        [TestCase("t")]
        [TestCase("some very long string baby")]
        public void CreateCategory_WhenPassedNameLengthIsInvalid_ShouldThrowIndexOutOfRangeException(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.factory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_WhenPassedNameIsValid_ShouldReturnNewCategory()
        {
            var category = this.factory.CreateCategory("validName");

            Assert.IsInstanceOf<Category>(category);
        }

        [Test]
        public void CreateShoppingCart_ShouldAlwayReturnNewShoppingCart()
        {
            var cart = this.factory.CreateShoppingCart();

            Assert.IsInstanceOf<ShoppingCart>(cart);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateToothPaste_WhenPassedNameIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            Assert.Throws<NullReferenceException>(
                () => this.factory.CreateToothpaste(
                 name,
                 this.validBrand,
                 this.validPrice,
                 GenderType.Men,
                 new List<string>()
                ));
        }

        [TestCase("pr")]
        [TestCase("veryLongProductName")]
        public void CreateToothPaste_WhenNameParameterLengthIsInvalid_ShouldThrowIndexOutOfRangeException(string name)
        {
            Assert.Throws<IndexOutOfRangeException>(
                 () => factory.CreateToothpaste(
                     name,
                     this.validBrand,
                     this.validPrice,
                     this.validGenderType,
                     new List<string>()
                ));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CreateToothPaste_WhenBrandParameterIsNullOrEmpty_ShoulThrowNullReferenceException(string brand)
        {
            Assert.Throws<NullReferenceException>(
                () => factory.CreateToothpaste(
                    this.validProductName,
                    brand,
                    this.validPrice,
                    this.validGenderType,
                    new List<string>()
               ));
        }

        [Test]
        public void CreateToothPaste_WhenBrandLengthIsInvalid_ShouldThrowIndexOutOfRangeException()
        {
            string brand = new string('*', 11);

            Assert.Throws<IndexOutOfRangeException>(
                   () => this.factory.CreateToothpaste(
                     this.validProductName,
                     brand,
                     this.validPrice,
                     this.validGenderType,
                     new List<string>()
                ));
        }

        [Test]
        public void CreateToothPaste_WhenAnyIngredientLegnthIsInvalid_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(
                   () => this.factory.CreateToothpaste(
                     this.validProductName,
                     this.validBrand,
                     this.validPrice,
                     this.validGenderType,
                     new List<string>(){ "factory", "uf" }
                ));
        }

        [Test]
        public void CreateToothPaste_WhenPassingValidParameters_ShouldReturnNewToothPaste()
        {
            var toothpaste = this.factory.CreateToothpaste(
                     this.validProductName,
                     this.validBrand,
                     this.validPrice,
                     this.validGenderType,
                     new List<string>() { "factory", }
                     );

            Assert.IsInstanceOf<Toothpaste>(toothpaste);
        }
    }
}
