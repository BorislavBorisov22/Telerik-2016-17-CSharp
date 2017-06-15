using Moq;
using NUnit.Framework;
using ProjectManager.Commands.Creational;
using ProjectManager.Data.Data.Contracts;
using ProjectManager.Data.Factories;
using System;

namespace ProjectManager.Tests.Commands.CreateUserCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedAddUserIsNull()
        {
            // arrange
            var addUser = new Mock<IAddUser>();
            var userFactory = new Mock<IUserFactory>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new CreateUserCommand(null, userFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedUserFactoryIsNull()
        {
            // arrange
            var addUser = new Mock<IAddUser>();
            var userFactory = new Mock<IUserFactory>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new CreateUserCommand(addUser.Object, null));
        }

        [Test]
        public void NotThrow_WhenPassedArgumentAreAllValid()
        {
            // arrange
            var addUser = new Mock<IAddUser>();
            var userFactory = new Mock<IUserFactory>();

            // act and assert
            Assert.DoesNotThrow(() => new CreateUserCommand(addUser.Object, userFactory.Object));
        }
    }
}
