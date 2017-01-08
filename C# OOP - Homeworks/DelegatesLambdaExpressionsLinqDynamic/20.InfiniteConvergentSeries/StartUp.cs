namespace InfiniteConvergentSeries
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var firstTest = InfiniteSeries.GetSum(1, 1, (x, y) => x / y, x => x, y => y * 2);
            var secondTest = InfiniteSeries.GetSum(1, 1, (x, y) => x / InfiniteSeries.Factorial(y), x => x, y => y + 1);
            var thirdTest = InfiniteSeries.GetSum(1, 2, (x, y) => x / y, x => x, y => y * -2) + 1;

            // for 1 + 1/2 + 1/4 + 1/8 + 1/16 + …
            Console.WriteLine("{0:0.00}", firstTest);

            // for 1 + 1/2! + 1/3! + 1/4! + 1/5! + …
            Console.WriteLine("{0:0.00}", secondTest);

            // for 1 + 1/2 - 1/4 + 1/8 - 1/16 + …
            Console.WriteLine("{0:0.00}", thirdTest);
        }
    }
}
