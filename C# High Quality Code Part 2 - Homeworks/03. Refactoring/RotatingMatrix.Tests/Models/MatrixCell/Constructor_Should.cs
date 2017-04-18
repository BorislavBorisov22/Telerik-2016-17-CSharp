namespace RotatingMatrix.Tests.MatrixCell
{
    using System;

    using RotatingMatrix.Models;
    using NUnit.Framework;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentOutOfRangeException_WhenPassedRowIsNegative()
        {
            // arrange
            int row = -1;
            int col = 1;

            // act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new MatrixCell(row, col));
        }

        [Test]
        public void ThrowArgumentOutOfRangeException_WhenPassedColIsNegative()
        {
            // arrange
            int row = 2;
            int col = -1;

            // act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new MatrixCell(row, col));
        }

        [Test]
        public void SetColCorrectly_WhenPassedParameterAreValid()
        {
            // arrange
            int row = 2;
            int col = 11;

            // act
            var cell = new MatrixCell(row, col);

            // assert
            Assert.AreEqual(col, cell.Col);
        }

        [Test]
        public void SetRowCorrectly_WhenPassedParametersAreValid()
        {
            // arrange
            int row = 2;
            int col = 11;

            // act
            var cell = new MatrixCell(row, col);

            // assert
            Assert.AreEqual(row, cell.Row);
        }
    }
}
