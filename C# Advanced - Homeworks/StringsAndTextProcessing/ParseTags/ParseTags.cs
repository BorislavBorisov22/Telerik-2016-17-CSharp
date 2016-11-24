using System;
using System.Text;

class TagParser
{
    static void Main()
    {
        string text = Console.ReadLine();
        text = ParseTags(text);
        Console.WriteLine(text);
        
    }
    public static string ParseTags(string text)
    {
        string openingTag = "<upcase>";
        string closingTag = "</upcase>";

        int indexOpeningTag = text.IndexOf(openingTag, 0);
        int indexClosingTag = text.IndexOf(closingTag, 0);

        //change all symbols srrounded by upcase tags to upper case
        while (indexOpeningTag > 0 && indexClosingTag > 0)
        {
            int toBeUpcasedStartIndex = indexOpeningTag + openingTag.Length;
            string toBeUpcased = text.Substring(toBeUpcasedStartIndex, indexClosingTag - toBeUpcasedStartIndex);

            text = text.Replace(openingTag + toBeUpcased + closingTag, toBeUpcased.ToUpper());

            indexOpeningTag = text.IndexOf(openingTag);
            indexClosingTag = text.IndexOf(closingTag);


        }
        
        var result = new StringBuilder(text.Length);

        for (int i = 0; i < text.Length - 1; i++)
        {
            char currSymbol = text[i];
            char nextSymbol = text[i + 1];

            if (currSymbol == ' ' && nextSymbol == ' ')
            {
                result.Append(currSymbol);
                i++;
            }
            else
            {
                result.Append(currSymbol);
            }
        }
        result.Append(text[text.Length-1]);

        return result.ToString().Trim();
    }
}

