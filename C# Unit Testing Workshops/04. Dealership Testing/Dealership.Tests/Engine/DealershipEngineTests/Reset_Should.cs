namespace Dealership.Tests.Engine.DealershipEngineTests
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Dealership.Factories;
    using Contracts;
    using Fakes;
    using System.Collections.Generic;
    using Dealership.Engine;

    [TestFixture]
    public class Reset_Should
    {
        [Test]
        public void SetUsersCollectionToEmpty_WhenResetCalled()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();

            var userStub = new Mock<IUser>();
           
            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            engine.Users.Add(userStub.Object);

            // act
            engine.Reset();

            // assert
            Assert.AreEqual(0, engine.Users.Count);
        }

        [Test]
        public void SetLoggedUserToNull_WhenResetCalled()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();

            var userStub = new Mock<IUser>();

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            engine.LoggedUser = userStub.Object;

            // act
            engine.Reset();

            // assert
            Assert.IsNull(engine.LoggedUser);
        }

        [Test]
        public void SetFactoryToDeafultDealershipFactory_WhenResetCalled()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);
            
            // act
            engine.Reset();

            // assert
            Assert.IsInstanceOf<DealershipFactory>(engine.Factory);
        }

        [Test]
        public void SetCommandParserToDeafultConsoleCommandParser_WhenResetCalled()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            // act
            engine.Reset();

            // assert
            Assert.IsInstanceOf<ConsoleCommandParser>(engine.CommandParser);
        }
    }
}
