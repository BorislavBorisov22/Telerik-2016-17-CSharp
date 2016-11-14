using System;
using System.Linq;

class LargerThanNeighbours
{
    private static bool ElementIsLargerThanNeighbours(int[] arr,int indexNumber)
    {
        bool isLargerThanNeighbours = arr[indexNumber] > arr[indexNumber + 1] &&
            arr[indexNumber] > arr[indexNumber - 1];


        return isLargerThanNeighbours;
    }
    static void Main()
    {
        int sizeArray = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int largerThanNeighboursCount = 0;
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (ElementIsLargerThanNeighbours(arr, i))
            {
                largerThanNeighboursCount++;
            }
        }

        Console.WriteLine(largerThanNeighboursCount);
    }
}

