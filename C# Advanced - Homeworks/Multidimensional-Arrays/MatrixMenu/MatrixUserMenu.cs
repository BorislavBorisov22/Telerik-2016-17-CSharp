using System;
using System.Linq;

class MatrixUserMenu
{
    private static void ReadMatrix(Matrix matrix)
    {
        for (int row = 0; row < matrix.Rows; row++)
        {
            var currRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int col = 0;col < currRow.Length; col++)
            {
                matrix[row, col] = currRow[col];
            }
        }
    }
    private static int[] ReadMatrixSizes()
    {
        int[] sizesMatrix = Console.ReadLine()
            .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        return sizesMatrix;
    }
    static void Main()
    {
        int[] firstMatrixSizes = ReadMatrixSizes();
        int firstMatrixRows = firstMatrixSizes[0];
        int firstMatrixCols = firstMatrixSizes[1];

        int[] secondMatrixSizes = ReadMatrixSizes();
        int secondMatrixRows = secondMatrixSizes[0];
        int secondMatrixCols = secondMatrixSizes[1];

        var firstMatrix = new Matrix(firstMatrixRows, firstMatrixCols);
        var secondMatrix = new Matrix(secondMatrixRows, secondMatrixCols);

        Console.WriteLine(firstMatrix + secondMatrix);
        Console.WriteLine(firstMatrix - secondMatrix);
        Console.WriteLine(firstMatrix * secondMatrix);
        
    }
}

