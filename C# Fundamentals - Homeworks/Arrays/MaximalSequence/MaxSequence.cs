using System;


namespace MaximalSequence
{
    class MaxSequence
    {
        static void Main()
        {
            int sizeArray = int.Parse(Console.ReadLine());

            long[] numbers = new long[sizeArray];

            for (int i = 0; i < sizeArray; i++)
            {
                long currnumber = long.Parse(Console.ReadLine());
                numbers[i] = currnumber;
            }

            int maxSequenceCount = 1;
            int currSequenceCount = 1;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                long number = numbers[i];
                long nextNumber = numbers[i+1];
                if (number == nextNumber)
                {
                    currSequenceCount++;
                    if (currSequenceCount > maxSequenceCount)
                    {
                        maxSequenceCount = currSequenceCount;
                    }
                }
                else
                {
                    if (currSequenceCount > maxSequenceCount)
                    {
                        maxSequenceCount = currSequenceCount;
                    }
                    currSequenceCount = 1;
                }
            }
            Console.WriteLine(maxSequenceCount);

        }
    }
}
