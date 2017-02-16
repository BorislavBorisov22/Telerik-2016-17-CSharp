namespace Dealership.Tests.Models.MotorcylceTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Models;

    [TestFixture]
    public class MotorcylceConstructor_Should
    {
        [Test]
        public void AlwaysAssingWheelsCountTo2WhenObjectIsConstructed()
        {
            // arrange and act
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            string category = "category";
            var motor = new Motorcycle(make, model, price, category);

            int expectedWheelsCount = 2;

            // assert
            Assert.AreEqual(expectedWheelsCount, motor.Wheels);
        }

        [Test]
        public void AssignCategoryCorrectly_WhenPassedCategoryPArameterIsValid()
        {
            // arrange and act
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            string category = "category";
            var motor = new Motorcycle(make, model, price, category);

            // assert
            Assert.AreEqual(category, motor.Category);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedCategoryIsNull()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            string category = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new Motorcycle(make, model, price, category));
        }

        [TestCase("io")]
        [TestCase("sososososososssososososososssososososososssososososososssososososososssososososososssososososososssososososososssososososososssososososososssososososososssososososososs")]
        public void ThrowArgumentExceptio_WhenPassedCategoryLengthIsInvalid(string category)
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;

            // act and assert
            Assert.Throws<ArgumentException>(() => new Motorcycle(make, model, price, category));
        }
    }
}
