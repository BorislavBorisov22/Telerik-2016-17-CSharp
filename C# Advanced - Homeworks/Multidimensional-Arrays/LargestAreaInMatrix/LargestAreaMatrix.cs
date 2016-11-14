using System;
using System.Linq;

class LargestAreaMatrix
{
    static int[,] array;
    static bool[,] visited;
    public static void Main()
    {
        int[] arraySize = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int arrayRows = arraySize[0];
        int arrayCols = arraySize[1];

        array = new int[arrayRows, arrayCols];
        visited = new bool[arrayRows, arrayCols];
        ReadField(array);

        int bestCount = 0;

        for (int row = 0;row < arrayRows; row++)
        {
            for (int col = 0;col < arrayCols; col++)
            {
                int currentCount = DepthFirstSearch(array[row, col], row, col);
                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                }
            }
        }

        Console.WriteLine(bestCount);
    }

    private static int DepthFirstSearch(int value, int row, int col)
    {
        if (visited[row, col])
        {
            return 0;
        }
        int result = 1;
        visited[row, col] = true;
       
        if (row + 1 < array.GetLength(0) && array[row + 1, col] == value && !visited[row + 1, col])
        {
            result += DepthFirstSearch(value, row + 1, col);
        }
        if (row - 1 >= 0 && array[row-1,col] == value && !visited[row - 1, col])
        {
            result += DepthFirstSearch(value, row - 1, col);
        }
        if (col + 1 < array.GetLength(1) && array[row,col+1] == value && !visited[row, col + 1])
        {
            result += DepthFirstSearch(value, row, col + 1);
        }
        if (col - 1 >= 0 && array[row,col-1] == value && !visited[row, col - 1])
        {
            result += DepthFirstSearch(value,row,col-1);
        }


        return result;
    }

    private static void ReadField(int[,] arr)
    {
        for (int row = 0;row < arr.GetLength(0); row++)
        {
            string[] currLine = Console.ReadLine().Split(' ');
            for (int col = 0;col < arr.GetLength(1); col++)
            {
                arr[row, col] = int.Parse(currLine[col]);
            }
        }
    }
    
}