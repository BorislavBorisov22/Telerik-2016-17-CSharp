using System;

class BinaryToHex
{
    static void Main()
    {
        string binaryValue = Console.ReadLine();
        string hexValue = ConvertBinaryToHex(binaryValue);
        Console.WriteLine(hexValue);
    }
    
    private static string ConvertBinaryToHex(string binaryValue)
    {
        long decimalValue = ConvertBinaryToDecimal(binaryValue);
        string hexValue = ConverDecimalToHex(decimalValue);

        return hexValue;
    }

    private static long ConvertBinaryToDecimal(string binaryValue)
    {
        long decimalValue = 0;

        for (int i = 0; i < binaryValue.Length; i++)
        {
            decimalValue += (binaryValue[binaryValue.Length - 1 - i] - '0') * (long)Math.Pow(2, i);
        }

        return decimalValue;
    }
    private static string ConverDecimalToHex(long decimalValue)
    {
        string hexValue = string.Empty;
        string hexDigits = "0123456789ABCDEF";

        while (decimalValue != 0)
        {
            int remainder = (int)(decimalValue % 16);
            hexValue = hexDigits[remainder] + hexValue;

            decimalValue /= 16;
        }

        return hexValue;
    }

}

