namespace RotatingMatrix.Models
{
    using System;
    using Contracts;

    public class MatrixGenerator : IMatrixGenerator
    {
        private const int MatrixMinSize = 1;
        private const int MatrixMaxSize = 100;

        public int[,] Generate(int matrixSize)
        {
            if (matrixSize < MatrixMinSize || matrixSize > MatrixMaxSize)
            {
                throw new ArgumentOutOfRangeException($"Provided matrix size must be at least {MatrixMinSize}!");
            }

            var matrix = new int[matrixSize, matrixSize];
            IMatrixCell currentCell = new MatrixCell(0, 0);

            int currentNumberToFill = 0;

            int deltaRow = 1;
            int deltaCol = 1;

            while (true)
            {
                currentNumberToFill++;
                matrix[currentCell.Row, currentCell.Col] = currentNumberToFill;

                if (!this.IsAnyNeighbourCellFree(matrix, currentCell))
                {
                    currentCell = this.FindNearestFreeCell(matrix, currentCell);

                    if (currentCell == null)
                    {
                        break;
                    }

                    deltaRow = 1;
                    deltaCol = 1;
                    continue;
                }

                while (this.IsCellInMatrixRange(matrixSize, currentCell.Row, currentCell.Col, deltaRow, deltaCol) || matrix[currentCell.Row + deltaRow, currentCell.Col + deltaCol] != 0)
                {
                    this.ChangeDirection(ref deltaRow, ref deltaCol);
                }

                currentCell.Row += deltaRow;
                currentCell.Col += deltaCol;
            }

            return matrix;
        }

        private void ChangeDirection(ref int deltaRow, ref int deltaCol)
        {
            int[] directionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirectionIndex = 0;

            for (int count = 0; count < directionsRow.Length; count++)
            {
                if (directionsRow[count] == deltaRow && directionsCol[count] == deltaCol)
                {
                    currentDirectionIndex = count;
                    break;
                }
            }

            if (currentDirectionIndex == directionsRow.Length - 1)
            {
                deltaRow = directionsRow[0];
                deltaCol = directionsCol[0];
            }
            else
            {
                deltaRow = directionsRow[currentDirectionIndex + 1];
                deltaCol = directionsCol[currentDirectionIndex + 1];
            }
        }

        private bool IsAnyNeighbourCellFree(int[,] matrix, IMatrixCell currentCell)
        {
            int[] directionsRows = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsCols = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (currentCell.Row + directionsRows[i] >= matrix.GetLength(0) || currentCell.Row + directionsRows[i] < 0)
                {
                    directionsRows[i] = 0;
                }

                if (currentCell.Col + directionsCols[i] >= matrix.GetLength(0) || currentCell.Col + directionsCols[i] < 0)
                {
                    directionsCols[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[currentCell.Row + directionsRows[i], currentCell.Col + directionsCols[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private IMatrixCell FindNearestFreeCell(int[,] arr, IMatrixCell currentCell)
        {
            for (int currentRow = 0; currentRow < arr.GetLength(0); currentRow++)
            {
                for (int currentCol = 0; currentCol < arr.GetLength(0); currentCol++)
                {
                    if (arr[currentRow, currentCol] == 0)
                    {
                        currentCell.Row = currentRow;
                        currentCell.Col = currentCol;
                        return currentCell;
                    }
                }
            }

            return null;
        }

        private bool IsCellInMatrixRange(int matrixSize, int row, int col, int deltaRow, int deltaCol)
        {
            bool isRowOutOfRange = row + deltaRow >= matrixSize || row + deltaRow < 0;
            bool isColOutOfRange = col + deltaCol >= matrixSize || col + deltaCol < 0;

            bool isCellOutOfRange = isRowOutOfRange || isColOutOfRange;

            return isCellOutOfRange;
        }
    }
}
