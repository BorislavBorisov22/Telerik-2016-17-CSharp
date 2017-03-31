namespace ControlFlowConditionalStatementsAndLoops._04.CSharpFundamentalsExam._04.MergingNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergingNumbers
    {
        public static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());

            string[] initialNumbers = new string[numbersCount];

            ReadArrayNumbers(initialNumbers);

            var mergedNumbers = MergeNumbers(initialNumbers);
            var summedNumbers = SumNumbersArray(initialNumbers);

            Console.WriteLine(string.Join(" ", mergedNumbers));
            Console.WriteLine(string.Join(" ", summedNumbers));
        }

        private static int[] SumNumbersArray(string[] numbersAsString)
        {
            var result = new List<int>();

            var numbers = numbersAsString.Select(int.Parse).ToArray();

            for (int i=0; i < numbers.Length - 1; i++)
            {
                int firstNumber = numbers[i];
                int secondNumber = numbers[i + 1];

                int sum = SumTwoNumber(firstNumber, secondNumber);

                result.Add(sum);
            }

            return result.ToArray();
        }

        private static int SumTwoNumber(int first, int second)
        {
            return first + second;
        }

        private static void ReadArrayNumbers(string[] numbersArr)
        {
            for (int i = 0; i < numbersArr.Length; i++)
            {
                string currentNumber = Console.ReadLine();
                numbersArr[i] = currentNumber;
            }
        }

        private static int[] MergeNumbers(string[] numbersToMerge)
        {
            var mergedNumbers = new List<int>();

            for (int i = 0; i < numbersToMerge.Length - 1; i++)
            {
                string firstNumber = numbersToMerge[i];
                string secondNumber = numbersToMerge[i + 1];

                int mergedNumber = MergeTwoNumbers(firstNumber, secondNumber);

                mergedNumbers.Add(mergedNumber);
            }

            return mergedNumbers.ToArray();
        }

        private static int MergeTwoNumbers(string first, string second)
        {
            string mergedNumberAsString = string.Format("{0}{1}", first[1], second[0]);

            int mergedNumber = int.Parse(mergedNumberAsString);

            return mergedNumber;
        }
    }
}
