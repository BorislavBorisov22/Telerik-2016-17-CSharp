using System;
using System.Numerics;


class OneSystemToAnyOther
{
    static void Main()
    {
        int currentBase = int.Parse(Console.ReadLine());
        string number = Console.ReadLine().ToUpper();
        int targetBase = int.Parse(Console.ReadLine());
        if (targetBase < 0)
        {
            targetBase *= -1;
        }
        BigInteger decimalValue = NToDecimal(number,currentBase);
        string resultValue = DecimalToN(decimalValue, targetBase);
        Console.WriteLine(resultValue);
    }
    private static BigInteger Pow(BigInteger number,int pow)
    {
        BigInteger poweredNumber = 1;

        for (int i = 0; i < pow; i++)
        {
            poweredNumber *= number;
        }

        return poweredNumber;
    }

    private static string DecimalToN(BigInteger decimalValue, int targetBase)
    {
        if (decimalValue == 0)
        {
            return "0";
        }
        string resultValue = string.Empty;
        string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        while (decimalValue != 0)
        {
            int remainder = (int)(decimalValue % targetBase);
            resultValue = digits[remainder] + resultValue;
            decimalValue /= targetBase;
        }


        return resultValue;
    }

    private static BigInteger NToDecimal(string number,int currentBase)
    {
        BigInteger decimalValue = 0;

        for (int i = 0; i < number.Length; i++)
        {
            char currDigit = number[number.Length - 1 - i];
            
            if (currDigit >= '0' && currDigit <= '9')
            {
                decimalValue += (currDigit - '0') * Pow(currentBase,i);
            }
            else
            {
                decimalValue = (currDigit - 'A' + 10) * Pow(currentBase, i);
            }
        }

        return decimalValue;
    }
}
