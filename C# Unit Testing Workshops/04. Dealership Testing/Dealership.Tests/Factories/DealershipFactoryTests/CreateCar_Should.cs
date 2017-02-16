namespace Dealership.Tests.Factories.DealershipFactoryTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Factories;
    using Dealership.Models;

    [TestFixture]
    public class CreateCar_Should
    {
        [Test]
        public void ReturnInstanceOfACar_WhenPassedParameterAreValid()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            int seats = 6;
            
            var factory = new DealershipFactory();

            // act
            var returnedCar = factory.CreateCar(make, model, price, seats);

            // assert
            Assert.IsInstanceOf<Car>(returnedCar);
        }
    }
}
