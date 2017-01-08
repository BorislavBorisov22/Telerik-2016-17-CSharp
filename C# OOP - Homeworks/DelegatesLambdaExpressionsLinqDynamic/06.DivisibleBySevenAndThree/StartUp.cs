namespace DivisibleBySevenAndThree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<long> numbers = new List<long> { 2, 3, 6, 21, 42, 1024, 50002, 9261, -18, -341231 };

        public static void Main()
        {
            int targetDivisor = 21;
            FindDivisiblesWithLinq(targetDivisor);
            Console.WriteLine();
            FindDivisiblesWithExtensionMethods(targetDivisor);
        }

        public static void FindDivisiblesWithLinq(int targetDivisor)
        {
            var targetNumbers = from n in numbers
                                where n % targetDivisor == 0
                                select n;
            foreach (var number in targetNumbers)
            {
                Console.Write("{0} ", number);
            }
        }

        public static void FindDivisiblesWithExtensionMethods(int targetDivisor)
        {
            numbers.Where(n => n % targetDivisor == 0).ToList()
                .ForEach(n => Console.Write("{0} ", n));
        }
    }
}
