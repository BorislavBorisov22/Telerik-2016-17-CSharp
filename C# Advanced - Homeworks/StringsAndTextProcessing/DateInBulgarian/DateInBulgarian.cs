using System;
using System.Globalization;

class DateInBulgarian
{

    public static void PrintDateInBulgarian(string input)
    {
        DateTime date = DateTime.ParseExact(input, "dd.MM.yyyy hh:mm:ss", CultureInfo.InvariantCulture);

        date = date.AddHours(6).AddMinutes(30);

        string output = date.ToString("dd.MM.yyyy hh:mm:ss");

        Console.WriteLine("{0} {1}",output,date.DayOfWeek);
        
        
    }
    static void Main()
    {
        string input = Console.ReadLine();
        PrintDateInBulgarian(input);
    }
}

