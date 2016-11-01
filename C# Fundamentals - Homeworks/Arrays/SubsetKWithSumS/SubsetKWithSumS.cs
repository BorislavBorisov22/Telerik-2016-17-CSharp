using System;
using System.Collections.Generic;
using System.Linq;


class SubsetWithSumS
{
    static int sum;
    static int[] nums;
    static int k;
    static bool sumExists = false;

    private static void PossibleSums(int index, List<int> subset)
    {
        
        if (subset.Count >= k)
        {
            int currSum = subset.Sum();
            if (currSum == sum)
            {
                sumExists = true;
            }
            return;
        }

        for (int i = index; i < nums.Length; i++)
        {
            subset.Add(nums[i]);
            PossibleSums(i + 1, subset);
            subset.RemoveAt(subset.Count - 1);
        }


    }
    static void Main()
    {
        //read input
        
        nums = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        sum = int.Parse(Console.ReadLine());
        k = int.Parse(Console.ReadLine());

        var subset = new List<int>();

        PossibleSums(0, subset);
        if (sumExists)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

