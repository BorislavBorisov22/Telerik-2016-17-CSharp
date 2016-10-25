using System;
using System.Numerics;

namespace CatalanNumbers
{
    
    class CatalanNumbers
    {
        static BigInteger CalculateFactorial(int number)
        {
            BigInteger factorial = 1;

            while (number > 1)
            {
                factorial *= number;
                number--;
            }
            return factorial;
        }
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger result = CalculateFactorial(2 * number)
                / (CalculateFactorial(number + 1) * CalculateFactorial(number));

            Console.WriteLine(result);
        }
    }
}
