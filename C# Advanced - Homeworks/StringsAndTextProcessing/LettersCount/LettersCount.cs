using System;
using System.Collections.Generic;
using System.Linq;

class LettersCount
{
    static void Main()
    {
        string text = Console.ReadLine();

        SortedDictionary<char, int> lettersAndCount = GetLetterCount(text);

        foreach(var symbol in lettersAndCount)
        {
            Console.WriteLine("{0} -> {1} times",symbol.Key,symbol.Value);
        }

        
    }

    private static SortedDictionary<char, int> GetLetterCount(string text)
    {
        var lettersCount = new SortedDictionary<char, int>();
        text = text.ToLower();

        foreach (var symbol in text)
        {
            if (char.IsLetter(symbol))
            {
                int currLetterCount = text.Where(letter => letter == symbol).Count();

                if (!lettersCount.ContainsKey(symbol))
                {
                    lettersCount.Add(symbol, currLetterCount);
                }
            }
        }
        
        return lettersCount;

    }
}

