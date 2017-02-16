namespace Dealership.Tests.Models.VehicleTests
{
    using Common.Enums;
    using Fakes;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class VehicleConstructor_Should
    {
        [Test]
        public void AssignNameCorrectly_WhenVehicleIsConstructed()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;
            var vehicle = new FakeVehicle(make, model, price, vehicleType);

            // act and assert
            Assert.AreEqual(make, vehicle.Make);
        }

        [Test]
        public void AssingModelCorrectly_WhenVechicleIsConstructed()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;
            var vehicle = new FakeVehicle(make, model, price, vehicleType);

            // act and assert
            Assert.AreEqual(model, vehicle.Model);
        }

        [Test]
        public void AssingPriceCorrectly_WhenVechicleIsConstructed()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;
            var vehicle = new FakeVehicle(make, model, price, vehicleType);

            // act and assert
            Assert.AreEqual(price, vehicle.Price);
        }

        [Test]
        public void AssingVehicleTypeCorrectly_WhenVechicleIsConstructed()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;
            var vehicle = new FakeVehicle(make, model, price, vehicleType);

            // act and assert
            Assert.AreEqual(vehicleType, vehicle.Type);
        }

        [Test]
        public void InitiateCommentsCollection_WhenObjectIsConstructed()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;
            var vehicle = new FakeVehicle(make, model, price, vehicleType);

            // act and assert
            Assert.IsNotNull(vehicle.Comments);
        }

        [Test]
        public void ThrowArgumentNullException_WhenMakeIsNullOrEmpty()
        {
            // arrange
            string make = null;
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new FakeVehicle(make, model, price, vehicleType));
        }

        [TestCase("i")]
        [TestCase("some very very very long string that is not a valid make")]
        public void ThrowArgumentException_WhenMakeHasInvalidLength(string make)
        {
            // arrange
            string model = "benz";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;

            // act and assert
            Assert.Throws<ArgumentException>(() => new FakeVehicle(make, model, price, vehicleType));
        }

        [Test]
        public void ThrowArgumentNulException_WhenModleIsNull()
        {
            // arrange
            string make = "mercedes";
            string model = null;
            decimal price = 150m;
            var vehicleType = VehicleType.Car;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new FakeVehicle(make, model, price, vehicleType));
        }

        [TestCase("")]
        [TestCase("some very very very long string that is not a valid model")]
        public void ThrowArgumentException_WhenModelHasInvalidLength(string model)
        {
            // arrange
            string make = "mercedes";
            decimal price = 150m;
            var vehicleType = VehicleType.Car;

            // act and assert
            Assert.Throws<ArgumentException>(() => new FakeVehicle(make, model, price, vehicleType));
        }

        [TestCase(-1)]
        [TestCase(1000000.1)]
        public void ThrowArgumentException_WhenInvalidPriceIsPassed(decimal price)
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            var vehicleType = VehicleType.Car;

            // act and assert
            Assert.Throws<ArgumentException>(() => new FakeVehicle(make, model, price, vehicleType));
        }
    }
}
