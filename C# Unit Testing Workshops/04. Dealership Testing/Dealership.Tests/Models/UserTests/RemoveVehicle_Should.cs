namespace Dealership.Tests.Models.UserTests
{
    using System;

    using NUnit.Framework;
    using Common.Enums;
    using Dealership.Models;
    using Moq;
    using Contracts;

    [TestFixture]
    public class RemoveVehicle_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTryingToRemoveNullVehicle()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            var user = new User(username, firstName, lastName, password, role);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => user.RemoveVehicle(null));
        }

        [Test]
        public void RemoveVehicleFromUserVehicles_WhenPassedAValidVehicle()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            var user = new User(username, firstName, lastName, password, role);

            var vehicleStub = new Mock<IVehicle>();
            user.Vehicles.Add(vehicleStub.Object);

            // act
            user.RemoveVehicle(vehicleStub.Object);

            // assert
            Assert.AreEqual(0, user.Vehicles.Count);
        }
    }
}
