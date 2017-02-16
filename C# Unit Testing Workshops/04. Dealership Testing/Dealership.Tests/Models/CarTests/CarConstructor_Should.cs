namespace Dealership.Tests.Models.CarTests
{
    using Contracts;
    using Dealership.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarConstructor_Should
    {
        [Test]
        public void AlwaysAssign4WheelsCount_WhenObjectIsConstructed()
        {
            // arrange and act
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            int seats = 6;
            var car = new Car(make, model, price,seats);

            int expectedWheelsCount = 4;
            // assert
            Assert.AreEqual(expectedWheelsCount, car.Wheels);
        }

        [TestCase(-5)]
        [TestCase(11)]
        public void ThrowArgumentException_WhenSeatsCountIsInvalid(int seats)
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;

            // aact and assert
            Assert.Throws<ArgumentException>(() => new Car(make, model, price, seats));
        }

        [Test]
        public void AssingSeatsCorrectly_WhenObjectIsConstructedWithValidParameters()
        {
            // arrange and act
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            int seats = 6;
            var car = new Car(make, model, price, seats);

            // assert
            Assert.AreEqual(seats, car.Seats);
        }    
    }
}
