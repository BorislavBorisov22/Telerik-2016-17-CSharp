namespace RotatingMatrix.Tests.RotatingMatrixStartUp
{
    using System;

    using NUnit.Framework;
    using Moq;
    using Contracts;
    using RotatingMatrix;

    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void CallWritersWriteLineWitthAstringContaininetEnterNumber_WhenInvoked()
        {
            // arrange
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();
            var matrixGenerator = new Mock<IMatrixGenerator>();
            var printer = new Mock<IPrinter>();

            var returnedMatrix = new int[,] { };
            var returnedInput = "5";

            writer.Setup(x => x.WriteLine(It.Is<string>(str => str.Contains("Enter a positive number"))));
            matrixGenerator.Setup(x => x.Generate(It.IsAny<int>()))
                .Returns(returnedMatrix);
            reader.Setup(x => x.ReadLine())
                .Returns(returnedInput);

            // act
            RotatingMatrixStartUp.Start(matrixGenerator.Object, writer.Object, reader.Object, printer.Object);

            // assert
            writer.Verify(x => x.WriteLine(It.Is<string>(str => str.Contains("Enter a positive number"))), Times.Once);
        }

        [Test]
        public void CallReadersReadLineOnce_WhenTheReadLineIsAValidMatrixSize()
        {
            // arrange
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();
            var matrixGenerator = new Mock<IMatrixGenerator>();
            var printer = new Mock<IPrinter>();

            var returnedMatrix = new int[,] { };
            var returnedInput = "5";

            matrixGenerator.Setup(x => x.Generate(It.IsAny<int>()))
                .Returns(returnedMatrix);
            reader.Setup(x => x.ReadLine())
                .Returns(returnedInput);

            // act
            RotatingMatrixStartUp.Start(matrixGenerator.Object, writer.Object, reader.Object, printer.Object);

            // assert
            reader.Verify(x => x.ReadLine(), Times.Once);
        }

        [Test]
        public void CallReadersReadLineOTwice_WhenTheReadLineReturnsInvalidSizeFirstTimeAndValidTheSecond()
        {
            // arrange
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();
            var matrixGenerator = new Mock<IMatrixGenerator>();
            var printer = new Mock<IPrinter>();

            var returnedMatrix = new int[,] { };
            var validInput = "5";

            matrixGenerator.Setup(x => x.Generate(It.IsAny<int>()))
                .Returns(returnedMatrix);
            reader.SetupSequence(x => x.ReadLine())
                .Returns(string.Empty)
                .Returns(validInput);


            // act
            RotatingMatrixStartUp.Start(matrixGenerator.Object, writer.Object, reader.Object, printer.Object);

            // assert
            reader.Verify(x => x.ReadLine(), Times.Exactly(2));
        }

        [Test]
        public void CallWritersWriteLineWithStringContainingCorrectPositiveNumber_WhenInvalidMatrixSizeIsPassed()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            var reader = new Mock<IReader>();
            var matrixGenerator = new Mock<IMatrixGenerator>();
            var printer = new Mock<IPrinter>();

            var returnedMatrix = new int[,] { };
            var validInput = "5";

            writerMock.Setup(x => x.WriteLine(It.Is<string>(str => str.Contains("correct positive number"))));
            matrixGenerator.Setup(x => x.Generate(It.IsAny<int>()))
                .Returns(returnedMatrix);
            reader.SetupSequence(x => x.ReadLine())
                .Returns(string.Empty)
                .Returns(validInput);


            // act
            RotatingMatrixStartUp.Start(matrixGenerator.Object, writerMock.Object, reader.Object, printer.Object);

            // assert
            writerMock.Verify(x => x.WriteLine(It.Is<string>(str => str.Contains("correct positive number"))));
        }

        [Test]
        public void CallMatrixGeneratorsGenerateWithTheReadMatrixSize_WhenAValidMatrixSizeIsRead()
        {
            // arrange
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();
            var matrixGeneratorMock = new Mock<IMatrixGenerator>();
            var printer = new Mock<IPrinter>();

            var returnedMatrix = new int[,] { };
            var validInput = "5";

            writer.Setup(x => x.WriteLine(It.Is<string>(str => str.Contains("correct positive number"))));
            matrixGeneratorMock.Setup(x => x.Generate(It.Is<int>(ms => ms == int.Parse(validInput))))
                .Returns(returnedMatrix);
            reader.SetupSequence(x => x.ReadLine())
                .Returns(string.Empty)
                .Returns(validInput);


            // act
            RotatingMatrixStartUp.Start(matrixGeneratorMock.Object, writer.Object, reader.Object, printer.Object);

            // assert
            matrixGeneratorMock.Verify(x => x.Generate(It.Is<int>(ms => ms == int.Parse(validInput))), Times.Once);
        }

        [Test]
        public void CallPrintersPrintMethodWithTheGeneratedMatrix_WhenAValidMatrixSizeIsRead()
        {
            // arrange
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();
            var matrixGenerator = new Mock<IMatrixGenerator>();
            var printer = new Mock<IPrinter>();

            var returnedMatrix = new int[,] { };
            var validInput = "5";
            var other = new int[,] { { 123 } };

            writer.Setup(x => x.WriteLine(It.Is<string>(str => str.Contains("correct positive number"))));
            matrixGenerator.Setup(x => x.Generate(It.Is<int>(ms => ms == int.Parse(validInput))))
                .Returns(returnedMatrix);
            reader.SetupSequence(x => x.ReadLine())
                .Returns(string.Empty)
                .Returns(validInput);
            printer.Setup(x => x.PrintMatrix(It.Is<int[,]>(m => m == returnedMatrix)));

            // act
            RotatingMatrixStartUp.Start(matrixGenerator.Object, writer.Object, reader.Object, printer.Object);

            // assert
            printer.Verify(x => x.PrintMatrix(It.Is<int[,]>(m => m == returnedMatrix)));
        }
    }
}
