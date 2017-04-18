using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Passed collection cannot be null!");
        Debug.Assert(arr.Length != 0, "Cannot sort an empty collection!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int i = 1; i < arr.Length; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i - 1]) >= 0, "Collection is not sorted correctly!");
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(value != null, "Searched value must not be null!");
        Debug.Assert(arr != null, "Provided collection must not be null!");
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
       where T : IComparable<T>
    {
        Debug.Assert(value != null, "Searched value must not be null!");
        Debug.Assert(arr != null, "Prodived collection must not be null!");
        Debug.Assert(startIndex >= 0, "Start index must not be a negative number!");
        Debug.Assert(endIndex >= 0, "End index must not be a negative number!");
        Debug.Assert(startIndex < arr.Length, "Start index must be less than the collection size!");
        Debug.Assert(endIndex < arr.Length, "End index must be less than the size of the collection!");
        Debug.Assert(startIndex <= endIndex, "Start index must not be greater than the end index!");
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Provided array cannot be null!");
        Debug.Assert(startIndex >= 0, "Start index cannot be a negative number!");
        Debug.Assert(endIndex >= 0, "End index cannot be a negative number!");
        Debug.Assert(startIndex < arr.Length, "Start index must be less than the size of the collection!");
        Debug.Assert(endIndex < arr.Length, "End index must be less than the size of the collection!");
        Debug.Assert(startIndex <= endIndex, "Start index must not be bigger than the end index!");
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[minElementIndex]) >= 0, "The found minimal element is not correct!");
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }
}
