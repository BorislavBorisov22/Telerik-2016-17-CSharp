using System;
using System.Numerics;

namespace TrailingZerosInNFactorial
{
    class TrailingZeros
    {
        
        static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            BigInteger powerOfFive = 5;

            BigInteger sumZeros = 0;
            while (powerOfFive < number)
            {
                sumZeros += (number / powerOfFive);
                powerOfFive *= 5;
            }

            Console.WriteLine(sumZeros);

        }
    }
}
