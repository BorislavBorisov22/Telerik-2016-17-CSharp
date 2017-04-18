namespace RotatingMatrix.Models
{
    using System;
    using RotatingMatrix.Contracts;

    public class MatrixCell : IMatrixCell
    {
        private int row;
        private int col;

        public MatrixCell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Matrix cell row cannot be negative!");
                }

                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Matrix cell row cannot be negative!");
                }

                this.col = value;
            }
        }
    }
}
