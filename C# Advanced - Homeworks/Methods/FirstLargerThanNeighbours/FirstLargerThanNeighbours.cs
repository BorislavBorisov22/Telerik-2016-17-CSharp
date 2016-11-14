using System;
using System.Linq;

class FirstLargerThanNeighbours
{
    private static int FirstLargerThanNeighboursIndex(int[] numbers)
    {
       
        for (int i = 1; i < numbers.Length - 1; i++)
        {
            bool isLargerThanNeighbours = numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1];
            if (isLargerThanNeighbours)
            {
                return i;
            }
        }


        return -1;
    }
    static void Main()
    {
        int sizeArray = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int indexFirstLargerThanNeighbours = FirstLargerThanNeighboursIndex(arr);

        Console.WriteLine(indexFirstLargerThanNeighbours);

    }
}

