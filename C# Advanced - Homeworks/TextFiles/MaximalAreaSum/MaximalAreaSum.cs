using System;
using System.IO;
using System.Linq;

class MaximalAreaSum
{
    static void Main()
    {
        try
        {
            string filePath = @"..\..\..\Matrix.txt";
            int[,] matrix = ReadMatrixFromFile(filePath);
            PrintMatrix(matrix);
            
            int maxAreaSum = GetMaxAreaSum(matrix);
            StreamWriter resultFile = new StreamWriter(@"..\..\maxArea.txt");
            using (resultFile)
            {
                resultFile.WriteLine(maxAreaSum);
            }
            
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static int GetMaxAreaSum(int[,] matrix)
    {
        int maxSum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0)-1; row++)
        {
            for (int col = 0;col < matrix.GetLength(1)-1; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }
        
        return maxSum;
    }

    private static int[,] ReadMatrixFromFile(string filePath)
    {
        StreamReader file = new StreamReader(filePath);

        int sizeMatrix = int.Parse(file.ReadLine());

        int[,] matrix = new int[sizeMatrix, sizeMatrix];

        int row = 0;

        while (row < sizeMatrix)
        {
            
            int[] currenLineMatrix = file.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int col = 0;col < currenLineMatrix.Length; col++)
            {
                matrix[row, col] = currenLineMatrix[col];
            }

            row++;
        }

        file.Close();
        return matrix;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0;row < matrix.GetLength(0); row++)
        {
            for (int col = 0;col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row,col] + " ");
            }
            Console.WriteLine();
        }
    }
}

