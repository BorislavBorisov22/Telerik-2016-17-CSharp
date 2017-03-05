namespace Academy.Tests.Models.Abstractions
{
    using System;

    using NUnit.Framework;
    using Mocks;

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_WhenPassedValidParameters_ShouldAssingParametersCorrectly()
        {
            // arrange
            string username = "valudName";

            //  act
            var user = new MockedUser(username);

            // assert
            Assert.AreEqual(user.Username, username);
        }

        [TestCase("as")]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("someveryverylongnamethatwillnotpass")]
        public void Username_WhenTryingToAssingInvalidUserName_ShouldThrowArgumentException(string invalidUsername)
        {
            // arrange
            string username = "valudName";

            var user = new MockedUser(username);

            // act and assert
            Assert.Throws<ArgumentException>(() => user.Username = invalidUsername);
        }

        [Test]
        public void Username_WhenAssigningValidUsername_ShouldNotThrowException()
        {
            // arrange
            string assigningValidName = "newValidName";
            string username = "valudName";

            var user = new MockedUser(username);

            // act and assert
            Assert.DoesNotThrow(() => user.Username = assigningValidName);
        }

        [Test]
        public void Username_WhenAssigningValidUsername_ShouldAssingNewValueCorrectly()
        {
            // arrange
            string assigningValidName = "newValidName";
            string username = "valudName";

            var user = new MockedUser(username);

            // act
            user.Username = assigningValidName;

            // assert
            Assert.AreEqual(user.Username, assigningValidName);
        }
    }
}
