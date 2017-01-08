namespace IEnumerable
{
    using System;
    using System.Collections.Generic;
    using IEnumerable.Extensions;

    public class StartUp
    {
        public static void Main()
        {
            // var myList = new List<double> { 10, 20, 30, 40 };
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var sum = list.Sum();
            var product = list.Product();
            var min = list.Min();
            var max = list.Max();
            var average = list.Average();
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine("Product: {0}", product);
            Console.WriteLine("Min: {0}", min);
            Console.WriteLine("Max: {0}", max);
            Console.WriteLine("Average: {0:0.00}", average);
        }
    }
}
