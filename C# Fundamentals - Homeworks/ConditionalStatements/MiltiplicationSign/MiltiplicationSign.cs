using System;

namespace MiltiplicationSign
{
    class MiltiplicationSign
    {
        static void Main()
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            string thirdNumber = Console.ReadLine();

            char firstNumberSign = firstNumber[0];
            char secondNumberSign = secondNumber[0];
            char thirdNumberSign = thirdNumber[0];

            int numberOfMinuses = 0;
            if (firstNumberSign == '-')
            {
                numberOfMinuses++;
            }
            if (secondNumberSign == '-')
            {
                numberOfMinuses++;
            }
            if (thirdNumberSign == '-')
            {
                numberOfMinuses++;
            }



            char resultSign = '+';

            if (firstNumber == "0" || secondNumber == "0" || thirdNumber == "0")
            {
                resultSign = '0';
            }

            if (numberOfMinuses == 1)
            {
                resultSign = '-';
            }
            else if (numberOfMinuses == 3)
            {
                resultSign = '-';
            }
            

            Console.WriteLine(resultSign);


        }
    }
}
