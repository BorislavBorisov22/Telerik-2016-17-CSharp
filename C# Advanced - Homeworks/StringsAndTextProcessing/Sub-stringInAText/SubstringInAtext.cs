using System;

class SubstringInAtext
{
    public static int GetStringOccurences(string text, string pattern)
    {
        int occurences = 0;

        int indexOfPattern = text.IndexOf(pattern,0);
       
        while (indexOfPattern > 0)
        {
            occurences++;
            indexOfPattern = text.IndexOf(pattern, indexOfPattern + 1);
        }
        
        return occurences;
    }
    static void Main()
    {
        string pattern = Console.ReadLine().ToLower();
        string text = Console.ReadLine().ToLower();

        int occurences = GetStringOccurences(text, pattern);
        Console.WriteLine(occurences);
    }
}

