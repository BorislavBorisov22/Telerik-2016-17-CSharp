using System;
using System.Linq;

class AppearanceCount
{
    private static int GetNumberOccurencesInArray(int[] arr, int numberToCount)
    {
        int occurences = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == numberToCount)
            {
                occurences++;
            }
        }

        return occurences;
    }
    static void Main()
    {
        int sizeArray = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
            Select(int.Parse).ToArray();
        int numberToCount = int.Parse(Console.ReadLine());

        int occurencesNumber = GetNumberOccurencesInArray(numbers, numberToCount);
        Console.WriteLine(occurencesNumber);

    }


}

