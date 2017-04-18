namespace _03.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class SortingAlgorithmsStartUp
    {
        public static void Main()
        {
            // checking the algorithms with a randomly picked values in the collections
            Console.WriteLine("Checking with random values");
            Console.WriteLine("  Integers: ");
            var integersList = new List<int>() { 1, 4, -1024, 2000018, 20, -128, 1914, 77, 1, 4, 16, 33, 22, 11, 44, 55, 12, 12, 12, 12, 1, 212, 2, 2, 22, 2, 2, 2, 2, 22, 2, 2, 2, 2, 22, 2, 2, 4, 44, 4, 2, 2, 2, 1, 11, 1, 1, 1, 11, 1, 3, 43, 2, 21, 1024, -1891 };
            TestSortingAlgorithms(integersList);

            Console.WriteLine("  Strings: ");
            var stringsList = new List<string>() { "aaaaa", "some-random-text", "sotring is kind of cool", "#", "ddddd", "ccccc", "z" };
            TestSortingAlgorithms(stringsList);

            Console.WriteLine("  Doubles: ");
            var doublesList = new List<double>() { 1.5, 4.3, -1024.3243221, 2000018.4312423, 20, -128.54333, 1914, 77, 1, 4, 16, 33, 22, 11, 44, 55, 12.4324, 12.43242, 12, 12.4324, 1.121, 212, 2, 2, 22, 2, 2, 2, 2, 22, 2, 2, 2, 2, 22, 2, 2, 4, 44, 4, 2, 2, 2, 1, 11, 1, 1, 1, 11, 1, 3, 43, 2, 21, 1024, -1891 };
            TestSortingAlgorithms(doublesList);
            Console.WriteLine();

            // checking the algorithms with already sorted collections
            Console.WriteLine("Checking with sorted values");
            Console.WriteLine("  Integers: ");
            integersList = Sorting.SelectionSort(integersList);
            TestSortingAlgorithms(integersList);

            Console.WriteLine("  Strings: ");
            stringsList = Sorting.SelectionSort(stringsList);
            TestSortingAlgorithms(stringsList);

            Console.WriteLine("  Doubles: ");
            doublesList = Sorting.SelectionSort(doublesList);
            TestSortingAlgorithms(doublesList);
            Console.WriteLine();

            // checking the algorithms with reverseley sorted collections
            Console.WriteLine("Checking with descendingley sorted values");
            Console.WriteLine("  Integers: ");
            integersList = Sorting.SelectionSort(integersList);
            integersList.Reverse();
            TestSortingAlgorithms(integersList);

            Console.WriteLine("  Strings: ");
            stringsList = Sorting.SelectionSort(stringsList);
            stringsList.Reverse();
            TestSortingAlgorithms(stringsList);

            Console.WriteLine("  Doubles: ");
            doublesList = Sorting.SelectionSort(doublesList);
            doublesList.Reverse();
            TestSortingAlgorithms(doublesList);
            Console.WriteLine();

            // checking the algorithms with collections with a lot ot elements => checking only for integers
            Console.WriteLine("     Testing the algorithms with a very big collections => only checking for integers");
            var hugeCollection = GetBigIntegerList();
            TestSortingAlgorithms(hugeCollection);
        }

        private static List<int> GetBigIntegerList()
        {
            int count = 300000;

            var result = new List<int>(count);

            for (int i = count; i >= 0; i--)
            {
                result.Add(i);
            }

            return result;
        }

        private static void PrintCollection<T>(IList<T> collection)
        {
            Console.WriteLine(string.Join(", ", collection));
        }

        private static void TestSortingAlgorithms<T>(List<T> elements) where T : IComparable
        {
            var elementsCopy = CopyList(elements);
            var sw = new Stopwatch();

            sw.Start();
            elementsCopy = Sorting.SelectionSort(elementsCopy);
            sw.Stop();
            Console.WriteLine($"     Selection sort: {sw.Elapsed}");

            elementsCopy = CopyList(elements);
            sw.Start();
            elementsCopy = Sorting.QuickSort(elementsCopy);
            sw.Stop();
            Console.WriteLine($"     Quicksort: {sw.Elapsed}");

            elementsCopy = CopyList(elements);
            sw.Start();
            elementsCopy = Sorting.InsertionSort(elementsCopy);
            sw.Stop();
            Console.WriteLine($"     InsertionSort: {sw.Elapsed}");

        }

        private static List<T> CopyList<T>(List<T> originalList)
        {
            var copyList = new List<T>();
            originalList.ForEach(x => copyList.Add(x));

            return copyList;
        }

    }
}
