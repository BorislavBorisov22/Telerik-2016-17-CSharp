using System;
using System.Numerics;

namespace CalculateThreeFactorial
{
    
    class CalculateThreeFactorial
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
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            BigInteger firstNumberFactorial = CalculateFactorial(firstNumber);
            BigInteger secondNumberFactorial = CalculateFactorial(secondNumber);

            BigInteger sumFactorial = CalculateFactorial(firstNumber - secondNumber);


            BigInteger result = firstNumberFactorial / (secondNumberFactorial * sumFactorial);

            Console.WriteLine(result);


            
        }
    }
}
