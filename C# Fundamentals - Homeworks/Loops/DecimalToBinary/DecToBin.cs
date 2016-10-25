using System;

namespace DecimalToBinary
{
    class DecToBin
    {
        static void Main()
        {
            long decimalValue = long.Parse(Console.ReadLine());

            string binaryValue = "";

            while (decimalValue != 0)
            {
                long remainder = decimalValue % 2;
                if (remainder == 1)
                {
                    binaryValue = "1" + binaryValue;
                }
                else
                {
                    binaryValue = "0" + binaryValue;
                }
                decimalValue /= 2;
            }

            Console.WriteLine(binaryValue);
        }
    }
}
