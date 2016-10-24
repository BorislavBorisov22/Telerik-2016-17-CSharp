using System;


namespace SortThreeNumbers
{
    class SortThreeNumbers
    {
        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());

            double maxNumber = 0;
            double midNumber = 0;
            double minNumber = 0;

            if (firstNumber > secondNumber && firstNumber > thirdNumber)
            {
                maxNumber = firstNumber;
                if (secondNumber > thirdNumber)
                {
                    midNumber = secondNumber;
                    minNumber = thirdNumber;
                }
                else
                {
                    midNumber = thirdNumber;
                    minNumber = secondNumber;
                }
            }
            else if (secondNumber > firstNumber && secondNumber > thirdNumber)
            {
                maxNumber = secondNumber;
                if (firstNumber > thirdNumber)
                {
                    midNumber = firstNumber;
                    minNumber = thirdNumber;
                }
                else
                {
                    midNumber = thirdNumber;
                    minNumber = firstNumber;
                }
            }
            else 
            {
                maxNumber = thirdNumber;
                if (firstNumber > secondNumber)
                {
                    midNumber = firstNumber;
                    minNumber = secondNumber;
                }
                else
                {
                    midNumber = secondNumber;
                    minNumber = firstNumber;
                }
            }

            Console.WriteLine("{0} {1} {2}",maxNumber,midNumber,minNumber);

        }
    }
}
