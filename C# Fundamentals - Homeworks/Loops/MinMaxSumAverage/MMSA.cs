using System;


namespace MinMaxSumAverage
{
    class MMSA
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double maxNumber = double.MinValue;
            double minNumber = double.MaxValue;
            double average = 0;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                double currNumber = double.Parse(Console.ReadLine());
                if (currNumber > maxNumber)
                {
                    maxNumber = currNumber;
                }
                if (currNumber < minNumber)
                {
                    minNumber = currNumber;
                }
                sum += currNumber;
            }

            average = sum / n;

            Console.WriteLine("min={0:f2}",minNumber);
            Console.WriteLine("max={0:f2}",maxNumber);
            Console.WriteLine("sum={0:f2}",sum);
            Console.WriteLine("avg={0:f2}",average);
        }
    }
}
