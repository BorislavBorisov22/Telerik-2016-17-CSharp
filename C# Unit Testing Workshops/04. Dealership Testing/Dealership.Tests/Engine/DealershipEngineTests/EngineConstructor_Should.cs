namespace Dealership.Tests.Engine.DealershipEngineTests
{
    using System;

    using NUnit.Framework;
    using Dealership.Engine;
    using Moq;
    using Contracts;
    using Dealership.Factories;
    using Fakes;

    [TestFixture]
    public class EngineConstructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedNullFactory()
        {
            // arrange
            var commandParserStub = new Mock<ICommandParser>();
            //var engine = new DealershipEngine(null, commandParserStub.Object);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new DealershipEngine(null, commandParserStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedNullCommandParser()
        {
            // arrange
            var factoryStub = new Mock<IDealershipFactory>();
            //var engine = new DealershipEngine(null, commandParserStub.Object);

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new DealershipEngine(factoryStub.Object, null));
        }

        [Test]
        public void AssingFactoryCoorectly_WhenObjectIsConstructed()
        {
            // arrange and act
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            // act and assert
            Assert.AreSame(factoryStub.Object, engine.Factory);
        }

        [Test]
        public void AssingCommandParserCoorectly_WhenObjectIsConstructed()
        {
            // arrange and act
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            // act and assert
            Assert.AreSame(commandParserStub.Object, engine.CommandParser);
        }

        [Test]
        public void InitiateUsersCollection_WhenObjectIsConstructed()
        {
            // arrange and act
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            // act and assert
            Assert.IsNotNull(engine.Users);
        }

        [Test]
        public void SetsLoggerUserToNull_WhenObjectIsConstructed()
        {
            // arrange and act
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();
            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            // act and assert
            Assert.IsNull(engine.LoggedUser);
        }

        [Test]
        public void SetLoggerToConsoleLoggerInstance_WhenObjectIsConstructed()
        {
            // arrange and act
            var factoryStub = new Mock<IDealershipFactory>();
            var commandParserStub = new Mock<ICommandParser>();

            var engine = new FakeDealershipEngine(factoryStub.Object, commandParserStub.Object);

            // assert
            Assert.IsInstanceOf<ConsoleLogger>(engine.Logger);
        }
    }
}
