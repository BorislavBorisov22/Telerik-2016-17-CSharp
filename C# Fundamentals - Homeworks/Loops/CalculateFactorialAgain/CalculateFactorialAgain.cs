using System;
using System.Numerics;
namespace CalculateFactorialAgain
{
    class CalculateFactorialAgain
    {
        static void Main()
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger k = BigInteger.Parse(Console.ReadLine());

            BigInteger nFactorial = 1;
            BigInteger kFactorial = 1;

            while (n > 1)
            {
                nFactorial *= n;

                if (k > 1)
                {
                    kFactorial *= k;
                    k--;
                }

                n--;
            }

            BigInteger result = nFactorial / kFactorial;

            Console.WriteLine(result);
           
        }
    }
}
