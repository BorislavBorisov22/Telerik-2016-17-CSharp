using System;
using System.Linq;
using System.Text;

class SentenceReversor
{
    static void Main()
    {
        string sentence = Console.ReadLine();

        string reversedSentence = ReverseSentence(sentence);
        Console.WriteLine(reversedSentence);
    }

    private static string ReverseSentence(string sentence)
    {
        var reversedSentence = new StringBuilder();
        char[] punctuationSigns = new char[] { '.', ' ', ',', '!', '?' };

        string[] words = sentence.Split(punctuationSigns, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string[] otherSymbols = sentence.Split(words, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Console.WriteLine(words.Length);
        Console.WriteLine(otherSymbols.Length);
        
        
        for (int i = 0; i < words.Length; i++)
        {
            string currWord = words[words.Length - 1 - i];
            string currOthersymbols = otherSymbols[i];
            reversedSentence.Append(currWord).Append(currOthersymbols);
        }


        return reversedSentence.ToString();

    }
}

