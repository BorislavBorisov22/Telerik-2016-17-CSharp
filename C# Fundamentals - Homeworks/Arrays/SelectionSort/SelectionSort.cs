using System;
using System.Collections.Generic;


namespace SelectionSort
{
    class SelectionSort
    {
        static void Main()
        {
            int sizeArray = int.Parse(Console.ReadLine());
            var numbersArr = new long[sizeArray];

            for (int i = 0; i < sizeArray; i++)
            {
                numbersArr[i] = long.Parse(Console.ReadLine());
            }

            for (int i = 0; i < numbersArr.Length; i++)
            {
                
                for (int k = i + 1; k < numbersArr.Length; k++)
                {
                    if (numbersArr[k] < numbersArr[i])
                    {
                        long store = numbersArr[i];
                        numbersArr[i] = numbersArr[k];
                        numbersArr[k] = store;
                    }
                }
            }

            for (int i = 0; i < numbersArr.Length; i++)
            {
                Console.WriteLine(numbersArr[i]);
            }
        }
    }
}
