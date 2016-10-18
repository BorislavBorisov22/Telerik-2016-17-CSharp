using System;

namespace IntroductionToProgramming
{
    class Program
    {
        static void Main()
        {
            var birthDate = DateTime.Parse(Console.ReadLine());
            var currentDate = DateTime.Now;

            int myAge = 0;

            if (currentDate.Month > birthDate.Month)
            {
                myAge = (currentDate.Year - birthDate.Year) - 1;
            }
            else if (currentDate.Month == birthDate.Month && currentDate.Day > birthDate.Day)
            {
                myAge = (currentDate.Year - birthDate.Year) - 1;
            }
            else
            {
                myAge = currentDate.Year - birthDate.Year;
            }

            Console.WriteLine(myAge);
            Console.WriteLine(myAge + 10);




        }
    }
}
