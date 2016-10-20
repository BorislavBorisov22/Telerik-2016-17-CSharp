using System;


namespace SumOfNNumbers
{
    class SumOfNNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double sumNumbers = 0;

            for (int i = 0; i < n; i++)
            {
                double currNumber = double.Parse(Console.ReadLine());
                sumNumbers += currNumber;
            }
            Console.WriteLine(sumNumbers);
        }
    }
}
