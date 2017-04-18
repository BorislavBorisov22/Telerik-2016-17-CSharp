using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("Input collection cannot be null!");
        }

        if (startIndex < 0 || startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("Start index must be within the boundaries of the collection!");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("Not enough count elements after the given start index!");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Count cannot be negative numer!");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentNullException("Input string must not null or empty!");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Count must be a non-negative number!");
        }

        if (count > str.Length)
        {
            return str;
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number <= 0)
        {
            return false;
        }

        bool isPrime = false;

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = true;
                break;
            }
        }

        return isPrime;
    }

    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        bool isTwentyThreePrime = CheckPrime(23);
        if (isTwentyThreePrime)
        {
            Console.WriteLine("23 is prime.");
        }
        else
        {
            Console.WriteLine("23 is not prime");
        }

        bool isThiryThreePrime = CheckPrime(33);

        if (isThiryThreePrime)
        {
            Console.WriteLine("33 is prime.");
        }
        else
        {
            Console.WriteLine("33 is not prime");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

        try
        {
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentOutOfRangeException aex)
        {
            Console.WriteLine(aex.Message);
        }
    }
}
