namespace RotatingMatrix.Models
{
    using System;
    using Contracts;

    public class Printer : IPrinter
    {
        private IWriter writer;

        public Printer(IWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("Printer's writer cannot be null!");
            }

            this.writer = writer;
        }

        protected IWriter Writer
        {
            get
            {
                return this.writer;
            }
        }

        public void PrintMatrix<T>(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix to be printed must not be null!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    this.writer.Write(string.Format("{0,3}", matrix[row, col]));
                }

                this.writer.WriteLine();
            }
        }
    }
}
