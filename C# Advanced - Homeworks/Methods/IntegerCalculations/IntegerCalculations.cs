using System;
using System.Linq;
using System.Numerics;

class BigIntegeregerCalculations
{
    private static BigInteger GetMinNumber(BigInteger[] numbers)
    {
        BigInteger min = long.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }

        return min;
    }
    private static BigInteger GetMaxNumber (BigInteger[] numbers)
    {
        BigInteger max = long.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }
    private static BigInteger GetSumNumbers(BigInteger[] numbers)
    {
        BigInteger sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }
    private static BigInteger GetProductNumbers (BigInteger[] numbers)
    {
        BigInteger product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }
    private static double GetAverageOfNumbers(BigInteger[] numbers)
    {
        double average = (double)GetSumNumbers(numbers) / numbers.Length;

        return average;
    }

    static void Main()
    {
        BigInteger numberCount = 5;

        BigInteger[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(BigInteger.Parse).ToArray();


        BigInteger min = GetMinNumber(numbers);
        BigInteger max = GetMaxNumber(numbers);
        BigInteger sum = GetSumNumbers(numbers);
        BigInteger product = GetProductNumbers(numbers);
        double average = GetAverageOfNumbers(numbers);

        Console.WriteLine(min);
        Console.WriteLine(max);
        Console.WriteLine("{0:0.00}",average);
        Console.WriteLine(sum);
        Console.WriteLine(product);
    }
}

