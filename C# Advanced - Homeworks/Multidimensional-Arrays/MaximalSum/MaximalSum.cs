using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        int[] fieldSizes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int fieldHeight = fieldSizes[0];
        int fieldWidth = fieldSizes[1];
        int[,] field = new int[fieldHeight, fieldWidth];

        int maxSum = int.MinValue;
        ReadFieldNumbers(field,fieldHeight);
        for (int row = 0; row < field.GetLength(0) - 2; row++)
        {
            for (int col = 0;col < field.GetLength(1) - 2; col++)
            {
                int currSum = field[row, col] + field[row, col + 1] + field[row, col + 2]
                   + field[row + 1, col] + field[row + 1, col + 1] + field[row + 1, col + 2]
                   + field[row + 2, col] + field[row + 2, col + 1] + field[row + 2, col + 2];

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                }
            }
        }

        Console.WriteLine(maxSum);
    }

    private static void ReadFieldNumbers(int[,] field,int rowsToRead)
    {
        for (int row = 0; row < rowsToRead; row++)
        {
            var currRow = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            for (int col = 0; col < currRow.Length; col++)
            {
                field[row, col] = currRow[col];
            }
        }
    }
}

