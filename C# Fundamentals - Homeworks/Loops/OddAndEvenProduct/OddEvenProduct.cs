using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OddAndEvenProduct
{
    class OddEvenProduct
    {
        static void Main()
        {
            int numbersToReadCount = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int positionNumber = 1;
            BigInteger oddNumbersProduct = 1;
            BigInteger evenNumbersProduct = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (positionNumber % 2 == 0)
                {
                    evenNumbersProduct *= numbers[i];
                    
                }
                else
                {
                    oddNumbersProduct *= numbers[i];
                }
                positionNumber++;
            }

            if (oddNumbersProduct == evenNumbersProduct)
            {
                Console.WriteLine("yes {0}",oddNumbersProduct);
            }
            else
            {
                Console.WriteLine("no {0} {1}",oddNumbersProduct,evenNumbersProduct);
            }
        }
    }
}
