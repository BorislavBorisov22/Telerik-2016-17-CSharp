namespace Dealership.Tests.Models.TruckTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Models;

    [TestFixture]
    public class TruckConstructor_Should
    {
        [Test]
        public void AlwaysAssingWheelCountTo8_WhenObjectIsConstructed()
        {
            // arrange and act
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            int weightCapacity = 1;
            var truck = new Truck(make, model, price, weightCapacity);

            int expectedWheelsCount = 8;

            // assert
            Assert.AreEqual(expectedWheelsCount, truck.Wheels);
        }

        [Test]
        public void AssingWeightCapacityCorrectly_WhenPassedCapacityParameterIsValid()
        {
            // arrange and act
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            int weightCapacity = 1;
            var truck = new Truck(make, model, price, weightCapacity);

            // assert
            Assert.AreEqual(weightCapacity, truck.WeightCapacity);
        }

        [TestCase(-5)]
        [TestCase(101)]
        public void ThrowArgumentException_WhenPassedWeightCapacityIsInInvalidRange(int capacity)
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;

            // act and assert
            Assert.Throws <ArgumentException>(() => new Truck(make, model, price, capacity));
        }
    }
}
