namespace ControlFlowConditionalStatementsAndLoops._04.CSharpFundamentalsExam._01.MagicalNumbers
{
    using System;

    public class MagicalNumbers
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int thirdDigit = GetIntegersLastNumber(number);
            number = RemoveIntegersLastNumber(number);

            int secondDigit = GetIntegersLastNumber(number);
            number = RemoveIntegersLastNumber(number);

            int firstDigit = GetIntegersLastNumber(number);

            double result = 0;
            if (IsNumberEven(secondDigit))
            {
                result = (double)(firstDigit + secondDigit) * thirdDigit;
            }
            else
            {
                result = (double)(firstDigit * secondDigit) / thirdDigit;
            }

            Console.WriteLine("{0:f2}", result);
        }

        public static bool IsNumberEven(int number)
        {
            return number % 2 == 0;
        }

        public static int GetIntegersLastNumber(int number)
        {
            return number % 10;
        }

        public static int RemoveIntegersLastNumber(int number)
        {
            return number / 10;
        }
    }
}
