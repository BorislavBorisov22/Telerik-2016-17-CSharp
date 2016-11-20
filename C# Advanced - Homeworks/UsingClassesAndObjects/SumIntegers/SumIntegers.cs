using System;
using System.Linq;

class Summator
{
    public static long GetSumSequence(string sequence)
    {
        long[] numbers = sequence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToArray();

        long sumNumbers = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sumNumbers += numbers[i];
        }

        return sumNumbers;
    }
}

class SumIntegers
{
    static void Main()
    {
        string sequence = Console.ReadLine();
        long sumSequence = Summator.GetSumSequence(sequence);
        Console.WriteLine(sumSequence);
    }
}

