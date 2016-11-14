using System;
using System.Linq;

class GetLargestNumber
{
    private static int GetMax(int firstNumber,int secondNumber)
    {
        if (firstNumber > secondNumber)
        {
            return firstNumber;
        }
        else
        {
            return secondNumber;
        }
    }
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int maxNumber = int.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            maxNumber = GetMax(maxNumber, numbers[i]);
        }
        Console.WriteLine(maxNumber);
    }
}

