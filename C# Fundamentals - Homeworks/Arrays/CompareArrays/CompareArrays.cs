using System;


namespace CompareArrays
{
    class CompareArrays
    {
        static void ArrayFill(long[] numberArray)
        {
            for (int i = 0; i < numberArray.Length; i++)
            {
                long currNumber = long.Parse(Console.ReadLine());
                numberArray[i] = currNumber;
            }
        }
        static void Main()
        {
            int sizeArrays = int.Parse(Console.ReadLine());

            long[] firstArray = new long[sizeArrays];
            long[] secondArray = new long[sizeArrays];

            ArrayFill(firstArray);
            ArrayFill(secondArray);

            bool areEqual = true;
            for (int i = 0; i < sizeArrays; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    areEqual = false;
                    break;
                }
            }
            if (areEqual)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }

        }
    }
}
