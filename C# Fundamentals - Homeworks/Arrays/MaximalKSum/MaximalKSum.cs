using System;


class MaximalKSum
{
    static void Main()
    {
        int sizeArray = int.Parse(Console.ReadLine());
        int K = int.Parse(Console.ReadLine());
        var numbersArr = new long[sizeArray];

        //fill in array
        for (int i = 0; i < numbersArr.Length; i++)
        {
            numbersArr[i] = long.Parse(Console.ReadLine());
        }

        long maxKSum = 0;
        Array.Sort(numbersArr);

        for (int i = 0; i < K; i++)
        {
            maxKSum += numbersArr[numbersArr.Length - 1 - i];
        }

        Console.WriteLine(maxKSum);
    }
}

