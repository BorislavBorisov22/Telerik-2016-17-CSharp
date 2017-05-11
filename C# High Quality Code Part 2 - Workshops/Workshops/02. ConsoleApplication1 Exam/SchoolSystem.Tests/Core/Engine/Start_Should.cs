namespace SchoolSystem.Tests.Core.Engine
{
    using Moq;
    using NUnit.Framework;
    using SchoolSystem.Contracts;
    using SchoolSystem.Core;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Start_Should
    { 
        [Test]
        public void CallReadersReadLineOnce_WhenTheReadCommandIsEnd()
        {
            // arrange
            var readerMock = new Mock<IReaderProvider>();
            var writerStub = new Mock<IWriterProvider>();
            var commandProviderStub = new Mock<ICommandProvider>();

            readerMock.Setup(x => x.ReadLine()).Returns("End");

            var engine = new Engine(readerMock.Object, writerStub.Object, commandProviderStub.Object);

            // act
            engine.Start();

            // assert
            readerMock.Verify(x => x.ReadLine(), Times.Once);
        }

        [Test]
        public void CallReadersReadLineMethodThreeTimes_WhenTheThirdCommandIsEnd()
        {
            // arrange
            var readerMock = new Mock<IReaderProvider>();
            var writerStub = new Mock<IWriterProvider>();
            var commandProviderStub = new Mock<ICommandProvider>();

            readerMock.SetupSequence(x => x.ReadLine())
                .Returns("AddStudent Ivan Ivanov 3")
                .Returns("RemoveStudent Ivan Ivanov 3")
                .Returns("End");

            var engine = new Engine(readerMock.Object, writerStub.Object, commandProviderStub.Object);

            // act
            engine.Start();

            // assert
            readerMock.Verify(x => x.ReadLine(), Times.Exactly(3));
        }

        [Test]
        public void CallCommandProviderWithCorrectCommandName_WhenPassedCommandIsAValidOne()
        {
            // arrange
            var readerStub = new Mock<IReaderProvider>();
            var writerStub = new Mock<IWriterProvider>();
            var commandProviderMock = new Mock<ICommandProvider>();

            string validCommand = "AddStudent Ivan Ivanov 3";
            string commandName = "AddStudent";

            readerStub.SetupSequence(x => x.ReadLine())
                .Returns(validCommand)
                .Returns("End");

            commandProviderMock.
                Setup(x => x.GetCommand(It.Is<string>(y => y.Contains(commandName))))
                .Verifiable();

            var engine = new Engine(readerStub.Object, writerStub.Object, commandProviderMock.Object);

            // act
            engine.Start();

            // assert
            commandProviderMock.Verify();
        }

        [Test]
        public void CallWritersWriteMethodWithTheThrownException_WhenAnExceptionIsThrownWhileProcessingFirstCommand()
        {
            // arrange
            var readerStub = new Mock<IReaderProvider>();
            var writerMock = new Mock<IWriterProvider>();
            var commandProviderStub = new Mock<ICommandProvider>();

            string validCommand = "AddStudent Ivan Ivanov 3";
            string commandName = "AddStudent";

            readerStub.SetupSequence(x => x.ReadLine())
                .Returns(validCommand)
                .Returns("End");

            var exceptionMessage = "Invalid Command Passed!";

            commandProviderStub.
                Setup(x => x.GetCommand(It.Is<string>(y => y.Contains(commandName))))
                .Throws(new ArgumentException(exceptionMessage));

            writerMock
                .Setup(x => x.WriteLine(It.Is<string>(y => y.Contains(exceptionMessage))))
                .Verifiable();

            var engine = new Engine(readerStub.Object, writerMock.Object, commandProviderStub.Object);

            // act
            engine.Start();

            // assert
            writerMock.Verify();
        }

        [Test]
        public void CallWritersWriteMethodOnce_WhenAnExceptionIsThrownInFirstCommandProcessing()
        {
            // arrange
            var readerStub = new Mock<IReaderProvider>();
            var writerMock = new Mock<IWriterProvider>();
            var commandProviderStub = new Mock<ICommandProvider>();

            string validCommand = "AddStudent Ivan Ivanov 3";
            string commandName = "AddStudent";
          
            readerStub.SetupSequence(x => x.ReadLine())
                .Returns(validCommand)
                .Returns("End");

            var exceptionMessage = "Invalid Command Passed!";
            

            commandProviderStub.
                Setup(x => x.GetCommand(It.Is<string>(y => y.Contains(commandName))))
                .Throws(new ArgumentException(exceptionMessage));

            writerMock
                .Setup(x => x.WriteLine(It.IsAny<string>()));

            var engine = new Engine(readerStub.Object, writerMock.Object, commandProviderStub.Object);

            // act
            engine.Start();

            // assert
            writerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallTheReturnedCommandsExecuteWithValidCommandParams_WhenProcessedCommandIsValid()
        {
            // arrange
            var readerStub = new Mock<IReaderProvider>();
            var writerStub = new Mock<IWriterProvider>();
            var commandProviderStub = new Mock<ICommandProvider>();

            string validCommand = "AddStudent Ivan Ivanov 3";
            string commandName = "AddStudent";

            readerStub.SetupSequence(x => x.ReadLine())
                .Returns(validCommand)
                .Returns("End");

            string returnedCommandString = "Command Completed";

            var commandMock = new Mock<ICommand>();
            commandMock.
                Setup(x => 
                x.Execute(It.Is<IList<string>>(y => 
                y.Contains("Ivan") &&
                y.Contains("Ivanov") &&
                y.Contains("3"))))
                .Returns(returnedCommandString)
                .Verifiable();

            commandProviderStub.
                Setup(x => x.GetCommand(It.Is<string>(y => y.Contains(commandName))))
                .Returns(commandMock.Object);

            writerStub
                .Setup(x => x.WriteLine(It.IsAny<string>()));

            var engine = new Engine(readerStub.Object, writerStub.Object, commandProviderStub.Object);

            // act
            engine.Start();

            // assert
            commandMock.Verify();
        }

        [Test]
        public void CallWritersWriteMethodWithTheReturnedStringFromCommandExecution_WhenCommandIsValidOne()
        {
            // arrange
            var readerStub = new Mock<IReaderProvider>();
            var writerMock = new Mock<IWriterProvider>();
            var commandProviderStub = new Mock<ICommandProvider>();

            string validCommand = "AddStudent Ivan Ivanov 3";
            string commandName = "AddStudent";

            readerStub.SetupSequence(x => x.ReadLine())
                .Returns(validCommand)
                .Returns("End");

            string returnedCommandString = "Command Completed";

            var commandStub = new Mock<ICommand>();
            commandStub.
                Setup(x =>
                x.Execute(It.IsAny<IList<string>>()))
                .Returns(returnedCommandString);

            commandProviderStub.
                Setup(x => x.GetCommand(It.Is<string>(y => y.Contains(commandName))))
                .Returns(commandStub.Object);

            writerMock
                .Setup(x => x.WriteLine(It.Is<string>(y => y.Contains(returnedCommandString))))
                .Verifiable();

            var engine = new Engine(readerStub.Object, writerMock.Object, commandProviderStub.Object);

            // act
            engine.Start();

            // assert
            writerMock.Verify();
        }

        [Test]
        public void CallWritersWriteMethodTwoTimes_WhenThirdCommandPassedIsEndAndOtherTwoAreValidWithNoExceptions()
        {
            // arrange
            var readerStub = new Mock<IReaderProvider>();
            var writerMock = new Mock<IWriterProvider>();
            var commandProviderStub = new Mock<ICommandProvider>();

            readerStub.SetupSequence(x => x.ReadLine())
                .Returns("AddStudent Ivancho Ivanov 3")
                .Returns("RemoveStudent Ivancho Ivanov 3")
                .Returns("End");

            string returnedCommandString = "Command Completed";

            var commandStub = new Mock<ICommand>();
            commandStub.
                Setup(x =>
                x.Execute(It.IsAny<IList<string>>()))
                .Returns(returnedCommandString);

            commandProviderStub.
                Setup(x => x.GetCommand(It.IsAny<string>()))
                .Returns(commandStub.Object);

            writerMock
                .Setup(x => x.WriteLine(It.IsAny<string>()));
   

            var engine = new Engine(readerStub.Object, writerMock.Object, commandProviderStub.Object);

            // act
            engine.Start();

            // assert
            writerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
