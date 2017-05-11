namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    using System;

    using NUnit.Framework;
    using Cosmetics.Common;
    using Cosmetics.Engine;
    using System.Collections.Generic;
    using Products;
    using Cosmetics.Products;

    [TestFixture]
    public class CreateToothpaste_Should
    {
        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullReferenceException_WhenPassedNameIsNullOrEmpty(string name)
        {
            // arrange
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            var ingredients = new List<string>() { "Koza", "Ovca", "Sudjuk" };

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<NullReferenceException>(
                () => factory.CreateToothpaste(name, brand, price, gender, ingredients));
        }

        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullReferenceException_WhenPassedBrandIsNullOrEmpty(string brand)
        {
            // arrange
            string name = "SomeName";
            decimal price = 20;
            var gender = GenderType.Men;
            var ingredients = new List<string>() { "Koza", "Ovca", "Sudjuk" };

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<NullReferenceException>(
                () => factory.CreateToothpaste(name, brand, price, gender, ingredients));
        }

        [TestCase("i")]
        [TestCase("some very very very very long string")]
        public void ThrowIndexOutOfRangeException_WhenPassednNameLengthIsInvalid(string name)
        {
            // arrange
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            var ingredients = new List<string>() { "Koza", "Ovca", "Sudjuk" };

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<IndexOutOfRangeException>(
                () => factory.CreateToothpaste(name, brand, price, gender, ingredients));
        }

        [TestCase("i")]
        [TestCase("some very very very very long string")]
        public void ThrowIndexOutOfRangeException_WhenPassednBrandLengthIsInvalid(string brand)
        {
            // arrange
            string name = "someName";
            decimal price = 20;
            var gender = GenderType.Men;
            var ingredients = new List<string>() { "Koza", "Ovca", "Sudjuk" };

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<IndexOutOfRangeException>(
                () => factory.CreateToothpaste(name, brand, price, gender, ingredients));
        }

        [Test]
        public void ThrowIndexOutOfRangeException_WhenAnyOfTheIngredientsPassedLengthIsLessThanTheMinimumLength()
        {
            // arrange
            string name = "someName";
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            var ingredients = new List<string>() { "kk", "Ovca", "Sudjuk" };

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<IndexOutOfRangeException>(
                () => factory.CreateToothpaste(name, brand, price, gender, ingredients));
        }

        [Test]
        public void ThrowIndexOutOfRangeException_WhenAnyOfTheIngredientsPassedLengthIsMoreThanTheMaximumLength()
        {
            // arrange
            string name = "someName";
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            var ingredients = new List<string>() { "koza", "Ovca", "Sudjuk", new string('*',13) };

            var factory = new CosmeticsFactory();

            // act and assert
            Assert.Throws<IndexOutOfRangeException>(
                () => factory.CreateToothpaste(name, brand, price, gender, ingredients));
        }

        [Test]
        public void ReturnNewToothpaste_WhenAllPassedParametersAreValid()
        {
            // arrange
            string name = "someName";
            string brand = "someBrand";
            decimal price = 20;
            var gender = GenderType.Men;
            var ingredients = new List<string>() { "koza", "Ovca", "Sudjuk" };

            var factory = new CosmeticsFactory();

            // act
            var returnedObj = factory.CreateToothpaste(name, brand, price, gender, ingredients);

            // assert
            Assert.IsInstanceOf<Toothpaste>(returnedObj);
        }
    }
}
