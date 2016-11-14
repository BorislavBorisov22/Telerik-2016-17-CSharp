using System;
using System.Collections.Generic;
using System.Numerics;


class NFactorial
{
    private static BigInteger MultiplyNumberByArray(int[] number,int n)
    {
        BigInteger result = n;
        for (int i = 0; i < number.Length; i++)
        {
            result *= number[i];
        }


        return result;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var numbers = new List<int>();
        for (int i = n;i > 0; i--)
        {
            numbers.Add(i);
        }


        BigInteger factorialN = MultiplyNumberByArray(numbers.ToArray(), 1);
        Console.WriteLine(factorialN);
    }
}

