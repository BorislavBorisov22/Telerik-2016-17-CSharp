namespace RotatingMatrix.Tests.Models.MatrixGenerator
{
    using System;

    using NUnit.Framework;
    using RotatingMatrix.Models;

    [TestFixture]
    public class Generate_Should
    {
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(101)]
        public void ThrowArgumentOutOfRangeException_WhenProvidedMatrixSizeIsNotPositive(int matrixSize)
        {
            // arrange
            var matrixGenerator = new MatrixGenerator();

            // act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => matrixGenerator.Generate(matrixSize));
        }

        [Test]
        public void NotThrow_WhenValidMatrixSizeIsPassed()
        {
            // arrange
            var matrixGenerator = new MatrixGenerator();
            int matrixSize = 10;

            // act and assert
            Assert.DoesNotThrow(() => matrixGenerator.Generate(matrixSize));
        }

        [Test]
        public void ReturnCorrectlyFilledMatrix_WhenPassedMatrixSizeIsThree()
        {
            // arrange
            var expectedMatrix = new int[,]
            {
                { 1, 7,  8 },
                { 6, 2, 9 },
                { 5,  4,  3 }
            };

            var matrixGenerator = new MatrixGenerator();
            int matrixSize = 3;

            // act
            var resultMatrix = matrixGenerator.Generate(matrixSize);

            CollectionAssert.AreEqual(expectedMatrix, resultMatrix);
        }

        public void ReturnCorrectlyFilledMatrix_WhenPassedMatrixSizeIsSix()
        {
            // arrange
            var expectedMatrix = new int[,]
                {
                  { 1, 16, 17, 18, 19, 20,},
                  { 15, 2, 27, 28, 29, 21,},
                  { 14, 31, 3, 26, 30, 22,},
                  { 13, 36, 32, 4, 25, 23,},
                  { 12, 35, 34, 33, 5, 24,},
                  {11, 10, 9, 8, 7, 6 }
                 };

            var matrixGenerator = new MatrixGenerator();
            int matrixSize = 3;

            // act
            var resultMatrix = matrixGenerator.Generate(matrixSize);

            CollectionAssert.AreEqual(expectedMatrix, resultMatrix);
        }

        [Test]
        public void ReturnCorrectlyFilledMatrix_WhenPassedMatrixSizeIsOne()
        {
            // arrange
            var expectedMatrix = new int[,]
            {
                { 1 }
            };

            var matrixGenerator = new MatrixGenerator();
            int matrixsize = 1;

            // act
            var resultMatrix = matrixGenerator.Generate(matrixsize);

            // assert
            CollectionAssert.AreEqual(expectedMatrix, resultMatrix);
        }

        [Test]
        public void ReturnCorrectlyFilledMatrix_WhenPassedMatrixSizeIsFive()
        {
            // arrange
            var expectedMatrix = new int[,]
            {
                { 1, 13, 14, 15, 16 },
                { 12, 2, 21, 22, 17},
                { 11, 23, 3, 20, 18, },
                { 10, 25, 24, 4, 19 },
                { 9, 8, 7, 6, 5}
            };

            var matrixGenerator = new MatrixGenerator();
            int matrixsize = 5;

            // act
            var resultMatrix = matrixGenerator.Generate(matrixsize);

            // assert
            CollectionAssert.AreEqual(resultMatrix, expectedMatrix);
        }
    }
}
