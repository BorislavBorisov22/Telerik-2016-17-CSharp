using System;
using System.Linq;

class NumberReverser
{
    private static string ReverseNumber (string number)
    {
        var numberArr = number.ToCharArray();
        Array.Reverse(numberArr);
        return new string(numberArr);
       
    }
    static void Main()
    {
        string number = Console.ReadLine();
        string reversedNumber = ReverseNumber(number);

        Console.WriteLine(reversedNumber);
    }
}

