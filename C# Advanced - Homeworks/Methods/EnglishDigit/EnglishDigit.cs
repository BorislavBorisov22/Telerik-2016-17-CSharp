using System;



class EnglishDigit
{
    private static string LastDigitAsWord(int number)
    {
        int lastDigit = number % 10;
        string lastDigitName = string.Empty;
        switch (lastDigit)
        {
            case 0:lastDigitName = "zero";break;
            case 1:lastDigitName = "one";break;
            case 2:lastDigitName = "two";break;
            case 3:lastDigitName = "three";break;
            case 4:lastDigitName = "four";break;
            case 5:lastDigitName = "five";break;
            case 6:lastDigitName = "six";break;
            case 7:lastDigitName = "seven";break;
            case 8:lastDigitName = "eight";break;
            case 9:lastDigitName = "nine";break;   
        }


        return lastDigitName;
    }
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string lastlastDigitName = LastDigitAsWord(number);

        Console.WriteLine(lastlastDigitName);
    }
}

