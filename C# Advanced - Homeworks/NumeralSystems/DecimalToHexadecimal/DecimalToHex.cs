using System;
using System.Numerics;

class DecimalToHex
{
    static void Main()
    {
        BigInteger decimalValue = BigInteger.Parse(Console.ReadLine());

        string hexadecimalValue = ConverDecimalToHex(decimalValue);
        Console.WriteLine(hexadecimalValue);
        
    }

    private static string ConverDecimalToHex(BigInteger decimalValue)
    {
        string hexValue = string.Empty;
        string hexDigits = "0123456789ABCDEF";

        while(decimalValue != 0)
        {
            int remainder = (int)(decimalValue % 16);
            hexValue = hexDigits[remainder] + hexValue;

            decimalValue /= 16;
        }

        return hexValue;
    }
}

