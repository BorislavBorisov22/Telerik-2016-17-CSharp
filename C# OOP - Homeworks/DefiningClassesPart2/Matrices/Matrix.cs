namespace Matrices
{
    using System;
    using System.Text;

    public class Matrix<T> where T : IComparable
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Matrix number of rows must be a positive number");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Matrix columns must be a positive number");
                }

                this.cols = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (!this.AreRowAndColValid(row, col))
                {
                    throw new IndexOutOfRangeException("Indexes for row and col must be within the boundaries of the matrix");
                }

                return this.matrix[row, col];
            }

            set
            {
                if (!this.AreRowAndColValid(row, col))
                {
                    throw new IndexOutOfRangeException("Indexes for row and col must be within the boundaries of the matrix");
                }

                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Cols != secondMatrix.Cols || firstMatrix.Rows != secondMatrix.Rows)
            {
                throw new ArgumentException("Matrices must have equal rows and columns in order to be added together");
            }

            var newMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int i = 0; i < newMatrix.Rows; i++)
            {
                for (int j = 0; j < newMatrix.Cols; j++)
                {
                    newMatrix[i, j] = (dynamic)firstMatrix[i, j] + secondMatrix[i, j];
                }
            }

            return newMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Cols != secondMatrix.Cols || firstMatrix.Rows != secondMatrix.Rows)
            {
                throw new ArgumentException("Matrices must have equal rows and columns in order to be added together");
            }

            var newMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int i = 0; i < newMatrix.Rows; i++)
            {
                for (int j = 0; j < newMatrix.Cols; j++)
                {
                    newMatrix[i, j] = (dynamic)firstMatrix[i, j] - secondMatrix[i, j];
                }
            }

            return newMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Cols != secondMatrix.Rows)
            {
                throw new ArgumentException("For multiplying matrices the columns of the first matrix should be equal to the rows of the second matrix");
            }

            var resultMatrix = new Matrix<T>(firstMatrix.Rows, secondMatrix.Cols);

            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)0;

                    for (int i = 0; i < firstMatrix.Cols; i++)
                    {
                        resultMatrix[row, col] += (dynamic)firstMatrix[row, i] * (dynamic)secondMatrix[i, col];
                    }
                }
            }

            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return HasNonZeroElement(matrix);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return HasNonZeroElement(matrix);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    output.AppendFormat("{0} ", this.matrix[i, j]);
                }

                output.AppendLine();
            }

            return output.ToString().Trim();
        }

        private static bool HasNonZeroElement(Matrix<T> matrix)
        {
            foreach (var element in matrix.matrix)
            {
                if (!element.Equals(default(T)))
                {
                    return true;
                }
            }

            return false;
        }

        private bool AreRowAndColValid(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                return false;
            }

            if (col < 0 || col >= this.Cols)
            {
                return false;
            }

            return true;
        }
    }
}
