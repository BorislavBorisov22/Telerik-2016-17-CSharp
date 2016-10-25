using System;

namespace MatrixOfNumbers
{
    class MatrixOfNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n ; i++)
            {
                int numberToFill = i;
                for (int k = 0; k < n; k++)
                {
                    if (k == n - 1)
                    {
                        Console.Write(numberToFill);
                    }
                    else
                    {
                        Console.Write(numberToFill + " ");
                    }
                    numberToFill++;
                }
                Console.WriteLine();
            }
        }
    }
}
