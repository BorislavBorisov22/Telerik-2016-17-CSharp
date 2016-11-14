using System;
using System.Linq;

class BinarySearch
{
    private static int BinSearch(int[] array, int searchedNumber)
    {
        int startIndex = 0;
        int endIndex = array.Length - 1;

        while (true)
        {
            if (startIndex > endIndex)
            {
                break;
            }
            int middleIndex = (startIndex + endIndex) / 2;
            if (array[middleIndex] == searchedNumber)
            {
                return middleIndex;
            }
            else if (array[middleIndex] < searchedNumber)
            {
                startIndex = middleIndex + 1;
            }
            else if (array[middleIndex] > searchedNumber)
            {
                endIndex = middleIndex - 1;
            }
        }


        return -1;
    }
    static void Main()
    {
        //int sizeArray = int.Parse(Console.ReadLine());
        var numbersArr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        int searchedNumber = int.Parse(Console.ReadLine());

        numbersArr = numbersArr.OrderBy(n => n).ToArray();

        int prevBiggestNumber = -1;
        int index = BinSearch(numbersArr, searchedNumber);

        if (index == -1)
        {
            Console.WriteLine("Number {0} does not exis in the array", searchedNumber);
        }
        else
        {
            //check for neighbour that is equal to number K
            bool foundEqual = false;
            if (index + 1 < numbersArr.Length)
            {
                if (numbersArr[index + 1] == numbersArr[index])
                {
                    prevBiggestNumber = numbersArr[index + 1];
                    foundEqual = true;
                }
            }
            if (index - 1 >= 0 && !foundEqual)
            {
                prevBiggestNumber = numbersArr[index - 1];
            }

            if (index -1 < 0 && !foundEqual)
            {
                Console.WriteLine("no smaller biggest number");
                return;
            }
        }


        Console.WriteLine(prevBiggestNumber);

    }
}

