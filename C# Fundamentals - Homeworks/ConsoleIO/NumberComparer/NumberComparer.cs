using System;

namespace NumberComparer
{
    class NumberComparer
    {
        static void Main()
        {
            decimal firstNumber = decimal.Parse(Console.ReadLine());
            decimal secondNumber = decimal.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                Console.WriteLine(firstNumber);
            }
            else
            {
                Console.WriteLine(secondNumber);
            }
        }
    }
}
