using System;
using System.Text;
using System.Text.RegularExpressions;

class HTMLExtractor
{
    static void Main()
    {
        string input = @"<html>
<head><title>News</title></head>
<body><p><a href=\""http:academy.telerik.com\\"">Telerik
Academy</a> aims to provide free real-world practical
training for young people who want to turn into
skilful .NET software engineers.</p></body>
                        </html>";
        //xctract title and then remove it from the main text
        string title = ExtractTitleFromHTML(input);
        int indexBody = input.IndexOf("<body>");
        input = input.Substring(indexBody);
        
        Console.WriteLine("Title: {0}",title);
        string extractedText = ExtractTextFromHTML(input);
        Console.WriteLine("Text: {0}",extractedText);
       
    }
    private static string ExtractTextFromHTML(string input)
    {
        var result = new StringBuilder();
        bool isTagOpened = false;

        for (int i = 0; i < input.Length; i++)
        {
            if (!isTagOpened && input[i] == '<')
            {
                isTagOpened = true;

            }
            else if (isTagOpened && input[i] == '>')
            {
                isTagOpened = false;
            }
            else if (!isTagOpened)
            {
                result.Append(input[i]);
            }
        }


        return result.ToString().Trim();
    }
    private static string ExtractTitleFromHTML(string input)
    {
        string title = string.Empty;
        string titlePath = @"<\s*title\s*>(?<title>.*)<\s*\/title\s*>";

        Regex titleMatcher = new Regex(titlePath);
        title = titleMatcher.Match(input).Groups["title"].ToString();

        return title.Trim();
    }
}

