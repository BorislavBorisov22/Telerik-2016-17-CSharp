namespace RotatingMatrix.Tests.Models.Printer
{
    using System;

    using NUnit.Framework;
    using Moq;
    using RotatingMatrix.Models;
    using Contracts;

    [TestFixture]
    public class PrintMatrix_Should
    {
        [TestCase(5, 5, 25)]
        [TestCase(5, 10, 50)]
        [TestCase(1, 1, 1)]
        public void CallWritersWriteMethodEqualToTheTotalCountOfCellsOfTheMatrix_WhenInvoked(int rows, int cols, int expectedCalls)
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            writerMock.Setup(x => x.Write(It.IsAny<string>()));

            var printer = new Printer(writerMock.Object);

            var matrix = new int[rows, cols];

            // act
            printer.PrintMatrix(matrix);

            // assert
            writerMock.Verify(x => x.Write(It.IsAny<string>()), Times.Exactly(expectedCalls));
        }

        [Test]
        public void CallWritersWriteLineMethodEqualToTheRowsOFtheMatrix_WhenInvoked()
        {
            // arrange
            var writerMock = new Mock<IWriter>();
            writerMock.Setup(x => x.WriteLine(It.IsAny<string>()));

            int rows = 5;
            int cols = 10;

            var matrix = new string[rows, cols];
            var printer = new Printer(writerMock.Object);

            // act
            printer.PrintMatrix(matrix);

            // assert
            writerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(rows));
        }

        [Test]
        public void ThrowArgumentNullException_WhenProvidedMatrixIsNull()
        {
            // arrange
            var writerStub = new Mock<IWriter>();
            var printer = new Printer(writerStub.Object);

            int[,] matrix = null;

            // act and assert
            Assert.Throws<ArgumentNullException>(() => printer.PrintMatrix(matrix));
        }
    }
}
