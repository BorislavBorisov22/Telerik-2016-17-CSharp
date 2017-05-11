using AcademyEcosystem.Core.Contracts;
using Moq;
using NUnit.Framework;
using System;
using AcademyEcosystem.Core;

namespace AcademyEcosystem.Tests.Core
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedReaderIsNull()
        {
            // arrange
            IReaderProvider reader = null;
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new Engine(reader, writer.Object, commandProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedWriterIsNull()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            IWriterProvider writer = null;
            var commandProvider = new Mock<ICommandProvider>();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, writer, commandProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedCommandProviderIsNull()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            ICommandProvider commandProvider = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => new Engine(reader.Object, writer.Object, commandProvider));
        }

        [Test]
        public void SetReaderCorrectly_WhenObjectIsContructedWithCorrectParameters()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new FakeEngine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreSame(reader.Object, engine.TestReader);
        }

        [Test]
        public void SetWriterCorrectly_WhenObjectIsContructedWithCorrectParameters()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new FakeEngine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreSame(writer.Object, engine.TestWriter);
        }

        [Test]
        public void SetCommandProviderCorrectly_WhenObjectIsContructedWithCorrectParameters()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new FakeEngine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreSame(commandProvider.Object, engine.TestCommandProvider);
        }

        [Test]
        public void SetAllOrganismsCollectionToNewList_WhenObjectIsConstructed()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreEqual(0, Engine.AllOgranisms.Count);
        }

        [Test]
        public void SetAnimalsCollectionToNewList_WhenObjectIsConstructed()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreEqual(0, Engine.Animals.Count);
        }

        [Test]
        public void SetPlantsCollectionToNewList_WhenObjectIsConstructed()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            // act
            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // assert
            Assert.AreEqual(0, Engine.Plants.Count);
        }
    }
}
