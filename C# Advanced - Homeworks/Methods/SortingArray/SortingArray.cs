using System;
using System.Collections.Generic;
using System.Linq;

class SortingArray
{
    private static int GetMaxIndexInPartOfArray(int[] arr,int startIndex)
    {
        int maxNumber = int.MinValue;
        int maxIndex = -1;
        for (int i = startIndex; i < arr.Length; i++)
        {
            if (arr[i] > maxNumber)
            {
                maxNumber = arr[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }
   
    private static void SortArrayDescending(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int maxIndex = GetMaxIndexInPartOfArray(arr, i);

            int temp = arr[i];
            arr[i] = arr[maxIndex];
            arr[maxIndex] = temp;
        }
    }
    private static void SortArrayAscending(int[] arr)
    {
        SortArrayDescending(arr);
        for (int i = 0;i < arr.Length / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[arr.Length - 1 - i];
            arr[arr.Length - 1 - i] = temp;
        }
    }
        
    static void Main()
    {
        int arrSize = int.Parse(Console.ReadLine());
        int[] arr = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        SortArrayAscending(arr);
        Console.WriteLine(string.Join(" ",arr));

    }
}

