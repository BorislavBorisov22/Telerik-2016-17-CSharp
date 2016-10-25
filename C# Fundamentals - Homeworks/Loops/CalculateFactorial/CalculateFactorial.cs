using System;
using System.Numerics;

namespace CalculateFactorial
{
    class CalculateFactorial
    {
       
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());

            double sum = 1;
            BigInteger lastFactorial = 1;
            for (int i = 1; i <= n; i++)
            {
                lastFactorial *= i;
                sum += (double)lastFactorial / Math.Pow(x, i);
                
            }

            Console.WriteLine("{0:f5}",sum);


        }


    }
}
