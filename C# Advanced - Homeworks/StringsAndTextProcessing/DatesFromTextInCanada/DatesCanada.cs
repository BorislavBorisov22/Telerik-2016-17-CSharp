using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

class DatesCanada
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<DateTime> dates = ExtractDates(input);

        
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
        //Console.WriteLine(CultureInfo.CurrentCulture);
        foreach (DateTime date in dates)
        {
            string currentDate = date.ToString();
            Console.WriteLine(currentDate);
        }

    }

    private static List<DateTime> ExtractDates(string input)
    {
        var dates = new List<DateTime>();

        string datePath = @"\b(?<day>\d{2}).(?<month>\d{2}).(?<year>\d{4})\b";
        var dateMatcher = new Regex(datePath);

        var dateMatches = dateMatcher.Matches(input);

        foreach(Match date in dateMatches)
        {
            int day = int.Parse(date.Groups["day"].ToString());
            int month = int.Parse(date.Groups["month"].ToString());
            int year = int.Parse(date.Groups["year"].ToString());

            var currentDate = new DateTime(year, month, day);
            dates.Add(currentDate);
        }


        return dates;
    }
}

