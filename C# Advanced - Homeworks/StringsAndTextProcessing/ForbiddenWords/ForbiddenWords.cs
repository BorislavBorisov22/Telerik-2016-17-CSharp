using System;
using System.Linq;
using System.Text.RegularExpressions;

class ForbiddenWords
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] forbiddenWords = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();


        text = HideForbiddenWords(text, forbiddenWords);
        Console.WriteLine(text);
    }

    private static string HideForbiddenWords(string text, string[] forbiddenWords)
    {
        foreach (var word in forbiddenWords)
        {
            string pattern = string.Format(@"\b{0}\b",word);

            text = Regex.Replace(text, pattern,new string('*',word.Length));
        }


        return text;
    }
}

