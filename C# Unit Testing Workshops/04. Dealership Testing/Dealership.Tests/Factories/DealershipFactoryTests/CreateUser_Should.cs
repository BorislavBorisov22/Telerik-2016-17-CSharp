namespace Dealership.Tests.Factories.DealershipFactoryTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Factories;
    using Dealership.Models;
    using Common.Enums;

    [TestFixture]
    public class CreateUser_Should
    {
        [Test]
        public void ReturnUserInstance_WhenPassedParametersAreValid()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            string role = Role.Normal.ToString();

            var factory = new DealershipFactory();

            // act
            var returnedObj = factory.CreateUser(username, firstName, lastName, password, role);

            // assert
            Assert.IsInstanceOf<User>(returnedObj);
        }
    }
}
