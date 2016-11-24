using System;
using System.Text;
using System.Text.RegularExpressions;



class PalindromeChecker
{
    static void Main()
    {
        string input = Console.ReadLine();

        var result = ExtractWords(input);

        Console.WriteLine(result);
        
    }

    private static string ExtractWords(string input)
    {
        var palindromes = new StringBuilder();
        //get all words from the input
        string wordPath = @"\b[A-Za-z-]+\b";
        Regex wordMatcher = new Regex(wordPath);
        MatchCollection words = wordMatcher.Matches(input);
        //iterate true every word and check if it is palindrome
        foreach (var word in words)
        {
            string currWord = word.ToString();
            bool isPalindrome = CheckIfPalindrome(currWord);
            
            if (isPalindrome)
            {
                palindromes.AppendLine(currWord);
            }
        }
        
        return palindromes.ToString();

    }

    public static bool CheckIfPalindrome(string word)
    {

        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                return false;
            }
        }
        
        return true;
    }
}