using System;

class LeapYear
{
    static void Main()
    {
        while (true)
        {
            int year = int.Parse(Console.ReadLine());

            bool isLeap = DateTime.IsLeapYear(year);

            if (isLeap)
            {
                Console.WriteLine("Leap");
            }
            else
            {
                Console.WriteLine("Common");
            }
        }
        

    }
}

