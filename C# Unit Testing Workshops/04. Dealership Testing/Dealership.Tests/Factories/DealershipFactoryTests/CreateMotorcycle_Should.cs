namespace Dealership.Tests.Factories.DealershipFactoryTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Factories;
    using Dealership.Models;

    [TestFixture]
    public class CreateMotorcycle_Should
    {
        [Test]
        public void ReturnInstacneOfMotorcyle_WhenPassedParametersAreValid()
        {
            // arrange
            string make = "mercedes";
            string model = "benz";
            decimal price = 150m;
            string category = "category";

            var factory = new DealershipFactory();

            // act
            var returnedObj = factory.CreateMotorcycle(make, model, price, category);

            // assert
            Assert.IsInstanceOf<Motorcycle>(returnedObj);
        }
    }
}
