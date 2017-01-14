namespace RangeException
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // Testing the exception for integers
            // to get the exception for invalid integer enter a number outside of the given range
            // on the console.
            // to get the exception for invalid date first enter a valid integer on the 
            // console or comment the first try-catch block

            // testing the invalid range excception for ints
            try
            {
                Console.WriteLine("Enter a number in the range 1 - 100");
                int number = int.Parse(Console.ReadLine());

                if (number < 0 || number > 100)
                {
                    throw new InvalidRangeException<int>("Number is outside the required range", 1, 100);
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }

            // testing the invalid range exception for dates
            try
            {
                var testDate = new DateTime(2020, 12, 12);
                DateTime minDate = new DateTime(1970, 1, 1);
                DateTime maxDate = new DateTime(2013, 12, 31);

                if (testDate < minDate || testDate > maxDate)
                {
                    throw new InvalidRangeException<DateTime>("Date was outside of the specified range", minDate, maxDate);
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
