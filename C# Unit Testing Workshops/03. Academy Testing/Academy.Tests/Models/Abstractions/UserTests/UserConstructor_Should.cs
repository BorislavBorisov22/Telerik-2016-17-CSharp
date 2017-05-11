namespace Academy.Tests.Models.Abstractions.UserTests
{
    using System;

    using NUnit.Framework;
    using Fakes;

    [TestFixture]
    public class UserConstructor_Should
    {
        [Test]
        public void CorrectlyAssignPassedValues_WhenTheyAreValid()
        {
            // arrange
            string username = "validName";

            // act
            var user = new FakeUser(username);

            // assert
            Assert.AreEqual(username, user.Username);
        }
    }
}
