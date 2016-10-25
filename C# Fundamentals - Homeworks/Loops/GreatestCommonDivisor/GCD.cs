using System;
using System.Linq;

namespace GreatestCommonDivisor
{
    class GCD
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int a = numbers[0];
            int b = numbers[1];

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            int GCD = a;
            Console.WriteLine(GCD);
        }
    }
}
