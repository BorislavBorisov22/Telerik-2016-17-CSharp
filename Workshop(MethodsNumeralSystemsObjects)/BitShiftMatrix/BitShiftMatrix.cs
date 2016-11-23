using System;
using System.Linq;
using System.Numerics;
 
class BitShiftMatrix
{
    static bool[,] visited;
    static BigInteger[,] matrix;
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        int movementsCount = int.Parse(Console.ReadLine());
        int[] movements = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        matrix = FillMatrix(rows, cols);
        visited = new bool[rows, cols];

        int coefficient = Math.Max(rows, cols);
        BigInteger totalSum = CalculateTotalSum(movements,coefficient);
        Console.WriteLine(totalSum);
        
    }

    private static BigInteger CalculateTotalSum(int[] movements, int coefficient)
    {
        int currRow = matrix.GetLength(0) - 1;
        int currCol = 0;
        BigInteger resultSum = 0;

        for (int i = 0;i < movements.Length; i++)
        {
            int currentCode = movements[i];
            int targetRow = currentCode / coefficient;
            int targetCol = currentCode % coefficient;

            //go to target col and collect number on the way
            int stepCol = currCol < targetCol ? 1 : -1;
            while (currCol != targetCol)
            {
                if (!visited[currRow, currCol])
                {
                    resultSum += matrix[currRow, currCol];
                    visited[currRow, currCol] = true;
                }

                currCol += stepCol;
            }

            //go to target row
            int stepRow = currRow < targetRow ? 1 : -1;

            while (currRow != targetRow)
            {
                if (!visited[currRow, currCol])
                {
                    resultSum += matrix[currRow, currCol];
                    visited[currRow, currCol] = true;
                }

                currRow += stepRow;
            }


            //check last
            if (!visited[currRow, currCol])
            {
                resultSum += matrix[currRow, currCol];
                visited[currRow, currCol] = true;
            }
        }


        return resultSum;
    }

    private static BigInteger[,] FillMatrix(int rows, int cols)
    {
        var resultMatrix = new BigInteger[rows, cols];
        BigInteger startNumberRow = 1;

        for (int row = rows - 1; row >= 0; row--)
        {
            BigInteger numberToFillCol = startNumberRow;
            for (int col = 0; col < cols; col++)
            {
                resultMatrix[row, col] = numberToFillCol;
                numberToFillCol *= 2;
            }

            startNumberRow *= 2;
        }

        return resultMatrix;
    }
}

