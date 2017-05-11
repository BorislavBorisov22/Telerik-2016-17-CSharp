namespace Academy.Tests.Commands.Adding.AddStudentToSeasonCommandTests
{
    using System;

    using NUnit.Framework;
    using Academy.Core.Contracts;
    using Moq;
    using Fakes;
    using Academy.Commands.Adding;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CorrectlyAssignFactory_WhenObjectIsConstructed()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // act
            var command = new FakeAddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            // assert
            Assert.AreSame(factoryStub.Object, command.Factory);
        }

        [Test]
        public void CorrectlyAssignEngine_WhenObjectIsConstructed()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // act
            var command = new FakeAddStudentToSeasonCommand(factoryStub.Object, engineStub.Object);

            // assert
            Assert.AreSame(engineStub.Object, command.Engine);
        }

        [Test]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            // arrange
            var engineStub = new Mock<IEngine>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEngineIsNull()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryStub.Object, null));
        }
    }
}
