using System;


class BinaryFloatingPoint
{
    static void Main()
    {
        float number = float.Parse(Console.ReadLine());

        int sign = number < 0 ? 1 : 0;
        number = Math.Abs(number);

        string numberInBinary = FloatToBinary(number);

        if ((int)number == 1 || (int)number == 0)
        {
            numberInBinary = "0" + numberInBinary;
        }

        string exponent = GetExponent(numberInBinary);
        string mantissa = GetMantissa(numberInBinary);

        Console.WriteLine("sign {0}",sign);
        Console.WriteLine("exponent {0}",exponent);
        Console.WriteLine("mantissa {0}",mantissa);
        
    }

    private static string GetExponent(string numberInBinary)
    {
        return numberInBinary.Substring(0, 8);
    }
    private static string GetMantissa(string numberInBinary)
    {
        return numberInBinary.Substring(8);
    }

    private static string FloatToBinary(float number)
    {
        int numberBytes = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);
        //Console.WriteLine(numberBytes);
        return Convert.ToString(numberBytes,2);
    }
}

