namespace Dealership.Tests.Factories.DealershipFactoryTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Factories;
    using Dealership.Models;

    [TestFixture]
    public class CreateTruck_Should
    {
        [Test]
        public void ReturnInstanceOfTruck_WhenPassedParametersAreValid()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            int weightCapacity = 1;

            var factory = new DealershipFactory();

            // act
            var returnedObj = factory.CreateTruck(make, model, price, weightCapacity);

            // assert
            Assert.IsInstanceOf<Truck>(returnedObj);       
        }
    }
}
