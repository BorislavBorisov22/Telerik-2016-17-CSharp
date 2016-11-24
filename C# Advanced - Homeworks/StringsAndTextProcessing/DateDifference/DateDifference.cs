using System;
using System.Globalization;

class DateDifference
{
    static void Main()
    {
        
        Console.Write("Enter the first date: ");
        string date = Console.ReadLine();
        DateTime firstDate = DateTime.ParseExact(date, "d.MM.yyyy", CultureInfo.InvariantCulture);

        Console.Write("Enter the second date: ");
        date = Console.ReadLine();
        DateTime secondDate = DateTime.ParseExact(date, "d.MM.yyyy", CultureInfo.InvariantCulture);

        int differenceDays = GetDateDifference(firstDate, secondDate);
        Console.WriteLine("Distance: {0} days",differenceDays);
    }

    private static int GetDateDifference(DateTime firstDate, DateTime secondDate)
    {
        TimeSpan result;
        if (firstDate > secondDate)
        {
            result = firstDate - secondDate;
        }
        else
        {
            result = secondDate - firstDate;
        }
        

        return result.Days;
    }
}

