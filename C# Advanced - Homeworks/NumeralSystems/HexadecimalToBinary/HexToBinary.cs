using System;



class HexToBinary
{
    private static long ConvertHexToDecimal(string hexValue)
    {
        long decimalValue = 0;

        for (int i = 0; i < hexValue.Length; i++)
        {
            int multiplier = 0;
            if (hexValue[hexValue.Length - 1 - i] >= '0' && hexValue[hexValue.Length - 1 - i] <= '9')
            {
                multiplier = hexValue[hexValue.Length - 1 - i] - '0';
            }
            else
            {
                multiplier = hexValue[hexValue.Length - 1 - i] - 'A' + 10;
            }

            decimalValue += multiplier * (long)Math.Pow(16, i);
        }


        return decimalValue;
    }
    private static string ConvertDecimalToBinary(long decimalValue)
    {
        
        string binaryValue = string.Empty;
        while (decimalValue != 0)
        {
            binaryValue = decimalValue % 2 + binaryValue;
            decimalValue /= 2;
        }

        return binaryValue;
    }
    private static string ConvertHexToBinary(string hexValue)
    {
        long decimalValue = ConvertHexToDecimal(hexValue);
        string binaryValue = ConvertDecimalToBinary(decimalValue);

        return binaryValue;
    }
    static void Main()
    {
        string hexValue = Console.ReadLine();
        string binaryValue = ConvertHexToBinary(hexValue);
        Console.WriteLine(binaryValue);
    }
}

