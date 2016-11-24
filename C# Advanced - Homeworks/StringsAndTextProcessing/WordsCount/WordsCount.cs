using System;
using System.Collections.Generic;
using System.Linq;

class WordCounter
{
    static void Main()
    {
        string text = Console.ReadLine();

        var wordsAndWordsCount = CountWords(text);

        foreach (var word in wordsAndWordsCount)
        {
            Console.WriteLine("{0} -> {1} times",word.Key,word.Value);
        }
    }

    private static Dictionary<string,int> CountWords(string text)
    {
        var resultDict = new Dictionary<string, int>();

        char[] separators = text.Where(n => !char.IsLetter(n)).ToArray();

        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        foreach (var word in words)
        {
            int currWordOccurences = words.Where(w => w == word).Count();
            if (!resultDict.ContainsKey(word))
            {
                resultDict.Add(word, currWordOccurences);
            }
        }

        return resultDict;
       
    }
}

