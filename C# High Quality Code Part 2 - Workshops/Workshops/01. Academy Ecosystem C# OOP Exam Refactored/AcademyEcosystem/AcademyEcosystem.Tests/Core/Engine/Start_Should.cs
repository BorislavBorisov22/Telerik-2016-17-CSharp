
using AcademyEcosystem.Commands.Contracts;
using AcademyEcosystem.Core.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AcademyEcosystem.Tests.Core
{
    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void CallReadersReadLineMethodOnce_WhenFirstLineReadIsTerminationCommand()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            reader.Setup(x => x.ReadLine())
                .Returns("end");

            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // act
            engine.Start();

            // assert
            reader.Verify(x => x.ReadLine(), Times.Once);
        }

        [Test]
        public void CallReadersReadLineTwice_WhenSecondCommandIsTerminationCommand()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            reader.SetupSequence(x => x.ReadLine())
                .Returns("invalid command that will still work for the test!")
                .Returns("end");

            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // act
            engine.Start();

            // assert
            reader.Verify(x => x.ReadLine(), Times.Exactly(2));
        }

        [Test]
        public void CallCommandProvidersGetCommandOnce_WhenFirstPassedCommandIsValidAndSecondIsTermination()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Execute(It.IsAny<IList<string>>()))
            .Returns("some message");

            commandProvider.Setup(x => x.GetCommand(It.IsAny<IList<string>>()))
                .Returns(command.Object);

            reader.SetupSequence(x => x.ReadLine())
                .Returns("birth bush (0, 0)")
                .Returns("end");

            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // act
            engine.Start();

            // assert
            commandProvider.Verify(x => x.GetCommand(It.IsAny<IList<string>>()), Times.Once);
        }

        [Test]
        public void CallGottenCommandFromProvidersExecuteMethodOnce_WhenFirstPassedCommandIsValidAndSecondIsTermination()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            var command = new Mock<ICommand>();
            command.Setup(x => x.Execute(It.IsAny<IList<string>>()))
            .Returns("some message");

            commandProvider.Setup(x => x.GetCommand(It.IsAny<IList<string>>()))
                .Returns(command.Object);

            reader.SetupSequence(x => x.ReadLine())
                .Returns("birth bush (0, 0)")
                .Returns("end");

            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // act
            engine.Start();

            // assert
            command.Verify(x => x.Execute(It.IsAny<IList<string>>()), Times.Once);
        }

        [Test]
        public void CallWriterWriteMethodWithValidMessage_WhenExecutedCommandReturnsNonEmptyString()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            string commandMessage = "some message";
            var command = new Mock<ICommand>();
            command.Setup(x => x.Execute(It.IsAny<IList<string>>()))
            .Returns(commandMessage);

            commandProvider.Setup(x => x.GetCommand(It.IsAny<IList<string>>()))
                .Returns(command.Object);

            reader.SetupSequence(x => x.ReadLine())
                .Returns("birth bush (0, 0)")
                .Returns("end");

            writer
                .Setup(x => x.WriteLine(It.Is<string>(str => str == commandMessage)))
                .Verifiable();

            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // act
            engine.Start();

            // assert
            writer.Verify();
        }

        [Test]
        public void NotCallWriterWriteMethodAtAll_WhenExecutedCommandReturnsEmptyString()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            string commandMessage = string.Empty;
            var command = new Mock<ICommand>();
            command.Setup(x => x.Execute(It.IsAny<IList<string>>()))
            .Returns(commandMessage);

            commandProvider.Setup(x => x.GetCommand(It.IsAny<IList<string>>()))
                .Returns(command.Object);

            reader.SetupSequence(x => x.ReadLine())
                .Returns("birth bush (0, 0)")
                .Returns("end");

            var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // act
            engine.Start();

            // assert
            writer.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void CallWritersWriteMethodWithTheThrownExceptionMessage_WhenExceptionIsThrowInTheMethod()
        {
            // arrange
            var reader = new Mock<IReaderProvider>();
            var writer = new Mock<IWriterProvider>();
            var commandProvider = new Mock<ICommandProvider>();

            string exceptionMessage = "Some exception message to check";
            commandProvider.Setup(x => x.GetCommand(It.IsAny<IList<string>>()))
                .Throws(new ArgumentException(exceptionMessage));
                
            reader.SetupSequence(x => x.ReadLine())
                .Returns("birth bush (0, 0)")
                .Returns("end");

            writer.Setup(x => x.WriteLine(It.Is<string>(str => str == exceptionMessage)))
                .Verifiable();


           var engine = new Engine(reader.Object, writer.Object, commandProvider.Object);

            // act
            engine.Start();

            // assert
            writer.Verify();
        }
    }
}
