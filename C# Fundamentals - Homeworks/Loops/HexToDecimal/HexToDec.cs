using System;

namespace HexToDec
{
    class HexToDec
    {
        static void Main()
        {
            string hexValue = Console.ReadLine();

            long decimalValue = 0;
            for (int i = 0; i < hexValue.Length; i++)
            {
                char currHexDigit = hexValue[hexValue.Length-1-i];
                if (currHexDigit >= '0' && currHexDigit <= '9')
                {
                    decimalValue += (currHexDigit - '0') * (long)(Math.Pow(16, i));

                }
                else
                {
                    decimalValue += (currHexDigit - 'A' + 10) * (long)(Math.Pow(16,i));
                }
            }

            Console.WriteLine(decimalValue);
        }
    }
}
