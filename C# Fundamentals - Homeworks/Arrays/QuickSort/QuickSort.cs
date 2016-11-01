using System;
using System.Collections.Generic;


class QuickSorter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var numbers = new List<int>();

        ReadList(n, numbers);
        numbers = QuickSort(numbers);
        PrintList(numbers);
    }

    private static void PrintList(List<int> numbers)
    {
        foreach(var number in numbers)
        {
            Console.WriteLine(number);
        }
    }

    private static List<int> QuickSort(List<int> numbers)
    {
        if (numbers.Count <= 1)
        {
            return numbers;
        }
            
        int indexPivot = numbers.Count / 2;
        int pivot = numbers[indexPivot];

        var left = new List<int>();
        var right = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (i != indexPivot)
            {
                if (numbers[i] < pivot)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }
        }

        left = QuickSort(left);
        right = QuickSort(right);

        left.Add(pivot);
        left.AddRange(right);

        return left;
    }

    private static void ReadList(int n, List<int> numbers)
    {

        for (int i = 0; i < n; i++)
        {
            int numberToAdd = int.Parse(Console.ReadLine());
            numbers.Add(numberToAdd);
        }
    }


}

