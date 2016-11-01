using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class BinarySearch
    {
        static void Main()
        {
            int sizeArray = int.Parse(Console.ReadLine());

            var numbersArr = new long[sizeArray];

            for (int i = 0; i < sizeArray; i++)
            {
                numbersArr[i] = long.Parse(Console.ReadLine());
            }

            long numberToSearchFor = long.Parse(Console.ReadLine());
            int searchedNumberIndex = -1;

            int startIndex = 0;
            int endIndex = numbersArr.Length - 1;


            while (true)
            {
                if(startIndex > endIndex)
                {
                    break;
                }

                int middleIndex = (startIndex + endIndex) / 2;

               if (numberToSearchFor == numbersArr[middleIndex])
                {
                    searchedNumberIndex = middleIndex;
                    break;
                }
               else if (numberToSearchFor > numbersArr[middleIndex])
                {
                    startIndex = middleIndex + 1;
                }
               else if (numberToSearchFor < numbersArr[middleIndex])
                {
                    endIndex = middleIndex - 1;
                }
            }

            Console.WriteLine(searchedNumberIndex);

        }


    }
}
