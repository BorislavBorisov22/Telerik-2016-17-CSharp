using System;
using System.Text;


class UnicodeCharacter
{
    static void Main()
    {
        string text = Console.ReadLine();

        string unicodeRepresentation = ConvertTextToUnicode(text);
        Console.WriteLine(unicodeRepresentation);
    }

    private static string ConvertTextToUnicode(string text)
    {
        var result = new StringBuilder();
       
        foreach (var symbol in text)
        {
            string currentSymbolUnicode = string.Format("\\u{0:X4}", (int)symbol);
            result.Append(currentSymbolUnicode);
        }


        return result.ToString().Trim();
    }
}

