using System;
using System.Collections.Generic;
using System.Linq;

class NumberAsArray
{
    private static int[] SumArrays(int[] firstArr,int[] secondArr)
    {
        var resultArr = new List<int>();
        int lastRemainder = 0;
        for (int i = 0;i < Math.Min(firstArr.Length, secondArr.Length); i++)
        {
            int currSum = firstArr[i] + secondArr[i] + lastRemainder;
            lastRemainder = currSum / 10;
            currSum = currSum % 10;
            resultArr.Add(currSum);
        }

        if (firstArr.Length == secondArr.Length && lastRemainder != 0)
        {
            resultArr.Add(lastRemainder);
        }
        else if (firstArr.Length > secondArr.Length)
        {
            for (int i = secondArr.Length; i < firstArr.Length; i++)
            {
                int currSum = firstArr[i] + lastRemainder;

                lastRemainder = currSum / 10;
                currSum %= 10;

                resultArr.Add(currSum);
            }
        }
        else if (secondArr.Length > firstArr.Length)
        {
            for (int i = firstArr.Length; i < secondArr.Length; i++)
            {
                int currSum = secondArr[i] + lastRemainder;

                lastRemainder = currSum / 10;
                currSum %= 10;

                resultArr.Add(currSum);
            }
        }

        

        return resultArr.ToArray();
    }
    static void Main()
    {
        int[] sizeArrays = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int firstArraySize = sizeArrays[0];
        int secondArraySize = sizeArrays[1];

        int[] firstArray = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int[] secondArray = Console.ReadLine()
           .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse).ToArray();

        int[] resultArr = SumArrays(firstArray, secondArray);

        Console.WriteLine(string.Join(" ",resultArr));
    }
}

