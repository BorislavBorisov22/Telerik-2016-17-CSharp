namespace Dealership.Tests.Models.UserTests
{
    using System;

    using NUnit.Framework;
    using Common.Enums;
    using Dealership.Models;
    using Moq;
    using Contracts;

    [TestFixture]
    public class PrintVehicles_Should
    {
        [Test]
        public void CallAllUserVehiclesToString_WhenCalled()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.VIP;

            var user = new User(username, firstName, lastName, password, role);

            var vehicleStub = new Mock<IVehicle>();
            vehicleStub.Setup(x => x.ToString());

            user.Vehicles.Add(vehicleStub.Object);

            // act
            user.PrintVehicles();

            // assert
            vehicleStub.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ReturnAStringThatCointainsNoVehicles_WhenCalledWithNoUserVehicles()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.VIP;

            var user = new User(username, firstName, lastName, password, role);

            string expectedString = "NO VEHICLES";

            // act
            var returnedString = user.PrintVehicles();

            // assert
            StringAssert.Contains(expectedString, returnedString);
        }
    }
}
