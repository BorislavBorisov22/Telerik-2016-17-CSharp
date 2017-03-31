namespace VariablesDataExpressionsConstants
{
    using System;

    public class Printer
    {
        public void PrintStatistics(double[] numbers, int count)
        {
            double maxNumber = double.MinValue;
            double minNumber = double.MaxValue;
            double sumNumbers = 0;

            for (int i = 0; i < count; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }

                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }

                sumNumbers += numbers[i];
            }

            this.Print("Maxium number in the collection is: {0:f2}", maxNumber);
            this.Print("Minimum number in the collection is: {0:f2}", maxNumber);
            this.Print("Average of the numbers in the collection is: {0:f2}", sumNumbers / count);
        }

        private void Print(string message, double value)
        {
            Console.WriteLine(message, value);
        }
    }
}
