using System;


namespace BiggestOfFive
{
    class BiggestOfFive
    {
        static void Main()
        {
            double maxNumber = double.MinValue;

            for (int i = 0; i < 5; i++)
            {
                double currNumber = double.Parse(Console.ReadLine());

                if (currNumber > maxNumber)
                {
                    maxNumber = currNumber;
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}
