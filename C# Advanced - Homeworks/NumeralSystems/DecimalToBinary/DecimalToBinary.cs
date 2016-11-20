using System;
using System.Numerics;



class DecimalToBinary
{
    static void Main()
    {
        string decimalValue = Console.ReadLine();

        string binaryValue = ConvertDecimalToBinary(decimalValue);

        Console.WriteLine(binaryValue);

    }

    private static string ConvertDecimalToBinary(string decimalValue)
    {
        long decValue = long.Parse(decimalValue);
        string binaryValue = string.Empty;
        while (decValue != 0)
        {
            binaryValue = decValue % 2 + binaryValue;
            decValue /= 2;
        }
        
        return binaryValue;
    }
}

