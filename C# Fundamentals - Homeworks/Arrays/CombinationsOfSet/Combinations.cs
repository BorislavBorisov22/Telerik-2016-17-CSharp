using System;


class Combinations
{
    private static void CombinationsGenerator(int[] arr, int index, int start, int n)
    {
        if (index >= arr.Length)
        {
            string combinations = string.Join(", ", arr);
            string output = "{ " + combinations + " }";
            Console.WriteLine(output);
        }
        else
        {
            for (int i = start; i <= n; i++)
            {
                arr[index] = i;
                CombinationsGenerator(arr, index + 1, i + 1, n);
            }
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] arr = new int[k];
        CombinationsGenerator(arr, 0, 1, n);

    }
}

