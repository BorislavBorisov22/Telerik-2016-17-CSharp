using System;
using System.Text;

class SeriesOfLetters
{
    static void Main()
    {
        string text = Console.ReadLine();
        text = TrimEqualConsecutives(text);
        Console.WriteLine(text);
    }

    private static string TrimEqualConsecutives(string text)
    {
        if (text.Length == 1)
        {
            return text;
        }
        var result = new StringBuilder();

        for (int i = 0; i < text.Length-1; i++)
        {
            char currLetter = text[i];
            char nexLetter = text[i+1];

            if (currLetter != nexLetter)
            {
                result.Append(currLetter);
            }
        }

        if (text[text.Length-1] != result[result.Length - 1])
        {
            result.Append(text[text.Length - 1]);
        }


        return result.ToString();
    }
}

