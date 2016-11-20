using System;
using System.Collections.Generic;
using System.Linq;

class WorkingDays
{
    public static int GetWorkDays(DateTime dateToCheck,List<DateTime> holidays)
    {
        int offDaysCount = 0;

       
        DateTime startDate =DateTime.Today;
        DateTime endDate = dateToCheck;

        if (startDate > dateToCheck)
        {
            startDate = dateToCheck;
            endDate = DateTime.Today;
        }
        int totalDaysBetweenDates = 0;
        for (DateTime date = startDate; date <= endDate;date = date.AddDays(1))
        {
            bool isSpecialHoliday = false;
            foreach(var holiday in holidays)
            {
                if (holiday.Day == date.Day && holiday.Month == date.Month && holiday.Year == date.Year)
                {
                    isSpecialHoliday = true;
                    break;
                }
            }

            if (isSpecialHoliday || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                offDaysCount++;
            }

            totalDaysBetweenDates++;
        }

        int workDays = totalDaysBetweenDates - offDaysCount;
        return workDays;

    }
}

class WorkDays
{
    static void Main()
    {
        DateTime date = DateTime.Parse(Console.ReadLine());
        var specialHolidays = new List<DateTime>();
        specialHolidays = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(DateTime.Parse).ToList();
        
        int offDays = WorkingDays.GetWorkDays(date, specialHolidays);
        Console.WriteLine(offDays);
    }
}

