namespace _01.SimpleMath
{
    using System;
    using System.Diagnostics;

    public class SimpleMathStartUp
    {
        public static void Main()
        {
            Console.WriteLine("Results for int ");
            int firstInt = 22;
            int secondInt = 42;
            TestNumberTypePerformance(firstInt, secondInt);

            Console.WriteLine($"{Environment.NewLine}Results for float ");
            float firstFloat = 22;
            float secondFloat = 42;
            TestNumberTypePerformance(firstFloat, secondFloat);

            Console.WriteLine($"{Environment.NewLine}Results for long ");
            long firstLong = 22;
            long secondLong = 42;
            TestNumberTypePerformance(firstLong, secondLong);

            Console.WriteLine($"{Environment.NewLine}Results for double ");
            double firstDouble = 22;
            double secondDouble = 42;
            TestNumberTypePerformance(firstDouble, secondDouble);

            Console.WriteLine($"{Environment.NewLine}Results for decimal ");
            decimal firstDecimal = 22;
            decimal secondDecimal = 42;
            TestNumberTypePerformance(firstDecimal, secondDecimal);
        }

        private static void TestNumberTypePerformance(dynamic firstNumber, dynamic secondNumber)
        {
            int loopEnd = 10;

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < loopEnd; ++i)
                {
                    firstNumber = secondNumber + secondNumber;
                }

            }, "adding values");

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < loopEnd; ++i)
                {
                    firstNumber = firstNumber - secondNumber;
                }
                
            }, "substracting values");


            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < loopEnd; ++i)
                {
                    firstNumber++;
                }
               
            }, "incrementing value");

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < loopEnd; ++i)
                {
                    firstNumber = firstNumber * secondNumber;
                }
           
            }, "miliplying values");

            DisplayExecutionTime(() =>
            {
                for (int i = 0; i < loopEnd; ++i)
                {
                    firstNumber = firstNumber / secondNumber;
                }
               
            }, "dividing values");
        }

        private static void DisplayExecutionTime(Action action, string operationName)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            action();
            sw.Stop();

            var elapsedTime = sw.Elapsed;

            Console.WriteLine($"{operationName} took: {elapsedTime}");
        }
    }
}
