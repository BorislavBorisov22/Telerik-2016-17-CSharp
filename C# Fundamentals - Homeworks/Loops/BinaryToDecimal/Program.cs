using System;

namespace BinaryToDecimal
{
    class Program
    {
        static void Main()
        {
            string binaryValue = Console.ReadLine();
            long decimalValue = 0;
            for (int i = 0; i < binaryValue.Length; i++)
            {
                char currDigit = binaryValue[binaryValue.Length - 1 - i];

                if (currDigit == '1')
                {
                    decimalValue += (long)(1 * Math.Pow(2, i));
                }
            }

            Console.WriteLine(decimalValue);
        }
    }
}
