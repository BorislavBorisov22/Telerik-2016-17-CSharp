using System;

class Permutations
{

    private static void GeneratePermutations(int[] arr, int k)
    {
        if (k >= arr.Length)
        {
            string permutations = string.Join(", ", arr);
            string output = "{ " + permutations + " }";
            Console.WriteLine(output);
        }
        else
        {
            GeneratePermutations(arr, k + 1);
            for (int i = k + 1; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                GeneratePermutations(arr, k + 1);
                Swap(ref arr[k], ref arr[i]);
            }
        }
    }

    private static void Swap(ref int first, ref int second)
    {
        first = first ^ second;
        second = first ^ second;
        first = first ^ second;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i + 1;
        }
        GeneratePermutations(arr, 0);

    }
}

