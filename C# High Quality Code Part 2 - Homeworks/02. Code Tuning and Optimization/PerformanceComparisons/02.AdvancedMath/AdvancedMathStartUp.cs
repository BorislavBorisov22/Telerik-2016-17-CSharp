namespace _02.AdvancedMath
{
    using System;
    using System.Diagnostics;

    public class AdvancedMathStartUp
    {
        public static void Main()
        {
            Console.WriteLine("Float results");
            float floatNumber = 222.45f;
            TestAdvancedMathOperationsPerformance(floatNumber);

            Console.WriteLine();
            Console.WriteLine("Double results");
            double doubleNumber = 222.45;
            TestAdvancedMathOperationsPerformance(doubleNumber);

            Console.WriteLine();
            Console.WriteLine("Decimal results");
            decimal decimalNumber = 222.45m;
            TestAdvancedMathOperationsPerformance(decimalNumber);
        }

        private static void TestAdvancedMathOperationsPerformance(dynamic number)
        {
            int loopEnd = 10000;

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < loopEnd; ++i)
                {
                    Math.Sqrt((double)number);
                }

            }, "Getting square root");

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < loopEnd; ++i)
                {
                    Math.Log10((double)number);
                }

            }, "Natural logarithm");

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < loopEnd; ++i)
                {
                    Math.Sin((double)number);
                }
            }, "Sinus");
        }

        private static void DisplayExecutionTime(Action action, string operationType)
        {
            var sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();

            Console.WriteLine($"{operationType} took {sw.Elapsed}");
        }
    }
}
