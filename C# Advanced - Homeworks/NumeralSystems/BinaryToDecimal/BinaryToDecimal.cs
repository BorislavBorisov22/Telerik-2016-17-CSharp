using System;


class BinaryToDecimal
{
    static void Main()
    {
        string binaryValue = Console.ReadLine();

        long decimalValue = ConvertBinaryToDecimal(binaryValue);

        Console.WriteLine(decimalValue);
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
}

