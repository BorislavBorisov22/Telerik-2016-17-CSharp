namespace SchoolSystem.Tests.Core.Engine
{
    using System;

    using NUnit.Framework;
    using Moq;
    using SchoolSystem.Contracts;
    using Fakes;
    using SchoolSystem.Core;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedReaderIsNull()
        {
            // arrange
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new Engine(null, writer.Object, commandProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedWriterIsNull()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, null, commandProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedCommandProviderIsNull()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, writer.Object , null));
        }

        [Test]
        public void SetCorrectReaderValue_WhenAllPassedParametersAreValid()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new FakeEngine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreSame(engine.ReaderProviderExposed, reader.Object);
        }


        [Test]
        public void SetCorrectWriterValue_WhenAllPassedParametersAreValid()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new FakeEngine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreSame(engine.WriterProviderExposed, writer.Object);
        }

        [Test]
        public void SetCorrectCommandProviderValue_WhenAllPassedParametersAreValid()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new FakeEngine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreSame(engine.CommandProviderExposed, commandProvider.Object);
        }
    }
}
