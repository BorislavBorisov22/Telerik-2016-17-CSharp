using System;
using System.Text.RegularExpressions;

class TagReplacer
{
    static void Main()
    {
        string input = Console.ReadLine();

        string result = ReplaceTags(input);
        Console.WriteLine(result);
    }
    public static string ReplaceTags(string input)
    {
        //string pattern = @"<a href=\""(.*?)\"">(.*?)</a>";

        input = Regex.Replace(input, @"(<a href=""(.*)"">(.*)</a>)?", @"[$2]($1)");

        return input;
    }
}

