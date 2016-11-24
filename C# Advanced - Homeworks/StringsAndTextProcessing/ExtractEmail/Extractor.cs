using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


class Extractor
{
    static void Main()
    {
        string input = Console.ReadLine();

        List<string> emails = ExtractEmails(input);
        for(int i = 0; i < emails.Count; i++)
        {
            Console.WriteLine("[{0}] -> {1}",i+1,emails[i]);
        }
       
    }

    private static List<string> ExtractEmails(string input)
    {
        var emails = new List<string>();

        string emailPath = @"\b(?<identifier>[a-zA-Z0-9-_]{6,20})@(?<host>[a-zA-z]{3,}).(?<domaing>[a-zA-z]{2,})\b";
        var emailMatcher = new Regex(emailPath);

        var emailMatches = emailMatcher.Matches(input);

        foreach (var email in emailMatches)
        {
            emails.Add(email.ToString());
        }

        return emails;
    }
}

