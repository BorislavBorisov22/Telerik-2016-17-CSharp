using System;

namespace AllocateArray
{
    class AllocateArray
    {
        static void Main()
        {
            int sizeArray = int.Parse(Console.ReadLine());

            long[] numbersArr = new long[sizeArray];

            for (int i = 0; i < numbersArr.Length; i++)
            {
                numbersArr[i] = i * 5;
            }

            // printing array

            for (int i = 0; i < numbersArr.Length; i++)
            {
                Console.WriteLine(numbersArr[i]);
            }
        }
    }
}
