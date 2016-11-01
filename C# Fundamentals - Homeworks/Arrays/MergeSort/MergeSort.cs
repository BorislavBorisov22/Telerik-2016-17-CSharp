using System;
using System.Collections.Generic;
using System.Linq;

class MergeSorter
{
    private static List<int> MergeSort(List<int> numbers)
    {
       if (numbers.Count <= 1)
        {
            return numbers;
        }

        var left = new List<int>();
        var right = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i % 2 == 1)
            {
                left.Add(numbers[i]);
            }
            else
            {
                right.Add(numbers[i]);
            }
        }

        left = MergeSort(left);
        right = MergeSort(right);



        return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        var result = new List<int>();

        while (left.Count > 0 && right.Count > 0)
        {
            if (left.First() <= right.First())
            {
                result.Add(left.First());
                left.RemoveAt(0);
            }
            else
            {
                result.Add(right.First());
                right.RemoveAt(0);
            }
        }


        while (left.Count > 0)
        {
            result.Add(left.First());
            left.RemoveAt(0);
        }
        while (right.Count > 0)
        {
            result.Add(right.First());
            right.RemoveAt(0);
        }
        
        return result;
    }

    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        var numbers = new List<int>();

        for (int i = 0; i < size; i++)
        {
            int number = int.Parse(Console.ReadLine());
            numbers.Add(number);
        }

        numbers = MergeSort(numbers);

        Console.WriteLine(string.Join("\n",numbers));


    }

    
}

