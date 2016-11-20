using System;


class DayOfWeek
{
    static void Main()
    {
        DateTime today = DateTime.Today;
        var dayOfWeek = today.DayOfWeek;
        Console.WriteLine(dayOfWeek);
    }
}

