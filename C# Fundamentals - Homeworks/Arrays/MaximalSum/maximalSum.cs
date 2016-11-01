using System;


class maximalSum
{
    static void Main()
    {
        int sizeArray = int.Parse(Console.ReadLine());

        var numbersArr = new long[sizeArray];

        for (int i = 0; i < numbersArr.Length; i++)
        {
            var currNumber = long.Parse(Console.ReadLine());
            numbersArr[i] = currNumber;
        }

        long maxSum = long.MinValue;

        for (int i = 0; i < numbersArr.Length; i++)
        {
            long currSum = 0;
            for (int k = i; k < numbersArr.Length; k++)
            {
                currSum += numbersArr[k];
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                }
            }
        }

        Console.WriteLine(maxSum);
    }
}

