namespace Methods.CSharpPartTwoExam._01.SecretNumeralSystem
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class SecretNumeralSystem
    {
        private static Dictionary<string, string> digitsDict;

        public static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split(
                new[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            digitsDict = new Dictionary<string, string>();
            digitsDict.Add("haralampi", "5");
            digitsDict.Add("hristofor", "3");
            digitsDict.Add("vladimir", "7");
            digitsDict.Add("hristo", "0");
            digitsDict.Add("pesho", "2");
            digitsDict.Add("tosho", "1");
            digitsDict.Add("vlad", "4");
            digitsDict.Add("zoro", "6");

            var numbersInDecimal = GetNumbersInDecimal(numbers);
            var resultSum = GetNumbersArrayProduct(numbersInDecimal);
            Console.WriteLine(resultSum);
        }

        private static List<BigInteger> GetNumbersInDecimal(string[] numbers)
        {
            BigInteger product = 1;

            var convertedNumbers = new List<BigInteger>();
            for (int i = 0; i < numbers.Length; i++)
            {
                string currentNumber = numbers[i];

                currentNumber = ReplaceCodesWidthDigits(currentNumber);
                BigInteger currentNumberInDecimal = ConvertEightToDecimal(currentNumber);

                convertedNumbers.Add(currentNumberInDecimal);
            }

            return convertedNumbers;
        }

        private static string ReplaceCodesWidthDigits(string currentNumber)
        {
            string resultNumber = currentNumber;

            foreach (var digit in digitsDict)
            {
                resultNumber = resultNumber.Replace(digit.Key, digit.Value);
            }

            return resultNumber;
        }

        private static BigInteger GetNumbersArrayProduct(List<BigInteger> numbers)
        {
            BigInteger product = 1;

            numbers.ForEach(x => product *= x);

            return product;
        }

        private static BigInteger ConvertEightToDecimal(string currentNumber)
        {
            BigInteger decimalValue = 0;
            for (int i = 0; i < currentNumber.Length; i++)
            {
                decimalValue = (decimalValue * 8) + (currentNumber[i] - '0');
            }

            return decimalValue;
        }
    }
}
