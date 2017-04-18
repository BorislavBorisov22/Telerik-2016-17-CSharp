namespace _03.SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public static class Sorting
    {
        public  static List<T> SelectionSort<T>(List<T> elementsToSort) where T : IComparable
        {
            for (int i = 0; i < elementsToSort.Count - 1; i++)
            {
                for (int j = i + 1; j < elementsToSort.Count; j++)
                {
                    if (elementsToSort[i].CompareTo(elementsToSort[j]) > 0)
                    {
                        T swapValue = elementsToSort[i];
                        elementsToSort[i] = elementsToSort[j];
                        elementsToSort[j] = swapValue;
                    }
                }
            }

            return elementsToSort;
        }

        public static List<T> QuickSort<T>(List<T> elementsToSort) where T : IComparable
        {
            if (elementsToSort.Count <= 1)
            {
                return elementsToSort;
            }

            int pivotIndex = elementsToSort.Count / 2;
            T pivotValue = elementsToSort[pivotIndex];

            List<T> left = new List<T>();
            List<T> right = new List<T>();

            for (int i = 0; i < elementsToSort.Count; i++)
            {
                if (i == pivotIndex)
                {
                    continue;
                }

                T currentElement = elementsToSort[i];
                
                if (currentElement.CompareTo(pivotValue) < 0)
                {
                    left.Add(currentElement);
                }
                else
                {
                    right.Add(currentElement);
                }
            }

            left = QuickSort(left);
            right = QuickSort(right);

            left.Add(pivotValue);
            left.AddRange(right);

            return left;
        }

        public static List<T> InsertionSort<T>(List<T> elementsToSort) where T : IComparable
        {
           for (int i = 1; i < elementsToSort.Count; i++)
            {
                int j = i;
                T element = elementsToSort[i];

                while (j > 0 && elementsToSort[j-1].CompareTo(element) > 0)
                {
                    elementsToSort[j] = elementsToSort[j - 1];
                    j--;
                }

                elementsToSort[j] = element;
            }

            return elementsToSort;
        }
    }
}
