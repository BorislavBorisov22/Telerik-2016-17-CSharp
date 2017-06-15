using Moq;
using NUnit.Framework;
using ProjectManager.Commands.Creational;
using ProjectManager.Data.Data.Contracts;
using ProjectManager.Data.Factories;
using ProjectManager.Data.Models.Contracts;
using System.Collections.Generic;

namespace ProjectManager.Tests.Commands.CreateUserCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void CallUserFactoryWithCorrectUsernameAndEmailParameters_WhenPassedParametersListIsValid()
        {
            // arrange
            var addUser = new Mock<IAddUser>();
            var userFactory = new Mock<IUserFactory>();

            string projectId = "0";
            string username = "someUsername";
            string email = "someEmail";
            var commandParameters = new List<string>() { projectId, username, email };

            var createUserCommand = new CreateUserCommand(addUser.Object, userFactory.Object);

            // act 
            createUserCommand.Execute(commandParameters);

            // assert
            userFactory.Verify(x => x.CreateUser(username, email), Times.Once);
        }

        [Test]
        public void CallAddUsersAddUserMethodWithCorrectProjectIdAndUser_WhenPassedParametersListIsValid()
        {
            // arrange
            var addUser = new Mock<IAddUser>();
            var userFactory = new Mock<IUserFactory>();
            var user = new Mock<IUser>();

            userFactory.Setup(x => x.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user.Object);

            string projectId = "0";
            string username = "someUsername";
            string email = "someEmail";
            var commandParameters = new List<string>() { projectId, username, email };

            var createUserCommand = new CreateUserCommand(addUser.Object, userFactory.Object);

            // act 
            createUserCommand.Execute(commandParameters);

            // assert
            addUser.Verify(x => x.AddUser(0, It.Is<IUser>(u => u == user.Object)), Times.Once);
        }

        [Test]
        public void ReturnCorrectMessage_WhenUserHasBeenSuccessfullyCreated()
        {
            // arrange
            var addUser = new Mock<IAddUser>();
            var userFactory = new Mock<IUserFactory>();
            var user = new Mock<IUser>();

            userFactory.Setup(x => x.CreateUser(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(user.Object);

            string projectId = "0";
            string username = "someUsername";
            string email = "someEmail";
            var commandParameters = new List<string>() { projectId, username, email };

            var createUserCommand = new CreateUserCommand(addUser.Object, userFactory.Object);
            string expectedMessage = "Successfully created a new user!";

            // act 
            string resultMessage = createUserCommand.Execute(commandParameters);

            // assert
            StringAssert.Contains(expectedMessage, resultMessage);
        }
    }
}
