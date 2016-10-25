using System;

namespace DecimalToHex
{
    class DecToHex
    {
        static void Main()
        {
            long decimalValue = long.Parse(Console.ReadLine());

            string[] hexDigits =
            {
                "0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F"
            };
            string hexValue = "";
            while (decimalValue != 0)
            {
                long remainder = decimalValue % 16;

                hexValue = hexDigits[remainder] + hexValue;
                decimalValue /= 16;
            }
            Console.WriteLine(hexValue);
        }
    }
}
