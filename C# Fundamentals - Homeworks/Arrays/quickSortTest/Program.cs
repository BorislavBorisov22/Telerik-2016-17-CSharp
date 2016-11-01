using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickSortTest
{
    class Program
    {
        private static void ReadList(List<int> numbersArr,int sizeArray)
        {
            for (int i = 0; i < sizeArray; i++)
            {
                int numberToAdd = int.Parse(Console.ReadLine());
                numbersArr.Add(numberToAdd);
            }
        }
        private static List<int> QuickSort(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }
            var left = new List<int>();
            var right = new List<int>();

            int indexPivot = numbers.Count / 2;
            int pivotValue = numbers[indexPivot];
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i != indexPivot)
                {
                    if (numbers[i] < pivotValue)
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

            left.Add(pivotValue);
            left.AddRange(right);

            return left;
        }
        static void Main()
        {
            int sizeNumbers = int.Parse(Console.ReadLine());        
            var numbers = new List<int>();
            ReadList(numbers, sizeNumbers);
            Console.WriteLine(string.Join(" ",numbers));
            numbers = QuickSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
