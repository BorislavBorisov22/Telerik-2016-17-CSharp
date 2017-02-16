namespace Dealership.Tests.Models.UserTests
{
    using Common.Enums;
    using Contracts;
    using Dealership.Models;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class AddVehicle_Should
    {
        [Test]
        public void ThrowArgumnetNullException_WhenAddingANullVehicle()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            var user = new User(username, firstName, lastName, password, role);

            IVehicle vehicle = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => user.AddVehicle(vehicle));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserRoleIsNormalAndAlreadyHas5Vehicles()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            var user = new User(username, firstName, lastName, password, role);

            var vehicleStub = new Mock<IVehicle>();
         
            for (int i=0; i < 5; i++)
            {
                user.Vehicles.Add(vehicleStub.Object);
            }

            // act and assert
            Assert.Throws<ArgumentException>(() => user.AddVehicle(vehicleStub.Object));
        }

        [Test]
        public void ThrowArgumentException_WhenUserRoleIsAdmin()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Admin;

            var user = new User(username, firstName, lastName, password, role);

            var vehicleStub = new Mock<IVehicle>();

            // act and assert
            Assert.Throws<ArgumentException>(() => user.AddVehicle(vehicleStub.Object));
        }

        [Test]
        public void AddVehicleToUser_WhenUserRoleIsNormalAndHasLessThan5Vehicles()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            var user = new User(username, firstName, lastName, password, role);

            var vehicleStub = new Mock<IVehicle>();

            // act
            user.AddVehicle(vehicleStub.Object);

            // assert
            Assert.AreSame(vehicleStub.Object, user.Vehicles.First());
        }

        [Test]
        public void AddVehicleToUser_WhenUserAlreadyHas5VehicesButRoleIsVip()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.VIP;

            var user = new User(username, firstName, lastName, password, role);

            var vehicleStub = new Mock<IVehicle>();

            for (int i=0; i< 5; i++)
            {
                user.Vehicles.Add(vehicleStub.Object);
            }

            // act
            user.AddVehicle(vehicleStub.Object);

            // assert
            Assert.AreEqual(6, user.Vehicles.Count);
        }
    }
}
