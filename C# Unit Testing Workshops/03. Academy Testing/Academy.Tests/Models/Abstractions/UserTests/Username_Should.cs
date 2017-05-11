using Academy.Tests.Models.Abstractions.UserTests.Fakes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Abstractions.UserTests
{
    [TestFixture]
    public class Username_Should
    {
        [TestCase(null)]
        [TestCase("ss")]
        [TestCase("very very very very very very very very veryvery very veryvery very very long")]
        public void ThrowArgumentException_WhenPassedValueIsInvalid(string invalidUsername)
        {
            // arrange
            string initialUsername = "validName";
            var user = new FakeUser(initialUsername);

            // act and assert
            Assert.Throws<ArgumentException>(() => user.Username = invalidUsername);
        }

        [Test]
        public void NotThrow_WhenPassedValueIsValid()
        {
            // arrange
            string initialUsername = "validName";
            var user = new FakeUser(initialUsername);

            string newUsername = "anotherValidName";

            // act and assert
            Assert.DoesNotThrow(() => user.Username = newUsername);
        }

        [Test]
        public void ShouldCorrectlyAssignPassedValue_WhenItIsValid()
        {
            // arrange
            string initialUsername = "validName";
            var user = new FakeUser(initialUsername);

            string newUsername = "anotherValidName";

            // act
            user.Username = newUsername;

            // act and assert
            Assert.AreEqual(user.Username, newUsername);
        }
    }
}
