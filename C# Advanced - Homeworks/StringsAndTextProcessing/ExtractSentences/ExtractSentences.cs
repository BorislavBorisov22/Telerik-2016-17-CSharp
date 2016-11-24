using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ExtractSentences
{
    public static string Extract(string text,string word)
    {
        string[] sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        char[] separators = text.Where(ch => !char.IsLetter(ch)).Distinct().ToArray();
        StringBuilder result = new StringBuilder();

        foreach (var sentence in sentences)
        {
            string[] currentSentenceWords = sentence
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (currentSentenceWords.Contains(word))
            {
                result.AppendFormat("{0}. ", sentence.Trim());
            }

        }

        return result.ToString().Trim();
    }
    public static string ExtractSentencesByWord(string text, string word)
    {
        string path = string.Format(@"\b{0}\b", word);
        string[] sentences = text.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder resultSentences = new StringBuilder(text.Length);

        for (int i = 0; i < sentences.Length; i++)
        {
            string currSentence = sentences[i].Trim();

            bool contains = Regex.IsMatch(currSentence, path);

            if (contains)
            {
                resultSentences.Append(currSentence).Append(". ");
            }

        }

        return resultSentences.ToString().Trim();
    }
    static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();
        Console.WriteLine("========================================================");
        //first method with regular expressions
        string result = ExtractSentencesByWord(text, word);
        Console.WriteLine(result);
        Console.WriteLine("========================================================");
        //second method without regular expressions => but some linq expressions
        result = Extract(text, word);
        Console.WriteLine(result);

    }
}

