using System;
using System.Linq;

class NumberCalculations
{
    private static T GetMaxNumber<T>( T[] numbers)
    {
        dynamic max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }
    private static T GetMinNumber<T>(T[] numbers)
    {
        dynamic min = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }


        return min;
    }
    private static T GetSumNumbers<T>(T[] numbers)
    {
        dynamic sum = 0;

        foreach(var num in numbers)
        {
            sum += num;
        }


        return sum;
    }
    private static T GetProductNumbers<T>(T[] numbers)
    {
        dynamic product = 1;
        foreach(var num in numbers)
        {
            product *= num;
        }

        return product;
    }
    private static double GetAverageNumbers<T>(T[] numbers)
    {
        dynamic sum = GetSumNumbers(numbers);
        return (double)sum / numbers.Length;
    }

    static void Main()
    {
        var sequence = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

        Console.WriteLine("min {0}",GetMinNumber(sequence));
        Console.WriteLine("max {0}",GetMaxNumber(sequence));
        Console.WriteLine("sum {0}",GetSumNumbers(sequence));
        Console.WriteLine("product {0}",GetProductNumbers(sequence));
        Console.WriteLine("average {0:f2}",GetAverageNumbers(sequence));
    }
}

