namespace Dealership.Tests.Models.UserTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Models;
    using Common.Enums;

    [TestFixture]
    public class UserConstructor_Should
    {
        [Test]
        public void AssignUsernameCorrectly_WhenObjectIsCOnstructed()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act
            var user = new User(username, firstName, lastName, password, role);

            // assert
            Assert.AreEqual(username, user.Username);
        }

        [Test]
        public void AssignFirstNameCorrectly_WhenObjectIsCOnstructed()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act
            var user = new User(username, firstName, lastName, password, role);

            // assert
            Assert.AreEqual(firstName, user.FirstName);
        }

        [Test]
        public void AssignLastNameCorrectly_WhenObjectIsCOnstructed()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act
            var user = new User(username, firstName, lastName, password, role);

            // assert
            Assert.AreEqual(lastName, user.LastName);
        }

        [Test]
        public void AssignPasswordCorrectly_WhenObjectIsCOnstructed()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act
            var user = new User(username, firstName, lastName, password, role);

            // assert
            Assert.AreEqual(password, user.Password);
        }

        [Test]
        public void AssignRoleCorrectly_WhenObjectIsCOnstructed()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act
            var user = new User(username, firstName, lastName, password, role);

            // assert
            Assert.AreEqual(role, user.Role);
        }

        [Test]
        public void InitiateCollectionOfVehicles_WhenObjectIsConstructed()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act
            var user = new User(username, firstName, lastName, password, role);

            // assert
            Assert.IsNotNull(user.Vehicles);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassingNullName()
        {
            // arrange
            string username = null;
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new User(username, firstName, lastName, password, role));
        }


        [Test]
        public void ThrowArgumentNullException_WhenPassingNullFistName()
        {
            // arrange
            string username = "validName";
            string firstName = null;
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new User(username, firstName, lastName, password, role));
        }


        [Test]
        public void ThrowArgumentNullException_WhenPassingNullLastName()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = null;
            string password = "12345678";
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new User(username, firstName, lastName, password, role));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassingNullPassword()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = null;
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new User(username, firstName, lastName, password, role));
        }

        [TestCase("i")]
        [TestCase("some very very very long invalid username")]
        [TestCase("..213")]
        public void ThrowArgumentException_WhenInvalidUsernameIsPassed(string username)
        {
            // arrange
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentException>(() => new User(username, firstName, lastName, password, role));
        }

        [TestCase("i")]
        [TestCase("some very very very very long first name that is invalid")]
        public void ThrowArgumentException_WhenInvalidFirstNameIsPassed(string firstName)
        {
            // arrange
            string username = "validName";
            string lastName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentException>(() => new User(username, firstName, lastName, password, role));
        }


        [TestCase("i")]
        [TestCase("some very very very very long first name that is invalid")]
        public void ThrowArgumentException_WhenInvalidLastNameIsPassed(string lastName)
        {
            // arrange
            string username = "validName";
            string firstName = "Ivanov";
            string password = "12345678";
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentException>(() => new User(username, firstName, lastName, password, role));
        }

        [Test]
        public void ThrowArgumentException_WhenInvalidPasswordSymbolsArePassed()
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            string password = "!!!invalidinvalidsymbols**/////";
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentException>(() => new User(username, firstName, lastName, password, role));
        }

        [TestCase("aaaa")]
        [TestCase("some somesome somesome somesome somesome somesome somesome somesome somesome some long pass")]
        public void ThrowArgumentException_WhenInvalidPasswordLengthIsPassed(string password)
        {
            // arrange
            string username = "validName";
            string firstName = "Ivan";
            string lastName = "Ivanov";
            var role = Role.Normal;

            // act and assert
            Assert.Throws<ArgumentException>(() => new User(username, firstName, lastName, password, role));
        }
    }
}
