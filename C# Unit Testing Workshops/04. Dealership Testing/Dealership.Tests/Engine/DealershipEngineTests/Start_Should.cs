namespace Dealership.Tests.Engine.DealershipEngineTests
{
    using Common.Enums;
    using Contracts;
    using Dealership.Engine;
    using Dealership.Factories;
    using Fakes;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void CallEngineLoggersWriteMethod_WhenFinishedProcessingCommands()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userToAddStub = new Mock<IUser>();

            string commandName = "InvalidCommandName";

            commandStub.Setup(x => x.Name).Returns(commandName);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Write(It.IsAny<string>()));

            engine.Logger = loggerMock.Object;

            // act
            engine.Start();

            // asssert
            loggerMock.Verify(x => x.Write(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddNewUserToEngineUsers_WhenProcessingValidCommandForRegisteringUser()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userToAddStub = new Mock<IUser>();

            string commandName = "RegisterUser";
            string username = "validUsername";
            string firstName = "Borislav";
            string lastName = "Borisov";
            string password = "1234567";
            string role = "Normal";

            var parametersCommand = new List<string>()
            {
                username,
                firstName,
                lastName,
                password,
                role
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            factoryStub.Setup(x =>
            x.CreateUser(It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()
            ))
            .Returns(userToAddStub.Object);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            // act
            engine.Start();

            // asssert
            Assert.AreSame(userToAddStub.Object, engine.Users.First());
        }

        [Test]
        public void NotAddUserWithTheSameName_WhenProcessingCommandForRegusteringAlredyRegisteresUser()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userToAddStub = new Mock<IUser>();

            string commandName = "RegisterUser";
            string username = "validUsername";
            string firstName = "Borislav";
            string lastName = "Borisov";
            string password = "1234567";
            string role = "Normal";

            userToAddStub.Setup(x => x.Username).Returns(username);

            var parametersCommand = new List<string>()
            {
                username,
                firstName,
                lastName,
                password,
                role
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            factoryStub.Setup(x =>
            x.CreateUser(It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()
            ))
            .Returns(userToAddStub.Object);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            engine.Users.Add(userToAddStub.Object);

            // act
            engine.Start();

            // asssert
            Assert.AreEqual(1, engine.Users.Count);
        }

        [Test]
        public void NotAddUserToEngineUsers_WhenProcessingRegisterUserCommandButWithUserAlreadyLoggedIn()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userToAddStub = new Mock<IUser>();

            string commandName = "RegisterUser";
            string username = "validUsername";
            string firstName = "Borislav";
            string lastName = "Borisov";
            string password = "1234567";
            string role = "Normal";

            var parametersCommand = new List<string>()
            {
                username,
                firstName,
                lastName,
                password,
                role
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            factoryStub.Setup(x =>
            x.CreateUser(It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>()
            ))
            .Returns(userToAddStub.Object);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggedUserStub = new Mock<IUser>();
            engine.LoggedUser = loggedUserStub.Object;

            // act
            engine.Start();

            // asssert
            Assert.AreEqual(0, engine.Users.Count);
        }

        [Test]
        public void SetLoggedUserCorrectly_WhenProcessingValidParametersLoginCommand()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userToLogStub = new Mock<IUser>();

            string commandName = "Login";
            string username = "validUsername";
            string password = "12345678";

            userToLogStub.Setup(x => x.Username).Returns(username);
            userToLogStub.Setup(x => x.Password).Returns(password);

            var parametersCommand = new List<string>()
            {
                username,
                password
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            engine.Users.Add(userToLogStub.Object);

            // act
            engine.Start();

            // asssert
            Assert.AreSame(userToLogStub.Object, engine.LoggedUser);
        }

        [Test]
        public void NotChangeLoggedUser_WhenProcessingLoginCommandButAUserIsAlreadyLoggedIn()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userToLogStub = new Mock<IUser>();

            string commandName = "Login";
            string username = "validUsername";
            string password = "12345678";

            userToLogStub.Setup(x => x.Username).Returns(username);
            userToLogStub.Setup(x => x.Password).Returns(password);

            var parametersCommand = new List<string>()
            {
                username,
                password
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var alreadyLoggedUser = new Mock<IUser>();

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);
            engine.LoggedUser = alreadyLoggedUser.Object;
            engine.Users.Add(userToLogStub.Object);

            // act
            engine.Start();

            // asssert
            Assert.AreSame(alreadyLoggedUser.Object, engine.LoggedUser);
            Assert.AreNotSame(userToLogStub.Object, engine.LoggedUser);
        }

        [Test]
        public void NotSetLoggedUser_WhenLoggingAUserWithCorrectUsernameButWrongPassword()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userToLogStub = new Mock<IUser>();

            string commandName = "Login";
            string username = "validUsername";
            string password = "12345678";

            string realPassword = "4554314132";
            userToLogStub.Setup(x => x.Username).Returns(username);
            userToLogStub.Setup(x => x.Password).Returns(realPassword);

            var parametersCommand = new List<string>()
            {
                username,
                password
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            engine.Users.Add(userToLogStub.Object);

            // act
            engine.Start();

            // asssert
            Assert.IsNull(engine.LoggedUser);
        }

        [Test]
        public void SetLoggedUserToNull_WhenProcessingValidLogOutCommand()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();

            string commandName = "Logout";


            var parametersCommand = new List<string>();

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commandListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commandListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggedUserStub = new Mock<IUser>();
            engine.LoggedUser = loggedUserStub.Object;

            // act
            engine.Start();

            // asssert
            Assert.IsNull(engine.LoggedUser);
        }

        [Test]
        public void InvokeLoggedUserAddVehicleMethod_WhenProcessingValidAddVehicleCommand()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();

            string commandName = "AddVehicle";
            string vehicleType = "Car";
            string make = "Volkswagen";
            string model = "Golf mk4";
            string price = "900";
            string additionalParam = "5"; // car -> seats count

            var carToAddStub = new Mock<IVehicle>();

            var parametersCommand = new List<string>()
            {
                vehicleType,
                make,
                model,
                price,
                additionalParam
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            factoryStub.Setup(x =>
            x.CreateCar(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<int>()
            ))
            .Returns(carToAddStub.Object);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggedUserMock = new Mock<IUser>();
            loggedUserMock.Setup(x => x.AddVehicle(It.IsAny<IVehicle>()));
            engine.LoggedUser = loggedUserMock.Object;

            // act
            engine.Start();

            // asssert
            loggedUserMock.Verify(x => x.AddVehicle(It.IsAny<IVehicle>()), Times.Once);
        }

        [Test]
        public void InvokeLoggedUsersRemoveVehicleMethod_WhenProcessingRemoveVehicleCommnadWithValidInRangeVehicleIndex()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();

            string commandName = "RemoveVehicle";
            string indexVehicle = "1";

            var parametersCommand = new List<string>()
            {
                indexVehicle
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggedUserMock = new Mock<IUser>();

            var loggedUserVehicle = new Mock<IVehicle>();
            var loggedUserVehicles = new List<IVehicle>() { loggedUserVehicle.Object };
            loggedUserMock.Setup(x => x.Vehicles).Returns(loggedUserVehicles);

            loggedUserMock.Setup(x => x.RemoveVehicle(It.IsAny<IVehicle>()));

            engine.LoggedUser = loggedUserMock.Object;

            // act
            engine.Start();

            // assert
            loggedUserMock.Verify(
                x => x.RemoveVehicle(It.IsAny<IVehicle>()),
                Times.Once
                );
        }

        [Test]
        public void InvokeLoggedUserAddCommentMethod_WhenProcessingValidAddCommentCommandWithAuthroThatIsEistingInEnginesUsers()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();

            string commandName = "AddComment";
            string content = "SomeRandomContent";
            string author = "Ivancho";
            string vehicleIndex = "1";

            var parametersCommand = new List<string>()
            {
                content,
                author,
                vehicleIndex
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var userStub = new Mock<IUser>();
            userStub.Setup(x => x.Username).Returns(author);

            var userMockVehicle = new Mock<IVehicle>();
            var userMockVehicles = new List<IVehicle>() { userMockVehicle.Object };
            userStub.Setup(x => x.Vehicles).Returns(userMockVehicles);

            var commentToAddStub = new Mock<IComment>();

            factoryStub.Setup(x => x.CreateComment(It.IsAny<string>()))
                .Returns(commentToAddStub.Object);

            engine.Users.Add(userStub.Object);

            var loggedUserMock = new Mock<IUser>();
            loggedUserMock.Setup(x => x.AddComment(It.IsAny<IComment>(), It.IsAny<IVehicle>()));
            engine.LoggedUser = loggedUserMock.Object;

            // act
            engine.Start();

            // assert
            loggedUserMock.Verify(
                x => x.AddComment(It.IsAny<IComment>(), It.IsAny<IVehicle>()),
                Times.Once);
        }

        [Test]
        public void InvkodeLoggedUsersRemoveCommentMethod_WhenProcessingValidRemoveCommentCommandWithValidParameter()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();

            string commandName = "RemoveComment";
            string vehicleIndex = "1";
            string commentIndex = "1";
            string username = "Invacho";

            var parametersCommand = new List<string>()
            {
                vehicleIndex,
                commentIndex,
                username
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(parametersCommand);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var userStub = new Mock<IUser>();
            userStub.Setup(x => x.Username).Returns(username);

            var commentStub = new Mock<IComment>();
            var vehicleComments = new List<IComment>() { commentStub.Object };

            var userMockVehicle = new Mock<IVehicle>();
            userMockVehicle.Setup(x => x.Comments).Returns(vehicleComments);
            var userMockVehicles = new List<IVehicle>() { userMockVehicle.Object };
            userStub.Setup(x => x.Vehicles).Returns(userMockVehicles);

            engine.Users.Add(userStub.Object);

            var loggedUserMock = new Mock<IUser>();
            loggedUserMock.Setup(x => x.RemoveComment(It.IsAny<IComment>(), It.IsAny<IVehicle>()));
            engine.LoggedUser = loggedUserMock.Object;

            // act
            engine.Start();

            // assert
            loggedUserMock.Verify(
                x => x.RemoveComment(It.IsAny<IComment>(), It.IsAny<IVehicle>()),
                Times.Once);
        }

        [Test]
        public void InvokeEnginesWriterWithStringThatContainsAdming_WhenTryingToShowUsersToAUserThatIsNotAdmin()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();

            string commandName = "ShowUsers";

            commandStub.Setup(x => x.Name).Returns(commandName);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggedUsserStub = new Mock<IUser>();
            loggedUsserStub.Setup(x => x.Role).Returns(Role.Normal);

            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Write(It.Is<string>(y => y.Contains("admin"))));

            engine.Logger = loggerMock.Object;
            engine.LoggedUser = loggedUsserStub.Object;

            // act
            engine.Start();

            // assert
            loggerMock.Verify(
                x => x.Write(It.Is<string>(y => y.Contains("admin"))), Times.Once
                );
        }

        [Test]
        public void InvokeAllEngineUsersToStringMethod_WhenProcesingValidShowUsersCommandWithAdminLoggedUser()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userMock = new Mock<IUser>();

            userMock.Setup(x => x.ToString());

            string commandName = "ShowUsers";

            commandStub.Setup(x => x.Name).Returns(commandName);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggedUsserStub = new Mock<IUser>();
            loggedUsserStub.Setup(x => x.Role).Returns(Role.Admin);

            engine.LoggedUser = loggedUsserStub.Object;
            engine.Users.Add(userMock.Object);

            // act
            engine.Start();

            // assert
            userMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void InvokeUsersPrintVehiclesMethod_WhenProcessingAValidShowVehiclesCommandWithUsernameThatIsCOnatinedInEnginesUsers()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();
            var userMock = new Mock<IUser>();


            string commandName = "ShowVehicles";
            string username = "Invancho";

            userMock.Setup(x => x.PrintVehicles());
            userMock.Setup(x => x.Username).Returns(username);

            var commandParameters = new List<string>()
            {
                username
            };

            commandStub.Setup(x => x.Name).Returns(commandName);
            commandStub.Setup(x => x.Parameters).Returns(commandParameters);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggedUsserStub = new Mock<IUser>();
            loggedUsserStub.Setup(x => x.Role).Returns(Role.Admin);

            engine.LoggedUser = loggedUsserStub.Object;
            engine.Users.Add(userMock.Object);

            // act
            engine.Start();

            // assert
            userMock.Verify(x => x.PrintVehicles(), Times.Once);
        }

        [Test]
        public void InvokeEnginesLoggerWriteMethodWithStrinsContainingInvalidCommand_WhenProcessingInvalidCommand()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var commandStub = new Mock<ICommand>();

            string commandName = "invalidCommandName";

            commandStub.Setup(x => x.Name).Returns(commandName);

            var commnadListToReturn = new List<ICommand>() { commandStub.Object };

            commandParserStub.Setup(x => x.ReadCommands()).
                Returns(commnadListToReturn);

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            var loggerMock = new Mock<ILogger>();
            string expectedContainedString = "Invalid command";
            loggerMock.Setup(x => x.Write(It.Is<string>(y => y.Contains(expectedContainedString))));

            var loggedUserStub = new Mock<IUser>();
            engine.LoggedUser = loggedUserStub.Object;

            engine.Logger = loggerMock.Object;

            // act
            engine.Start();

            // assert
            loggerMock.Verify(
                x => x.Write(It.Is<string>(y => y.Contains(expectedContainedString))),
                Times.Once
                );
        }
    }
}
