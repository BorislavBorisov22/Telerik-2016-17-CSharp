using System;

namespace BiggestOfThree
{
    class biggestOfThree
    {
        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());

            double maxNumber = 0;

            if (firstNumber > secondNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    maxNumber = firstNumber;
                }
                else
                {
                    maxNumber = thirdNumber;
                }
            }
            else
            {
                if (secondNumber > thirdNumber)
                {
                    maxNumber = secondNumber;
                }
                else
                {
                    maxNumber = thirdNumber;
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}
