using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class Messages
{
    static List<string> digits = new List<string>(){ "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan" };
    static List<string> digitValues = new List<string>(){ "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    static void Main()
    {
        string firstNumberInGeorge = Console.ReadLine();
        string operation = Console.ReadLine();
        string secondNumberInGeorge = Console.ReadLine();

        BigInteger firstNumberDecValue = GeorgeToDecimal(firstNumberInGeorge);
        BigInteger secondNumberDecValue = GeorgeToDecimal(secondNumberInGeorge);
        
        BigInteger resultNumberDecimal = OperateWithNumbers(firstNumberDecValue, secondNumberDecValue, operation);
        
        string resultInGeorgeSystem = DecimalToGeorge(resultNumberDecimal);
        Console.WriteLine(resultInGeorgeSystem);
    }

    private static string DecimalToGeorge(BigInteger decimalValue)
    {
        string result = string.Empty;

        while (decimalValue > 0)
        {
            BigInteger remainder = decimalValue % 10;
            result = digits[(int)remainder] + result;
            decimalValue /= 10;
        }

        return result;

    }

    private static BigInteger OperateWithNumbers(BigInteger firstNumberDecValue, BigInteger secondNumberDecValue, string operation)
    {
        if (operation == "+")
        {
            return firstNumberDecValue + secondNumberDecValue;
        }
        else
        {
            return firstNumberDecValue - secondNumberDecValue;
        }
    }

    private static BigInteger GeorgeToDecimal(string inputNumber)
    {
        BigInteger result = 0;

        StringBuilder temp = new StringBuilder(inputNumber.Length);

        for (int i = 0; i < inputNumber.Length; i++)
        {
            temp.Append(inputNumber[i]);

            if (digits.Contains(temp.ToString()))
            {
                int digitIndex = digits.IndexOf(temp.ToString());
                result = result * 10 + (digitIndex);
                temp.Clear();
            }
            
        }

        return result;
    }
}

