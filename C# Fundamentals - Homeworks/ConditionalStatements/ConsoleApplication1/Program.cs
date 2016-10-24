using System;
using System.Globalization;
class Age
{
    static void Main()
    {
        Console.WriteLine("Enter you'r Birthday date (YYYY.MM.DD): ");
        DateTime BithDay = DateTime.Parse(Console.ReadLine());
        DateTime now = DateTime.Now;
        int age = (int)((now - BirthDay).TotalDays / 365.242199);
        Console.WriteLine("You Are" + age + "Year's old");
        Console.WriteLine("After ten Years you will be at the age of" + (age + 10));
    }
}