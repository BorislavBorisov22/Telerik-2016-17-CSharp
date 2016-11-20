using System;


class HexToDecimal
{
    static void Main()
    {
        string hexValue = Console.ReadLine();

        long decimalValue = ConvertHexToDecimal(hexValue);
        Console.WriteLine(decimalValue);
    }

    private static long ConvertHexToDecimal(string hexValue)
    {
        long decimalValue = 0;

        for (int i = 0;i < hexValue.Length; i++)
        {
            int multiplier = 0;
            if (hexValue[hexValue.Length-1-i] >= '0' && hexValue[hexValue.Length-1-i] <= '9')
            {
                multiplier = hexValue[hexValue.Length-1-i] - '0';
            }
            else
            {
                multiplier = hexValue[hexValue.Length-1-i] - 'A' + 10;
            }

            decimalValue += multiplier * (long)Math.Pow(16, i);
        }


        return decimalValue;
    }
}

