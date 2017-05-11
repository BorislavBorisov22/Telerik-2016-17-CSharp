namespace Academy.Tests.Commands.Adding.AddStudentToCourseTests
{
    using Academy.Commands.Adding;
    using Academy.Core.Contracts;
    using Fakes;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CorrectlyAssignEngine_WhenObjectIsConstructed()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // act
            var command = new FakeAddStudentToCourseCommand(factoryStub.Object, engineStub.Object);

            // assert
            Assert.AreSame(engineStub.Object, command.Engine);
        }

        [Test]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            // arrange
            var engineStub = new Mock<IEngine>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, engineStub.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEngineIsNull()
        {
            // arrange
            var factoryStub = new Mock<IAcademyFactory>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factoryStub.Object, null));
        }
    }
}
