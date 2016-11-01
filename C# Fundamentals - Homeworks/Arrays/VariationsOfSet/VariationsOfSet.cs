using System;


class VariationsOfSet
{

    private static void VariationsGenerator(int index, int[] arr, int n)
    {
        if (index >= arr.Length)
        {
            string output = string.Join(", ", arr);
            Console.WriteLine("{ " + output + " }");
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                VariationsGenerator(index + 1, arr, n);
            }
        }
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[k];
        VariationsGenerator(0, arr, n);
    }
}

